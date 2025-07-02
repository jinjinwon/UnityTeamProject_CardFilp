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
    public AudioClip bombSoundClip;

    public SpriteRenderer frontImage;

    public Vector2 fixedSize = new Vector2(1f, 1f);

    public static bool canClick = true;

    public GameObject bombPrefab;


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
        if (GameManager.Instance.isMatching)
            return;

        //if (!canClick) return; // 클릭 잠금 시 무시

        // 애니메이션 중엔 클릭 금지
        //canClick = false;

        if (GameManager.Instance.secondCard != null)
        {
            GameManager.Instance.firstCard.CloseCard();
            GameManager.Instance.secondCard.CloseCard();

            GameManager.Instance.firstCard = null;
            GameManager.Instance.secondCard = null;
        }

        audioSource.PlayOneShot(clip);
        anim.SetBool("isOpen", true);
        front.SetActive(true);
        back.SetActive(false);

        if (idx == 0)
        {
            GameObject bomb = Instantiate(bombPrefab);
            audioSource.PlayOneShot(bombSoundClip);
            GameManager.Instance.ReduceTimeByBomb();
            CloseCard();
            DestroyCard();
            Destroy(bomb, 2f);
        }


        if (GameManager.Instance.firstCard == null)
        {
            GameManager.Instance.firstCard = this;
        }
        else if (GameManager.Instance.secondCard == null)
        {
            GameManager.Instance.secondCard = this;
            GameManager.Instance.Matched();
        }

        // 애니메이션 끝나고 다시 클릭 가능하도록 타이머 설정
        Invoke(nameof(EnableClick), 0.5f); // 애니메이션 길이에 따라 조절
    }
    void EnableClick()
    {
        canClick = true;
    }


    public void DestroyCard()
    {
        Invoke("DestroyCardInvoke", 1.0f);
    }
    void DestroyCardInvoke()
    {
        GameManager.Instance.isMatching = false;
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
        Invoke("CloseCardInvoke2", 0.2f);
    }
    void CloseCardInvoke2()
    {
        GameManager.Instance.isMatching = false;
        anim.SetBool("isClose", false);
    }
    //카드 미리보기함수
    public IEnumerator StartLookDelay1()
    {
        LookCard();
        yield return new WaitForSeconds(3f);
        DontLook();
    }
    public IEnumerator StartLookDelay2()
    {
        LookCard();
        yield return new WaitForSeconds(2f);
        DontLook();
    }
    public void LookCard()
    {
        anim.SetBool("isOpen", true);
        front.SetActive(true);
        back.SetActive(false);
    }
    public void DontLook()
    {
        anim.SetBool("isOpen", false);
        front.SetActive(false);
        back.SetActive(true);
    }
}
