using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{

    //controls
    public static KeyCode invUI = KeyCode.E;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void backToOpenWorld()
    {
        SceneManager.LoadScene(sceneBuildIndex: 0);
    }

}
