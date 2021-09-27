using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "ScriptableObjects/Entity/CharacterData", order = 1)]
public class CharacterData : CollectableSO
{
    public TextureData spriteSheet;
    public int characterSpriteOffset = 0;
    public AnimationData walk;
    public AnimationData jump;
    public AnimationData attack;
    public PaletteData characterPalette;
}
