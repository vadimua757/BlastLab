using UnityEngine;

namespace BlastLab.Core
{
    /// <summary>Global app configuration (ScriptableObject). Create via Assets ▸ Create ▸ BlastLab ▸ App Settings.</summary>
    [CreateAssetMenu(fileName = "AppSettings", menuName = "BlastLab/App Settings")]
    public sealed class AppSettings : ScriptableObject
    {
        [Tooltip("Target frame rate applied on startup. Validate on a real device before changing.")]
        [SerializeField, Range(30, 120)] private int targetFrameRate = 60;

        [SerializeField] private string mainMenuSceneName = "MainMenu";
        [SerializeField] private string sandboxSceneName = "Sandbox";

        public int TargetFrameRate => targetFrameRate;
        public string MainMenuSceneName => mainMenuSceneName;
        public string SandboxSceneName => sandboxSceneName;
    }
}
