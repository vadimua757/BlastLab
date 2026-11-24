using BlastLab.Domain;
using UnityEngine;

/// <summary>
/// Composition root. Lives in Assembly-CSharp (Core) so it can reference every BlastLab assembly.
/// Later tasks wire services here explicitly instead of using Singletons.
/// </summary>
public sealed class Bootstrap : MonoBehaviour
{
    private void Awake()
    {
        Application.targetFrameRate = 60;
        Debug.Log($"{AppInfo.ProductName} bootstrapped.");
    }
}
