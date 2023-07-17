using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class EnemyBase : MonoBehaviour
{
    public float Maxhp;
    public float hp;

    public static float pdm = 0;
    public float dm;

    public float speed = 5f;

    private bool isDamage = false;
    public MeshRenderer[] meshs = new MeshRenderer[1];

    private void Awake()
    {
        hp = Maxhp;
        pdm = dm;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.deathMonster == true)
        {
            hp = 0;
            Player.deathMonster = false;
        }
    }

    public virtual void OnDamage(float dmg)
    {
        hp -= dmg;
        StartCoroutine(OnDamage());

        if (hp <= 0)
        {
            MonserSpawn.monster++;
            Destroy(this.gameObject);
        }
    }

    IEnumerator OnDamage()
    {

        isDamage = true;
        foreach (MeshRenderer mesh in meshs)
        {
            mesh.material.color = Color.red;
        }
        yield return new WaitForSeconds(0.5f);

        isDamage = false;
        foreach (MeshRenderer mesh in meshs)
        {
            mesh.material.color = Color.white;
        }
    }

    protected abstract void DieDestroy();
}
