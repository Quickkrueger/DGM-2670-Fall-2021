using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickerInitializer : MonoBehaviour
{
    private PaletteData paletteData;
    public void SetupColors(UI8Bit UIData)
    {
        paletteData = UIData.UIPalette;
        ColorPreview[] colors = GetComponentsInChildren<ColorPreview>();
        for (int i = 0; i < 3; i++)
        {
            colors[i].InitializeColor(paletteData.GetColor(i));
        }
    }

    public void SaveColors()
    {
        ColorPreview[] colors = GetComponentsInChildren<ColorPreview>();
        for (int i = 0; i < 3; i++)
        {
            paletteData.SetColor(i, colors[i].GetColor());
        }
    }
}
