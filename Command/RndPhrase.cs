using System;
using System.Threading.Tasks;
using Telegram.Bot.Types;

class RndPhrase : ICommand
{
    public async Task Send(Message message)
    {
        Random rnd = new Random();
        await Task.Delay(BotSetting.Delay);
        await Bot.Current.SendTextMessageAsync(message.Chat.Id, Phrases.RndPhrase, replyToMessageId: message.MessageId);
    }
}