using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAppearance : MonoBehaviour
{
    public PlayerConfigData playerData;
    private SpriteRenderer spriteRenderer;
    private SpriteRenderer childRenderer;

    Coroutine walkRoutine;
    Coroutine jumpRoutine;
    Coroutine attackRoutine;

    private void Start()
    {
        
        spriteRenderer = GetComponent<SpriteRenderer>();
        childRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();

        Stand();
    }
    
    private Texture2D InitializePalette(int spriteX, int spriteY)
    {
        Texture2D texture = playerData.visualData.spriteSheet.texture;
        Color[] pixels = texture.GetPixels(spriteX, spriteY - playerData.visualData.characterSpriteOffset, 8, 8);
        
        return PaletteSwapper.SwapPalette(pixels, playerData.visualData.spriteSheet.basePalette, playerData.visualData.characterPalette, 0, 0, 8, 8);
    }

    public void UpdateSprite()
    {
        Stand();
    }

    private void Stand()
    {
        Sprite newSprite = Sprite.Create(InitializePalette(playerData.visualData.walk.spriteCoords[0].x, playerData.visualData.walk.spriteCoords[0].y), new Rect(0, 0, 8, 8), new Vector2(0.5f, 0.5f), 10);
        spriteRenderer.sprite = newSprite;
    }

    public void StartWalk()
    {
        walkRoutine = StartCoroutine(Walk(new WaitForSeconds(playerData.visualData.walk.durationInSeconds / (float)playerData.visualData.walk.spriteCoords.Length)));
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
        jumpRoutine = StartCoroutine(Jump(new WaitForSeconds(playerData.visualData.jump.durationInSeconds / (float)playerData.visualData.jump.spriteCoords.Length)));
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
            attackRoutine = StartCoroutine(Attack(new WaitForSeconds(playerData.visualData.attack.durationInSeconds / (float)playerData.visualData.attack.spriteCoords.Length)));
        }
    }

    IEnumerator Attack(WaitForSeconds delay)
    {
        Sprite newSprite;
        for (int i = 0; i < playerData.visualData.attack.spriteCoords.Length; i++)
        {
            newSprite = Sprite.Create(InitializePalette(playerData.visualData.attack.spriteCoords[i].x, playerData.visualData.attack.spriteCoords[1].y), new Rect(0, 0, 8, 8), new Vector2(0.5f, 0.5f), 10);
            childRenderer.sprite = newSprite;
            yield return delay;
        }

        attackRoutine = null;
    }

    IEnumerator Walk(WaitForSeconds delay)
    {

        Sprite newSprite;
        for (int i = 0; i < playerData.visualData.walk.spriteCoords.Length; i++)
        {
            newSprite = Sprite.Create(InitializePalette(playerData.visualData.walk.spriteCoords[i].x, playerData.visualData.walk.spriteCoords[1].y), new Rect(0, 0, 8, 8), new Vector2(0.5f, 0.5f), 10);
            spriteRenderer.sprite = newSprite;
            yield return delay;
        }

        walkRoutine = StartCoroutine(Walk(delay));
    }

    private IEnumerator Jump(WaitForSeconds delay)
    {
        Sprite newSprite;
        for (int i = 0; i < playerData.visualData.jump.spriteCoords.Length; i++) {
            newSprite = Sprite.Create(InitializePalette(playerData.visualData.jump.spriteCoords[i].x, playerData.visualData.jump.spriteCoords[1].y), new Rect(0, 0, 8, 8), new Vector2(0.5f, 0.5f), 10);
            spriteRenderer.sprite = newSprite;
            yield return delay;
        }

        jumpRoutine = StartCoroutine(Jump(delay));
    }
    
    


}
