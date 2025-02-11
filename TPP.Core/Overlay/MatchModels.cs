using System.Runtime.Serialization;

namespace TPP.Core.Overlay
{
    /// Describes under what circumstances switching is allowed.
    [DataContract]
    public enum SwitchingPolicy
    {
        /// Switching is allowed under all circumstances.
        [EnumMember(Value = "always")] Always,
        /// Switching is never allowed.
        [EnumMember(Value = "never")] Never,
        /// Players can only switch pokemon during a regular move selection.
        [EnumMember(Value = "only_regular")] OnlyRegular,
        /// Players can only influence what pokemon to switch to after a faint.
        [EnumMember(Value = "only_faint")] OnlyFaint,
        /// Players can only influence what pokemon to switch to after an event that isn't a regular switch or a faint,
        /// e.g. after using Baton Pass.
        [EnumMember(Value = "only_other")] OnlyOther,
    }

    /// Describes how the moves to use are being chosen.
    [DataContract]
    public enum MoveSelectingPolicy
    {
        /// Always explicitly select the move to use.
        [EnumMember(Value = "always")] Always,
        /// Automatically choose a move to use at random.
        [EnumMember(Value = "random")] Random,
    }

    /// Describes how the pokemon to target with an attack are being selected.
    [DataContract]
    public enum TargetingPolicy
    {
        /// Always explicitly select the target pokemon.
        [EnumMember(Value = "always")] Always,
        /// Automatically select a target pokemon at random.
        [EnumMember(Value = "random")] Random,
        /// No target selection is available (1v1 battle).
        [EnumMember(Value = "disabled")] Disabled,
    }

    /// Describes in what style the battle is performed.
    [DataContract]
    public enum BattleStyle
    {
        /// 1v1 battle
        [EnumMember(Value = "singles")] Singles,
        /// 2v2 battle
        [EnumMember(Value = "doubles")] Doubles,
        // There's more, e.g. showdown multi-battles, but those aren't supported (yet).
    }

}
