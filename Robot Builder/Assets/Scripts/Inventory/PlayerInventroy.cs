using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerInventroy : MonoBehaviour
{
    public Canvas InventoryUICanvas; //the canvas on which the inventory is rendered
    public GameObject InventoryContainer; //the container which holds the display objects in the inventory
    public List<GameObject> PlayerInventory = new List<GameObject>(); //the objects the inventory
    public List<int> PlayerInvIDs = new List<int>(); //the ids of the objects in PlayerInventory (for using and deleting inventory objects)
    public Vector3 InvObjLocation; //the first grid location for the objects in the UI
    public int InvObjGapSize; //distance between the objects in the UI
    public int TextGapSize; //distance from object to text
    private int RenderedInventory = 0; //number of inventory items enstantiated in the UI


    //managers get initialized in the start method
    public GameObject MainManager; //the MainManager Object
    private MainManager MainManagerScript; //the MainManager Script attached to the MainManager Object
    public GameObject OpenWorldManager; //the Open World Manager Object

    // Start is called before the first frame update
    void Start()
    {
        //initialize the managers
        MainManagerScript = MainManager.GetComponent<MainManager>(); //make an instance of the MainManager script

        //initialize the canvases to start off
        InventoryUICanvas.enabled = false; //the inventory UI is enabled by default and must be turned off first
        InventoryContainer.SetActive(false); //the inventory container is active by default and must be turned off first

        //populate the starting inventory
        DisplayInitialInventory();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !InventoryUICanvas.isActiveAndEnabled || SceneManager.GetActiveScene().name.Equals("Workshop"))  //if 'E' is pressed and another UI is disabled
        {
            InventoryUICanvas.enabled = !InventoryUICanvas.enabled; //toggle the canvas
            InventoryContainer.SetActive(true); //activate the inventory container
        } else if (Input.GetKeyDown(KeyCode.E)) //if 'E' is pressed and another UI is enabled
        {
            InventoryUICanvas.enabled = false; //disable the canvas
            InventoryContainer.SetActive(false); //deactivate the inventory container
        }
        
    }

    public void DisplayInitialInventory()
    {
        /*
         * Creates all the starting inventory items using AddToInventory (for preset or saved inventory)
         * Warning: calling this method will duplicated the entire iventory
         * Only call on start
         */
        for (int i = 0; i < PlayerInventory.Count; i++)
        {
            AddToInventory(PlayerInventory[i].name);
        }
    }

    public void AddToInventory(string myName)
    {
        /*
         * Enstantiates the inventory item with the index equal to the number of inventory objects rendered (RenderedInventory)
         * Uses InvObjectLocation and GetGridPosition() to place the item
         * Uses passed parameters and LocateText() to place the name under the inventory object in the UI
         * Sets the text properties
         * Sets all of the objects as children of the canvas and inventory container
         * Sets all of the objects to layer 5: the UI layer
         * Incriments RenderedInventory
         */
        GameObject newInventoryObject = Instantiate(PlayerInventory[RenderedInventory], InventoryContainer.transform.position, Quaternion.identity);
        //create text under the object
        GameObject newText = new GameObject("text", typeof(RectTransform));
        var myNameText = newText.AddComponent<Text>();
        myNameText.text = myName;
        Text InvObjNameText = Instantiate(myNameText, InventoryUICanvas.transform.position, Quaternion.identity) as Text;
        //set text properties
        InvObjNameText.rectTransform.sizeDelta = new Vector2(300, 100);
        InvObjNameText.alignment = TextAnchor.MiddleCenter;
        InvObjNameText.color = Color.black;
        InvObjNameText.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        InvObjNameText.fontSize = 28;
        //set the parent of the object to be the Inventory UI canvas
        newInventoryObject.transform.parent = InventoryContainer.transform;
        InvObjNameText.transform.SetParent(InventoryUICanvas.transform, true);
        //set the layer of the object and its children to UI layer (layer index is 5)
        newInventoryObject.layer = 5;
        InvObjNameText.gameObject.layer = 5;
        InvObjNameText.transform.localScale = new Vector3(1, 1, 1);
        var childrenArray = newInventoryObject.GetComponentsInChildren<Transform>();
        for (int i = 0; i < childrenArray.Length; i++)
        {
            childrenArray[i].gameObject.layer = 5;
        }
        //correct the object's position
        newInventoryObject.transform.localPosition = (GetGridPosition(RenderedInventory));
        InvObjNameText.transform.localPosition = (LocateText(RenderedInventory));
        //incriment RenderedInventory
        RenderedInventory++;
    }

    public void RemoveFromInventory(int invID)
    {
        /*
         * Removes an item from the inventory using its ID
         */
        for (int i = 0; i < PlayerInventory.Count; i++)
        {
            if (PlayerInvIDs.Count == i + 1)
            {
                if (PlayerInvIDs[i] == invID)
                {
                    //Working on writing method to remove rendered inv item
                    //Destroy(PlayerInventory[i]);
                    //PlayerInventory.RemoveAt(i);
                }
            }
        }
    }

    public Vector3 GetGridPosition(int ObjNum)
    {
        /*
         * Gets the position of the next inventory object using InvObjLocation and adding its order in the inventory multiplied by InvObjGapSize
         */
        Vector3 myVector3 = InvObjLocation; //copy the InvObjLocation vector3
        myVector3.x += ObjNum * InvObjGapSize; //update the vector3 with the new location
        return myVector3; //pass the corrected vector3
    }

    public Vector3 LocateText(int ObjNum)
    {
        /*
         * simply modifies the location of the object to which the text corisponds so that it sits right below it
         */
        Vector3 myVector3 = GetGridPosition(ObjNum);
        myVector3.y -= TextGapSize;
        return myVector3;
    }


}
