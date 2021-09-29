using UnityEngine;

public class EnvironmentTile : MonoBehaviour
{
    public TileData tileData;

    private SpriteRenderer spriteRenderer;

    private Collider2D tileCollider;
    // Start is called before the first frame update
    void Awake()
    {
        
        spriteRenderer = GetComponent<SpriteRenderer>();
        tileCollider = GetComponent<Collider2D>();
        
        CreateTile();
        
    }

    void CreateTile()
    {
        Sprite newSprite = Sprite.Create(InitializePalette(tileData.tileCoord.x, tileData.tileCoord.y), new Rect(0, 0, 8, 8), new Vector2(0.5f, 0.5f), 8);
        spriteRenderer.sprite = newSprite;
        
        
        if (tileData.type == TileType.Background)
        {
            spriteRenderer.sortingLayerName = "Background";
            tileCollider.enabled = false;
        }
        else if(tileData.type == TileType.Foreground)
        {
            spriteRenderer.sortingLayerName = "Foreground";
            gameObject.AddComponent<Ground>();
        }
        else if (tileData.type == TileType.Hazard)
        {
            spriteRenderer.sortingLayerName = "Foreground";
            tileCollider.isTrigger = true;
        }
    }

    public void UpdateTile(TileData newData)
    {
        tileData = newData;
        CreateTile();
    }
    
    private Texture2D InitializePalette(int spriteX, int spriteY)
    {
        Texture2D texture = tileData.tileSheet.texture;
        Color[] pixels = texture.GetPixels(spriteX, spriteY, 8, 8);
        
        return PaletteSwapper.SwapPalette(pixels, tileData.tileSheet.basePalette, tileData.tilePalette);
    }
}
