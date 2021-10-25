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
        GameObject nextPalette;

        nextPalette = transform.GetChild(0).gameObject;

        nextPalette.GetComponent<UI8Bit>().UIPalette = allPalettes.palettes[0];
        nextPalette.GetComponent<UI8Bit>().FillColors();
        
        for (int i = 1; i < allPalettes.palettes.Count; i++)
        {

            nextPalette = Instantiate(paletteObjectPrefab, transform);

            nextPalette.GetComponent<UI8Bit>().UIPalette = allPalettes.palettes[i];
            nextPalette.GetComponent<UI8Bit>().FillColors();
        }
    }
}
