using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderUpdater : MonoBehaviour
{
    public Slider slider;
    // Start is called before the first frame update

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    public void LoadValue()
    {
        if (PlayerPrefs.HasKey("volume"))
        {
            slider.value = PlayerPrefs.GetFloat("volume");
        }
        else
        {
            slider.value = 1f;
        }
        slider.onValueChanged.Invoke(slider.value);
    }

    public void SaveValue()
    {
        PlayerPrefs.SetFloat("volume", slider.value);
    }

}
