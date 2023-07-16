using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orca : EnemyBase
{
    public GameObject shot;
    public Transform spawn;

    public Transform target;
    public float range = 15f;
    public string playerTag = "Player";
    public Transform partToRotate;
    public float turnSpeed = 10f;

    private float rotationalDamp = 0.1f;
    private float rayCastOffset = 2.5f;
    private float detectionDistance = 20f;

    public float dg = 0;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        target = InGameManager.Instance.curPlayer.transform;
        //Oct.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Range();
        //PathFinding();
        Turn();
        Move();
        BossPhase();
    }

    void UpdateTarget()
    {

        GameObject[] players = GameObject.FindGameObjectsWithTag(playerTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject player in players)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
            if (distanceToPlayer < shortestDistance)
            {
                shortestDistance = distanceToPlayer;
                nearestEnemy = player;
            }

        }
        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    void Turn()
    {
        Vector3 pos = new Vector3(target.position.x, target.position.y, target.position.z + 90) - new Vector3(transform.position.x, transform.position.y, transform.position.z);
        pos.Normalize();
        var rotation = Quaternion.LookRotation(-pos);
        transform.rotation = rotation;
        //transform.rotation = Quaternion.Euler(trans.x, trans.y, trans.z + 90);
    }

    void Move()
    {
        //Oct.SetBool("Move", true);
        transform.position += -transform.forward * speed * Time.deltaTime;
    }

    void Range()
    {
        if (target == null)
            return;

        Vector3 dir = new Vector3(target.position.x, target.position.y, target.position.z) - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Slerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(rotation.x, rotation.y, rotation.z);
    }

    void PathFinding()
    {
        RaycastHit hit;
        var rayCastVectorOffset = Vector3.zero;

        //각 가장자리 꼭짓점에 Ray 발사 그중 목표에 가까운쪽으로 값 증가 및 감소

        var left = transform.position - transform.right * rayCastOffset;
        var right = transform.position + transform.right * rayCastOffset;
        var up = transform.position + transform.up * rayCastOffset;
        var down = transform.position - transform.up * rayCastOffset;

        if (Physics.Raycast(left, transform.forward, out hit, detectionDistance))
            rayCastVectorOffset += transform.right;
        else if (Physics.Raycast(right, transform.forward, out hit, detectionDistance))
            rayCastVectorOffset -= transform.right;

        if (Physics.Raycast(up, transform.forward, out hit, detectionDistance))
            rayCastVectorOffset -= transform.up;
        else if (Physics.Raycast(down, transform.forward, out hit, detectionDistance))
            rayCastVectorOffset += transform.up;

        if (rayCastVectorOffset != Vector3.zero)
            transform.Rotate(rayCastVectorOffset * 0.1f * Time.deltaTime);
        else
            Turn();
    }

    public void BossPhase()
    {
        PhaseOne();
    }

    public float colTime = 2;
    public float timer;

    public void PhaseOne()
    {
        Vector3 pos = new Vector3(target.position.x, target.position.y, target.position.z) - transform.position;
        pos.Normalize();
        var dir = Quaternion.LookRotation(-pos);
        if (Time.time > colTime)
        {
            Instantiate(shot, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Lerp(partToRotate.rotation, dir, Time.deltaTime * 0.1f));
            colTime = timer + Time.time;
        }
    }

    public float colTime2 = 2;
    public float timer2;
    //public GameObject skillWater;

    public void PhaseTwo()
    {
        speed = 4;
        Vector3 pos = new Vector3(target.position.x, target.position.y, target.position.z) - transform.position;
        pos.Normalize();
        var dir = Quaternion.LookRotation(-pos);
        if (Time.time > colTime)
        {
            for(int i = 0; i < 5; i++)
            {
                //Instantiate(skillWater, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Lerp(partToRotate.rotation, dir, Time.deltaTime * 0.1f));
                colTime = timer + Time.time;
            }
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            hpGauge.i--;
            collision.collider.GetComponent<Player>()?.OnDamage(10);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("err"))
        {
            DieDestroy();
        }
    }

    protected override void DieDestroy()
    {
        MonserSpawn.monster++;
        Destroy(gameObject);
    }
}
