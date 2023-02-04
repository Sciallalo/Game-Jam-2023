using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moovement : MonoBehaviour
{
    [SerializeField] GameObject other_hand;
    [SerializeField] float moovement_velocity = 0.3f;
    [SerializeField] float range_z;
    [SerializeField] Transform center;
    [SerializeField] float approachingVelocity = 1.5f;
    [SerializeField] float max_distance = 0.6f;

    bool WIN = false;
    float seed;

    Transform left_top, rightTop;
    //bool done = false;
    //[SerializeField] bool collided = false;

    // Start is called before the first frame update
    void Start()
    {
        Collider collider = GetComponent<Collider>();

        if(gameObject.name == "LeftHand")
        {
            left_top = gameObject.transform.GetChild(0).transform;
            rightTop = other_hand.transform.GetChild(0).transform;
        }
        else
        {
            left_top = other_hand.transform.GetChild(0).transform;
            rightTop = gameObject.transform.GetChild(0).transform;
        }
        
        seed = UnityEngine.Random.Range(0, 100);
        moovement_velocity = UnityEngine.Random.Range(3f, 5f);
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, UnityEngine.Random.Range(-range_z, range_z));
    }

    // Update is called once per frame
    void Update()
    {
        if (!WIN)
        {
            float new_z_val = Mathf.Sin(seed) * range_z;

            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, new_z_val);
            seed += moovement_velocity * Time.deltaTime;
        }

        else
        {
            gameObject.transform.position += Vector3.MoveTowards(gameObject.transform.GetChild(0).position, center.position, approachingVelocity * Time.deltaTime) - gameObject.transform.GetChild(0).position;
        }

        if (Input.GetMouseButton(0))
        {
            if (compute_offsetZ(left_top, rightTop, max_distance))
            {
                WIN = true;
                Debug.Log("Collision detected");
            }
            else
            {
                Debug.Log("Collision NOT detected");
            }
        }

    }


    bool compute_offsetZ(Transform p1, Transform p2, float max_offset)
    {
        float offset = MathF.Abs(p1.position.z - p2.position.z);

        return offset < max_offset;
            
    }
}
