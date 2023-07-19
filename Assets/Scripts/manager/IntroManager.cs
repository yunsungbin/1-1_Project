using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    public GameObject[] Intro;

    public GameObject Skip;

    [Header("Text UI")] public Text textUI;
    public GameObject textui;
    [Header("Text UI2")] public Text textUI2;
    public GameObject textui2;
    [Header("타이핑 지연 시간")] public float delayTime;
    IEnumerator startTyping;
    public string[] write;
    bool typingCheck = false;
    WaitForSeconds time;

    public int textNum = 0;

    void Start()
    {
        textui.SetActive(true);
        textui2.SetActive(true);
        time = new WaitForSeconds(delayTime);
        StartCoroutine(IntroStart());
    }

    void Update()
    {
        
    }

    IEnumerator IntroStart()
    {
        for(int i = 0; i < 3; i++)
        {
            NextStory();
            for (int j = 0; j < 3; j++)
            {
                Intro[0].SetActive(true);
                yield return new WaitForSeconds(0.5f);
                Intro[1].SetActive(true);
                Intro[0].SetActive(false);
                yield return new WaitForSeconds(0.5f);
                Intro[1].SetActive(false);
            }
            textNum++;
        }
        textui.SetActive(false);
        Intro[0].SetActive(false);
        for (int i = 0; i < 2; i++)
        {
            NextStory2();
            for (int j = 0; j < 5; j++)
            {
                Intro[2].SetActive(true);
                yield return new WaitForSeconds(0.3f);
                Intro[3].SetActive(true);
                Intro[2].SetActive(false);
                yield return new WaitForSeconds(0.3f);
                Intro[3].SetActive(false);
            }
            textNum++;
        }
        textui.SetActive(true);
        textui2.SetActive(false);
        Intro[2].SetActive(false);
        for (int i = 0; i < 3; i++)
        {
            NextStory();
            for (int j = 0; j < 5; j++)
            {
                Intro[4].SetActive(true);
                yield return new WaitForSeconds(0.3f);
                Intro[5].SetActive(true);
                Intro[4].SetActive(false);
                yield return new WaitForSeconds(0.3f);
                Intro[6].SetActive(true);
                Intro[5].SetActive(false);
                yield return new WaitForSeconds(0.3f);
                Intro[6].SetActive(false);
            }
            textNum++;
        }
        textui.SetActive(false);
        textui2.SetActive(false);
        LoadingSceneManager.LoadScene("Title");
    }

    void NextStory()
    {
        
        if (!typingCheck)
        {
            startTyping = TypingPage();
            typingCheck = true;
            StartCoroutine(startTyping);
        }
        else
        {
            // 타이핑 효과 넘기기
            if (typingCheck)
            {
                StopCoroutine(startTyping);
                textUI.text = write[textNum];
                typingCheck = false;
            }
        }
    }

    void NextStory2()
    {

        if (!typingCheck)
        {
            startTyping = TypingPage2();
            typingCheck = true;
            StartCoroutine(startTyping);
        }
        else
        {
            // 타이핑 효과 넘기기
            if (typingCheck)
            {
                StopCoroutine(startTyping);
                textUI2.text = write[textNum];
                typingCheck = false;
            }
        }
    }

    IEnumerator TypingPage2()
    {
        string pageText;

        for (int i = 0; i < write[textNum].Length + 1; i++)
        {
            pageText = write[textNum].Substring(0, i);
            pageText += "<color=#00000000>" + write[textNum].Substring(i) + "</color>";
            textUI2.text = pageText;
            yield return time;
        }

        typingCheck = false;
    }

    IEnumerator TypingPage()
    {
        string pageText;

        for (int i = 0; i < write[textNum].Length + 1; i++)
        {
            pageText = write[textNum].Substring(0, i);
            pageText += "<color=#00000000>" + write[textNum].Substring(i) + "</color>";
            textUI.text = pageText;
            yield return time;
        }

        typingCheck = false;
    }

    public void SKIP()
    {
        LoadingSceneManager.LoadScene("Title");
    }

}
