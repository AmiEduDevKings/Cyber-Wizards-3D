using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour {

    public float RotateSpeed;
    public float MovementSpeed;

    void FixedUpdate()
    {

        if (Input.GetMouseButton(2))
        {
            float x = RotateSpeed * Input.GetAxis("Mouse X");
            gameObject.transform.Rotate(0, x, 0);
        }
        

        if (Input.GetKey(KeyCode.W))
        {
            gameObject.transform.Translate(Vector3.forward * MovementSpeed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.Translate(Vector3.back * MovementSpeed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.Translate(Vector3.right * MovementSpeed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.Translate(Vector3.left * MovementSpeed);
        }
    }


}
