using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class navmesh : MonoBehaviour
{
    public float speed = 5f;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 dir = player.transform.position;
        //transform.Translate(dir * speed * Time.deltaTime);
    }
}
