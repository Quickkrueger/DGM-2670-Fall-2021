using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaletteData : ScriptableObject
{
    public Color primaryColor;
    public Color secondaryColor;
    public Color accentColor;
    public Color backgroundColor;

    public void ChangePrimaryColor(Color newColor)
    {
        primaryColor = newColor;
    }
    public void ChangeSecondaryColor(Color newColor)
    {
        secondaryColor = newColor;
    }
    public void ChangeAccentColor(Color newColor)
    {
        accentColor = newColor;
    }
    public void ChangeBackgroundColor(Color newColor)
    {
        backgroundColor = newColor;
    }
}
