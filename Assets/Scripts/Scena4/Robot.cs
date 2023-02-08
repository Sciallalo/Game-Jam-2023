using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class Robot : MonoBehaviour
{
    public CreaCodice cc;
    public string code;
    private int ind = 0;
    private int count = 0;
    public GameObject scatola_aperta;
    public GameObject scatola_chiusa;
    private GameObject tmp_aperta;
    private GameObject tmp_chiusa;
    private bool creato = false;
    private char letter = ' ';
    private char pressed = ' ';

    public AudioSource pressedButton;

    public GameObject cv;
    public GameObject canvas;
    public VideoPlayer video;
    public VideoPlayer livello_prima;
    
    public Transform canvasError;


    private void Start()
    {
        canvasError = GameObject.FindWithTag("CanvasError").transform;

        livello_prima.Stop();
        video.Stop();
        pressedButton.Stop();
        code = cc.GetCodice();

        CreateVisualCode(code);
        
        tmp_aperta = Instantiate(scatola_aperta, new Vector3(0, 0, 0), Quaternion.identity);
    }

    void CreateVisualCode(string code) {
        
        for(int i = 0; i < 4; i++)
        {
            var tmp = code[i];

            switch (tmp)
            {
                case 'd':
                    cv.transform.GetChild(i + 1).GetChild(0).gameObject.SetActive(true);
                    break;
                case 'l':
                    cv.transform.GetChild(i + 1).GetChild(1).gameObject.SetActive(true);
                    break;
                case 'u':
                    cv.transform.GetChild(i + 1).GetChild(2).gameObject.SetActive(true);
                    break;
                case 'r':
                    cv.transform.GetChild(i + 1).GetChild(3).gameObject.SetActive(true);
                    break;
            }
        }
    }

    void ClearVisualCode()
    {
        for(int i = 0; i < 4; i++)
        {
            for(int j = 0; j < 4; j++)
            {
                cv.transform.GetChild(i + 1).GetChild(j).gameObject.SetActive(false);
            }
        }
    }

    char GetKeyPressed()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            return 'd';
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            return 'l';
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            return 'u';
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            return 'r';
        }

        return ' ';
    }

    // Update is called once per frame
    void Update()
    {
        if (count == 3)
        {
            StartCoroutine(WaitVideo());
        }
        else
        {
            if(ind < 4)
            {
                letter = code[ind];
                pressed = GetKeyPressed();
            }

            if(pressed != ' ')
            {
                if(letter != pressed)
                {
                    StartCoroutine(GoBack());
                }

                if(letter == pressed || creato)
                {
                    if (!creato)
                    {
                        ind++;
                        pressedButton.Play();
                    }
                    
                    if(ind == 4)
                    {
                        if (!creato)
                            count++;

                        if(count < 3)
                        {
                            
                            if (!creato)
                            {
                                Destroy(tmp_aperta);
                                tmp_chiusa = Instantiate(scatola_chiusa, new Vector3(0, 0, 0), Quaternion.identity);
                                tmp_aperta = Instantiate(scatola_aperta, new Vector3(-5.5f, 0, 0), Quaternion.identity);
                                ClearVisualCode();
                                creato = true;
                            }
                            else
                            {
                                if(tmp_aperta.transform.position.x <= 0f)
                                {
                                    tmp_chiusa.transform.Translate(Vector3.right * Time.deltaTime * 3f, Space.World);
                                    tmp_aperta.transform.Translate(Vector3.right * Time.deltaTime * 3f, Space.World);
                                }
                                else
                                {
                                    Destroy(tmp_chiusa);
                                    code = cc.GetCodice();
                                    CreateVisualCode(code);
                                    ind = 0;
                                    creato = false;
                                }
                            }
                            
                        }
                    }
                }
            }
            
        }
        
    }

    IEnumerator GoBack()
    {
        canvasError.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(0.8f);
        canvas.gameObject.SetActive(true);
        livello_prima.Play();
        yield return new WaitForSeconds(4.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    IEnumerator WaitVideo()
    {
        canvas.gameObject.SetActive(true);
        video.Play();
        yield return new WaitForSeconds(3.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}