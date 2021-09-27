using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAppearance : MonoBehaviour
{

    public CharacterData characterData;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Sprite newSprite = Sprite.Create(InitializePalette(characterData.walk.spriteCoords[0].x, characterData.walk.spriteCoords[0].y),new Rect(0, 0, 8, 8), new Vector2(0.5f, 0.5f), 8);
        spriteRenderer.sprite = newSprite;
    }

    private Texture2D InitializePalette(int spriteX, int spriteY)
    {
        Texture2D texture = characterData.spriteSheet.texture;
        Color[] pixels = texture.GetPixels(spriteX, spriteY, 8, 8);
        
        return SwapPalette(pixels, characterData.spriteSheet.basePalette, characterData.characterPalette);
    }

    private Texture2D SwapPalette(Color[] sprite, PaletteData oldPalette, PaletteData newPalette)
    {
        Texture2D response = new Texture2D(8, 8)
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

        response.SetPixels(0, 0, 8, 8, sprite);
        response.Apply();
        return response;
    }

    public void StartWalk()
    {
        
    }

    public void StartJump()
    {
        StartCoroutine(Jump(new WaitForSeconds(characterData.jump.durationInSeconds / (float)characterData.jump.spriteCoords.Length)));
    }

    public void StopJump()
    {
        StopCoroutine("Jump");
    }

    public void PlayAttack()
    {
        
    }

    IEnumerator Walk(WaitForSeconds delay)
    {
        
        yield return delay;
        StartCoroutine(Walk(delay));
    }

    private IEnumerator Jump(WaitForSeconds delay)
    {
        Sprite newSprite;
        for (int i = 0; i < characterData.jump.spriteCoords.Length; i++) {
            newSprite = Sprite.Create(InitializePalette(characterData.jump.spriteCoords[i].x, characterData.jump.spriteCoords[1].y - characterData.characterSpriteOffset), new Rect(0, 0, 8, 8), new Vector2(0.5f, 0.5f), 8);
            spriteRenderer.sprite = newSprite;
            yield return delay;
        }

        StartCoroutine(Jump(delay));
    }
    
    


}
