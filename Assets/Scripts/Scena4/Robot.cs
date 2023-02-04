using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    public CreaCodice cc;
    public string code;
    private int ind = 0;
    private int count = 0;

    private void Start()
    {
        code = cc.GetCodice();
        Debug.Log(code);
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
            Debug.Log("Vinto");
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
                            Debug.Log(code);
                            ind = 0;
                        }
                    }
                }
            }
            
        }
        
    }
}
