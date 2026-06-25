using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndGameManager : MonoBehaviour
{
    public static EndGameManager Instance;

    public bool gameEnded = false;

    public GameObject endGamePanel;
    public TextMeshProUGUI endGameText;

    void Awake()
    {
        Instance = this;
    }

    void Start()
{
    gameEnded = false;

    if (endGamePanel != null)
        endGamePanel.SetActive(false);
}

    public void EndGame(string message)
{
    if (AudioManager.Instance != null)
{
    AudioManager.Instance.PlayWinnerPopupSound();
}
    gameEnded = true;

    Debug.Log("Activando popup: " + message);

    if (endGamePanel == null)
    {
        Debug.LogError("EndGamePanel NO está asignado.");
        return;
    }
    

    endGamePanel.SetActive(true);
    endGamePanel.transform.SetAsLastSibling();

    if (endGameText != null)
        endGameText.text = message;
    else
        Debug.LogError("EndGameText NO está asignado.");
}

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMainMenu()
    {
        PlayerPrefs.SetInt("SkipSplash", 1);
        SceneManager.LoadScene("MainMenu");
    }
}