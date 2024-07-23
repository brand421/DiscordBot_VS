using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.Commands;

namespace DiscordBot
{
    internal class BandCommand
    {
        [Command("band")]
        public static ValueTask ExecuteAsync(CommandContext context) =>
            context.RespondAsync(
                "Y’know, like, this band sucks. But it’s like, they suck like, in new ways, y’know.Like, they suck in ways we haven’t, like, seen stuff suck before"
            );
    }

    internal class LincolnCommand
    {
        // NEED TO ADD ABILITY TO ADD NAME TO COMMAND
        [Command("lincoln")]
        public static ValueTask ExecuteAsync(CommandContext context) =>
            context.RespondAsync(
                "When I almost scored with four chicks seven years ago, this one chick’s father brought forth upon me a prostitute. Huh-huh. Because some dudes just weren’t created equal. Huh-huh"
            );
    }

    internal class WorkCommand
    {
        // NEED TO ADD ABILITY TO ADD NAME TO COMMAND
        [Command("work")]
        public static ValueTask ExecuteAsync(CommandContext context) =>
            context.RespondAsync("Work sucks, let's go break something");
    }

    internal class BallsCommand
    {
        // NEED TO ADD ABILITY TO ADD NAME TO COMMAND
        [Command("balls")]
        public static ValueTask ExecuteAsync(CommandContext context) =>
            context.RespondAsync(
                "Beavis, your balls are filthy. Take them to the ball washer immediately"
            );
    }

    internal class KickassCommand
    {
        // NEED TO ADD ABILITY TO ADD NAME TO COMMAND
        [Command("kickass")]
        public static ValueTask ExecuteAsync(CommandContext context) =>
            context.RespondAsync(
                "Shut up Beavis before I kick your ass so hard it’ll turn inside-out and come out your mouth."
            );
    }

    internal class RocksCommand
    {
        // NEED TO ADD ABILITY TO ADD NAME TO COMMAND
        [Command("rock")]
        public static ValueTask ExecuteAsync(CommandContext context) =>
            context.RespondAsync("I've got a rock formation in my pants");
    }

    internal class ListCommand
    {
        [Command("list")]
        public static ValueTask ExecuteAsync(CommandContext context) =>
            context.RespondAsync("My list includes any girl with at least one boob");
    }

    internal class HelloCommand
    {
        [Command("hello")]
        public static ValueTask ExecuteAsync(CommandContext context) =>
            context.RespondAsync("Hey losers. huh huh");
    }

    public class TagNameAutoCompleteProvider : IAutoCompleteProvider
    {
        private readonly ITagService tagService;

        public TagNameAutoCompleteProvider(ITagService tagService) => tagService = tagService;

        public ValueTask<IReadOnlyDictionary<string, object>> AutoCompleteAsync(
            AutoCompleteContext context
        )
        {
            var tags = tagService
                .GetTags()
                .Where(x =>
                    x.Name.StartsWith(context.UserInput, StringComparison.OrdinalIgnoreCase)
                )
                .ToDictionary(x => x.Name, x => x.Id);

            return ValueTask.FromResult(tags);
        }
    }

    internal class TargetUser
    {
        [Command("target")]
        public async ValueTask ExecuteAsync(
            CommandContext context,
            [SlashAutoCompleteProvider<TagNameAutoCompleteProvider>] string tagName
        )
        {
            context.RespondAsync($"{tagName} will never score");
        }
    }
}
