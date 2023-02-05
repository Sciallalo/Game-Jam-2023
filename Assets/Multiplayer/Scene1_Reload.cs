using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene1_Reload : MonoBehaviour
{
    [SerializeField] GameObject Nucleo;
    [SerializeField] GameObject[] Elettroni;
    // Start is called before the first frame update
    void Start()
    {
        Nucleo.SetActive(true);
        for(int i =0; i < Elettroni.Length; i++)
        {
            Elettroni[i].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    private void OnEnable()
    {
        Nucleo.SetActive(true);
        for (int i = 0; i < Elettroni.Length; i++)
        {
            Elettroni[i].SetActive(true);
        }
    }

    public void reload()
    {
        Nucleo.SetActive(true);
        for (int i = 0; i < Elettroni.Length; i++)
        {
            Elettroni[i].SetActive(true);
        }
    }

    
}
