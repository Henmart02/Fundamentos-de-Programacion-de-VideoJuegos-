using UnityEngine;
using TMPro;

public class QuickMatchUIManager : MonoBehaviour
{
    public TextMeshProUGUI whitePlayerText;
    public TextMeshProUGUI blackPlayerText;

    public BoardManager boardManager;
    public UniversalPopupUI universalPopup;

    private string whiteName;
    private string blackName;

    void Start()
    {
        whiteName = PlayerPrefs.GetString("WhitePlayer", "Jugador Blancas");
        blackName = PlayerPrefs.GetString("BlackPlayer", "Jugador Negras");

        whitePlayerText.text = "Blancas: " + whiteName;
        blackPlayerText.text = "Negras: " + blackName;
    }

    public void Resign()
    {
        bool turnoBlanco = boardManager.whiteTurn;

        string ganadorColor = turnoBlanco ? "negras" : "blancas";
        string jugadorGanador = turnoBlanco ? blackName : whiteName;

        EndGameManager.Instance.EndGame(
            "Ganan las " + ganadorColor +
            "\nJugador: " + jugadorGanador +
            "\npor rendición"
        );
    }
/*
    public void RequestUndo()
    {
        bool turnoBlanco = boardManager.whiteTurn;

        string jugadorQuePide = turnoBlanco ? whiteName : blackName;
        string rival = turnoBlanco ? blackName : whiteName;

        universalPopup.Show(
            "DESHACER JUGADA",
            jugadorQuePide + " solicita deshacer la jugada.\n¿Acepta " + rival + "?",
            () =>
            {
                boardManager.UndoLastMove();
            },
            () =>
            {
                Debug.Log("Deshacer rechazado.");
            },
            true
        );
    }*/
    public void RequestUndo()
{
    string jugadorQuePide = boardManager.lastMoveWasWhite ? whiteName : blackName;
    string jugadorRival = boardManager.lastMoveWasWhite ? blackName : whiteName;

    universalPopup.Show(
        "DESHACER JUGADA",
        jugadorQuePide + " solicita deshacer la jugada.\n\n¿Acepta " + jugadorRival + "?",
        () =>
        {
            boardManager.UndoLastMove();
        },
        () =>
        {
            Debug.Log("Deshacer rechazado.");
        },
        true
    );
}

    public void RequestDraw()
    {
        bool turnoBlanco = boardManager.whiteTurn;

        string jugadorQuePide = turnoBlanco ? whiteName : blackName;
        string rival = turnoBlanco ? blackName : whiteName;

        universalPopup.Show(
            "TABLAS",
            jugadorQuePide + " propone tablas.\n¿Acepta " + rival + "?",
            () =>
            {
                EndGameManager.Instance.EndGame("TABLAS");
            },
            () =>
            {
                Debug.Log("Tablas rechazadas.");
            },
            true
        );
    }
}