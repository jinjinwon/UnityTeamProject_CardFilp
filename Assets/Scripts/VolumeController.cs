using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    [SerializeField] private AudioMixer myaudioMixer;
    public void SetVolume(float slidervalue)
    {

        myaudioMixer.SetFloat("MyExposedParam", Mathf.Log10(slidervalue) * 20);
    }
    public void SetVolumeSFX(float slidervalue)
    {
        myaudioMixer.SetFloat("MyExposedParam1", Mathf.Log10(slidervalue) * 20);

    }
    

   

}  