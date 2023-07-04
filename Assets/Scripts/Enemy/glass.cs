using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class glass : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            hpGauge.i--;
            collision.collider.GetComponent<Player>()?.OnDamage(10);
        }
    }
}
