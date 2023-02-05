using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene2_Reload : MonoBehaviour
{
    [SerializeField] GameObject alieno;
    [SerializeField] TimeLimit timeLimit;
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
        timeLimit.starting();
    }
}
