using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DCBot.BOT.Commands
{
    class UsefulComs : BaseCommandModule
    {
        [Command("online")]
        [Description("Checks if the bot is ready and, if online, returns the boot time.")]
        public async Task check_on(CommandContext c)
        {
            await c.Channel.SendMessageAsync("Ready!\nOn since " + Program.onTime).ConfigureAwait(false);
        }
        /*
        [Command("whoami")]
        [Description("Retuens information about the sender.")]
        public async Task WhoAmI(CommandContext c)
        {
            var embedBuilder = new DiscordEmbedBuilder
            {
                Title = c.Message.Author.Username,
            };
            await c.Channel.SendMessageAsync(" ");
        }
        */
    } 
}
