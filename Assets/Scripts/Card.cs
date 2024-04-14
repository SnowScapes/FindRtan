using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public int index = 0;

    public SpriteRenderer frontImage;
    public GameObject front;
    public GameObject back;
    public Animator anim;
    public AudioClip clip;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Setting(int number)
    {
        index = number;
        frontImage.sprite = Resources.Load<Sprite>($"rtan{index}");
    }

    public void OpenCard()
    {
        audioSource.PlayOneShot(clip);

        anim.SetBool("isOpen", true);
        front.SetActive(true);
        back.SetActive(false);

        if (GameManager.Instance.firstCard == null)
            GameManager.Instance.firstCard = this;
        else
        {
            GameManager.Instance.SecondCard = this;
            GameManager.Instance.isMatched();
        }
    }

    public void DestroyCard()
    {
        Invoke("DestoryCardInvoke", 0.5f);
    }

    void DestoryCardInvoke()
    {
        Destroy(gameObject);
    }

    public void CloseCard()
    {
        Invoke("CloseCardInvoke", 0.5f);
    }

    void CloseCardInvoke()
    {
        anim.SetBool("isOepn", false);
        front.SetActive(false);
        back.SetActive(true);
    }
}
