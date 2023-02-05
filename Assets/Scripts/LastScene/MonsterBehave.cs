using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterBehave : MonoBehaviour
{
    [SerializeField] GalaxyManager galaxyManager;
    [SerializeField] float increaseScaleStepPercentage;
    [SerializeField] float decreaseScaleStepPercentage;
    [SerializeField] float velocity;
    

    [SerializeField] int galaxyMalus;
    int eatGalaxies;

    // Start is called before the first frame update
    void Start()
    {
        eatGalaxies = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float new_velocity = velocity * Time.deltaTime;

        if (Input.GetKey(KeyCode.UpArrow)){
            transform.position += new Vector3(0, 0, new_velocity);
        }
        if (Input.GetKey(KeyCode.DownArrow)) {
            transform.position += new Vector3(0, 0, -new_velocity);
        }
        if (Input.GetKey(KeyCode.LeftArrow)) {
            transform.position += new Vector3(-new_velocity, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            transform.position += new Vector3(new_velocity, 0, 0);
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Galaxy")
        {
            Debug.Log("Galaxy Collision");
            transform.localScale *= increaseScaleStepPercentage;
            galaxyManager.decreaseGalaxyCounter(collision.gameObject);
            
        }

        else if(collision.collider.tag == "Boundaries")
        {
            Debug.Log("Boundaries Collision: " + collision.collider.name);

            if (collision.collider.name == "LeftB" || collision.collider.name == "RightB") {
                transform.position = new Vector3(0, transform.position.y, transform.position.z);
            }
            else if(collision.collider.name == "TopB" || collision.collider.name == "BottomB") {
                transform.position = new Vector3(transform.position.x, transform.position.y, 0);
            }

            // Reduce scale of the monster
            transform.localScale *= decreaseScaleStepPercentage;

            // Apply a malus on the galaxy counter
            if (eatGalaxies >= galaxyMalus) { eatGalaxies -= galaxyMalus; }
            else { eatGalaxies = 0; }

        }
    }
}
