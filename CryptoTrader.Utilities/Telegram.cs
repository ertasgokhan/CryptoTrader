using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;

namespace CryptoTrader.Utilities
{
    public static class Telegram
    {
        private static TelegramBotClient botClient;

        private static async void SendTextMessageAsync(string token, string chatId, string message)
        {
            botClient = new TelegramBotClient(token);

            await botClient.SendTextMessageAsync(chatId, message);
        }
    }
}
