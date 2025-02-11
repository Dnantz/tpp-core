using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using TPP.Core.Chat;
using TPP.Persistence.Models;

namespace TPP.Core.Commands.Definitions
{
    public class ModeratorCommands : ICommandCollection
    {
        private readonly ImmutableHashSet<string> _moderatorNamesLower;
        private readonly IChatModeChanger _changer;

        public ModeratorCommands(IEnumerable<string> moderatorNames, IEnumerable<string> operatorNames, IChatModeChanger changer)
        {
            _moderatorNamesLower = operatorNames.Concat(moderatorNames).Select(s => s.ToLowerInvariant())
                .Distinct().ToImmutableHashSet(); //add both mods and ops to mod list
            _changer = changer;
        }

        public IEnumerable<Command> Commands => new[]
        {
            new Command("emoteonly", EnableEmoteOnly)
            {
                Aliases = new[] { "emoteonlyon" },
                Description = "Moderators only: Set the chat to emote only mode."
            },
            new Command("emoteonlyoff", DisableEmoteOnly)
            {
                Description = "Moderators only: Disable emote only mode."
            }
        }.Select(cmd => cmd.WithCondition(
            canExecute: ctx => IsModerator(ctx.Message.User),
            ersatzResult: new CommandResult { Response = "Only moderators can use that command" }));

        private bool IsModerator(User user) => _moderatorNamesLower.Contains(user.SimpleName);

        private async Task<CommandResult> EnableEmoteOnly(CommandContext context)
        {
            await _changer.EnableEmoteOnly();
            return new CommandResult();
        }

        private async Task<CommandResult> DisableEmoteOnly(CommandContext context)
        {
            await _changer.DisableEmoteOnly();
            return new CommandResult();
        }
    }
}
