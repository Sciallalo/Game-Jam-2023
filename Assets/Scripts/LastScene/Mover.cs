using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] float velocity;
    void Update()
    {
        float new_velocity = velocity * Time.deltaTime;

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 0, new_velocity);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, 0, -new_velocity);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-new_velocity, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(new_velocity, 0, 0);
        }


    }
}
