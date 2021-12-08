using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPlayer : MonoBehaviour
{
    TempStats tStats;
    // Start is called before the first frame update
    void Start()
    {
        tStats = new TempStats("Player", 20, 7, 5, 6, 7, 8, 8);
    }

    public void PrintStats()
    {
        Debug.Log(tStats.getName()+" HP: "+tStats.getHP());
    }
    public TempStats getTemptStats()
    {
        return this.tStats;
    }
}
