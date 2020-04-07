using Telegram.Bot;

public static class Bot
{
    private static TelegramBotClient instance = new TelegramBotClient(AppSettings.Token);
    public static TelegramBotClient Current => instance;
}