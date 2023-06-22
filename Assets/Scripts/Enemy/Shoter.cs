using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoter : EnemyBase
{
    public float colTime = 2;
    public float timer;

    public GameObject shot;
    public Transform spawn;

    public float dg = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dg = Player.dmp;
        if(Time.time > colTime)
        {
            Instantiate(shot, new Vector3(transform.position.x -1, transform.position.y - 5, transform.position.z), Quaternion.Euler(0, 0, 0));
            colTime = timer + Time.time;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.collider.GetComponent<EnemyBase>()?.OnDamage(hp);
            InGameManager.kMoster++;
            Destroy(gameObject);
        }
    }

    protected override void DieDestroy()
    {
        InGameManager.kMoster++;
        Destroy(gameObject);
    }
}
