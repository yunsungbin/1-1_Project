using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillAttack : MonoBehaviour
{
    public Transform target;
    public float range = 15f;
    public string enemyTag = "Enemy";
    public Transform partToRotate;
    public float turnSpeed = 10f;
    public float speed = 20f;

    private float rotationalDamp = 5f;
    private float rayCastOffset = 2.5f;
    private float detectionDistance = 20f;

    public float damage;
    public ParticleSystem bomb;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        Destroy(gameObject, 10f);
    }

    void Update()
    {
        Range();
        PathFinding();
        Turn();
        Move();
    }

    void UpdateTarget()
    {

        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
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
        var pos = target.transform.position - transform.position;
        var rotation = Quaternion.LookRotation(pos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationalDamp * Time.deltaTime);
    }

    void Move()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
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

    void OnTriggerEnter(Collider col)
    {
        if (col.transform.tag == "Enemy")
        {
            Instantiate(bomb, transform.position, Quaternion.identity);
            col.GetComponent<EnemyBase>()?.OnDamage(damage);
            Destroy(gameObject);
        }

    }

}
