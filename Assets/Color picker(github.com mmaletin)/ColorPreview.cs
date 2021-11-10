/*MIT License

Copyright (c) 2019 Max Maletin

Permission is hereby granted, free of charge, to any person obtaining a copy
    of this software and associated documentation files (the "Software"), to deal
    in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
    furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
    copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.*/
    
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
        yield return new WaitForSecondsRealtime(0.1f);
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
        yield return new WaitForSecondsRealtime(0.1f);
        OnClickDelayed.Invoke();
    }
}