﻿using System;
using System.Collections.Generic;

public static class BotSetting
{
    public static double SmileChance => 0.15;
    public static double DaChance => 1;
    public static double NetChance => 1;
    public static double AntChance => 1;
    public static double PrikolChance => 1;
	public static (double Step1, double Step2) СoolChance => (0.08, 0.5);
	public static (int Step1, int Step2) СoolLenght => (60, 160);
	private static (int Step1, int Step2) delaySec => (2, 15);
	public static double PhraseChance => 0.08;
	public static double QuestionChance => 0.13;

	public static readonly HashSet<string> HahaTriggers = new HashSet<string>
		{
			")))",
			"ахах",
			"ааах",
			"аххх",
			"f[f[",
		};

	public static readonly HashSet<string> DaTriggers = new HashSet<string>
		{
			"да",
			"da",
			"d@",
			"да)",
			"da)",
			"да))",
			"da))",
			"d@)",
			"да?",
			"da?",
			"d@!",
			"да!",
			"da!",
			"d@!",
		};

	public static readonly HashSet<string> NetTriggers = new HashSet<string>
		{
			"нет",
			"net",
			"нет)",
			"net)",
			"нет))",
			"net))",
			"нет?",
			"net?",
			"нет!",
			"net!",
		};

	public static readonly HashSet<string> AntTriggers = new HashSet<string>
		{
			"делать"
		};

	public static readonly HashSet<string> PrikolTriggers = new HashSet<string>
		{
			"прикол"
		};

	public static readonly string DaNa = "Хуй нннааааа!!!";
	public static readonly string NetOtvet = "пидора ответ :)";
	public static readonly string AntOtvet = "Муравью хуй приделать! :)))";
	public static readonly string PrikolOtvet = "Хуем за щеку укол :))";

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
			"сосатель членов",
			"А ты сам какой рассы будешь ? Небось даже до 6й не эволюционировал лох ебаный",
			"там малолетний школяр которому 15 лет заставил тебя сделать в жизни какие-то выводы?))) чо ебнулся - хуй забей - он даже до 6й рассы ещё не эволюционировал скот ебаный, втирает тебе какую-то дичь - нахуй послан быстро",
			"У них пальцы слишком длинные - нейро мышечная передача дольше - они как расса не подходят. По этой же причине Китайцы ебут европейцев",
			"Агга",
			"Агга. Мне кажется с вашими мозгами в Мск можно не кисло заработать",
			"лох пошли воевать пидр",
			"бля я бы с удовольствием 3 литра в себя бы положил эхх",
			"А я пока перепил, и восстанавливаю печень, чот она меня с пищеводом послала нахуй",
			"Нет, сейчас только микрозелень в массы идёт",
			"Хз мне нравится мак!",
			"Настоящий андерпидр грун давн",
			"Поднял письку да вставить некуда",
			"у меня невыносимая гореч стоит в холодосе",
			"Гамить и пить пивас... Прикуриваться",
			"Я когда на такой шмат смотрю, у меня сразу начинает болеть сердечко",
			"А я пока перепил, и восстанавливаю печень, чот она меня с пищеводом послала нахуй",
			"Я могу яйца сфотать и скинуть сюда, что бы вы блеванули. Потому что атака сообщений когда спишь",
			"Я пошел воткну здоровенный шприц с азотом себе в сракотам, что бы черви из печени повылазили и можно было пить пивас",
			"я же не медик - я педик :))))))",
			"Члееееен ососный баклаыен",
			"Shuttlecock :) тебе в рот",
			"100%",
			"100%",
			"+",
		};

	public static int Delay => new Random().Next(delaySec.Step1 * 1000, delaySec.Step2 * 1000);
}