using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class LanciaNeutrini : MonoBehaviour
{
    public List<GameObject> elettroni;
    public GameObject neutrino;
    public Ellipse ellisse;
    public Canvas canvas;
    public VideoPlayer video;
    public float maxTime = 15f;
    private float currentTime;
    private float tmpTime;

    private void Start()
    {
        currentTime = 0;
        tmpTime = 0;
        video.Stop();
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
            SceneManager.LoadScene(0);
        }

        if(currentTime >= maxTime)
        {
            canvas.gameObject.SetActive(true);
            video.Play();
            StartCoroutine(WaitVideo());
        }

        if(tmpTime >= Random.Range(.5f, 2f))
        {
            Vector2 orbitPos = ellisse.Evaluate(Random.Range(0f, 1f));
            Instantiate(neutrino, new Vector3(orbitPos.x, 0, orbitPos.y), Quaternion.identity);

            tmpTime = 0;
        }
    }

    IEnumerator WaitVideo()
    {
        yield return new WaitForSeconds(4.176f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
