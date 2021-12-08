using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.Math.Random;

public class ScrapPile : MonoBehaviour
{

    System.Random Rand;
    ArrayList arList;
    GameObject gOb1;
    // Start is called before the first frame update
    void Start()
    {
        gOb1 = GameObject.Find("Arm 1");
        gOb1.SetActive(false);
        arList = new ArrayList();
        arList.Add(GameObject.Find("Leg 5"));
        arList.Add("Nothing");
        arList.Add(GameObject.Find("Leg 4"));
        arList.Add("Nothing");
        arList.Add(GameObject.Find("Leg 3"));
        arList.Add(GameObject.Find("Leg 2"));
        arList.Add(GameObject.Find("Arm 1"));
        arList.Add("Nothing");

        
        Rand = new System.Random();
    }

    public string getRandomNumber()
    {
        int a = Rand.Next(0, 5);

        Debug.Log("A debug log from the random number generator... in this case it's: "+a+"  or "+arList[a].ToString());

        return arList[a].ToString();

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
