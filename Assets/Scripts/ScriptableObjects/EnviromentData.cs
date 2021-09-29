using UnityEngine;

[CreateAssetMenu(fileName = "EnviromentData", menuName = "ScriptableObjects/Environment/EnviromentData", order = 1)]
public class EnviromentData : ScriptableObject
{
    public TileData[] groundTiles;
    public TileData[] undergroundTiles;
    public TileData[] decorationTiles;
}
