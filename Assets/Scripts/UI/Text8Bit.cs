using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Text8Bit : MonoBehaviour
{
    public PaletteData UIPalette;

    public Text text;
    // Start is called before the first frame update
    private void Awake()
    {
        text.color = UIPalette.accentColor;
        UIPalette.OnColorChanged += UpdateColor;
    }

    void UpdateColor()
    {
        text.color = UIPalette.accentColor;
    }
}
