using System.Threading.Tasks;
using Telegram.Bot.Types;

public interface ICommand
{
    public Task Send(Message message);
}