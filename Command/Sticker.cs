using System;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;

class Sticker : ICommand
{
    private InputOnlineFile sticker;

    public Sticker(string id)
    {
        sticker = new InputOnlineFile(id);
    }

    public async Task Send(Message message)
    {
        Random rnd = new Random();
        await Task.Delay(BotSetting.Delay);
        await Bot.Current.SendStickerAsync(message.Chat.Id, sticker, replyToMessageId: message.MessageId);
    }
}