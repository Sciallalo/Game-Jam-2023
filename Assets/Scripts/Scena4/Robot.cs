using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Robot : MonoBehaviour
{
    public CreaCodice cc;
    public Text text;
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

    private void Start()
    {
        pressedButton.Stop();

        code = cc.GetCodice();
        text.text = code.ToUpper();
        tmp_aperta = Instantiate(scatola_aperta, new Vector3(0, 0, 0), Quaternion.identity);
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
            SceneManager.LoadScene(0);
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
                                text.text = "";
                                creato = true;
                            }
                            else
                            {
                                if(tmp_aperta.transform.position.x <= 0f)
                                {
                                    tmp_chiusa.transform.Translate(Vector3.right * Time.deltaTime, Space.World);
                                    tmp_aperta.transform.Translate(Vector3.right * Time.deltaTime, Space.World);
                                }
                                else
                                {
                                    Destroy(tmp_chiusa);
                                    code = cc.GetCodice();
                                    text.text = code.ToUpper();
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
}