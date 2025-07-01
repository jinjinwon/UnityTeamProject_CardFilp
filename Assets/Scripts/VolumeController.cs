using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    
    public AudioMixer mixer;
    public string exposedParam = "MyExposedParam"; // 정확한 노출 이름
    public Slider slider;

    void Start()
    {
        slider.onValueChanged.AddListener(SetVolume);
    }

    void SetVolume(float value)
    {
        // 0~1 범위를 dB 값으로 변환
        float dB = Mathf.Log10(Mathf.Clamp(value, 0.0001f, 1)) * 20;
        mixer.SetFloat(exposedParam, dB);
    }





}  