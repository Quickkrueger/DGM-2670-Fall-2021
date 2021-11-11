using UnityEngine;

[CreateAssetMenu(fileName = "PaletteData", menuName = "ScriptableObjects/Sprite/PaletteData", order = 1)]
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

    public void SetColor(int index, Color newColor)
    {
        if (index == 0)
        {
            primaryColor = newColor;
        }
        else if (index == 1)
        {
            secondaryColor = newColor;
        }
        else if (index == 2)
        {
            accentColor = newColor;
        }
        else
        {
            backgroundColor = newColor;
        }

        OnColorChanged();
    }

    public void SavePalette()
    {
        PlayerPrefs.SetString(this.name + "_primary", "#" + ColorUtility.ToHtmlStringRGBA(primaryColor));
        PlayerPrefs.SetString(this.name + "_secondary", "#" + ColorUtility.ToHtmlStringRGBA(secondaryColor));
        PlayerPrefs.SetString(this.name + "_accent", "#" + ColorUtility.ToHtmlStringRGBA(accentColor));
        PlayerPrefs.Save();
    }

    public void LoadPalette()
    {
        if (PlayerPrefs.HasKey(this.name + "_primary"))
        {
            ColorUtility.TryParseHtmlString(PlayerPrefs.GetString(this.name + "_primary"), out primaryColor);
        }

        if (PlayerPrefs.HasKey(this.name + "_secondary"))
        {
            ColorUtility.TryParseHtmlString(PlayerPrefs.GetString(this.name + "_secondary"), out secondaryColor);
        }

        if (PlayerPrefs.HasKey(this.name + "_accent"))
        {
            ColorUtility.TryParseHtmlString(PlayerPrefs.GetString(this.name + "_accent"), out accentColor);
        }
    }

    public delegate void OnColorChangedDelegate();
    public event OnColorChangedDelegate OnColorChanged;
}
