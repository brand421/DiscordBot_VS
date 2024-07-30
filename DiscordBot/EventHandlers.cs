using System.Threading.RateLimiting;
using DiscordBuilder;
using DSharpPlus;
using DSharpPlus.AsyncEvents;

namespace DiscordBot
{
    public class ConfigureEventHandlers
    {
        static async Task ConfigureEventHandlersAsync(string[] args)
        {
            RateLimiter limiter = new TokenBucketRateLimiter(
                new TokenBucketRateLimiterOptions(
                    tokenLimit: 5,
                    queueProcessingOrder: QueueProcessingOrder.OldestFirst,
                    queueLimit: 5,
                    replenishmentPeriod: TimeSpan.FromSeconds(5),
                    tokensPerPeriod: 1,
                    autoreplenishment: true
                )
            );
            using RateLimitLease lease = await limiter.WaitAsync(5);

            HashSet<string> commandList = new HashSet<string>();
            commandList.Add("band");
            commandList.Add("lincoln");
            commandList.Add("work");
            commandList.Add("balls");
            commandList.Add("kickass");
            commandList.Add("list");
            commandList.Add("rock");
            commandList.Add("hello");

            DiscordBuilder.ConfigureEventHandlers(b =>
                b.HandleMessageCreated(
                    async (s, e) =>
                    {
                        string user = e.Author.Mention.ToString();
                        string command = e.Message.Content.Substring(1);
                        string message = e.Message.Content.
                        if (lease.isAcquired)
                        {
                            Console.WriteLine(command);
                            if (e.Message.Content.ToLower().StartsWith("ping"))
                            {
                                await e.Message.RespondAsync("pong!");
                            }
                            if (e.Message.Content.StartsWith("!") && !commandList.Contains(command))
                            {
                                await e.Message.RespondAsync(
                                    $"{user} you buttmunch, {command} isn't a real command"
                                );
                            }
                        }
                        else
                        {
                            FileStream gif = new FileStream("output.gif", FileMode.Open);
                            DiscordMessageBuilder messagefile = new DiscordMessageBuilder();
                            messagefile.AddFile(gif);
                            await e.Message.RespondAsync("I'm not gonna respond" + messagefile);
                            gif.Close();
                        }
                    }
                )
            );
        }
    }
}
