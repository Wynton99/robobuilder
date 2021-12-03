using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* NOTE THIS IS THE SCRIPT FOR THE SCRAPYARD'S ROLL BUTTON,
 * YES I COULD MAKE IT MORE EFFICIENT BUT I'm not
 
     */

public class ScrapYardThing : MonoBehaviour
{
    public Button btn00;//this is 
    // Start is called before the first frame update
    void Start()
    {
        btn00 = GetComponent<Button>();
        btn00.onClick.AddListener(TaskOnClick);
    }

    public void TaskOnClick()
    {
        //SceneManager.LoadScene(sceneBuildIndex: 1);
        Debug.Log("HA HA HA MESSAGE OUT");
    }

    public void OUTPUTTER()
    {
        
            //SceneManager.LoadScene(sceneBuildIndex: 1);
            Debug.Log("HA HA HA MESSAGE OUT");

    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
