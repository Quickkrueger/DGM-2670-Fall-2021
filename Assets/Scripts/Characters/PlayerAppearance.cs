using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAppearance : MonoBehaviour
{

    public CharacterData characterData;
    private SpriteRenderer spriteRenderer;

    Coroutine walkRoutine;
    Coroutine jumpRoutine;
    Coroutine attackRoutine;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        Stand();
    }

    private Texture2D InitializePalette(int spriteX, int spriteY)
    {
        Texture2D texture = characterData.spriteSheet.texture;
        Color[] pixels = texture.GetPixels(spriteX, spriteY - characterData.characterSpriteOffset, 8, 8);
        
        return PaletteSwapper.SwapPalette(pixels, characterData.spriteSheet.basePalette, characterData.characterPalette);
    }

    private void Stand()
    {
        Sprite newSprite = Sprite.Create(InitializePalette(characterData.walk.spriteCoords[0].x, characterData.walk.spriteCoords[0].y), new Rect(0, 0, 8, 8), new Vector2(0.5f, 0.5f), 8);
        spriteRenderer.sprite = newSprite;
    }

    public void StartWalk()
    {
        walkRoutine = StartCoroutine(Walk(new WaitForSeconds(characterData.walk.durationInSeconds / (float)characterData.walk.spriteCoords.Length)));
    }

    public void StopWalk()
    {
        if (walkRoutine != null)
        {
            StopCoroutine(walkRoutine);
        }
    }

    public void StartJump()
    {
        StopWalk();
        jumpRoutine = StartCoroutine(Jump(new WaitForSeconds(characterData.jump.durationInSeconds / (float)characterData.jump.spriteCoords.Length)));
    }

    public void StopJump()
    {
        if (jumpRoutine != null)
        {
            StopCoroutine(jumpRoutine);
        }

        StartWalk();
    }

    public void PlayAttack()
    {
        if (attackRoutine == null)
        {
            attackRoutine = StartCoroutine(Attack(new WaitForSeconds(characterData.attack.durationInSeconds / (float)characterData.attack.spriteCoords.Length)));
        }
    }

    IEnumerator Attack(WaitForSeconds delay)
    {
        Sprite newSprite;
        for (int i = 0; i < characterData.attack.spriteCoords.Length; i++)
        {
            newSprite = Sprite.Create(InitializePalette(characterData.attack.spriteCoords[i].x, characterData.attack.spriteCoords[1].y), new Rect(0, 0, 8, 8), new Vector2(0.5f, 0.5f), 8);
            spriteRenderer.sprite = newSprite;
            yield return delay;
        }

        attackRoutine = null;
    }

    IEnumerator Walk(WaitForSeconds delay)
    {

        Sprite newSprite;
        for (int i = 0; i < characterData.walk.spriteCoords.Length; i++)
        {
            newSprite = Sprite.Create(InitializePalette(characterData.walk.spriteCoords[i].x, characterData.walk.spriteCoords[1].y), new Rect(0, 0, 8, 8), new Vector2(0.5f, 0.5f), 8);
            spriteRenderer.sprite = newSprite;
            yield return delay;
        }

        walkRoutine = StartCoroutine(Walk(delay));
    }

    private IEnumerator Jump(WaitForSeconds delay)
    {
        Sprite newSprite;
        for (int i = 0; i < characterData.jump.spriteCoords.Length; i++) {
            newSprite = Sprite.Create(InitializePalette(characterData.jump.spriteCoords[i].x, characterData.jump.spriteCoords[1].y), new Rect(0, 0, 8, 8), new Vector2(0.5f, 0.5f), 8);
            spriteRenderer.sprite = newSprite;
            yield return delay;
        }

        jumpRoutine = StartCoroutine(Jump(delay));
    }
    
    


}
