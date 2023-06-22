using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    float vMove;
    float hMove;

    Vector3 moveVector;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        KeyboardInput();
        PlayerMove();


    }

    void KeyboardInput()
    {
        vMove = Input.GetAxisRaw("Vertical");
        hMove = Input.GetAxisRaw("Horizontal");
    }

    void PlayerMove()
    {
        moveVector = hMove * transform.right + vMove * transform.forward;

        moveVector = new Vector3(moveVector.x, 0, moveVector.z).normalized;

        transform.position += moveVector * speed * Time.deltaTime;
    }
}
