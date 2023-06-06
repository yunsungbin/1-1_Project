using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpGauge : MonoBehaviour
{
    public Image gauge;

    public void SetGauge(float fillAmout)
    {
        gauge.fillAmount = fillAmout;
    }
}
