using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    public float rotateSpeed = 10.0f;

    public float MaxHp;
    public float hp;

    private float nextFire;
    public GameObject shot;
    public Transform shotSpawn;
    public float fire;

    public float dmPlayer;
    public static float dmp;

    private Vector3 vc;

    public static bool deathMonster = false;

    private void Awake()
    {
        hp = MaxHp;
        dmPlayer = dmp;
    }
    void Start()
    {
        
    }

    void Update()
    {
        BulletShot();
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v);
        vc = dir;

        if (!(h == 0 && v == 0))
        {
            transform.position += dir * Speed * Time.deltaTime;

            //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * rotateSpeed);
        }
    }

    void BulletShot()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && Time.time > nextFire)
        {
            Instantiate(shot, transform.position, Quaternion.Euler(0, 0, 180));
            nextFire = Time.time + fire;
        }
        if (Input.GetKey(KeyCode.RightArrow) && Time.time > nextFire)
        {
            Instantiate(shot, transform.position, Quaternion.Euler(0, 0, 0));
            nextFire = Time.time + fire;
        }
        if (Input.GetKey(KeyCode.UpArrow) && Time.time > nextFire)
        {
            Instantiate(shot, transform.position, Quaternion.Euler(0, -90, 0));
            nextFire = Time.time + fire;
        }
        if (Input.GetKey(KeyCode.DownArrow) && Time.time > nextFire)
        {
            Instantiate(shot, transform.position, Quaternion.Euler(0, 90, 0));
            nextFire = Time.time + fire;
        }
    }

    void Skill()
    {
        if (Input.GetKey(KeyCode.Q))
        {

        }
    }

    void GMSkill()
    {
        if (Input.GetKey(KeyCode.F1))
        {
            deathMonster = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("EBullet"))
        {
            hp -= EnemyBase.pdm;
        }
        if (collision.collider.CompareTag("block"))
        {
            transform.position += -vc * Speed * Time.deltaTime;
        }
    }
}
