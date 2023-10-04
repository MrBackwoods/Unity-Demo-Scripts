using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Simple functionality for handling game volume via slider
public class VolumeSlider : MonoBehaviour
{
    Slider slider;

    void Start() 
    {
        slider = GetComponent<Slider>();
        slider.value = AppManager.GetVolume();
        slider.onValueChanged.AddListener (delegate {SetVolumeOnSliderChange ();});
    }

    void SetVolumeOnSliderChange()
    {
        AppManager.SetVolume(slider.value);
    }
}
