using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanciaNeutrini : MonoBehaviour
{
    public List<GameObject> elettroni;
    public GameObject neutrino;
    public Ellipse ellisse;
    public float maxTime = 15f;
    private float currentTime;
    private float tmpTime;

    private void Start()
    {
        currentTime = 0;
        tmpTime = 0;
    }
    
    bool CheckState()
    {
        for(int i = 0; i< elettroni.Count; i++)
        {
            if (elettroni[i].gameObject != null)
                return true;
        }

        return false;
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
        tmpTime += Time.deltaTime;

        if (!CheckState()){
            Debug.Log("Perso");
        }

        if(currentTime >= maxTime)
        {
            Debug.Log("Vinto");
        }

        if(tmpTime >= 1.5f)
        {
            Vector2 orbitPos = ellisse.Evaluate(Random.Range(0f, 1f));
            Instantiate(neutrino, new Vector3(orbitPos.x, 0, orbitPos.y), Quaternion.identity);

            orbitPos = ellisse.Evaluate(Random.Range(0f, 1f));
            Instantiate(neutrino, new Vector3(orbitPos.x, 0, orbitPos.y), Quaternion.identity);

            tmpTime = 0;
        }
    }
}
