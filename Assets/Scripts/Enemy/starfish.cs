using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starfish : EnemyBase
{
    public float colTime = 2;
    public float timer;

    public GameObject shot;
    public Transform spawn;

    public float dg = 0;
    // Start is called before the first frame update
    void Start()
    {
        target = InGameManager.Instance.curPlayer.transform;
    }

    // Update is called once per frame
    void Update()
    {
        dg = Player.dmp;
        Vector3 dir = (target.position - transform.position);
        transform.position += dir.normalized * speed * Time.deltaTime;
        Attack();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            hpGauge.i--;
            collision.collider.GetComponent<Player>()?.OnDamage(10);
            //InGameManager.kMoster++;
            Destroy(gameObject);
        }
    }

    public void Attack()
    {
        if (Time.time > colTime)
        {
            
            colTime = timer + Time.time;
        }
    }

    protected override void DieDestroy()
    {
        InGameManager.kMoster++;
        Destroy(gameObject);
    }
}
