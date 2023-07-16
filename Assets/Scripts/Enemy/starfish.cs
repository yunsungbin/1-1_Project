using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starfish : EnemyBase
{
    public float colTime = 3;
    public float timer;

    public Transform target;
    public float range = 15f;
    public string playerTag = "Player";
    public Transform partToRotate;
    public float turnSpeed = 10f;

    private float rotationalDamp = 5f;
    private float rayCastOffset = 2.5f;
    private float detectionDistance = 20f;

    public float dg = 0;
    private bool attackorder = false;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        target = InGameManager.Instance.curPlayer.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Range();
        PathFinding();
        Turn();
        Move();
        Attack();
    }

    void Attack()
    {
        if (Time.time > colTime && attackorder == false)
        {
            speed = 5;
            attackorder = true;
            colTime = timer + Time.time;
        }
        else if(Time.time > colTime && attackorder == true)
        {
            speed = 4;
            attackorder = true;
            colTime = timer + Time.time;
        }
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
        Vector3 pos = new Vector3(target.position.x, target.position.y + 2, target.position.z) - transform.position;
        var rotation = Quaternion.LookRotation(pos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationalDamp * Time.deltaTime);
    }

    void Move()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
        //Oct.SetBool("Move", true);
    }

    void Range()
    {
        if (target == null)
            return;

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
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
            transform.Rotate(rayCastVectorOffset * 5f * Time.deltaTime);
        else
            Turn();
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
