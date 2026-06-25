using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class TutorialPieceManager : MonoBehaviour
{
    public Image imgPieza;
    public TMP_Text txtTituloPieza;
    public TMP_Text txtDescripcion;

    public Sprite peon;
    public Sprite torre;
    public Sprite caballo;
    public Sprite alfil;
    public Sprite dama;
    public Sprite rey;

    public GameObject tilePrefab;
public GameObject piecePrefab;
public Transform tutorialBoard;

private bool pieceSelected = false;
private bool[,] validMoves = new bool[8, 8];

private GameObject[,] tiles = new GameObject[8,8];
private GameObject currentPiece;

private string currentPieceType = "Peon";
private int pieceX = 3;
private int pieceY = 3;

    public void ShowPeon()
{
    currentPieceType = "Peon";
    imgPieza.sprite = peon;
    txtTituloPieza.text = "PEÓN";
    txtDescripcion.text = "Avanza una casilla hacia adelante. Captura en diagonal.";
     ClearHighlights();
     SpawnPiece(peon);
}

public void ShowTorre()
{
    currentPieceType = "Torre";
    imgPieza.sprite = torre;
    txtTituloPieza.text = "TORRE";
    txtDescripcion.text = "Se mueve en línea recta horizontal o vertical.";
    ClearHighlights();
    SpawnPiece(torre);
}

public void ShowCaballo()
{
    currentPieceType = "Caballo";
    imgPieza.sprite = caballo;
    txtTituloPieza.text = "CABALLO";
    txtDescripcion.text = "Se mueve en forma de L y puede saltar piezas.";
    ClearHighlights();
    SpawnPiece(caballo);
}

public void ShowAlfil()
{
    currentPieceType = "Alfil";
    imgPieza.sprite = alfil;
    txtTituloPieza.text = "ALFIL";
    txtDescripcion.text = "Se mueve en diagonal.";
    ClearHighlights();
    SpawnPiece(alfil);
}

public void ShowDama()
{
    currentPieceType = "Dama";
    imgPieza.sprite = dama;
    txtTituloPieza.text = "DAMA";
    txtDescripcion.text = "Combina torre y alfil.";
    ClearHighlights();
    SpawnPiece(dama);
}

public void ShowRey()
{
    currentPieceType = "Rey";
    imgPieza.sprite = rey;
    txtTituloPieza.text = "REY";
    txtDescripcion.text = "Se mueve una casilla en cualquier dirección.";
    ClearHighlights();
    SpawnPiece(rey);
}
    void Start()
{
    CreateBoard();
}

void CreateBoard()
{
    for(int y = 0; y < 8; y++)
    {
        for(int x = 0; x < 8; x++)
        {
            GameObject tile = Instantiate(tilePrefab, tutorialBoard);
            tiles[x,y] = tile;

            Image img = tile.GetComponent<Image>();

            if((x + y) % 2 == 0)
                img.color = new Color(0.95f, 0.85f, 0.7f);
            else
                img.color = new Color(0.45f, 0.3f, 0.2f);

                int capturedX = x;
int capturedY = y;

Button btn = tile.AddComponent<Button>();
btn.onClick.AddListener(() => MovePieceTo(capturedX, capturedY));
        }
        
    }
    
}

void MovePieceTo(int x, int y)
{
    if (!pieceSelected)
        return;

    if (!validMoves[x, y])
        return;

    pieceX = x;
    pieceY = y;

    currentPiece.transform.SetParent(tiles[x, y].transform, false);
    currentPiece.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;

    pieceSelected = false;
    ClearHighlights();
}

void SpawnPiece(Sprite sprite)
{
    if(currentPiece != null)
        Destroy(currentPiece);

    currentPiece = Instantiate(piecePrefab, tutorialBoard);
    currentPiece.GetComponent<Image>().sprite = sprite;

    // posición en el centro (ej: 3,3)
    //currentPiece.transform.SetParent(tiles[3,3].transform, false);
currentPiece.transform.SetParent(tiles[pieceX, pieceY].transform, false);
currentPiece.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
    Button btn = currentPiece.AddComponent<Button>();
    btn.onClick.AddListener(ShowMovesExample);
}

void ShowMovesExample()
{
    pieceSelected = true;
    ClearHighlights();

    if (currentPieceType == "Peon")
    {
        Highlight(pieceX, pieceY + 1);
    }
    else if (currentPieceType == "Torre")
    {
        for (int i = 0; i < 8; i++)
        {
            Highlight(pieceX, i);
            Highlight(i, pieceY);
        }
    }
    else if (currentPieceType == "Caballo")
    {
        Highlight(pieceX + 1, pieceY + 2);
        Highlight(pieceX - 1, pieceY + 2);
        Highlight(pieceX + 2, pieceY + 1);
        Highlight(pieceX - 2, pieceY + 1);
        Highlight(pieceX + 1, pieceY - 2);
        Highlight(pieceX - 1, pieceY - 2);
        Highlight(pieceX + 2, pieceY - 1);
        Highlight(pieceX - 2, pieceY - 1);
    }
    else if (currentPieceType == "Alfil")
    {
        for (int i = 1; i < 8; i++)
        {
            Highlight(pieceX + i, pieceY + i);
            Highlight(pieceX - i, pieceY + i);
            Highlight(pieceX + i, pieceY - i);
            Highlight(pieceX - i, pieceY - i);
        }
    }
    else if (currentPieceType == "Dama")
    {
        for (int i = 0; i < 8; i++)
        {
            Highlight(pieceX, i);
            Highlight(i, pieceY);
        }

        for (int i = 1; i < 8; i++)
        {
            Highlight(pieceX + i, pieceY + i);
            Highlight(pieceX - i, pieceY + i);
            Highlight(pieceX + i, pieceY - i);
            Highlight(pieceX - i, pieceY - i);
        }
    }
    else if (currentPieceType == "Rey")
    {
        Highlight(pieceX + 1, pieceY);
        Highlight(pieceX - 1, pieceY);
        Highlight(pieceX, pieceY + 1);
        Highlight(pieceX, pieceY - 1);
        Highlight(pieceX + 1, pieceY + 1);
        Highlight(pieceX - 1, pieceY + 1);
        Highlight(pieceX + 1, pieceY - 1);
        Highlight(pieceX - 1, pieceY - 1);
    }
}

void Highlight(int x, int y)
{
    if (x < 0 || x >= 8 || y < 0 || y >= 8)
        return;

    validMoves[x, y] = true;
    tiles[x, y].GetComponent<Image>().color = Color.green;
}
void ClearHighlights()
{
    for (int y = 0; y < 8; y++)
    {
        for (int x = 0; x < 8; x++)
        {
            validMoves[x, y] = false;
            Image img = tiles[x, y].GetComponent<Image>();

            if ((x + y) % 2 == 0)
                img.color = new Color(0.95f, 0.85f, 0.7f);
            else
                img.color = new Color(0.45f, 0.3f, 0.2f);
        }
    }
}
void OnEnable()
{
    StartCoroutine(ShowPeonNextFrame());
}

System.Collections.IEnumerator ShowPeonNextFrame()
{
    yield return null;
    ShowPeon();
}

}