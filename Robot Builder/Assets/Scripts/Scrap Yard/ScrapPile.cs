using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.Math.Random;

public class ScrapPile : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public int getRandomNumber(string strang)
    {
        int bee = Random.Range(0, 1)*100;

        Debug.Log("A debug log from the random number generator... in this case it's: "+bee);
        return 0;

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
