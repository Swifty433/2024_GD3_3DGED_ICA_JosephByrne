using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;

    private void Start()
    {
        float savedVolume = AudioManager.instance.GetMusicVolume();
        volumeSlider.value = savedVolume;

        volumeSlider.onValueChanged.AddListener(UpdateVolume);
    }

    private void UpdateVolume(float value)
    {
        AudioManager.instance.SetMusicVolume(value);
    }
}
