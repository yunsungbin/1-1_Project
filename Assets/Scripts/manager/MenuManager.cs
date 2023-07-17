using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject gm;
    public GameObject exit;
    public GameObject create;
    public GameObject s;
    // Start is called before the first frame update
    void Start()
    {
        InGameManager.stages = 1;
        InGameManager.StartGame = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        InGameManager.StartGame = true;
        InGameManager.stages = 1;
        LoadingSceneManager.LoadScene("InGame");
    }

    public void Setting()
    {
        StartCoroutine(NoSet());
    }

    public void SetAciveTRUE()
    {
        gm.SetActive(true);
    }

    public void SetAciveFALSE()
    {
        gm.SetActive(false);
    }

    public void SetExit()
    {
        exit.SetActive(true);
    }

    public void SetExitFALSE()
    {
        exit.SetActive(false);
    }

    public void SetCreater()
    {
        create.SetActive(true);
    }

    public void NonCreater()
    {
        create.SetActive(false);
    }

    public void SetExitTrue()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // 어플리케이션 종료
#endif
    }

    IEnumerator NoSet()
    {
        s.SetActive(true);

        yield return new WaitForSeconds(1);

        s.SetActive(false);
        StopCoroutine(NoSet());
    }
}
