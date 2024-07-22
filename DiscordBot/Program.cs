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

            client.UseVoiceNext();

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

            builder.ConfigureEventHandlers(b =>
                b.HandleMessageCreated(
                    async (s, e) =>
                    {
                        string command = e.Message.Content.Substring(1);
                        if (e.Message.Content.ToLower().StartsWith("dude"))
                        {
                            await e.Message.RespondAsync("score!");
                        }
                        else if (
                            e.Message.Content.ToLower().StartsWith("!")
                            && !commandList.Contains(command.ToLower())
                        )
                        {
                            await e.Message.RespondAsync(
                                $"you buttmunch, {e.Message.Content} isn't a command"
                            );
                        }
                    }
                )
            );

            CommandsExtension commandsExtension = client.UseCommands(
                new CommandsConfiguration()
                {
                    RegisterDefaultCommandProcessors = true,
                    UseDefaultCommandErrorHandler = false
                }
            );

            // commandsExtension.CommandErrored += async (s, e) =>
            // {
            //     StringBuilder stringBuilder = new();
            //     stringBuilder.Append("You buttmunch, ");
            //     stringBuilder.Append(e.Exception.GetType().Name);
            //     stringBuilder.Append(" doesn't exist");
            //     stringBuilder.Append(
            //         DSharpPlus.Formatter.InlineCode(
            //             DSharpPlus.Formatter.Sanitize(e.Exception.Message)
            //         )
            //     );

            //     await eventArgs.Context.RespondAsync(stringBuilder);
            // };

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

            await client.ConnectAsync(status, DiscordUserStatus.Online);
            await Task.Delay(-1);
        }
    }
}
