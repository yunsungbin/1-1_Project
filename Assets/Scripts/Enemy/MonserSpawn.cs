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

    public static float monster;
    // Start is called before the first frame update
    void Start()
    {
        mSpawn = MaxSpawn;
        spawn = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(InGameManager.stages == 1)
        {
            stage1();
        }
        else if(InGameManager.stages == 2)
        {
            stage2();
        }
    }

    public void stage1()
    {
        if (spawn <= MaxSpawn)
        {
            if (Time.time > spawnTime)
            {
                Instantiate(Spawner[Random.Range(0, 1)], new Vector3(Random.Range(Random.Range(-20, -15), Random.Range(15, 21)), 4f, Random.Range(Random.Range(-20, -15), Random.Range(15, 21))), Quaternion.Euler(-90, 0, 0));
                Instantiate(Spawner[Random.Range(0, 1)], new Vector3(Random.Range(Random.Range(-20, -15), Random.Range(15, 21)), 4f, Random.Range(Random.Range(-20, -15), Random.Range(15, 21))), Quaternion.Euler(-90, 0, 0));
                spawn++;
                spawnTime = sTime + Time.time;
            }
        }
    }

    public void stage2()
    {
        if (spawn <= MaxSpawn)
        {
            if (Time.time > spawnTime)
            {
                Instantiate(Spawner[Random.Range(0, 2)], new Vector3(Random.Range(Random.Range(-20, -15), Random.Range(15, 21)), 4f, Random.Range(Random.Range(-20, -15), Random.Range(15, 21))), Quaternion.Euler(-90, 0, 0));
                Instantiate(Spawner[Random.Range(0, 2)], new Vector3(Random.Range(Random.Range(-20, -15), Random.Range(15, 21)), 4f, Random.Range(Random.Range(-20, -15), Random.Range(15, 21))), Quaternion.Euler(-90, 0, 0));
                spawn++;
                spawnTime = sTime + Time.time;
            }
        }
    }
}
