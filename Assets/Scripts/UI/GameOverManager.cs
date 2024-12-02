using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverManager : MonoBehaviour
{
    //[Header("Settings")]

    [Header("References")]
    [SerializeField] GameObject gameOverPanel;

    //[Space(10)]
    // RSO
    // RSF
    // RSP

    [Header("Input")]
    [SerializeField] RSE_OnPlayerDeath rseOnPlayerDeath;
    //[Header("Output")]

    private void OnEnable()
    {
        rseOnPlayerDeath.action += OpenGameOverpanel;
    }
    private void OnDisable()
    {
        rseOnPlayerDeath.action -= OpenGameOverpanel;
    }

    void OpenGameOverpanel()
    {
        gameOverPanel.SetActive(true);
    }

    public void RetryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}