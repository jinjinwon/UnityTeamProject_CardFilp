using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Board : MonoBehaviour
{
    public Transform cards;
    public GameObject card;

    
    private void Start()
    {

        int[] arr = { 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, -1 }; // -1 == Bomb
        arr = arr.OrderBy(x => Random.Range(1f, 7f)).ToArray();

        //GameManager.Instance.cardCount = arr.Length;


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
            tempCard.StartCoroutine(tempCard.StartLookDelay1());
        }

    }

}
