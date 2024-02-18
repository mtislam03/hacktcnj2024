using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BoardController : MonoBehaviour
{
    public int rowNum = 3;
    public float partitionWidth;
    public GameObject partition;
    public GameObject tilePrefab;
    public TextMeshProUGUI TurnDisplay;
    public TextMeshProUGUI CatDisplay;
    public TextMeshProUGUI WordDisplay;
    public TextMeshProUGUI LettersUsedGUI;
    public TextMeshProUGUI LetterDisplay;
    public float secsBetweenTurns;

    public AudioClip clickClip;
    public AudioClip badClickClip;
    public AudioClip winClip;

    public Color currHighlightColor;
    public Color[] playerColors;

    private int numPlayers;
    private Tile[,] tiles;
    private int CurrentPlayer;
    private bool tileSelected;
    private WordGenerator.WordType category;

    private bool active = true;
    
    void Start()
    {
        numPlayers = playerColors.Length;
        int namesCount = System.Enum.GetNames(typeof(WordGenerator.WordType)).Length;
        // CatDisplay.SetText("Current Category: Animals");
        int randomIndex = Random.Range(0, namesCount);

        category = (WordGenerator.WordType)randomIndex;
        CatDisplay.SetText("Current Category: " + category.ToString());

        CurrentPlayer = -1;
        NextPlayer();
        tileSelected = false;
        tiles = new Tile[rowNum, rowNum];
        Generate();
        LettersUsedGUI.enabled = false;
    }

    void Generate()
    {
        RectTransform rt = GetComponent<RectTransform>();
        Vector2 bottomLeft = new Vector2(rt.rect.xMin, rt.rect.yMin);
        Vector2 bounds = rt.rect.size;

        float tileX = (bounds.x - partitionWidth * (rowNum - 1)) / rowNum;
        float tileY = (bounds.y - partitionWidth * (rowNum - 1)) / rowNum;
        Vector2 tileSize = new Vector2(tileX, tileY);
        for (int y = 0; y < rowNum; y++)
        {
            for (int x = 0; x < rowNum; x++)
            {
                Tile tile = Instantiate(tilePrefab, transform).GetComponent<Tile>();
                tile.transform.localPosition = bottomLeft + tileSize / 2 + new Vector2(x, y) * (tileSize + new Vector2(partitionWidth, partitionWidth));
                tile.transform.localScale = tileSize;
                tiles[x, y] = tile;
                tile.OnClick += OnClick;
                tile.OnTurnTaken += EndTurn;
                tile.SetCategory(category);
                if (y == 0 && x > 0)
                {
                    GameObject part = Instantiate(partition, transform);
                    Vector2 scale = new Vector2(partitionWidth, bounds.y);
                    part.transform.localPosition = bottomLeft + new Vector2(x, 0) * (tileSize + new Vector2(partitionWidth, partitionWidth)) + new Vector2(-partitionWidth, bounds.y) / 2;
                    part.transform.localScale = scale;
                }
            }
            if (y > 0)
            {
                GameObject part = Instantiate(partition, transform);
                Vector2 scale = new Vector2(bounds.x, partitionWidth);
                part.transform.localPosition = bottomLeft + new Vector2(0, y) * (tileSize + new Vector2(partitionWidth, partitionWidth)) + new Vector2(bounds.x, -partitionWidth) / 2;
                part.transform.localScale = scale;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    void NextPlayer() {
        CurrentPlayer = (CurrentPlayer + 1) % numPlayers;
        TurnDisplay.SetText("Current Player: " + (CurrentPlayer + 1).ToString());
        TurnDisplay.color = playerColors[CurrentPlayer];
        ShowPick();
    }

    bool CheckColumn()
    {
        // column wise
        for (int y = 0; y < rowNum; y++)
        {
            bool found = true;
            for (int x = 0; x < rowNum; x++)
            {
                if (tiles[x, y].Winner != CurrentPlayer)
                {
                    found = false;
                    break;
                }
            }
            if (found) return true;
        }
        return false;
    }

    bool CheckRow()
    {
        // row wise
        for (int x = 0; x < rowNum; x++)
        {
            bool found = true;
            for (int y = 0; y < rowNum; y++)
            {
                if (tiles[x, y].Winner != CurrentPlayer)
                {
                    found = false;
                    break;
                }
            }
            if (found) return true;
        }
        return false;
    }

    bool CheckLeftDiag()
    {
        // left diag
        for (int x = 0; x < rowNum; x++)
        {
            if (tiles[x, x].Winner != CurrentPlayer) return false;
        }
        return true;
    }

    bool CheckRightDiag()
    {
        // right diag
        for (int x = 0; x < rowNum; x++)
        {
            if (tiles[x, rowNum - x - 1].Winner != CurrentPlayer) return false;
        }
        return true;
    }

    bool CheckForWin() 
    {
        return CheckColumn() | CheckRow() | CheckLeftDiag() | CheckRightDiag();
    }

    void EndTurn(Tile tile, bool continueTurn)
    {
        tile.UpdateText(WordDisplay);
        tile.UpdateLetterBank(LetterDisplay);
        if (continueTurn) return;
        bool won = tile.GameWon();
        if (won)
        {
            tile.SetColor(playerColors[CurrentPlayer]);
            tile.Winner = CurrentPlayer;

            // check for tic tac toe win
            bool winner = CheckForWin();

            if (winner)
            {
                AudioManager.Instance.PlayEffect(winClip);
                active = false;
                LetterDisplay.SetText("");
                LettersUsedGUI.enabled = false;
                WordDisplay.SetText("Player " + (CurrentPlayer+1) + " wins!");
                WordDisplay.color = playerColors[CurrentPlayer];
                return;
            }
        }
        StartCoroutine(StepTurn(tile, won));
    }

    IEnumerator StepTurn(Tile tile, bool won)
    {
        yield return new WaitForSeconds(secsBetweenTurns);
        if (!won)
        {
            tile.ResetColor();
            NextPlayer();
        }
        else ShowPick();
        tileSelected = false;
        LettersUsedGUI.enabled = false;
        yield break;
    }

    private void OnClick(Tile tile)
    {
        if (tile.Winner == -1 && !tileSelected && active)
        {
            AudioManager.Instance.PlayEffect(clickClip);
            tile.PlayGame();
            tileSelected = true;

            tile.UpdateText(WordDisplay);
            tile.UpdateLetterBank(LetterDisplay);
            tile.SetColor(currHighlightColor);
            LettersUsedGUI.enabled = true;
            return;
        }
        AudioManager.Instance.PlayEffect(badClickClip);
    }

    private void ShowPick()
    {
        LetterDisplay.SetText("");
        WordDisplay.SetText("Player " + (CurrentPlayer + 1) + "'s pick");
        WordDisplay.color = playerColors[CurrentPlayer];
    }
}
