namespace DiscordBot
{
    public class ClientBuilder
    {
        DiscordClientBuilder builder = DiscordClientBuilder.CreateDefault(
            "MTI2MDI0OTgwMDM0ODAwODQ1OA.Gl_tlt.-y50U7e_9PPDv0v1232EQ0OxTNkkSogCngmo_I",
            DiscordIntents.AllUnprivileged
                | DiscordIntents.MessageContents
                | DiscordIntents.GuildVoiceStates
        );
        DiscordClient client = builder.Build();
        return client;
    }
}
