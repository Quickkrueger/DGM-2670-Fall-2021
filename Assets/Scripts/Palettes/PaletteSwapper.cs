using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaletteSwapper
{
    // Start is called before the first frame update
    public static Texture2D SwapPalette(Color[] sprite, PaletteData oldPalette, PaletteData newPalette, int x, int y, int width, int height)
    {
        Texture2D response = new Texture2D(width, height)
        {
            filterMode = FilterMode.Point,
            wrapMode = TextureWrapMode.Clamp
        };

        float colorDiff;

        for (int c = 0; c < sprite.Length; c++)
        {

            for (int i = 0; i < 4; i++)
            {
                colorDiff = new Vector4(
                    sprite[c].r - oldPalette.GetColor(i).r,
                    sprite[c].g - oldPalette.GetColor(i).g,
                    sprite[c].b - oldPalette.GetColor(i).b,
                    sprite[c].a - oldPalette.GetColor(i).a
                ).sqrMagnitude;

                //colorDiff = Mathf.Abs(pixels[c].grayscale - SelectPalette(0)[i].grayscale);

                if (colorDiff <= 4 * ((1f / 100f) * (1f / 100f)) && sprite[c].a != 0)
                {
                    sprite[c] = newPalette.GetColor(i);
                    i = 4;
                }
            }
        }

        response.SetPixels(0, 0,  width, height, sprite);
        response.Apply();
        return response;
    }
}
