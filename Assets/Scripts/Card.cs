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

            float targetWidth = 1f;  
            float targetHeight = 1.2f;

            float scaleX = targetWidth / spriteWidth;
            float scaleY = targetHeight / spriteHeight;

            frontImage.transform.localScale = new Vector3(scaleX, scaleY, 1f);
        }
    }


    public void OpenCard()
    {
        if (GameManager.Instance.secondCard != null) return;

        audioSource.PlayOneShot(clip);
        anim.SetBool("isOpen", true);
        front.SetActive(true);
        back.SetActive(false);

        //first�� ����ٸ�
        if (GameManager.Instance.firstCard == null)
        {
            //firstCard�� �� ������ �Ѱ��ش�
            GameManager.Instance.firstCard = this;
        }
        //firstCard�� ������� �ʴٸ�.
        else
        {
            //secondCard�� �� ������ �Ѱ��ش�
            GameManager.Instance.secondCard = this;
            //Mached �Լ��� ȣ��
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
    }
    void CloseCardInvoke()
    {
        anim.SetBool("isOpen", false);
        front.SetActive(false);
        back.SetActive(true);
    }
    
}
