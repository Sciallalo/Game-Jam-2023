using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Formats.Alembic.Importer;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Dog_behaviour : MonoBehaviour
{
    [SerializeField] float MAX_x = 25.0f;
    [SerializeField] float MIN_x = -19.0f;
    [SerializeField] float movement_x = 4f;
    [SerializeField] GameObject splash;
    [SerializeField] GameObject water;
    [SerializeField] float increment =0.01f;
    [SerializeField] float time = 1.958333f;
    [SerializeField] AlembicStreamPlayer pianta;

    public Canvas canvas;
    public VideoPlayer video;
    public GameObject manager;

    private float current_x;
    private float target;

    public float percentage = 0;

    // Start is called before the first frame update
    void Start()
    {
        target= Random.Range(MIN_x, MAX_x);
    }

    // Update is called once per frame
    void Update()
    {
        current_x = transform.position.x;

        if ((int) current_x != (int) target)
        {
            if (current_x > target && current_x > MIN_x)
            {
                 transform.position += new Vector3(-movement_x, 0, 0) * Time.deltaTime;
            }

            else if (current_x < MAX_x)
            {
                transform.position += new Vector3(movement_x, 0, 0) * Time.deltaTime;
            }
        }
        else { target = Random.Range(MIN_x, MAX_x); }

        if (percentage >= time)
        {
            Debug.Log("you win");
            StartCoroutine(WaitWin());
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        splash.SetActive(true);
        water.SetActive(false);
    }
    private void OnTriggerExit(Collider other)
    {
        splash.SetActive(false);
        water.SetActive(true);
    }

    private void OnTriggerStay(Collider other)
    {
        percentage += increment * Time.deltaTime;
        pianta.UpdateImmediately(percentage);
        
    }

    IEnumerator WaitWin()
    {
        manager.SetActive(false);
        canvas.gameObject.SetActive(true);
        video.Play();
        yield return new WaitForSeconds(4.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
