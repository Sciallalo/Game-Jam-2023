using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neutrino : MonoBehaviour
{
    private GameObject target;
    [SerializeField] LanciaNeutrini lancia;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Elettrone")
        {
            //Destroy(collision.collider.gameObject);
            collision.collider.gameObject.SetActive(false);
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
        StartCoroutine(kill_neutrino());
        //lancia = GetComponentInParent<LanciaNeutrini>();
    }

    void Update()
    {
       // if(lancia.finish) { Destroy(gameObject); }
       if(target!=null)
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 0.03f);
    }

    IEnumerator kill_neutrino()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);

    }
}
