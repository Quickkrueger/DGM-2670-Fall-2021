using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PaletteCollection", menuName = "ScriptableObjects/Sprite/PaletteCollection", order = 1)]
public class PaletteCollection : ScriptableObject
{
    public List<PaletteData> palettes;
}
