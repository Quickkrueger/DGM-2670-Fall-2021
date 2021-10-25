
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ColorPreview : MonoBehaviour
{
    public Graphic previewGraphic;
    public ColorPicker colorPicker;
    public UnityEvent ColorChanged;
    public UnityEvent ColorChangedDelayed;
    public UnityEvent OnClickDelayed;

    private bool selecting = false;

    private void Start()
    {
        colorPicker.onColorChanged += OnColorChanged;
    }

    public void OnColorChanged(Color c)
    {
        if (selecting)
        {
            previewGraphic.color = c;
            ColorChanged.Invoke();
            StartCoroutine(OnColorChangedAsync());
        }
    }

    private IEnumerator OnColorChangedAsync()
    {
        yield return new WaitForSeconds(0.1f);
        ColorChangedDelayed.Invoke();
    }

    public Color GetColor()
    {
        return previewGraphic.color;
    }

    public void InitializeColor(Color c)
    {
        previewGraphic.color = c;
    }

    private void OnDestroy()
    {
        if (colorPicker != null)
            colorPicker.onColorChanged -= OnColorChanged;
    }

    public void Interacting()
    {
        selecting = true;
    }

    public void EndInteraction()
    {
        selecting = false;
    }

    public void OnClickDelay()
    {
        StartCoroutine(OnClickAsync());
    }

    public IEnumerator OnClickAsync()
    {
        yield return new WaitForSeconds(0.1f);
        OnClickDelayed.Invoke();
    }
}