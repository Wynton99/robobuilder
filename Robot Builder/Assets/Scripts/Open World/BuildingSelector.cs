using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BuildingSelector : MonoBehaviour
{
    public Camera myCam;
    Ray ray; //ray to be used to detect what is inline with the mouse when clicking
    RaycastHit hit; //hit to be used to figure out which collider is hit

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        ray = myCam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonDown(0))
            {
                //print(hit.collider.name);

                //look at build settings to see which index each scene has
                if (hit.collider.name.Equals("Arena"))
                {
                    //print(hit.collider.name);
                    SceneManager.LoadScene(sceneBuildIndex: 1);
                }
                else if (hit.collider.name.Equals("Scrap_Yard"))
                {
                    SceneManager.LoadScene(sceneBuildIndex: 2);
                }
                else if (hit.collider.name.Equals("Shop"))
                {
                    SceneManager.LoadScene(sceneBuildIndex: 3);
                }
                else if (hit.collider.name.Equals("Workshop"))
                {
                    SceneManager.LoadScene(sceneBuildIndex: 4);
                }
                else
                {
                    print("No Building");
                }
            }

        }
    }

}
