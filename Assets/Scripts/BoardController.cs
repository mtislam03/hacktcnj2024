using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour
{
    public Vector2 bottomLeft;
    public Vector2 bounds;
    public int rowNum = 3;

    public GameObject tilePrefab;

    private Tile[,] tiles;

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
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnClick(Tile tile)
    {
        Debug.Log("Clicked tile");
    }
}
