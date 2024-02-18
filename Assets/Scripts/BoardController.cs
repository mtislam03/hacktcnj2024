using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BoardController : MonoBehaviour
{
    public Vector2 bottomLeft;
    public Vector2 bounds;
    public int rowNum = 3;
    public float partitionWidth;
    public GameObject partition;

    public GameObject tilePrefab;

    private Tile[,] tiles;

    private int CurrentPlayer = 1;

    public TextMeshProUGUI TurnDisplay;

    private bool tileSelected;
    //public TMT_Text TurnDisplay;

    //TurnDisplay.SetText(CurrentPlayer.ToString());
    // TurnDisplay.text = "Hello";
    

    // Start is called before the first frame update
    void Start()
    {
        tileSelected = false;
        tiles = new Tile[rowNum, rowNum];
        Vector2 tileSize = bounds / rowNum;
        for (int y = 0; y < rowNum; y++)
        {
            for (int x = 0; x < rowNum; x++)
            {
                Tile tile = Instantiate(tilePrefab, transform).GetComponent<Tile>();
                tile.transform.localPosition = bottomLeft + tileSize / 2 + new Vector2(x, y) * (tileSize + new Vector2(partitionWidth, partitionWidth) / 2);
                tile.transform.localScale = tileSize;
                tiles[x, y] = tile;
                tile.OnClick += OnClick;
                tile.OnTurnTaken += EndTurn;
                if (y == 0 && x > 0)
                {
                    GameObject part = Instantiate(partition, transform);
                    Vector2 scale = new Vector2(partitionWidth, bounds.y);
                    part.transform.localPosition = bottomLeft + new Vector2(x, 0) * tileSize + scale / 2;
                    part.transform.localScale = scale;
                }
            }
            if (y > 0)
            {
                GameObject part = Instantiate(partition, transform);
                Vector2 scale = new Vector2(bounds.x, partitionWidth);
                part.transform.localPosition = bottomLeft + new Vector2(0, y) * tileSize + scale / 2;
                part.transform.localScale = scale;
            }
        }

        //TurnDisplay.SetText(CurrentPlayer.ToString());
        TurnDisplay.SetText("Current Turn " + CurrentPlayer.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangePlayer() {
        if (CurrentPlayer == 1)
        {
            CurrentPlayer = 0;
        }
            
        else 
        {
            CurrentPlayer = 1;
        }
    }

    void EndTurn(Tile tile, bool continueTurn)
    {
        if (continueTurn) return;
        if (tile.GameWon())
        {
            // game win sequence
        }
        tile.game.Deactivate();
        ChangePlayer();
        TurnDisplay.SetText("Current Turn " + CurrentPlayer.ToString());
        tileSelected = false;
    }

    private void OnClick(Tile tile)
    {
        if (tile.CheckSquareWon() == -1 && !tileSelected)
        {
            tile.PlayGame();
            tileSelected = true;
        }
    }
}
