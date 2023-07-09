using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public GameObject[] stage;
    public GameObject[] star1;
    public GameObject[] star2;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i > 2; i++)
        {
            stage[i].SetActive(false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        stageTrue();
    }

    public void Stage2()
    {
        InGameManager.stages = 2;
        SceneManager.LoadScene("InGame2");
    }

    public void Title()
    {
        SceneManager.LoadScene("Title");
    }

    public void stageTrue()
    {
        if(InGameManager.stages == 1)
        {
            stage[0].SetActive(true);
            star1[0].SetActive(true);
            if (InGameManager.times <= 180)
            {
                star1[1].SetActive(true);
            }
            if (InGameManager.times <= 120)
            {
                star1[2].SetActive(true);
            }
        }
        else if(InGameManager.stages == 2)
        {
            stage[1].SetActive(true);
            star2[0].SetActive(true);
        }
    }
}
