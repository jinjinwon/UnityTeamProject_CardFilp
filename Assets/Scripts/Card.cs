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
    // 이미 열려있으면 아무것도 하지 않음
    if (GameManager.Instance.secondCard != null)
    {
        // 현재 열린 두 장을 닫고 새로운 카드부터 다시 시작
        GameManager.Instance.firstCard.CloseCard();
        GameManager.Instance.secondCard.CloseCard();

        GameManager.Instance.firstCard = null;
        GameManager.Instance.secondCard = null;
    }

    audioSource.PlayOneShot(clip);
    anim.SetBool("isOpen", true);
    front.SetActive(true);
    back.SetActive(false);

        // 첫 번째 카드가 비었으면 나 자신을 첫 번째 카드로 설정
        if (GameManager.Instance.firstCard == null)
        {
            GameManager.Instance.firstCard = this;
        }
        // 첫 번째 카드가 이미 있으면 나 자신을 두 번째 카드로 설정 후 매칭 체크
        else if (GameManager.Instance.secondCard == null)
        {
            GameManager.Instance.secondCard = this;
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
        Invoke("CloseCardInvoke", 1.0f);
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
