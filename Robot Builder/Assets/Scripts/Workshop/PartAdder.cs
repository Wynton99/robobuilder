using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartAdder : MonoBehaviour
{

    public GameObject robotContainer; //the container for the robot
    public GameObject inventoryContainer; //the container of the inventory to be use for checking what items are parts
    bool holdingPart; //true if the user is holding a robot part
    GameObject selectedPart; //the part currently selected
    GameObject placeHolderPart; //a place holder for the selectedPart
    public GameObject heldPartSlot; //the gameobject which will hold parts when the player selects them
    public Camera myCam; //the camera for raycasting
    Ray ray; //ray to be used to detect what is inline with the mouse when clicking
    RaycastHit hit; //hit to be used to figure out which collider is hit

    // Start is called before the first frame update
    void Start()
    {
        //initialize holdingPart to false
        holdingPart = false;
        //initialize the selected part to the placeholder part
        placeHolderPart = new GameObject();
        selectedPart = placeHolderPart;
    }

    // Update is called once per frame
    void Update()
    {

        ray = myCam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (holdingPart) //there is a part to be placed on the core
                {
                    if (hit.collider.name.Contains("Connector_In")) //the player has clicked on a connector
                    {
                        //enstantiate the part into the position of the targeted node and scale properly
                        GameObject placedPart = Instantiate(selectedPart.gameObject, hit.collider.transform.position, hit.collider.transform.rotation);
                        placedPart.transform.localScale = new Vector3(placedPart.transform.localScale.x, placedPart.transform.localScale.y * -1, placedPart.transform.localScale.z);
                        //move the part to be a child of the core
                        placedPart.transform.parent = robotContainer.transform;
                        placedPart.gameObject.GetComponent<Collider>().enabled = false;

                        //clear the held part slot
                        foreach (Transform item in heldPartSlot.transform)
                        {
                            Destroy(item.gameObject);
                        }
                        //reset the selected part
                        selectedPart = placeHolderPart;
                        holdingPart = false;
                    }
                }
                else //the user has not picked up a part yet
                {
                    if (hit.collider.gameObject.transform.parent.gameObject.name.Equals(inventoryContainer.name)) //the player has selected a part within inventory
                    {
                        //clear the held part slot
                        foreach (Transform item in heldPartSlot.transform)
                        {
                            Destroy(item.gameObject);
                        }

                        //enstantiate the part into the position of the heldPartSlot
                        selectedPart = Instantiate(hit.collider.gameObject, heldPartSlot.transform.position, heldPartSlot.transform.rotation);
                        //move the part to be a child of the UI canvas
                        selectedPart.transform.parent = heldPartSlot.transform;
                        holdingPart = true;
                    }
                }
            }
        }

    }
}
