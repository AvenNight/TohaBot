using System;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

public static class TriggersManager
{
	private static readonly ICommand smile = new Sticker(StickersID.Smile);
	private static readonly ICommand cool = new Sticker(StickersID.Cool);
	private static readonly ICommand question = new Sticker(StickersID.Question);
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
		var contains = false;
		foreach (var trigger in BotSetting.HahaTriggers)
			if (text.Contains(trigger))
			{
				contains = true;
				break;
			}
		return contains && Proc(BotSetting.SmileChance);
	}

	private static bool Proc(double chance) => rnd.NextDouble() <= chance;
}