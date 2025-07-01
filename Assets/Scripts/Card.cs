using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public int idx = 0;

    public GameObject front;
    public GameObject back;

    public Animator anim;

    AudioSource audioSource;
    public AudioClip clip;

    public SpriteRenderer frontImage;

    public Vector2 fixedSize = new Vector2(1f, 1f);


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Setting(int number)
    {
        idx = number;
        frontImage.sprite = Resources.Load<Sprite>($"Team_{idx}");

        if (frontImage.sprite != null)
        {
            frontImage.transform.localScale = Vector3.one;

            float spriteWidth = frontImage.sprite.bounds.size.x;
            float spriteHeight = frontImage.sprite.bounds.size.y;

            float targetWidth = 0.8f;
            float targetHeight = 1f;

            float scaleX = targetWidth / spriteWidth;
            float scaleY = targetHeight / spriteHeight;

            frontImage.transform.localScale = new Vector3(scaleX, scaleY, 1f);
        }
    }


    public void OpenCard()
    {
        // �̹� ���������� �ƹ��͵� ���� ����
        if (GameManager.Instance.secondCard != null)
        {
            // ���� ���� �� ���� �ݰ� ���ο� ī����� �ٽ� ����
            GameManager.Instance.firstCard.CloseCard();
            GameManager.Instance.secondCard.CloseCard();

            GameManager.Instance.firstCard = null;
            GameManager.Instance.secondCard = null;
        }

        audioSource.PlayOneShot(clip);
        anim.SetBool("isOpen", true);
        front.SetActive(true);
        back.SetActive(false);

<<<<<<< HEAD
        //first가 비었다면
        if (GameManager.Instance.firstCard == null)
        {
            //firstCard에 내 정보를 넘겨준다
            GameManager.Instance.firstCard = this;
        }
        //firstCard가 비어있지 않다면.
        else
        {
            //secondCard에 내 정보를 넘겨준다
            GameManager.Instance.secondCard = this;
            //Mached 함수를 호출
=======
        // ù ��° ī�尡 ������� �� �ڽ��� ù ��° ī��� ����
        if (GameManager.Instance.firstCard == null)
        {
            GameManager.Instance.firstCard = this;
        }
        // ù ��° ī�尡 �̹� ������ �� �ڽ��� �� ��° ī��� ���� �� ��Ī üũ
        else if (GameManager.Instance.secondCard == null)
        {
            GameManager.Instance.secondCard = this;
>>>>>>> e5998102678c50e9d942553bd4dbdf50a4d8adb0
            GameManager.Instance.Matched();
        }
    }


    public void DestroyCard()
    {
        Invoke("DestroyCardInvoke", 1.0f);
    }
    void DestroyCardInvoke()
    {
        Destroy(gameObject);
    }
    public void CloseCard()
    {
        Invoke("CloseCardInvoke", 0.5f);
        //Invoke("CloseCardInvoke2", 1.0f);
    }
    void CloseCardInvoke()
    {
        anim.SetBool("isOpen", false);
        //anim.SetBool("isClose", true);
        front.SetActive(false);
        back.SetActive(true);
        Invoke("CloseCardInvoke2", 1.0f);
    }
    void CloseCardInvoke2()
    {
        anim.SetBool("isClose", false);
    }
    
}