using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpGauge : MonoBehaviour
{
    public GameObject[] gauge;

    public static int i = 10;

    public void Start()
    {
        i = 10;
    }


    public void SetGauge(float fillAmout)
    {
        gauge[i].SetActive(true);
    }
}
