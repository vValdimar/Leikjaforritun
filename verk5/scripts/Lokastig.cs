using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Lokastig : MonoBehaviour
{
    public static int stigValue;
    public TextMeshProUGUI stig;
    // Start is called before the first frame update
    void Start()
    { 
        stig.text = "Stig: " + stigValue.ToString();
    }

    
}
