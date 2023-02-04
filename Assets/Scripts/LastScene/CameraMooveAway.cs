using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraMooveAway : MonoBehaviour
{
    [SerializeField] float moveAwayVelocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, moveAwayVelocity * Time.deltaTime, 0);
    }
}