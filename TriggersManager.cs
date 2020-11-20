using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

public static class TriggersManager
{
	private static readonly ICommand smile = new Sticker(StickersID.Smile);
	private static readonly ICommand cool = new Sticker(StickersID.Cool);
	private static readonly ICommand question = new Sticker(StickersID.Question);
	private static readonly ICommand nnnna = new Phrase(BotSetting.DaNa);
	private static readonly ICommand net = new Phrase(BotSetting.NetOtvet);
	private static readonly ICommand ant = new Phrase(BotSetting.AntOtvet);
	private static readonly ICommand prikol = new Phrase(BotSetting.PrikolOtvet);
	private static readonly ICommand phrases = new RndPhrase();

	private static readonly Random rnd = new Random();

	public static async void Check(Message message)
	{
		if (message?.Type == MessageType.Text)
		{
			if (CoolTriggered(message.Text))
				await cool.Send(message);
			if (SmileTriggered(message.Text))
				await smile.Send(message);
			if (EndWordTriggered(message.Text, BotSetting.DaTriggers, BotSetting.DaChance))
				await nnnna.Send(message);
			if (EndWordTriggered(message.Text, BotSetting.NetTriggers, BotSetting.NetChance))
				await net.Send(message);
			if (EndWordTriggered(message.Text, BotSetting.AntTriggers, BotSetting.AntChance, true))
				await ant.Send(message);
			if (EndWordTriggered(message.Text, BotSetting.PrikolTriggers, BotSetting.PrikolChance, true))
			{
				var pricol = new Phrase(GetAnswer(message.Text, BotSetting.PrikolTriggers));
				await pricol.Send(message);
			}
			if (QuestionTriggered(message.Text))
				await question.Send(message);
			if (Proc(BotSetting.PhraseChance))
				await phrases.Send(message);
		}
	}

	private static bool QuestionTriggered(string text) =>
		text.Contains('?') && Proc(BotSetting.QuestionChance);

	private static bool CoolTriggered(string text)
	{
		return ((text.Length > BotSetting.СoolLenght.Step1 && Proc(BotSetting.СoolChance.Step1))
			|| (text.Length > BotSetting.СoolLenght.Step2 && Proc(BotSetting.СoolChance.Step2)))
			&& !text.Contains('?');
	}

	private static bool SmileTriggered(string text)
	{
		return Triggered(text,
			(text, trigger) => text.Contains(trigger, StringComparison.InvariantCultureIgnoreCase),
			BotSetting.HahaTriggers,
			BotSetting.SmileChance);
	}

	private static bool EndWordTriggered(string text, IEnumerable<string> triggers, double chance, bool contains = false)
	{
		Func<string, string, bool> predicate = (text, trigger) => 
			contains ?
			text.Split().LastOrDefault().Contains(trigger, StringComparison.InvariantCultureIgnoreCase) :
			text.Split().LastOrDefault().Equals(trigger, StringComparison.InvariantCultureIgnoreCase);
		return Triggered(text,
			predicate, 
			triggers,
			chance);
	}

	private static bool Triggered(string text, Func<string, string, bool> predicate, IEnumerable<string> triggers, double chance)
	{
		var contains = false;
		foreach (var trigger in triggers)
			if (predicate(text, trigger))
			{
				contains = true;
				break;
			}
		return contains && Proc(chance);
	}

	public static string GetAnswer(string text, IEnumerable<string> triggers)
	{
		Func<string, string, bool> predicate = (text, trigger) => text.Contains(trigger, StringComparison.InvariantCultureIgnoreCase);
		var answer = string.Empty;
		foreach (var trigger in triggers)
			if (predicate(text, trigger))
			{
				var lastWord = text.Split().LastOrDefault();
				var index = lastWord.IndexOf(trigger, StringComparison.InvariantCultureIgnoreCase) + trigger.Length;
				var postfix = new string(lastWord.Skip(index).ToArray()).Replace("?", string.Empty);
				answer = string.Format(BotSetting.PrikolOtvet, BotSetting.PrikolUkol + postfix);
				break;
			}
		return answer;
	}

	private static bool Proc(double chance) => rnd.NextDouble() <= chance;
}