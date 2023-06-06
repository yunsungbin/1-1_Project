using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonserSpawn : MonoBehaviour
{
    public GameObject[] Spawner;
    public float spawnTime = 5;
    public float sTime;

    public float MaxSpawn;
    public static float mSpawn;
    private float spawn = 0;
    // Start is called before the first frame update
    void Start()
    {
        mSpawn = MaxSpawn;
        spawn = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(spawn <= MaxSpawn)
        {
            if(Time.time > spawnTime)
            {
                Instantiate(Spawner[Random.Range(0, 1)], new Vector3(Random.Range(Random.Range(-20, -15), Random.Range(15, 21)), 2f, Random.Range(Random.Range(-20, -15), Random.Range(15, 21))), Quaternion.Euler(-90, 0, 0));
                Instantiate(Spawner[Random.Range(0, 1)], new Vector3(Random.Range(Random.Range(-20, -15), Random.Range(15, 21)), 2f, Random.Range(Random.Range(-20, -15), Random.Range(15, 21))), Quaternion.Euler(-90, 0, 0));
                spawn++;
                spawnTime = sTime + Time.time;
            }
        }
    }
}
