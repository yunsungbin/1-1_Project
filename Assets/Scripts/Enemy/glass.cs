using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class glass : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hpGauge.i--;
            other.GetComponent<Player>()?.OnDamage(10);
        }
    }
}
