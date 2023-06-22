using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class aSkill : MonoBehaviour
{
    public Image skillGauge1;
    public static Image s;

    private void Start()
    {
        s = skillGauge1;
    }

    public static void Setskill(float fillAmount)
    {
        s.fillAmount = fillAmount;

        s.gameObject.SetActive(fillAmount > 0f);
    }
}
