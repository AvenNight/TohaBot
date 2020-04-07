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
			if (DaTriggered(message.Text))
				await nnnna.Send(message);
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

	private static bool DaTriggered(string text)
	{
		return Triggered(text, 
			(text, trigger) => text.Split().LastOrDefault().Equals(trigger, StringComparison.InvariantCultureIgnoreCase), 
			BotSetting.DaTriggers, 
			BotSetting.DaChance);
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
		return contains && Proc(BotSetting.DaChance);
	}

	private static bool Proc(double chance) => rnd.NextDouble() <= chance;
}