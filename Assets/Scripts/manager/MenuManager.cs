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
    // Start is called before the first frame update
    void Start()
    {
        InGameManager.StartGame = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        InGameManager.StartGame = true;
        SceneManager.LoadScene("InGame");
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
}
