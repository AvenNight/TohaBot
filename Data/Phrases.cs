using System;

public static class Phrases
{
    public static string RndPhrase => BotSetting.Phrases[new Random().Next(0, BotSetting.Phrases.Length - 1)];
}