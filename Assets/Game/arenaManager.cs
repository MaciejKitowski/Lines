using UnityEngine;
using System.Collections;

public class arenaManager : MonoBehaviour 
{
    public arenaBlockController[] arenaBlock;

    void Awake()
    {
        arenaBlock = new arenaBlockController[49];
        for (int i = 0; i < 49; ++i) arenaBlock[i] = gameObject.transform.GetChild(i).gameObject.GetComponent<arenaBlockController>();
    }
    
}
