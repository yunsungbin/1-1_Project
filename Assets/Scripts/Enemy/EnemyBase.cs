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

    UnityEngine.AI.NavMeshAgent nav;

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

        if (hp <= 0)
        {
            MonserSpawn.monster++;
            Destroy(this.gameObject);
        }
    }

    protected abstract void DieDestroy();
}
