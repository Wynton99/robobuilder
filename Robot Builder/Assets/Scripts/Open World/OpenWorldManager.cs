using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenWorldManager : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        /*this adds a basic fucntion that allows for the game to know*/
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
