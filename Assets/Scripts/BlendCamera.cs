using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlendCamera : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] private Vector3 des;
    
    public bool cameraPositioned;
    
    private Vector3 start;
    private float fraction = 0;


    void Start()
    {
        start = gameObject.transform.position;
        cameraPositioned = false;
        //des = new Vector3(transform.position.x, 10f, transform.position.z);

    }

    void Update()
    {
        if (!Camera.main.orthographic)
        {
            if (fraction < 1)
            {
                fraction += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(start, des, fraction);
            }
            else
            {
                cameraPositioned = true;
            }
        }
        else
        {
            if (fraction < 1)
            {
                fraction += Time.deltaTime * speed;
                Camera.main.orthographicSize = Mathf.Lerp(start.x, des.x, fraction);
            }
            else
            {
                cameraPositioned = true;
            }
        }
        
    }
}
