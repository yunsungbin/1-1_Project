using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ebullet : MonoBehaviour
{
    public float timer = 0;
    public EnemyBase enemy;
    //public Transform target;
    public float speed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        //target = InGameManager.Instance.curPlayer.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer >= 2)
        {
            Destroy(gameObject);
        }
        //Vector3 dir = (target.position - transform.position);
        //transform.position += dir.normalized * speed * Time.deltaTime;
        timer += Time.deltaTime;
    }
}
