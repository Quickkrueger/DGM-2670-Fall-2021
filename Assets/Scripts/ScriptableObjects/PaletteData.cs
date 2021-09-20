using UnityEngine;

[CreateAssetMenu(fileName = "PaletteData", menuName = "ScriptableObjects/SpriteInfo/PaletteData", order = 1)]
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

    public Color GetColor(int index)
    {
        if (index == 0)
        {
            return primaryColor;
        }
        else if (index == 1)
        {
            return secondaryColor;
        }
        else if (index == 2)
        {
            return accentColor;
        }
        else
        {
            return backgroundColor;
        }
    }
}
