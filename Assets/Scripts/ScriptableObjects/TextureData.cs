using UnityEngine;

[CreateAssetMenu(fileName = "TextureData", menuName = "ScriptableObjects/SpriteInfo/TextureData", order = 1)]
public class TextureData : ScriptableObject
{
    public PaletteData basePalette;
    public Texture2D texture;

}
