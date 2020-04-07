using System;
using System.Threading.Tasks;
using Telegram.Bot.Types;

class Phrase : ICommand
{
    private string text;

    public Phrase(string text)
    {
        this.text = text;
    }

    public async Task Send(Message message)
    {
        await Task.Delay(BotSetting.Delay);
        await Bot.Current.SendTextMessageAsync(message.Chat.Id, text, replyToMessageId: message.MessageId);
    }
}