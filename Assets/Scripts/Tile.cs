using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tile : MonoBehaviour
{
    public delegate void ClickAction(Tile tile);
    public event ClickAction OnClick;
    public int SquareWinner = -1;

    public Hangman hangman;
    public TextMeshProUGUI text;

    private void Update()
    {
        text.SetText(hangman.GetRepr());
    }

    public void OnClickInt()
    {
        OnClick(this);
    }

    //returns who won square, if no one has won square yet returns -1
    public int CheckSquareWon() 
    {
        if (SquareWinner == -1)
        {
            return -1;

        }
        else if (SquareWinner == 1)
        {
            return 1;
        } 
        else 
        {
            return 0;
        }



    }
}
