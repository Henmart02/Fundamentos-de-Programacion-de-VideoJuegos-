using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    public GameObject splashPanel;
    public GameObject menuPanel;
    public GameObject modePanel;
    public GameObject tutorialPanel;
    public GameObject creditsPanel;
    //public MainMenuManager mainMenuManager;

    public GameObject quickNamesPanel;
public TMP_InputField inputPlayer1;
public TMP_InputField inputPlayer2;

public GameObject bughouseNamesPanel;

public TMP_InputField inputTeam1;
public TMP_InputField inputTeam1PlayerWhite;
public TMP_InputField inputTeam1PlayerBlack;

public TMP_InputField inputTeam2;
public TMP_InputField inputTeam2PlayerBlack;
public TMP_InputField inputTeam2PlayerWhite;

[Header("Panels")]
public GameObject settingsPanel;

public void OpenSettingsPanel()
{
    settingsPanel.SetActive(true);
    settingsPanel.transform.SetAsLastSibling();
}

public void CloseSettingsPanel()
{
    settingsPanel.SetActive(false);
}

    void Start()
{
    bool skipSplash = PlayerPrefs.GetInt("SkipSplash", 0) == 1;

    if (skipSplash)
    {
        PlayerPrefs.SetInt("SkipSplash", 0);

        splashPanel.SetActive(false);
        menuPanel.SetActive(true);
        modePanel.SetActive(false);
        tutorialPanel.SetActive(false);
        quickNamesPanel.SetActive(false);
    }
    else
    {
        splashPanel.SetActive(true);
        menuPanel.SetActive(false);
        modePanel.SetActive(false);
        tutorialPanel.SetActive(false);
        quickNamesPanel.SetActive(false);
    }
}

    void Update()
    {
        if (splashPanel.activeSelf && Input.anyKeyDown)
        {
            splashPanel.SetActive(false);
            menuPanel.SetActive(true);
        }
    }

    public void OpenModeMenu()
    {
        menuPanel.SetActive(false);
        modePanel.SetActive(true);
    }

    public void PlayPasaPiezas()
    {
        //SceneManager.LoadScene("MainScene");
        splashPanel.SetActive(false);
    menuPanel.SetActive(false);
    modePanel.SetActive(false);
    tutorialPanel.SetActive(false);
    creditsPanel.SetActive(false);
    quickNamesPanel.SetActive(false);

    bughouseNamesPanel.SetActive(true);
    }

    public void PlayQuickMatch()
{
    //SceneManager.LoadScene("QuickMatchScene");
    splashPanel.SetActive(false);
    menuPanel.SetActive(false);
    modePanel.SetActive(false);
    tutorialPanel.SetActive(false);
    creditsPanel.SetActive(false);
    quickNamesPanel.SetActive(true);
}

/*public void StartBughouse()
{
    PlayerPrefs.SetString("Team1Name", inputTeam1.text);
    PlayerPrefs.SetString("Team1WhitePlayer", inputTeam1PlayerWhite.text);
    PlayerPrefs.SetString("Team1BlackPlayer", inputTeam1PlayerBlack.text);

    PlayerPrefs.SetString("Team2Name", inputTeam2.text);
    PlayerPrefs.SetString("Team2BlackPlayer", inputTeam2PlayerBlack.text);
    PlayerPrefs.SetString("Team2WhitePlayer", inputTeam2PlayerWhite.text);

    PlayerPrefs.Save();

    UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
}*/
public void StartBughouse()
{
    // Validar campos vacíos
    if (string.IsNullOrWhiteSpace(inputTeam1.text) ||
        string.IsNullOrWhiteSpace(inputTeam1PlayerWhite.text) ||
        string.IsNullOrWhiteSpace(inputTeam1PlayerBlack.text) ||
        string.IsNullOrWhiteSpace(inputTeam2.text) ||
        string.IsNullOrWhiteSpace(inputTeam2PlayerWhite.text) ||
        string.IsNullOrWhiteSpace(inputTeam2PlayerBlack.text))
    {
        Debug.Log("Debes llenar todos los campos.");
        return;
    }

    PlayerPrefs.SetString("Team1Name", inputTeam1.text);
    PlayerPrefs.SetString("Team1WhitePlayer", inputTeam1PlayerWhite.text);
    PlayerPrefs.SetString("Team1BlackPlayer", inputTeam1PlayerBlack.text);

    PlayerPrefs.SetString("Team2Name", inputTeam2.text);
    PlayerPrefs.SetString("Team2BlackPlayer", inputTeam2PlayerBlack.text);
    PlayerPrefs.SetString("Team2WhitePlayer", inputTeam2PlayerWhite.text);

    PlayerPrefs.Save();

    SceneManager.LoadScene("MainScene");
}

public void BackFromBughouseNames()
{
    bughouseNamesPanel.SetActive(false);
    modePanel.SetActive(true);
}

public void StartQuickMatch()
{
    string p1 = inputPlayer1.text.Trim();
    string p2 = inputPlayer2.text.Trim();

    if (string.IsNullOrWhiteSpace(p1) ||
        string.IsNullOrWhiteSpace(p2) ||
        p1 == "Ingrese nombre del jugador" ||
        p2 == "Ingrese nombre del jugador")
    {
        Debug.Log("Debes llenar ambos nombres.");
        return;
    }

    bool player1White = Random.Range(0, 2) == 0;

    PlayerPrefs.SetString("WhitePlayer", player1White ? p1 : p2);
    PlayerPrefs.SetString("BlackPlayer", player1White ? p2 : p1);

    SceneManager.LoadScene("QuickMatchScene");
}


   public void OpenTutorial()
{
    splashPanel.SetActive(false);
    menuPanel.SetActive(false);
    modePanel.SetActive(false);
    tutorialPanel.SetActive(true);
}

    public void BackToModes()
{
    splashPanel.SetActive(false);
    tutorialPanel.SetActive(false);
    menuPanel.SetActive(false);
    quickNamesPanel.SetActive(false);
    bughouseNamesPanel.SetActive(false);
    modePanel.SetActive(true);
}

    public void BackToMainMenu()
{
    splashPanel.SetActive(false);
    tutorialPanel.SetActive(false);
    modePanel.SetActive(false);
    menuPanel.SetActive(true);
}

    public void ExitGame()
    {
        Application.Quit();
    }
    public void ShowTutorial()
{
    splashPanel.SetActive(false);
    menuPanel.SetActive(false);
    modePanel.SetActive(false);
    tutorialPanel.SetActive(true);
}

public void ShowMainMenu()
{
    splashPanel.SetActive(false);
    tutorialPanel.SetActive(false);
    modePanel.SetActive(false);
    menuPanel.SetActive(true);
}
public void ShowCredits()
{
    splashPanel.SetActive(false);
    menuPanel.SetActive(false);
    modePanel.SetActive(false);
    tutorialPanel.SetActive(false);
    creditsPanel.SetActive(true);
}
public void BackFromCredits()
{
    creditsPanel.SetActive(false);
    menuPanel.SetActive(true);
}

}