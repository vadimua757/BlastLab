using System;

namespace BlastLab.Core
{
    /// <summary>
    /// Minimal top-level state machine. Plain C# (no MonoBehaviour), created and owned by <see cref="GameBootstrapper"/>.
    /// Allowed transitions: None → MainMenu, MainMenu ↔ Sandbox.
    /// </summary>
    public sealed class GameStateMachine
    {
        /// <summary>Current state. Starts as <see cref="GameState.None"/>.</summary>
        public GameState Current { get; private set; } = GameState.None;

        /// <summary>Raised after a successful transition: (previous, new).</summary>
        public event Action<GameState, GameState> StateChanged;

        /// <summary>Returns true if a transition from <see cref="Current"/> to <paramref name="next"/> is allowed.</summary>
        public bool CanChangeTo(GameState next)
        {
            switch (Current)
            {
                case GameState.None: return next == GameState.MainMenu;
                case GameState.MainMenu: return next == GameState.Sandbox;
                case GameState.Sandbox: return next == GameState.MainMenu;
                default: return false;
            }
        }

        /// <summary>Switches state. Throws <see cref="InvalidOperationException"/> if the transition is not allowed.</summary>
        public void ChangeTo(GameState next)
        {
            if (!CanChangeTo(next))
                throw new InvalidOperationException($"Invalid state transition {Current} -> {next}.");

            var previous = Current;
            Current = next;
            StateChanged?.Invoke(previous, next);
        }
    }
}
