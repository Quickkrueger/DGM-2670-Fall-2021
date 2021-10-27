using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalettePopulator : MonoBehaviour
{
    public PaletteCollection allPalettes;
    public GameObject paletteObjectPrefab;
    void Start()
    {
        InitializePalettes();
    }

    void InitializePalettes()
    {
        List<GameObject> nextPalette;
        nextPalette = new List<GameObject>();

        nextPalette.Add(transform.GetChild(0).gameObject);
        
        for (int i = 1; i < allPalettes.palettes.Count; i++)
        {
            nextPalette.Add(Instantiate(paletteObjectPrefab, transform));
        }


        for(int i = 0; i < nextPalette.Count; i++)
        {
            UI8Bit ui = nextPalette[i].GetComponent<UI8Bit>();
            ui.UIPalette.OnColorChanged -= ui.ColorChanged;
            ui.UIPalette = allPalettes.palettes[i];
            ui.UIPalette.OnColorChanged += ui.ColorChanged;
            ui.FillColors();
        }
    }
}
