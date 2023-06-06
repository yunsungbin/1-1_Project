using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject gm;
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
}
