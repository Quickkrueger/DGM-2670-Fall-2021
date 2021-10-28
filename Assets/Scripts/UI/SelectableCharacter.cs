using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SelectableCharacter : MonoBehaviour
{
    private CharacterData characterData;
    private Image characterImage;

    public void InitializeCharacter(CollectableSO data)
    {
        
        characterData = (CharacterData)data;

        characterData.characterPalette.OnColorChanged += ColorChanged;
        
        characterImage = GetComponent<Image>();

        FillColors();
        
    }

    private void FillColors()
    {
        characterImage.sprite = Sprite.Create(InitializeCharacterElement(characterData.walk.spriteCoords[0].x, characterData.walk.spriteCoords[0].y), new Rect(0, 0, 8, 8), new Vector2(0.5f, 0.5f), 10f);
    }
    
    private Texture2D InitializeCharacterElement(int spriteX, int spriteY)
    {
        Texture2D texture = characterData.spriteSheet.texture;
        Color[] pixels = texture.GetPixels(spriteX, spriteY - characterData.characterSpriteOffset, 8, 8);
        
        return PaletteSwapper.SwapPalette(pixels, characterData.spriteSheet.basePalette, characterData.characterPalette, 0, 0, 8, 8);
    }

    public void Clicked()
    {
        transform.parent.GetComponent<CharacterSelect>().NewSelectionMade(characterData);
    }

    void ColorChanged()
    {
        FillColors();
    }

    private void OnDestroy()
    {
        characterData.characterPalette.OnColorChanged -= ColorChanged;
    }


}
