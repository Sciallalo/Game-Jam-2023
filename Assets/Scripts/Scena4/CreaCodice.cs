using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreaCodice : MonoBehaviour
{
    //Ad Bl Cu Dr
    Dictionary<int, string> permutazioni  = new Dictionary<int, string>(){
        {1,"dlur"}, {2,"ldur"}, {3,"udlr"}, {4,"rdlu"},
        {5,"dulr"}, {6,"ludr"}, {7,"uldr"}, {8,"rdul"},
        {9,"durl"}, {10,"lrdu"}, {11,"urdl"}, {12,"rudl"}
    };

    public string GetCodice()
    {
        int ind = UnityEngine.Random.Range(1, 12);

        return permutazioni[ind];
    }
}
