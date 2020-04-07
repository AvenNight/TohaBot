using System.Threading;
using Telegram.Bot.Args;

class Program
{
	static void Main()
	{
		Bot.Current.OnMessage += BotOnMessageReceived;
		Bot.Current.StartReceiving();
		new ManualResetEvent(false).WaitOne();
		Bot.Current.StopReceiving();
	}

	private static void BotOnMessageReceived(object sender, MessageEventArgs e)
	{
		TriggersManager.Check(e.Message);
	}
}