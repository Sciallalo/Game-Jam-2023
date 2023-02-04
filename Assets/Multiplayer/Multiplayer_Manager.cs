using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multiplayer_Manager : MonoBehaviour
{
    public Camera cam1, cam2;

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
}
