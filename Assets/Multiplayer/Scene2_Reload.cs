using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene2_Reload : MonoBehaviour
{
    [SerializeField] GameObject alieno;
    [SerializeField] TimeLimit timeLimit;

    [SerializeField] GameObject leftHand;
    [SerializeField] GameObject rightHand;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        alieno.SetActive(true);
        leftHand.transform.position = new Vector3(-5f,0f,0f);
        rightHand.transform.position = new Vector3(5f, 0f, 0f);
        timeLimit.starting();
    }
}
