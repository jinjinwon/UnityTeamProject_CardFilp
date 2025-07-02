using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class Board : MonoBehaviour
{
    public Transform cards;
    public GameObject card;

    //public Stage stage;


    private void Start()
    {
        Stage stage = StageManager.Instance.GetCurrentStage();

        int[] arr = stage.cardCount;

        if(stage.level <= 1)
        {
            arr = arr.OrderBy(x => UnityEngine.Random.Range(0f, 5f)).ToArray();

            for (int i = 0; i < arr.Length; i++)
            {
                GameObject go = Instantiate(card, this.transform);
                go.transform.parent = cards;

                float x = (i % 3) * 1.4f - 1.4f;
                float y = (i / 3) * 1.6f - 1.6f;

                go.transform.position = new Vector2(0, 0);

                Card tempCard = go.GetComponent<Card>();
                tempCard.Setting(arr[i]);

                tempCard.GetComponent<CardMover>().Show(new Vector2(x, y), tempCard, i);
                //레벨1,3은 3초공개 레벨2,4는 2초공개 정상작동
                if (stage.level == 0 || stage.level == 2)
                {
                    tempCard.StartCoroutine(tempCard.StartLookDelay1());
                }
                else
                {
                    tempCard.StartCoroutine(tempCard.StartLookDelay2());
                }
            }
        }
        else if (stage.level > 1)
        {
            arr = arr.OrderBy(x => UnityEngine.Random.Range(0f, 7f)).ToArray();

            for (int i = 0; i < arr.Length; i++)
            {
                GameObject go = Instantiate(card, this.transform);
                go.transform.parent = cards;
                float x = (i % 4) * 1.4f - 2.1f;
                float y = (i / 4) * 1.6f - 3.0f;

                go.transform.position = new Vector2(0, 0);

                Card tempCard = go.GetComponent<Card>();
                tempCard.Setting(arr[i]);
                tempCard.GetComponent<CardMover>().Show(new Vector2(x, y), tempCard, i);
                //1스테이지 제외 2초보여주기 코루틴 정상작동
                if (stage.level == 2)
                {
                    tempCard.StartCoroutine(tempCard.StartLookDelay1());
                }
                else
                {
                    tempCard.StartCoroutine(tempCard.StartLookDelay2());
                }
            }
        }
    }
        //GameManager.Instance.cardCount = arr.Length;
}
