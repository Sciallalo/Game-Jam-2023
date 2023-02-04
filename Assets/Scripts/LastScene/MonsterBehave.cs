using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterBehave : MonoBehaviour
{
    [SerializeField] float increaseScaleStep;
    [SerializeField] float decreaseScaleStep_percentage;
    [SerializeField] float verticalMoveVelocity;
    [SerializeField] float horizontalMoveVelocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)){
            transform.position += new Vector3(0, 0, verticalMoveVelocity);
        }
        if (Input.GetKey(KeyCode.S)) {
            transform.position += new Vector3(0, 0, -verticalMoveVelocity);
        }
        if (Input.GetKey(KeyCode.A)) {
            transform.position += new Vector3(-horizontalMoveVelocity, 0, 0);
        }
        if (Input.GetKey(KeyCode.D)) {
            transform.position += new Vector3(horizontalMoveVelocity, 0, 0);
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Galaxy")
        {
            Debug.Log("Galaxy Collision");
            transform.localScale += new Vector3(increaseScaleStep, increaseScaleStep, increaseScaleStep);
        }
        if(collision.collider.tag == "Boundaries")
        {
            Debug.Log("Boundaries Collision");
            transform.localScale *= decreaseScaleStep_percentage;
        }
    }
}
