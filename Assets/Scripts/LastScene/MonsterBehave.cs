using System;
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

    public float scale;
    
    [SerializeField] int galaxyMalus;
    int eatGalaxies;

    public GameObject controller;
    public SpringManager springManager;
    public Canvas canvas;
    public VideoPlayer video;

    public Material shaders1;
    public Material shaders2;
    public Material shaders3;
    private static readonly int Vector1Aaaef0d118A44A8da5Ebc3Ee7Ce1877E = Shader.PropertyToID("Vector1_aaaef0d118a44a8da5ebc3ee7ce1877e");
    private static readonly int Vector18Fc588776A484C988d78Bb1A70A10749 = Shader.PropertyToID("Vector1_8fc588776a484c988d78bb1a70a10749");


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
            //transform.localScale *= increaseScaleStepPercentage;
            
            scale += increaseScaleStepPercentage;
            SetScaleShaders(scale);
            
            controller.transform.localScale *= increaseScaleStepPercentage;

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
            //transform.localScale *= decreaseScaleStepPercentage;

            scale -= decreaseScaleStepPercentage;
            SetScaleShaders(scale);

            controller.transform.localScale *= decreaseScaleStepPercentage;

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

    void SetScaleShaders(float scale1)
    {
        shaders1.SetFloat(Vector1Aaaef0d118A44A8da5Ebc3Ee7Ce1877E, scale1/5);
        shaders1.SetFloat(Vector18Fc588776A484C988d78Bb1A70A10749, scale1/5);
        shaders1.SetFloat(Vector18Fc588776A484C988d78Bb1A70A10749, scale1/5);
    }

    void OnDisable()
    {
        SetScaleShaders(0);
    }
}
