using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameManager : MonoBehaviour
{
    public static bool StartGame = false;

    public static bool None = false;
    public static bool nextGame = false;

    public static float kMoster;

    private 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(kMoster >= MonserSpawn.mSpawn * 2)
        {
            nextGame = true;
        }
        if(nextGame == true)
        {
            nextGame = false;
            SceneManager.LoadScene("InGame2");
        }
    }
}
