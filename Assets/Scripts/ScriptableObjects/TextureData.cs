using UnityEngine;

[CreateAssetMenu(fileName = "TextureData", menuName = "ScriptableObjects/Sprite/TextureData", order = 1)]
public class TextureData : ScriptableObject
{
    public PaletteData basePalette;
    public Texture2D texture;

}
