using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    public delegate void TurnTakenAction(Tile tile, bool continueTurn);
    public event TurnTakenAction OnTurnTaken;

    public delegate void ClickAction(Tile tile);
    public event ClickAction OnClick;

    public Hangman game;
    public TextMeshProUGUI text;
    public Image img;

    private int SquareWinner = -1;
    private Color defaultColor;

    public int Winner
    {
        get => SquareWinner;
        set { SquareWinner = value; }
    }
    public void SetCategory(WordGenerator.WordType category)
    {
        game.InitCat(category);
    }

    private void Start()
    {
        defaultColor = img.color;
    }

    private void Update()
    {
        text.SetText(game.GetRepr());
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
        bool cont = game.TakeInput(Event.current);
        if (!cont) game.Deactivate();
        OnTurnTaken(this, cont);
    }
    
    public bool GameWon()
    {
        return game.DidWin();
    }

    void OnClickInt()
    {
        OnClick(this);
    }

    public void UpdateText(TextMeshProUGUI gui)
    {
        gui.SetText(game.GetRepr());
        gui.color = Color.white;
    }

    public void UpdateLetterBank(TextMeshProUGUI gui)
    {
        gui.SetText(string.Join("", game.GetWrongLetters()));
    }

    public void SetColor(Color color)
    {
        img.color = color;
    }

    public void ResetColor()
    {
        img.color = defaultColor;
    }
}
