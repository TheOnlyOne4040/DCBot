using DCBot.BOT.Commands;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Enums;
using DSharpPlus.Interactivity.Extensions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DCBot.BOT
{
    public class Bot
    {
        public DiscordClient Client { get; private set; }
        public InteractivityExtension Interactivity { get; private set; }
        public CommandsNextExtension Commands { get; private set; }

        public Bot(IServiceProvider services)
        {
                var json = string.Empty;

                using (var fs = File.OpenRead("config.json"))
                using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
                    json = sr.ReadToEnd();

                var configJson = JsonConvert.DeserializeObject<ConfigJSON>(json);

                var config = new DiscordConfiguration
                {
                    Token = configJson.Token,
                    TokenType = TokenType.Bot,
                    AutoReconnect = true,
                    MinimumLogLevel = LogLevel.Debug,
                };

                var Client = new DiscordClient(config);

                Client.Ready += async (s, e) =>
                {
                    Console.WriteLine("On!");
                };

                Client.UseInteractivity(new InteractivityConfiguration
                {
                    Timeout = TimeSpan.FromMinutes(2)
                });

                var commandsConfig = new CommandsNextConfiguration
                {
                    StringPrefixes = new string[] { configJson.Prefix },
                    EnableMentionPrefix = true,
                    EnableDms = false,
                    DmHelp = true,
                    Services = services
                };


                Commands = Client.UseCommandsNext(commandsConfig);

                Commands.RegisterCommands<UsefulComs>();

                Client.MessageCreated += async (s, e) =>
                {
                    Console.WriteLine(e.Message.Content);
                    if (e.Message.Content.ToLower().StartsWith("ping"))
                        await e.Message.RespondAsync("pong!");
                };

                Client.ConnectAsync();
        }

        public async Task MainAsync()
        {
        }
    }
}
