
using UnityEngine;
using UnityEngine.UI;

public class Button8Bit : Button
{
    public PaletteData basePalette;
    public PaletteData UIPalette;

    Image UIImage;
    Text UIText;

    public void Initialize(PaletteData basePal, PaletteData UIPal)
    {
        basePalette = basePal;
        UIPalette = UIPal;
        
        UIText = GetComponentInChildren<Text>();
        UIImage = GetComponent<Image>();
        UIImage.sprite = Sprite.Create(InitializeUIElement(UIImage.sprite), new Rect(0, 0, UIImage.sprite.rect.width, UIImage.sprite.rect.height), new Vector2(0.5f, 0.5f), 10, 0, SpriteMeshType.FullRect, new Vector4(2f, 2f, 2f, 2f) );

        SpriteState ss = spriteState;
        ss.highlightedSprite = Sprite.Create(InitializeUIElement(ss.highlightedSprite), new Rect(0, 0, ss.highlightedSprite.rect.width, ss.highlightedSprite.rect.height), new Vector2(0.5f, 0.5f), 10, 0, SpriteMeshType.FullRect, new Vector4(2f, 2f, 2f, 2f) );
        ss.disabledSprite = Sprite.Create(InitializeUIElement(ss.disabledSprite), new Rect(0, 0, ss.disabledSprite.rect.width, ss.disabledSprite.rect.height), new Vector2(0.5f, 0.5f), 10, 0, SpriteMeshType.FullRect, new Vector4(2f, 2f, 2f, 2f) );
        ss.pressedSprite = Sprite.Create(InitializeUIElement(ss.pressedSprite), new Rect(0, 0, ss.pressedSprite.rect.width, ss.pressedSprite.rect.height), new Vector2(0.5f, 0.5f), 10, 0, SpriteMeshType.FullRect, new Vector4(2f, 2f, 2f, 2f) );
        ss.selectedSprite = Sprite.Create(InitializeUIElement(ss.selectedSprite), new Rect(0, 0, ss.selectedSprite.rect.width, ss.selectedSprite.rect.height), new Vector2(0.5f, 0.5f), 10, 0, SpriteMeshType.FullRect, new Vector4(2f, 2f, 2f, 2f) );

        spriteState = ss;
        UIText.color = UIPalette.accentColor;
    }

    Texture2D InitializeUIElement(Sprite spriteToChange)
    {
        Texture2D texture = spriteToChange.texture;
        Color[] pixels = texture.GetPixels((int)spriteToChange.rect.x, (int)spriteToChange.rect.y, (int)spriteToChange.rect.width, (int)spriteToChange.rect.height);
        
        return PaletteSwapper.SwapPalette(pixels, basePalette, UIPalette, (int)spriteToChange.rect.x, (int)spriteToChange.rect.y, (int)spriteToChange.rect.width, (int)spriteToChange.rect.height);
    }

    
}


