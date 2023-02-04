using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neutrino : MonoBehaviour
{
    private GameObject target;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Elettrone")
        {
            Destroy(collision.collider.gameObject);
            Destroy(gameObject);
        }

        if (collision.collider.tag == "Nucleo")
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        target = GameObject.FindGameObjectsWithTag("Nucleo")[0];
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 0.01f);
    }
}
