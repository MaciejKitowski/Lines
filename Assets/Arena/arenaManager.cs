using UnityEngine;
using System.Collections;

public class arenaManager : MonoBehaviour 
{
    public arenaBlock [] arenaBlock;
	
	void Awake () 
    {
        arenaBlock = new arenaBlock[40];

        for (int i = 0; i < 40; i++) arenaBlock[i] = gameObject.transform.GetChild(i).gameObject.GetComponent<arenaBlock>();
	}
}
