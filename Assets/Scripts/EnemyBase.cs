using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public float Maxhp;
    public float hp;
    // Start is called before the first frame update
    void Start()
    {
        hp = Maxhp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
