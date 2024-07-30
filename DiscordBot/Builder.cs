using DSharpPlus;

namespace DiscordBot
{
    class DiscordBuilder
    {
        static async Task Builder(string[] args)
        {
            DiscordClientBuilder builder = DiscordClientBuilder.CreateDefault(
                "MTI2MDI0OTgwMDM0ODAwODQ1OA.Gl_tlt.-y50U7e_9PPDv0v1232EQ0OxTNkkSogCngmo_I",
                DiscordIntents.AllUnprivileged
                    | DiscordIntents.MessageContents
                    | DiscordIntents.GuildVoiceStates
            );
            return builder.Build();
        }
    }
}
