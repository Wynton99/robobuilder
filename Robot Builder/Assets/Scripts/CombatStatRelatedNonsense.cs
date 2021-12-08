using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*Programmed by: TYLER KELLEY
 *
 *This is code designed to do some basic stuff with regards to combat.
 * I think there were a great many errors in communication.
 * 
 * I Am Literally not referencing any of the other code because nobody has bothered commenting on it.
 * 
 */
public class CombatStatRelatedNonsense : MonoBehaviour
{

    /*I HONESTLY DOUBT YOU WILL READ THIS, PLEASE SPEI*/

    // Start is called before the first frame update

    //TempStats pStats;
    public Button atkbtn;//okay by setting this public I don't actually need it to be referenced at all apparently I can assign this from the in game gui, might not be "secure" but I like it!
    //Button quitButton;
    //GetComponent<TMPro.TextMeshProUGUI>().text
    public TMPro.TextMeshProUGUI PLabel0, PLabel1, ELabel0, ELabel1, Outptr;

    TempPlayer pStats;
    TempEnemy tEnemy;
    void Start()
    {
       // atkbtn = GetComponentInChildren<Button>();
        atkbtn.onClick.AddListener(TaskOnClick);
        
        //pStats = GetComponent<TempStats>();
        pStats = GetComponentInChildren<TempPlayer>();
        tEnemy = GetComponentInChildren<TempEnemy>();
    }
    /*
    private void quitBtn()
    {
        Debug.Log("QUIT!"); 
    }*/

    private void TaskOnClick()
    {
        Debug.Log("test");
        //Debug.Log(pStats.getName()+" , "+pStats.getHP());
        pStats.PrintStats();
        tEnemy.PrintStats();
        Outptr.SetText(TempStats.attack(pStats.getTemptStats(), tEnemy.getTemptStats()));
        PLabel0.SetText(pStats.getTemptStats().getHP(),true);
        ELabel0.SetText(tEnemy.getTemptStats().getHP(), true);
    }

    private void OnGUI()
    {
        PLabel0.SetText(pStats.getTemptStats().getHP(), true);
        ELabel0.SetText(tEnemy.getTemptStats().getHP(), true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
