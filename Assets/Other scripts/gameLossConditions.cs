using UnityEngine;
using System.Collections;

public class gameLossConditions : MonoBehaviour
{
	void Update () 
    {
        if (manager.blocks.blockCount() >= 40 && !manager.blocks.checkDestroy()) manager.gameLossPanel.gameObject.SetActive(true);
	}
}
