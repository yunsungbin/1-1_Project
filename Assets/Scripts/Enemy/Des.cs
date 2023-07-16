using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Des : MonoBehaviour
{
    private float ds = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ds > 3)
        {
            Destroy(gameObject);
            ds = 0;
        }
        ds += Time.deltaTime;
    }
}
