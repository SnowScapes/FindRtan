using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Text timeTxt;
    public GameObject endTxt;
    public Card firstCard;
    public Card SecondCard;
    public AudioClip clip;
    AudioSource audioSource;

    float time = 0.0f;
    public int cardCount = 0;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timeTxt.text = time.ToString("N2");
        if (time >= 30.0f)
        {
            endTxt.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }

    public void isMatched()
    {
        if (firstCard.index == SecondCard.index)
        {
            audioSource.PlayOneShot(clip);

            firstCard.DestroyCard();
            SecondCard.DestroyCard();
            cardCount -= 2;

            if (cardCount == 0)
            {
                endTxt.SetActive(true);
                Time.timeScale = 0.0f;
            }
        }
        else
        {
            firstCard.CloseCard();
            SecondCard.CloseCard();
        }

        firstCard = null;
        SecondCard = null;
    }
}
