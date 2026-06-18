using UnityEngine;
using System.Collections.Generic;

using UnityEngine.SceneManagement;
using TMPro;

public class BughouseManager : MonoBehaviour
{
    public static BughouseManager Instance;

    [Header("Boards")]
    public BoardManager boardA;
    public BoardManager boardB;

    [Header("Fin de partida")]
public bool gameEnded = false;
public GameObject endGamePanel;
public TextMeshProUGUI endGameText;
public UniversalPopupUI universalPopup;

    // Inventarios: piezas disponibles para colocar
    private Dictionary<string, List<PieceType>> pockets = new Dictionary<string, List<PieceType>>();



    [Header("UI Nombres")]
public TMP_Text txtTeam1;
public TMP_Text txtTeam1White;
public TMP_Text txtTeam1Black;

public TMP_Text txtTeam2;
public TMP_Text txtTeam2White;
public TMP_Text txtTeam2Black;

    private void Awake()
    {
        Instance = this;

        // Crear bolsillos vacíos
        pockets["BoardA_White"] = new List<PieceType>();
        pockets["BoardA_Black"] = new List<PieceType>();
        pockets["BoardB_White"] = new List<PieceType>();
        pockets["BoardB_Black"] = new List<PieceType>();
    }

private void Start()
{
    LoadPlayerNames();
}

    public BoardManager GetPartnerBoard(BoardManager currentBoard)
    {
        if (currentBoard == boardA) return boardB;
        if (currentBoard == boardB) return boardA;
        return null;
    }

    public int GetTeam(BoardManager board, bool isWhite)
    {
        if (board == boardA)
            return isWhite ? 1 : 2;

        if (board == boardB)
            return isWhite ? 2 : 1;

        return -1;
    }

    public bool GetPartnerColor(BoardManager currentBoard, bool isWhite)
    {
        int team = GetTeam(currentBoard, isWhite);
        BoardManager partnerBoard = GetPartnerBoard(currentBoard);

        if (partnerBoard == null) return false;

        if (partnerBoard == boardA)
            return team == 1; // Team 1 en BoardA = blancas

        if (partnerBoard == boardB)
            return team == 2; // Team 2 en BoardB = blancas

        return false;
    }

    public string GetPartnerInfo(BoardManager currentBoard, bool isWhite)
    {
        BoardManager partnerBoard = GetPartnerBoard(currentBoard);
        bool partnerColor = GetPartnerColor(currentBoard, isWhite);

        if (partnerBoard == null)
            return "Sin compañero";

        return "Compañero en " + partnerBoard.name + " con " + (partnerColor ? "blancas" : "negras");
    }

    private string GetPocketKey(BoardManager board, bool isWhite)
    {
        string boardName = board == boardA ? "BoardA" : "BoardB";
        string colorName = isWhite ? "White" : "Black";
        return boardName + "_" + colorName;
    }

    public void AddCapturedPieceForPartner(BoardManager sourceBoard, bool capturerIsWhite, PieceType capturedPieceType)
    {
        BoardManager partnerBoard = GetPartnerBoard(sourceBoard);
        bool partnerColor = GetPartnerColor(sourceBoard, capturerIsWhite);

        if (partnerBoard == null)
        {
            Debug.LogWarning("No se encontró tablero compañero.");
            return;
        }

        string key = GetPocketKey(partnerBoard, partnerColor);
        pockets[key].Add(capturedPieceType);

        Debug.Log("Se agregó " + capturedPieceType + " al inventario de "
            + partnerBoard.name + " "
            + (partnerColor ? "blancas" : "negras"));

        DebugPocket(key);

        if (GameManager.Instance != null)
    GameManager.Instance.RefreshAllPocketButtons();
    }

    public List<PieceType> GetPocket(BoardManager board, bool isWhite)
    {
        string key = GetPocketKey(board, isWhite);
        return pockets[key];
    }

    public bool RemovePieceFromPocket(BoardManager board, bool isWhite, PieceType pieceType)
    {
        string key = GetPocketKey(board, isWhite);

        if (pockets[key].Contains(pieceType))
        {
            pockets[key].Remove(pieceType);
            Debug.Log("Se removió " + pieceType + " del inventario de " + key);
            DebugPocket(key);
            return true;
        }

        return false;
    }

    private void DebugPocket(string key)
    {
        string content = key + ": ";

        if (pockets[key].Count == 0)
        {
            content += "vacío";
        }
        else
        {
            for (int i = 0; i < pockets[key].Count; i++)
            {
                content += pockets[key][i];
                if (i < pockets[key].Count - 1)
                    content += ", ";
            }
        }

        Debug.Log(content);
    }

public void EndGame(string message)
{
    gameEnded = true;

    if (AudioManager.Instance != null)
        AudioManager.Instance.PlayWinnerPopupSound();

    if (endGamePanel != null)
        endGamePanel.SetActive(true);

    if (endGameText != null)
        endGameText.text = message;
    else
        Debug.LogWarning("EndGameText no está asignado en BughouseManager.");

    Debug.Log("Resultado: " + message);
}
/*{
    if (AudioManager.Instance != null)
{
    AudioManager.Instance.PlayWinnerPopupSound();
}
    gameEnded = true;

    if (endGamePanel != null)
        endGamePanel.SetActive(true);

    if (endGameText != null)
        //endGameText.text = message + "\nJaque mate";
        endGameText.text = message;
}*/

public void PlayAgain()
{
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
}

public void BackToMainMenu()
{
    PlayerPrefs.SetInt("SkipSplash", 1);
    SceneManager.LoadScene("MainMenu");
}

void LoadPlayerNames()
{
    string team1 = PlayerPrefs.GetString("Team1Name", "Equipo 1");
    string team1White = PlayerPrefs.GetString("Team1WhitePlayer", "Jugador 1");
    string team1Black = PlayerPrefs.GetString("Team1BlackPlayer", "Jugador 2");

    string team2 = PlayerPrefs.GetString("Team2Name", "Equipo 2");
    string team2Black = PlayerPrefs.GetString("Team2BlackPlayer", "Jugador 1");
    string team2White = PlayerPrefs.GetString("Team2WhitePlayer", "Jugador 2");

    if (txtTeam1 != null) txtTeam1.text = "Equipo 1: " + team1;
    if (txtTeam1White != null) txtTeam1White.text = "Blancas: " + team1White;
    if (txtTeam1Black != null) txtTeam1Black.text = "Negras: " + team1Black;

    if (txtTeam2 != null) txtTeam2.text = "Equipo 2: " + team2;
    if (txtTeam2White != null) txtTeam2White.text = "Blancas: " + team2White;
    if (txtTeam2Black != null) txtTeam2Black.text = "Negras: " + team2Black;
}

public void RequestUndoBoardA()
{
    string jugadorQuePide = boardA.lastMoveWasWhite ? txtTeam1White.text : txtTeam2Black.text;
    string jugadorRival = boardA.lastMoveWasWhite ? txtTeam2Black.text : txtTeam1White.text;
    

    universalPopup.Show(
        "DESHACER JUGADA",
        jugadorQuePide + " solicita deshacer la jugada.\n\n¿Acepta " + jugadorRival + "?",
        () =>
        {
            boardA.UndoLastMove();
        },
        () =>
        {
            Debug.Log("Deshacer tablero A rechazado.");
        },
        true
    );
}

public void RequestUndoBoardB()
{
    string jugadorQuePide = boardB.lastMoveWasWhite ? txtTeam2White.text : txtTeam1Black.text;
    string jugadorRival = boardB.lastMoveWasWhite ? txtTeam1Black.text : txtTeam2White.text;

    universalPopup.Show(
        "DESHACER JUGADA",
        jugadorQuePide + " solicita deshacer la jugada.\n\n¿Acepta " + jugadorRival + "?",
        () =>
        {
            boardB.UndoLastMove();
        },
        () =>
        {
            Debug.Log("Deshacer tablero B rechazado.");
        },
        true
    );
}

public void RequestDrawBoardA()
{
    universalPopup.Show(
        "TABLAS",
        "¿El equipo rival acepta tablas en el Tablero A?",
        () =>
        {
            EndGame("TABLAS\nAmbos equipos aceptaron tablas\nTablero A");
        },
        () =>
        {
            Debug.Log("Tablas tablero A rechazadas.");
        },
        true
    );
}

public void RequestDrawBoardB()
{
    universalPopup.Show(
        "TABLAS",
        "¿El equipo rival acepta tablas en el Tablero B?",
        () =>
        {
            EndGame("TABLAS\nAmbos equipos aceptaron tablas\nTablero B");
        },
        () =>
        {
            Debug.Log("Tablas tablero B rechazadas.");
        },
        true
    );
}

public void SurrenderBoardA()
{
    bool seRindeBlanco = boardA.whiteTurn;

    if (seRindeBlanco)
    {
        EndGame(
            txtTeam1White.text + " se rindió.\n\n" +
            "Gana el Equipo 2:\n" +
            txtTeam2White.text + "\n" +
            txtTeam2Black.text +
            "\n\nTablero A"
        );
    }
    else
    {
        EndGame(
            txtTeam2Black.text + " se rindió.\n\n" +
            "Gana el Equipo 1:\n" +
            txtTeam1White.text + "\n" +
            txtTeam1Black.text +
            "\n\nTablero A"
        );
    }
}

public void SurrenderBoardB()
{
    bool seRindeBlanco = boardB.whiteTurn;

    if (seRindeBlanco)
    {
        EndGame(
            txtTeam2White.text + " se rindió.\n\n" +
            "Gana el Equipo 1:\n" +
            txtTeam1White.text + "\n" +
            txtTeam1Black.text +
            "\n\nTablero B"
        );
    }
    else
    {
        EndGame(
            txtTeam1Black.text + " se rindió.\n\n" +
            "Gana el Equipo 2:\n" +
            txtTeam2White.text + "\n" +
            txtTeam2Black.text +
            "\n\nTablero B"
        );
    }
}

public void RemoveCapturedPieceFromPartner(BoardManager sourceBoard, bool capturerIsWhite, PieceType capturedPieceType)
{
    BoardManager partnerBoard = GetPartnerBoard(sourceBoard);
    bool partnerColor = GetPartnerColor(sourceBoard, capturerIsWhite);

    if (partnerBoard == null) return;

    string key = GetPocketKey(partnerBoard, partnerColor);

    if (pockets[key].Contains(capturedPieceType))
    {
        pockets[key].Remove(capturedPieceType);
        Debug.Log("Se quitó " + capturedPieceType + " del inventario de " + key);

        if (GameManager.Instance != null)
            GameManager.Instance.RefreshAllPocketButtons();
    }
}

public void AddPieceBackToPocket(BoardManager board, bool isWhite, PieceType pieceType)
{
    string key = GetPocketKey(board, isWhite);
    pockets[key].Add(pieceType);

    Debug.Log("Se regresó " + pieceType + " al pocket de " + key);

    if (GameManager.Instance != null)
        GameManager.Instance.RefreshAllPocketButtons();
}

public bool PartnerStillHasCapturedPiece(BoardManager sourceBoard, bool capturerIsWhite, PieceType capturedPieceType)
{
    BoardManager partnerBoard = GetPartnerBoard(sourceBoard);
    bool partnerColor = GetPartnerColor(sourceBoard, capturerIsWhite);

    if (partnerBoard == null) return false;

    string key = GetPocketKey(partnerBoard, partnerColor);

    return pockets[key].Contains(capturedPieceType);
}

public void EndGameByCheckmate(BoardManager board, bool winnerIsWhite)
{
    string tablero = board == boardA ? "A" : "B";

    string equipoGanador = "";
    string jugadorBlancas = "";
    string jugadorNegras = "";

    // TABLERO A
    if (board == boardA)
    {
        if (winnerIsWhite)
        {
            equipoGanador = txtTeam1.text.Replace("Equipo 1: ", "");
            jugadorBlancas = txtTeam1White.text.Replace("Blancas: ", "");
            jugadorNegras = txtTeam1Black.text.Replace("Negras: ", "");
        }
        else
        {
            equipoGanador = txtTeam2.text.Replace("Equipo 2: ", "");
            jugadorBlancas = txtTeam2White.text.Replace("Blancas: ", "");
            jugadorNegras = txtTeam2Black.text.Replace("Negras: ", "");
        }
    }

    // TABLERO B
    else
    {
        if (winnerIsWhite)
        {
            equipoGanador = txtTeam2.text.Replace("Equipo 2: ", "");
            jugadorBlancas = txtTeam2White.text.Replace("Blancas: ", "");
            jugadorNegras = txtTeam2Black.text.Replace("Negras: ", "");
        }
        else
        {
            equipoGanador = txtTeam1.text.Replace("Equipo 1: ", "");
            jugadorBlancas = txtTeam1White.text.Replace("Blancas: ", "");
            jugadorNegras = txtTeam1Black.text.Replace("Negras: ", "");
        }
    }

    string mensaje =
        "JAQUE MATE EN EL TABLERO " + tablero +
        "\n\nGANA EL EQUIPO: " + equipoGanador +
        "\n\nJUGADORES:" +
        "\nBlanco: " + jugadorBlancas +
        "\nNegro: " + jugadorNegras;

    EndGame(mensaje);
}
}