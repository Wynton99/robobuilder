using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* Tyler Kelley
 *this is entirely for the purposes of working out a combat system where I don't have to worry at all about systems I'm not exactly sure of.
*:MonoBehaviour
*/
public class TempStats
{
    string thingName;
    int maxHp;//this is the theoretical max HP;
    int cHp; //this is real hp;
             /*--> //weapons-stats (total)
              int weap0;
              int weap1;
              int weap2;

               *0=impact;
               *1=piercing;
               *2=energy

               this.weap0 = weap0;
               this.weap1 = weap1;
               this.weap2 = weap2;*/
    int[] weap0;
        //armor stats;
    /*int armor0;
    int armor1;
    int armor2;*/

    int[] armor0;
    /*0=composite;
     * 1=heavy;
     * 2=energy;
     *  this.armor0 = armor0;
        this.armor1 = armor1;
        this.armor2 = armor2;
     * 
     */
  

    public TempStats(string name, int hp, int weap0, int weap1, int weap2, int armor0,int armor1, int armor2)
    {
        this.thingName = name;
        this.maxHp = hp;
        this.cHp = hp;
        this.weap0 = new int[] { weap0, weap1, weap2 }; 
        this.armor0 = new int[] { armor0, armor1, armor2 };
        
    }

    public string getName()
    {
        return this.thingName;
    }

    public string getHP()
    {
        return string.Format("HP:{0}/{1}",cHp,maxHp);
    }
    public bool getDead()
    {
        if (cHp > 0)
        {
            return false;
        }
        else
        {
            return true;
        }

    }

    public int[] getAtks()
    {
        return this.weap0;
    }
    public int[] getDefs()
    {
        return this.armor0;
    }

    public void doDamage(int dmg)//this is the damage!
    {
        if (dmg > 0 && cHp>0)
        {
            this.cHp = this.cHp - dmg;
        }
    }

    public static string attack(TempStats atkr, TempStats defndr)
    {
        /*
            some of this is extremely stupid and messy but so what!
         
         */

        int temp0;
        int temp1;
        int temp2;
        int[] atkrAtks = atkr.getAtks();
        int[] defDef = defndr.getDefs();
        string[] atkTypes = { "impact","piercing","energy" };
        string[] defTypes = { "composite","heavy","energy" };


        //this is what handles the basic calculations that roughly cover "combat" and "combat orientating"-like things.
        string s=string.Format("{0} attacks {1}",atkr.getName(),defndr.getName());


        if (atkr.getDead())//this is because it's funny. people forgetting they're dead and stuff, etc.
        {
            s = s+" but attack fails because they're already dead.";
            return s;
        }
        else
        {
            temp0 = atkrAtks[0] - defDef[0];
            s = s + string.Format("\n{0} -Type Attacks: {1}", atkTypes[0], temp0);

            temp1 = atkrAtks[1] - defDef[1];
            s = s + string.Format("\n{0} -Type Attacks: {1}", atkTypes[1], temp1);

            temp2 = atkrAtks[2] - defDef[2];
            s = s + string.Format("\n{0} -Type Attacks: {1}", atkTypes[2], temp2);

            defndr.doDamage((temp0+temp1+temp2));
        }



        return s;
    }
}

