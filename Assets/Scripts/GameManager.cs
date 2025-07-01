using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;


public class GameManager : MonoBehaviour

{
    public static GameManager Instance;
    public Card firstCard;
    public Card secondCard;
    public GameObject failEndTxt;   //���� ������ �� UI
    public GameObject SuccEndTxt;   //���� ������ �� UI
    public Text timeTxt;
    public float time = 30.0f;
    AudioSource audioSource;
    public AudioClip clip;
    public AudioClip alarm;
    public int cardCount = 0;
    public Stage stage;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        Time.timeScale = 1.0f;
        audioSource = GetComponent<AudioSource>();
        stage = StageManager.Instance.GetCurrentStage();

        // ���� ó��
        if (stage != null)
            time = stage.time;
        else
            time = 30.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(cardCount != 0) { time -= Time.deltaTime; }
        timeTxt.text = time.ToString("N2");
        if (time <= 0.0f)
        {
            Time.timeScale = 0.0f;
            failEndTxt.SetActive(true);
        }
        if (time > 25f)
        {
            PlayAlarm();
        }
    }

    private void PlayAlarm()
    {
        audioSource.clip = alarm;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void Matched()
    {
        if (firstCard.idx == secondCard.idx)
        {
            audioSource.PlayOneShot(clip);
            firstCard.DestroyCard();
            secondCard.DestroyCard();
            cardCount -= 2;
            if (cardCount == 0)
            {
                //Time.timeScale = 0.0f;    0���� ����� ���� ��ƼŬ�� �ȳ��ͼ� �ּ���
                SuccEndTxt.SetActive(true);
            }
        }
        else
        {
            firstCard.CloseCard();
            secondCard.CloseCard();
        }
        firstCard = null;
        secondCard = null;


    }
}
