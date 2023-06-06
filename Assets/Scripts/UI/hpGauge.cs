using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpGauge : MonoBehaviour
{
    public Image gauge;

    public void SetGauge(float fillAmout)
    {
        gauge.fillAmount = fillAmout;
    }
}
