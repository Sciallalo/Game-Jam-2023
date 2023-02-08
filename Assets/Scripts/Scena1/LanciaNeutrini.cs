using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class LanciaNeutrini : MonoBehaviour
{
    [SerializeField] BlendCamera blendCam;
    [SerializeField] Atom atom;

    public GameObject cv_gameplay;

    public List<GameObject> elettroni;
    public GameObject neutrino;
    public Ellipse ellisse;
    public Canvas canvas;
    public VideoPlayer video;
    public float maxTime = 15f;
    private float currentTime;
    private float tmpTime;
    public bool stop = false;
    private int counter = 0;

    private void Start()
    {
        currentTime = 0;
        blendCam.GetComponent<BlendCamera>().enabled = true;
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
        if (blendCam.cameraPositioned)
        {
            if(!cv_gameplay.activeSelf) cv_gameplay.SetActive(true);

            currentTime += Time.deltaTime;
            tmpTime += Time.deltaTime;


            // Non puoi perdere
            //if (!CheckState())
            //{
            //    SceneManager.LoadScene(0);
            //}

            //if (counter >= 5)
            //{
            //stop = true;
            if (atom.WIN)
            {
                
                StartCoroutine(WaitVideo());
                
            }
            //}

            //if (tmpTime >= Random.Range(.5f, 2f) && !stop)
            //{
            //    counter++;

            //    Vector2 orbitPos = ellisse.Evaluate(Random.Range(0f, 1f));
            //    var tmp = Instantiate(neutrino, new Vector3(orbitPos.x, 0, orbitPos.y), Quaternion.identity);
            //    tmp.GetComponent<Neutrino>().enabled = true;
            //    tmpTime = 0;
            //}
        }
    }

    IEnumerator WaitVideo()
    {
        canvas.gameObject.SetActive(true);
        video.Play();
        yield return new WaitForSeconds(4.176f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
