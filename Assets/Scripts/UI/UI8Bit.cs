using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UI8Bit : MonoBehaviour
{
    public PaletteData basePalette;
    public PaletteData UIPalette;
    Sprite imageStorage;

    Image UIImage;

    private void Awake()
    {
        UIImage = GetComponent<Image>();
        imageStorage = UIImage.sprite;
        FillColors();
        UIPalette.OnColorChanged += ColorChanged;
    }

    Texture2D InitializeUIElement(PaletteData oldPalette, PaletteData newPalette)
    {
        Texture2D texture = imageStorage.texture;
        Color[] pixels = texture.GetPixels((int)imageStorage.rect.x, (int)imageStorage.rect.y, (int)imageStorage.rect.width, (int)imageStorage.rect.height);

        return PaletteSwapper.SwapPalette(pixels, oldPalette, newPalette, (int)imageStorage.rect.x, (int)imageStorage.rect.y, (int)imageStorage.rect.width, (int)imageStorage.rect.height);
    }

    public void FillColors()
    {
        
        UIImage.sprite = Sprite.Create(InitializeUIElement(basePalette, UIPalette), new Rect(0, 0, imageStorage.rect.width, imageStorage.rect.height), new Vector2(0.5f, 0.5f), 10, 0, SpriteMeshType.FullRect, new Vector4(2f, 2f, 2f, 2f) );
        UIImage.pixelsPerUnitMultiplier = 0.1f;
    }
    
    public void FillColors(UI8Bit uiData)
    {
        UIPalette.OnColorChanged -= ColorChanged;
        UIPalette = uiData.UIPalette;
        UIPalette.OnColorChanged += ColorChanged;
        UIImage.sprite = Sprite.Create(InitializeUIElement(basePalette, UIPalette), new Rect(0, 0, imageStorage.rect.width, imageStorage.rect.height), new Vector2(0.5f, 0.5f), 10, 0, SpriteMeshType.FullRect, new Vector4(2f, 2f, 2f, 2f));
        UIImage.pixelsPerUnitMultiplier = 0.1f;
    }

    public void ColorChanged()
    {
        FillColors();
    }



}
