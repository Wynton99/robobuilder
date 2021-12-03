using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InventoryItem : MonoBehaviour
{
    public GameObject InventoryPrefab; //the prefab which represents this object in the inventory
    public string InvObjName; //the name of this object for the inventory UI
    public int InvID; //the ID of this object for use in the inventory

    public GameObject InGameManager; //InGameManager object
    private PlayerInventroy PlayerInventoryScript; //the script that controls the inventory (atatched to the InGameManager)

    // Start is called before the first frame update
    void Start()
    {
        PlayerInventoryScript = InGameManager.GetComponent<PlayerInventroy>(); //make an instance of the player inventory script
        System.Random myRandom = new System.Random(); //create random number for the ID
        //the ID cannot be zero, or it will not be identified as an inventory object
        InvID = myRandom.Next(1,1000); //set the id to a random number with a range of 999 (lower bound is included, upper bound is excluded)
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        /*
         * Handles collision for non-trigger coliders (see OnTriggerEnter)
         * Adds this objects inventory item prefab to the player inventory array as a gameobject
         * Adds the ID of this object to the player inventory id array
         * Uses the player inventory script to render the new object in the inventory UI and passes the name
         * Set this instance of the object to inactive
         */
        if (collision.gameObject.name == "Player") {
            PlayerInventoryScript.PlayerInventory.Add(InventoryPrefab);
            PlayerInventoryScript.PlayerInvIDs.Add(InvID);
            PlayerInventoryScript.AddToInventory(InvObjName);
            gameObject.SetActive(false);
            //Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        /*
         * Handles collision for trigger coliders (see OnCollisionEnter)
         * Adds this objects inventory item prefab to the player inventory array as a gameobject
         * Adds the ID of this object to the player inventory id array
         * Uses the player inventory script to render the new object in the inventory UI and passes the name
         * Set this instance of the object to inactive
         */
        if (collider.gameObject.name == "Player")
        {
            PlayerInventoryScript.PlayerInventory.Add(InventoryPrefab);
            PlayerInventoryScript.PlayerInvIDs.Add(InvID);
            PlayerInventoryScript.AddToInventory(InvObjName);
            gameObject.SetActive(false);
            //Destroy(gameObject);
        }
    }
}
