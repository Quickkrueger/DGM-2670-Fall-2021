using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "ScriptableObjects/EntityData/CharacterData", order = 1)]
public class CharacterData : ScriptableObject
{
    public TextureData spriteSheet;
    public int characterSpriteOffset = 0;
    public AnimationData[] animations;
    public PaletteData characterPalette;
}
