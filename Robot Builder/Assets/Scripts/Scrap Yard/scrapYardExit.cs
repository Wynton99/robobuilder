using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/* NOTE THIS IS THE SCRIPT FOR THE SCRAPYARD'S ROLL BUTTON,
 * YES I COULD MAKE IT MORE EFFICIENT BUT I'm not
 
     */
public class scrapYardExit : MonoBehaviour
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
        SceneManager.LoadScene(sceneBuildIndex: 0);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
