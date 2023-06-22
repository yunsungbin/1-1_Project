using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View : MonoBehaviour
{
    public float mouseSpeed = 4.0f;
    public GameObject shot;

    float xRotate = 0.0f;
    GameObject cam;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        cam = transform.GetChild(1).gameObject;
    }

    void Update()
    {
        MouseRotation();

        if (Input.GetMouseButtonDown(0))
        {
            ShootBullet();
        }
    }

    void MouseRotation()
    {
        float yRotateSize = Input.GetAxis("Mouse X") * mouseSpeed;
        float yRotate = transform.eulerAngles.y + yRotateSize;

        float xRotateSize = -Input.GetAxis("Mouse Y") * mouseSpeed;
        xRotate = Mathf.Clamp(xRotate + xRotateSize, -45, 80);

        transform.eulerAngles = new Vector3(0, yRotate, 0);
        cam.transform.localEulerAngles = new Vector3(xRotate, 0, 0);
    }

    void ShootBullet()
    {
        GameObject bullet = Instantiate(shot, cam.transform.position, cam.transform.rotation);
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        bulletRigidbody.velocity = cam.transform.forward * 10f; // 정면 방향으로 속도 설정
    }
}
