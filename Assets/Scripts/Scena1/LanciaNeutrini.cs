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
    public bool stop = false;

    private void Start()
    {
        blendCam.GetComponent<BlendCamera>().enabled = true;
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

            if (atom.WIN)
            {
                
                StartCoroutine(WaitVideo());
                
            }
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
