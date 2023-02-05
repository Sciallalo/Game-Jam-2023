using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neutrino : MonoBehaviour
{
    private GameObject target;
    public AudioSource explosion;
    public AudioSource absorb;
    public LanciaNeutrini ln;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Elettrone")
        {
            if(!ln.stop)
                explosion.Play();
            Destroy(collision.collider.gameObject);
            Destroy(gameObject);
        }

        if (collision.collider.tag == "Nucleo")
        {
            if (!ln.stop)
                absorb.Play();
            Destroy(gameObject);   
        }
    }

    private void Start()
    {
        target = GameObject.FindGameObjectsWithTag("Nucleo")[0];
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 0.03f);
    }
}
