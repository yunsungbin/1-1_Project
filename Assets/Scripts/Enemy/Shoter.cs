using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoter : EnemyBase
{
    public float colTime = 3;
    public float timer;

    public GameObject shot;
    public Transform spawn;

    public Transform target;

    public float dg = 0;
    public Animator Oct;
    // Start is called before the first frame update
    void Start()
    {
        target = InGameManager.Instance.curPlayer.transform;
        //Oct.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        dg = Player.dmp;
        Vector3 dir = (new Vector3(target.position.x, target.position.y + 2, target.position.z) - transform.position);
        transform.position += dir.normalized * speed * Time.deltaTime;
        if (Time.time > colTime)
        {
            Instantiate(shot, new Vector3(transform.position.x -1, transform.position.y, transform.position.z), Quaternion.Euler(90, 0, 0));
            colTime = timer + Time.time;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            hpGauge.i--;
            collision.collider.GetComponent<Player>()?.OnDamage(10);
            DieDestroy();
        }
    }

    protected override void DieDestroy()
    {
        MonserSpawn.monster++;
        Destroy(gameObject);
    }
}
