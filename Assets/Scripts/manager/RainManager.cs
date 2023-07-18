using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainManager : MonoBehaviour
{
    public GameObject rain;
    // Start is called before the first frame update
    void Start()
    {
        if(MenuManager.hard == false)
        {
            rain.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
