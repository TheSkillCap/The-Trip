using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct KeysConstructor 
{
    private Sprite sprite;
    private char doorColor;

    public KeysConstructor(Sprite sprite, char doorColor)
    {
        this.sprite = sprite;
        this.doorColor = doorColor;
    }

    public Sprite Sprite { get => sprite; set => sprite = value; }
    public char DoorColor { get => doorColor; set => doorColor = value; }
}
