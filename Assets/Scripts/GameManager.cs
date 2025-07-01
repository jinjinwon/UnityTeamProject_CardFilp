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
    public AudioClip complete;

    public AlarmAnim alarmAnim;
    private bool bAlarm = false;

    public void Awake()
    {
        if (Instance == null)
            Instance = this;
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
            StopAlarm();
        }

        if (time < 5f && !bAlarm)
        {
            bAlarm = true;
            PlayAlarm();
        }
    }

    private void PlayAlarm()
    {
        audioSource.clip = alarm;
        audioSource.loop = true;
        audioSource.Play();

        alarmAnim.AlarmStart();
    }

    private void StopAlarm()
    {
        audioSource.Stop();
        alarmAnim.AlarmStop();
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
                //Time.timeScale = 0.0f;   
                SuccEndTxt.SetActive(true);
                audioSource.PlayOneShot(complete);
                StopAlarm();
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
    public void ReduceTimeByBomb()
    {
        time -= 5.0f;
        if (time < 0f) time = 0f;
    }
}
