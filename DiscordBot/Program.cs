using System;
using System.Diagnostics.Tracing;
using System.Net.NetworkInformation;
using System.Runtime.Serialization;
using System.Text;
using DSharpPlus;
using DSharpPlus.AsyncEvents;
using DSharpPlus.Commands;
using DSharpPlus.Commands.Processors.TextCommands;
using DSharpPlus.Commands.Processors.TextCommands.Parsing;
using DSharpPlus.Entities;
using DSharpPlus.VoiceNext;

namespace DiscordBot
{
    class Program
    {
        static async Task Main(string[] args)
        {
            DiscordClientBuilder builder = DiscordClientBuilder.CreateDefault(
                "MTI2MDI0OTgwMDM0ODAwODQ1OA.Gl_tlt.-y50U7e_9PPDv0v1232EQ0OxTNkkSogCngmo_I",
                DiscordIntents.AllUnprivileged
                    | DiscordIntents.MessageContents
                    | DiscordIntents.GuildVoiceStates
            );
            DiscordClient client = builder.Build();

            //client.UseVoiceNext();

            //DiscordChannel channel;
            //if (channel != null)
            //{
            //    VoiceNextConnection connection = await channel.ConnectAsync();
            //}

            HashSet<string> commandList = new HashSet<string>();
            commandList.Add("band");
            commandList.Add("lincoln");
            commandList.Add("work");
            commandList.Add("balls");
            commandList.Add("kickass");
            commandList.Add("list");
            commandList.Add("rock");
            commandList.Add("hello");

            
            builder.ConfigureEventHandlers
            (
                b => b.HandleMessageCreated(async (s, e) =>
                {
                string command = e.Message.Content.Substring(1);
                Console.WriteLine(command);
                if (e.Message.Content.ToLower().StartsWith("ping"))
                    {
                        await e.Message.RespondAsync("pong!");
                    }
                    if (e.Message.Content.StartsWith("!") && !commandList.Contains(command))
                    {
                        string user = e.Author.Mention.ToString();
                        await e.Message.RespondAsync($"{user} you buttmunch, {command} isn't a real command");
                    }
               })
                );

            CommandsExtension commandsExtension = client.UseCommands(
                new CommandsConfiguration()
                {
                    RegisterDefaultCommandProcessors = true,
                    UseDefaultCommandErrorHandler = false
                }
            );

            commandsExtension.AddCommands(typeof(Program).Assembly);
            TextCommandProcessor textCommandProcessor =
                new(
                    new()
                    {
                        PrefixResolver = new DefaultPrefixResolver(
                            true,
                            "!",
                            "&"
                        ).ResolvePrefixAsync
                    }
                );

            await commandsExtension.AddProcessorsAsync(textCommandProcessor);

            DiscordActivity status = new("trying to score", DiscordActivityType.Custom);

            await builder.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}
