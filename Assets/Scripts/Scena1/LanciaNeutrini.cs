using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class LanciaNeutrini : MonoBehaviour
{
    [SerializeField] BlendCamera blendCam;

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
            currentTime += Time.deltaTime;
            tmpTime += Time.deltaTime;

            if (!CheckState())
            {
                SceneManager.LoadScene(0);
            }

            if (counter >= 5)
            {
                stop = true;
                canvas.gameObject.SetActive(true);
                video.Play();
                StartCoroutine(WaitVideo());
            }

            if (tmpTime >= Random.Range(.5f, 2f) && !stop)
            {
                counter++;

                Vector2 orbitPos = ellisse.Evaluate(Random.Range(0f, 1f));
                var tmp = Instantiate(neutrino, new Vector3(orbitPos.x, 0, orbitPos.y), Quaternion.identity);
                tmp.GetComponent<Neutrino>().enabled = true;
                tmpTime = 0;
            }
        }
    }

    IEnumerator WaitVideo()
    {
        yield return new WaitForSeconds(4.176f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
