using System;
using System.Net.NetworkInformation;
using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.VoiceNext;

namespace DiscordBot
{
    class Program
    {
        public class Client
        {
            //DiscordClientBuilder builder = DiscordClientBuilder.CreateDefault("MTI2MDI0OTgwMDM0ODAwODQ1OA.Gl_tlt.-y50U7e_9PPDv0v1232EQ0OxTNkkSogCngmo_I", DiscordIntents.AllUnprivileged | DiscordIntents.MessageContents | DiscordIntents.GuildVoiceStates);
            //DiscordClient client = builder.Build()
        }
        static async Task Main(string[] args)
        {
            DiscordClientBuilder builder = DiscordClientBuilder.CreateDefault("MTI2MDI0OTgwMDM0ODAwODQ1OA.Gl_tlt.-y50U7e_9PPDv0v1232EQ0OxTNkkSogCngmo_I", DiscordIntents.AllUnprivileged | DiscordIntents.MessageContents | DiscordIntents.GuildVoiceStates);
            DiscordClient client = builder.Build();

            client.UseVoiceNext();

            DiscordChannel channel;
            VoiceNextConnection connection = await channel.ConnectAsync();

            builder.ConfigureEventHandlers
            (
                b => b.HandleMessageCreated(async (s, e) =>
                {
                    if (e.Message.Content.ToLower().StartsWith("dude"))
                    {
                        await e.Message.RespondAsync("score!");
                    }
                })
            );

            await client.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}
