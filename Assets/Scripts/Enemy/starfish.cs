using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starfish : EnemyBase
{
    public float colTime = 2;
    public float timer;

    public Transform target;

    public float dg = 0;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        target = InGameManager.Instance.curPlayer.transform;
        anim.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        dg = Player.dmp;
        Vector3 dir = (new Vector3(target.position.x, target.position.y + 2, target.position.z) - transform.position);
        transform.position += dir.normalized * speed * Time.deltaTime;
        if (Time.time > colTime)
        {
            StartCoroutine(StarfishAttack());
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("err"))
        {
            DieDestroy();
        }
    }

    IEnumerator StarfishAttack()
    {
        speed = 5;
        yield return new WaitForSeconds(1f);
        speed = 4;
        StopCoroutine(StarfishAttack());
    }

    protected override void DieDestroy()
    {
        MonserSpawn.monster++;
        Destroy(gameObject);
    }
}
