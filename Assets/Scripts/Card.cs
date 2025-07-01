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
        // ¿ÃπÃ ø≠∑¡¿÷¿∏∏È æ∆π´∞Õµµ «œ¡ˆ æ ¿Ω
        if (GameManager.Instance.secondCard != null)
        {
            // «ˆ¿Á ø≠∏∞ µŒ ¿Â¿ª ¥›∞Ì ªı∑ŒøÓ ƒ´µÂ∫Œ≈Õ ¥ŸΩ√ Ω√¿€
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
        //firstÍ∞Ä ÎπÑÏóàÎã§Î©¥
        if (GameManager.Instance.firstCard == null)
        {
            //firstCardÏóê ÎÇ¥ Ï†ïÎ≥¥Î•º ÎÑòÍ≤®Ï§ÄÎã§
            GameManager.Instance.firstCard = this;
        }
        //firstCardÍ∞Ä ÎπÑÏñ¥ÏûàÏßÄ ÏïäÎã§Î©¥.
        else
        {
            //secondCardÏóê ÎÇ¥ Ï†ïÎ≥¥Î•º ÎÑòÍ≤®Ï§ÄÎã§
            GameManager.Instance.secondCard = this;
            //Mached Ìï®ÏàòÎ•º Ìò∏Ï∂ú
=======
        // √π π¯¬∞ ƒ´µÂ∞° ∫Òæ˙¿∏∏È ≥™ ¿⁄Ω≈¿ª √π π¯¬∞ ƒ´µÂ∑Œ º≥¡§
        if (GameManager.Instance.firstCard == null)
        {
            GameManager.Instance.firstCard = this;
        }
        // √π π¯¬∞ ƒ´µÂ∞° ¿ÃπÃ ¿÷¿∏∏È ≥™ ¿⁄Ω≈¿ª µŒ π¯¬∞ ƒ´µÂ∑Œ º≥¡§ »ƒ ∏≈ƒ™ √º≈©
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