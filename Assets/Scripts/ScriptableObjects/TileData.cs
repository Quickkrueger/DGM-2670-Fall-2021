using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TileData", menuName = "ScriptableObjects/Environment/TileData", order = 1)]
public class TileData : ScriptableObject
{
    public TextureData tileSheet;
    public Vector2Int tileCoord;
    public TileType type;
    public PaletteData tilePalette;
}

public enum TileType
{
    Background, Hazard, Foreground
}
