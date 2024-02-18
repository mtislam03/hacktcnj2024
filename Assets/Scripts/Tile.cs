using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tile : MonoBehaviour
{
    public delegate void ClickAction(Tile tile);
    public event ClickAction OnClick;

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
}
