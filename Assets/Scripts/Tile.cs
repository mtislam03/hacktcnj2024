using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tile : MonoBehaviour
{
    public delegate void TurnTakenAction(Tile tile, bool continueTurn);
    public event TurnTakenAction OnTurnTaken;

    public delegate void ClickAction(Tile tile);
    public event ClickAction OnClick;

    public Game game;
    public TextMeshProUGUI text;

    private int SquareWinner = -1;

    private void Update()
    {
        text.SetText(game.GetPreview());
    }

    public void PlayGame()
    {
        game.Activate();
    }

    public void PauseGame()
    {
        game.Deactivate();
    }

    private void OnGUI()
    {
        if (game.Inactive) return;
        OnTurnTaken(this, game.TakeInput(Event.current));
    }
    
    public bool GameWon()
    {
        return game.DidWin();
    }

    void OnClickInt()
    {
        OnClick(this);
    }

    //returns who won square, if no one has won square yet returns -1
    public int CheckSquareWon() 
    {
        return SquareWinner;
    }
}
