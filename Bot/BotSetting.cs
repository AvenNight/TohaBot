using System;
using System.Collections.Generic;

public static class BotSetting
{
	public static double SmileChance => 0.35;
	public static (double Step1, double Step2) СoolChance => (0.1, 0.7);
	public static (int Step1, int Step2) СoolLenght => (60, 150);
	private static (int Step1, int Step2) delaySec => (2, 15);
	public static double PhraseChance => 0.1;
	public static double QuestionChance => 0.15;

	public static readonly HashSet<string> HahaTriggers = new HashSet<string>
		{
			")))",
			"ахах",
			"ааах",
			"аххх",
			"f[f[",
		};

	public static readonly string [] Phrases = new string[]
		{
			")согласен",
			"Блиайтьсукатанугах :)",
			"члееен",
			"я обоссан ок)",
			")))))",
			"проплатил вов",
			"Это портал просто",
			"Невыносимая гореч (икс 7)*2",
			"Пойду посру",
			"сосатель членов"
		};

	public static int Delay => new Random().Next(delaySec.Step1 * 1000, delaySec.Step2 * 1000);
}