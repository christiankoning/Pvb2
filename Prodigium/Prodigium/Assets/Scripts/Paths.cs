using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paths : MonoBehaviour {

    public GameObject PathToLevel1;
    public GameObject PathToLevel2;
    public GameObject PathToBoss;
    public int DungeonCompleted;

    void Update()
    {
        CheckDungeon();
    }

    void CheckDungeon()
    {
        if (DungeonCompleted == 0)
        {
            PathToLevel1.SetActive(true);
        }

        else if (DungeonCompleted == 1)
        {
            PathToLevel1.SetActive(false);
            PathToLevel2.SetActive(true);
        }

        else if (DungeonCompleted == 2)
        {
            PathToLevel1.SetActive(false);
            PathToLevel2.SetActive(false);
            PathToBoss.SetActive(true);
        }
    }
}
