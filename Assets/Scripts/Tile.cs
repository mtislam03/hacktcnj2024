using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public delegate void ClickAction(Tile tile);
    public event ClickAction OnClick;

    public void OnClickInt()
    {
        OnClick(this);
    }
}
