using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverManager : MonoBehaviour
{
    [Header("Input")]
    [SerializeField] RSE_OnPlayerDeath rseOnPlayerDeath;
    [Header("Output")]
    [SerializeField] RSE_ResetLevel rseResetLevel;
    
    private void OnEnable()
    {
        rseOnPlayerDeath.action += ResetLevel;
    }
    private void OnDisable()
    {
        rseOnPlayerDeath.action -= ResetLevel;
    }

    void ResetLevel()
    {
        rseResetLevel.Call();
    }
}