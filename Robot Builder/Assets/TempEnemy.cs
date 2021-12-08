using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempEnemy : MonoBehaviour
{
    TempStats tStats;
    // Start is called before the first frame update
    void Start()
    {
        tStats = new TempStats("ENEMY", 15, 4, 4, 3, 7, 5, 5);
    }

    public void PrintStats()
    {
        Debug.Log(tStats.getName() + " HP: " + tStats.getHP());
    }
    public TempStats getTemptStats()
    {
        return this.tStats;
    }
}
