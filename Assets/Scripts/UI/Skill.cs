using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    public Image skillGauge;
    public static Image s;

    private void Start()
    {
        s = skillGauge;
    }

    public static void Setskill(float fillAmount)
    {
        s.fillAmount = fillAmount;

        s.gameObject.SetActive(fillAmount > 0f);
    }
}
