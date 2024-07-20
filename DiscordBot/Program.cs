using System;
using System.Net.NetworkInformation;
using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.VoiceNext;
using DSharpPlus.Commands;
using DSharpPlus.Commands.Processors.TextCommands;
using DSharpPlus.Commands.Processors.TextCommands.Parsing;
using DSharpPlus.AsyncEvents;
using System.Text;
using System.Runtime.Serialization;
using System.Diagnostics.Tracing;


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
            

            builder.ConfigureEventHandlers(b =>
                b.HandleMessageCreated(
                        async (s, e) =>
                        {
                            if (e.Message.Content.ToLower().StartsWith("dude"))
                            {
                                await e.Message.RespondAsync("score!");
                            }
                        }
                    )
            );

            CommandsExtension commandsExtension = client.UseCommands(new CommandsConfiguration()
            {
                RegisterDefaultCommandProcessors = true,
                UseDefaultCommandErrorHandler = false
            });

            commandsExtension.CommandErrored += async (s, e) =>
            {
                StringBuilder stringBuilder = new();
                stringBuilder.Append("You buttmunch, ");
                stringBuilder.Append(e.Exception.GetType().Name);
                stringBuilder.Append(" doesn't exist");
                stringBuilder.Append(DSharpPlus.Formatter.InlineCode(DSharpPlus.Formatter.Sanitize(e.Exception.Message)));

                await eventArgs.Context.RespondAsync(stringBuilder);
            };

            commandsExtension.AddCommands(typeof(Program).Assembly);
            TextCommandProcessor textCommandProcessor = new(new()
            {
                PrefixResolver = new DefaultPrefixResolver(true, "!", "&").ResolvePrefixAsync
            });

            await commandsExtension.AddProcessorsAsync(textCommandProcessor);


            DiscordActivity status = new("trying to score", DiscordActivityType.Custom);

            await client.ConnectAsync(status, DiscordUserStatus.Online);
            await Task.Delay(-1);
        }
    }
}
