
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class Button8Bit : MonoBehaviour
{
    public PaletteData basePalette;
    public PaletteData UIPalette;
    Sprite imageStorage;
    SpriteState stateStorage;

    Image UIImage;
    Text UIText;

    protected void Awake()
    {

        UIText = GetComponentInChildren<Text>();
        UIImage = GetComponent<Image>();
        imageStorage = UIImage.sprite;
        stateStorage = GetComponent<Button>().spriteState;

        UIPalette.OnColorChanged += ColorChanged;

        Initialize();
    }

    public void Initialize()
    {        
        
        UIImage.sprite = Sprite.Create(InitializeUIElement(imageStorage), new Rect(0, 0, imageStorage.rect.width, imageStorage.rect.height), new Vector2(0.5f, 0.5f), 10, 0, SpriteMeshType.FullRect, new Vector4(2f, 2f, 2f, 2f) );

        SpriteState ss = stateStorage;
        ss.highlightedSprite = Sprite.Create(InitializeUIElement(stateStorage.highlightedSprite), new Rect(0, 0, stateStorage.highlightedSprite.rect.width, stateStorage.highlightedSprite.rect.height), new Vector2(0.5f, 0.5f), 10, 0, SpriteMeshType.FullRect, new Vector4(2f, 2f, 2f, 2f) );
        ss.disabledSprite = Sprite.Create(InitializeUIElement(stateStorage.disabledSprite), new Rect(0, 0, stateStorage.disabledSprite.rect.width, stateStorage.disabledSprite.rect.height), new Vector2(0.5f, 0.5f), 10, 0, SpriteMeshType.FullRect, new Vector4(2f, 2f, 2f, 2f) );
        ss.pressedSprite = Sprite.Create(InitializeUIElement(stateStorage.pressedSprite), new Rect(0, 0, stateStorage.pressedSprite.rect.width, stateStorage.pressedSprite.rect.height), new Vector2(0.5f, 0.5f), 10, 0, SpriteMeshType.FullRect, new Vector4(2f, 2f, 2f, 2f) );
        ss.selectedSprite = Sprite.Create(InitializeUIElement(stateStorage.selectedSprite), new Rect(0, 0, stateStorage.selectedSprite.rect.width, stateStorage.selectedSprite.rect.height), new Vector2(0.5f, 0.5f), 10, 0, SpriteMeshType.FullRect, new Vector4(2f, 2f, 2f, 2f) );

        GetComponent<Button>().spriteState = ss;
        UIText.color = UIPalette.accentColor;
    }

    Texture2D InitializeUIElement(Sprite spriteToChange)
    {
        Texture2D texture = spriteToChange.texture;
        Color[] pixels = texture.GetPixels((int)spriteToChange.rect.x, (int)spriteToChange.rect.y, (int)spriteToChange.rect.width, (int)spriteToChange.rect.height);
        
        return PaletteSwapper.SwapPalette(pixels, basePalette, UIPalette, (int)spriteToChange.rect.x, (int)spriteToChange.rect.y, (int)spriteToChange.rect.width, (int)spriteToChange.rect.height);
    }

    void ColorChanged()
    {
        Initialize();
    }

    private void OnDestroy()
    {
        UIPalette.OnColorChanged -= ColorChanged;
    }


}


