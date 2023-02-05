using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multiplayer_Manager : MonoBehaviour
{
    public Camera cam1, cam2;
    public GameObject scene1;
    public GameObject scene2;

    public GameObject Starting_Canvas;
    public GameObject Starting_Camera;

    // Start is called before the first frame update
    void Start()
    {
        cam1.rect = new Rect(0f,0f,0.5f,1f);
        cam2.rect = new Rect(0.5f, 0f, 0.5f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playScene() {
        scene1.SetActive(true);
        scene2.SetActive(true);
        Starting_Canvas.SetActive(false);
        Starting_Camera.SetActive(false);
        cam1.rect = new Rect(0f, 0f, 0.5f, 1f);
        cam2.rect = new Rect(0.5f, 0f, 0.5f, 1f);
    }

    public void Change_cam1(Camera cam) {
        cam1 = cam;
        cam1.rect = new Rect(0f, 0f, 0.5f, 1f);
    }

    public void Change_cam2(Camera cam)
    {
        cam2 = cam;
        cam2.rect = new Rect(0.5f, 0f, 0.5f, 1f);
    }
}
