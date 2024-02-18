using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BoardController : MonoBehaviour
{
    public Vector2 bottomLeft;
    public Vector2 bounds;
    public int rowNum = 3;

    public GameObject tilePrefab;

    private Tile[,] tiles;

    public int CurrentPlayer = 1;

    public TextMeshProUGUI TurnDisplay;
    //public TMT_Text TurnDisplay;

    //TurnDisplay.SetText(CurrentPlayer.ToString());
    // TurnDisplay.text = "Hello";
    

    // Start is called before the first frame update
    void Start()
    {
        tiles = new Tile[rowNum, rowNum];
        Vector2 tileSize = bounds / rowNum;
        for (int y = 0; y < rowNum; y++)
        {
            for (int x = 0; x < rowNum; x++)
            {
                Tile tile = Instantiate(tilePrefab, transform).GetComponent<Tile>();
                tile.transform.localPosition = bottomLeft + tileSize / 2 + new Vector2(x, y) * tileSize;
                tile.transform.localScale = tileSize;
                tiles[x, y] = tile;
                tile.OnClick += OnClick;
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

    void OnClick(Tile tile)
    {
        //Debug.Log("Clicked tile");
        Debug.Log("Current turn:" + CurrentPlayer);

        if (tile.CheckSquareWon() == -1) {
            //CurrentPlayer = CurrentPlayer + 1;
            
            ChangePlayer();
            TurnDisplay.SetText("Current Turn " + CurrentPlayer.ToString());
            // TurnDisplay.text = CurrentPlayer.ToString();
        }
            
            
    }
}
