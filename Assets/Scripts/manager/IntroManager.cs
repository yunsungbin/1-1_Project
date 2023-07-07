using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    [SerializeField] Image image = null;
    [SerializeField] Text text = null;

    public GameObject Skip;

    void Start()
    {
        StartCoroutine(FadeTextToFullAlpha(1.5f, image, text));
    }

    void Update()
    {
        
    }

    public IEnumerator FadeTextToFullAlpha(float t, Image i, Text j)
    {
        j.color = new Color(j.color.r, j.color.g, j.color.b, 0);

        while (j.color.a < 2.0f)
        {
            j.color = new Color(j.color.r, j.color.g, j.color.b, j.color.a + (Time.deltaTime / t));
            yield return null;
        }
        j.color = new Color(j.color.r, j.color.g, j.color.b, 1);
        while (j.color.a > 0.0f)
        {
            j.color = new Color(j.color.r, j.color.g, j.color.b, j.color.a - (Time.deltaTime / t));
            yield return null;
        }

        SceneManager.LoadScene("Title");
    }

    public void SKIP()
    {
        SceneManager.LoadScene("Title");
    }

}
