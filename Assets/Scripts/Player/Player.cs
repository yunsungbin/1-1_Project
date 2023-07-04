using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public Animator anim;

    private void Awake()
    {
        hp = MaxHp;
        dmPlayer = dmp;
    }
    void Start()
    {
        hp = MaxHp;
        dmPlayer = dmp;
        hpGauge.i = 10;
        anim.GetComponent<Animator>();
    }

    void Update()
    {
        BulletShot();
        GMSkill();
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

            if(v >= 0)
            {
                anim.SetBool("Run", true);
                anim.SetBool("Back", false);
            }
            if (v <= 0)
            {
                anim.SetBool("Back", true);
                anim.SetBool("Run", false);
            }
        }
        if(h==0 && v == 0)
        {
            anim.SetBool("Back", false);
            anim.SetBool("Run", false);
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

    void GMSkill()
    {
        if (Input.GetKey(KeyCode.F1))
        {
            SceneManager.LoadScene("InGame2");
        }
        if (Input.GetKey(KeyCode.F2))
        {
            SceneManager.LoadScene("Title");
        }
    }

    public void HpRecover(float amount = 10f)
    {
        hp += amount;
        hpGauge.i++;
        OnDamage(0);
        if (hp > MaxHp) hp = MaxHp;
    }

    public void OnDamage(float dm)
    {
        hp -= dm;
        for (int j = 0; j < 10; j++)
        {
            hpGauge.g[j].SetActive(false);
        }
        for (int k = 0; k < hpGauge.i; k++)
        {
            hpGauge.g[k].SetActive(true);
        }

        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("EBullet"))
        {
            hpGauge.i--;
            OnDamage(10);
        }
        if (collision.collider.CompareTag("block"))
        {
            transform.position += -vc * Speed * Time.deltaTime;
        }
        if (collision.collider.CompareTag("sea"))
        {
            transform.position = new Vector3(0, 3.12f, 0);
            hpGauge.i--;
            OnDamage(10);
        }
    }
}
