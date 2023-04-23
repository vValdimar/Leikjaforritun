using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Daudi : MonoBehaviour
{
    public Transform leikmadur;
    //public Canvas konni;
    
    void Update()
    {
        //Debug.Log("halló");
        if (transform.position.y<=-6)
        {
           SceneManager.LoadScene(1);//byrja á byrjun ef leikmaður fellur fram af brún eða í vatnið
        }
    }
}
