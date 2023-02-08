using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_movement : MonoBehaviour
{
    [SerializeField] float movement_x = 0.2f;
    [SerializeField] float MAX_x = 0.2f;
    [SerializeField] float MIN_x = 0.2f;

    private float current_x;

    // Update is called once per frame
    void Update()
    {
        current_x = transform.position.x;


        if (Input.GetKey(KeyCode.A) && current_x>MIN_x)
        {
            transform.position += new Vector3(-movement_x, 0, 0) * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D) && current_x<MAX_x)
        {
            transform.position += new Vector3(movement_x, 0, 0) * Time.deltaTime;
        }

       
    }
}
