using BlastLab.Domain;
using UnityEngine;

namespace BlastLab.Core
{
    /// <summary>
    /// Composition root, placed in the MainMenu (initial) scene. Applies <see cref="AppSettings"/>,
    /// creates the <see cref="GameStateMachine"/> and enters <see cref="GameState.MainMenu"/>.
    /// Dependencies are wired explicitly here; no Singletons.
    /// </summary>
    public sealed class GameBootstrapper : MonoBehaviour
    {
        [SerializeField] private AppSettings settings;

        /// <summary>State machine created on Awake. Pass it explicitly to systems that need it.</summary>
        public GameStateMachine StateMachine { get; private set; }

        private void Awake()
        {
            if (settings == null)
            {
                Debug.LogError("GameBootstrapper: AppSettings is not assigned.", this);
                enabled = false;
                return;
            }

            Application.targetFrameRate = settings.TargetFrameRate;
            StateMachine = new GameStateMachine();
            StateMachine.StateChanged += (from, to) => Debug.Log($"GameState: {from} -> {to}");
            StateMachine.ChangeTo(GameState.MainMenu);
            Debug.Log($"{AppInfo.ProductName} bootstrapped.");
        }
    }
}
