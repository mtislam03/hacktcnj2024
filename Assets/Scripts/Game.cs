using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Game : MonoBehaviour
{
    private bool revealed;
    private bool active;

    public bool Revealed
    {
        get => revealed;
    }

    public bool Inactive
    {
        get => !active;
    }

    private void Start()
    {
        revealed = false;
        active = false;
    }

    public void Activate()
    {
        active = true;
        revealed = true;
    }

    public void Deactivate()
    {
        active = false;
    }

    // abstract methods
    public abstract bool TakeInput(Event e);
    public abstract bool DidWin();
    public abstract string GetPreview();
    public abstract string GetName();
}
