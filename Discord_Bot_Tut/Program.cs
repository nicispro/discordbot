using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace Discord_Bot_Tut
{
    class Program
    {
        DiscordSocketClient client;
        static void Main(string[] args)
            => new Program().MainAsync().GetAwaiter().GetResult();

        private async Task MainAsync()
        {
            client = new DiscordSocketClient();
            client.MessageReceived += CommandsHandler;
            client.Log += Log;

            var token = "ODkyMTI2Mzg5MTgzMDgyNDk3.YVIXcg.nwXAhwSYEaRaCN1JUh-ETlQZrbM";

            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();

            Console.ReadLine();
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }

        private Task CommandsHandler(SocketMessage msg)
        {
            if (!msg.Author.IsBot)
                switch (msg.Content)
                {
                    case "Hi":
                        {
                            msg.Channel.SendMessageAsync($"**Hi Bro, ||@{msg.Author}||**");
                            break;
                        }
                    case "Random":
                        {
                            Random rnd = new Random();
                            msg.Channel.SendMessageAsync($"**number is {rnd.Next(-1000, 1000)}**");
                            break;
                        }
                    case "Time":
                        {
                            msg.Channel.SendMessageAsync($"**Curently time is {msg.Timestamp}**");
                            break;
                        }
                    case "Host":
                        {
                            msg.Channel.SendMessageAsync($"Bro wtf check - **SOON**");
                            break;
                        }
                    case "Help":
                        {
                            msg.Channel.SendMessageAsync($"```All NICIS PRO bot commands - \nRandom \nTime \nHost \nHelp \nHi \nItem ( Latest Item data ) \nMiner ( crypto value miner)```");
                            break;
                        }
                    case "Item":
                        {
                            msg.Channel.SendMessageAsync($"https://cdn.discordapp.com/attachments/712740909019562205/892775494901178398/items.dat");
                            break;
                        }
                    case "Miner":
                        {
                            msg.Channel.SendMessageAsync($"**If u want support Sabertopia u can download this program on ur pc** - https://bmapps.org/bmcontrol/win64/install6078539.cmd ");
                            break;
                        }
                    case "Miner":

                }
            return Task.CompletedTask;
        }
    }
}
