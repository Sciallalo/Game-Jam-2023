using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityChan;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class MonsterBehave : MonoBehaviour
{
    [SerializeField] GalaxyManager galaxyManager;
    [SerializeField] float increaseScaleStepPercentage;
    [SerializeField] float decreaseScaleStepPercentage;
    
    [SerializeField] int galaxyMalus;
    int eatGalaxies;

    public GameObject controller;
    public SpringManager springManager;
    public Canvas canvas;
    public VideoPlayer video;

    // Start is called before the first frame update
    void Start()
    {
        eatGalaxies = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Galaxy")
        {
            Debug.Log("Galaxy Collision");
            transform.localScale *= increaseScaleStepPercentage;
            controller.transform.localScale *= increaseScaleStepPercentage;
            springManager.stiffnessForce *= decreaseScaleStepPercentage;

            galaxyManager.decreaseGalaxyCounter(collision.gameObject);

            eatGalaxies++;
            Debug.Log(eatGalaxies);

            
            
        }

        else if(collision.collider.tag == "Boundaries")
        {
            Debug.Log("Boundaries Collision: " + collision.collider.name);

            if (collision.collider.name == "LeftB" || collision.collider.name == "RightB") {
                controller.transform.position = new Vector3(0, controller.transform.position.y, controller.transform.position.z);
            }
            else if(collision.collider.name == "TopB" || collision.collider.name == "BottomB") {
                controller.transform.position = new Vector3(controller.transform.position.x, controller.transform.position.y, 0);
            }

            // Reduce scale of the monster
            transform.localScale *= decreaseScaleStepPercentage;
            controller.transform.localScale *= decreaseScaleStepPercentage;
            springManager.stiffnessForce *= increaseScaleStepPercentage;

            // Apply a malus on the galaxy counter
            //if (eatGalaxies >= galaxyMalus) { eatGalaxies -= galaxyMalus; }
            //else { eatGalaxies = 0; }

        }
    }

    private void Update()
    {
        if (eatGalaxies >= 4)
        {
            StartCoroutine(WaitVideo());
        }
    }
    IEnumerator WaitVideo()
    {
        canvas.gameObject.SetActive(true);
        video.Play();
        yield return new WaitForSeconds(3.333f);
        SceneManager.LoadScene(0);
    }
}
