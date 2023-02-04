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

    private void Start()
    {
        code = cc.GetCodice();
        text.text = code.ToUpper();
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
        if(count == 3)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            char letter = code[ind];

            char pressed = GetKeyPressed();

            if(pressed != ' ')
            {
                if(letter == pressed)
                {
                    ind++;
                    
                    if(ind == 4)
                    {
                        count++;

                        if(count < 3)
                        {
                            code = cc.GetCodice();
                            text.text = code.ToUpper();
                            ind = 0;
                        }
                    }
                }
            }
            
        }
        
    }
}
