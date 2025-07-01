using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;


    AudioSource audioSource;
    public AudioClip clip;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            //이걸통해 오디오매니저 게임오브젝트가 파괴되지 않음
        }
        else
        {
            Destroy(gameObject);
            //이거 없으면 브금 2개 나옴
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = this.clip;
        audioSource.Play();

    }
}
