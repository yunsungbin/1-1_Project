using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndingManager : MonoBehaviour
{
    public GameObject[] Intro;

    public GameObject Skip;

    [Header("Text UI")] public Text textUI;
    [Header("타이핑 지연 시간")] public float delayTime;
    IEnumerator startTyping;
    public string[] write;
    bool typingCheck = false;
    WaitForSeconds time;

    public int textNum = 0;

    void Start()
    {
        time = new WaitForSeconds(delayTime);
        StartCoroutine(IntroStart());
    }

    IEnumerator IntroStart()
    {
        for (int i = 0; i < 3; i++)
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
