using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed;
    public float damage;
    public Vector3 dir;

    private float ds = 0;

    void Update()
    {
        transform.Translate(dir * Time.deltaTime * moveSpeed);
        if(ds > 5)
        {
            Destroy(gameObject);
            ds = 0;
        }
        ds += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyBase>()?.OnDamage(damage);
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
