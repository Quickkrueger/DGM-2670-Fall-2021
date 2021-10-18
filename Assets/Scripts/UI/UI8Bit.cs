using UnityEngine;
using UnityEngine.UI;

public class UI8Bit : MonoBehaviour
{
    public PaletteData basePalette;
    public PaletteData UIPalette;

    Image UIImage;

    private void Start()
    {
        UIImage = GetComponent<Image>();
        UIImage.sprite = Sprite.Create(InitializeUIElement(), new Rect(0, 0, UIImage.sprite.rect.width, UIImage.sprite.rect.height), new Vector2(0.5f, 0.5f), 10, 0, SpriteMeshType.FullRect, new Vector4(2f, 2f, 2f, 2f) );
        UIImage.pixelsPerUnitMultiplier = 0.1f;
    }

    Texture2D InitializeUIElement()
    {
        Texture2D texture = UIImage.sprite.texture;
        Color[] pixels = texture.GetPixels((int)UIImage.sprite.rect.x, (int)UIImage.sprite.rect.y, (int)UIImage.sprite.rect.width, (int)UIImage.sprite.rect.height);

        return PaletteSwapper.SwapPalette(pixels, basePalette, UIPalette, (int)UIImage.sprite.rect.x, (int)UIImage.sprite.rect.y, (int)UIImage.sprite.rect.width, (int)UIImage.sprite.rect.height);
    }



}
