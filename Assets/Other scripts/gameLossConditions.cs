using UnityEngine;
using System.Collections;

public class gameLossConditions : MonoBehaviour
{
	void Update () 
    {
        if (gameManager.BlockManager().blockCount() >= 40 && !gameManager.BlockManager().checkDestroy() && !gameManager.GameLossPanel().active) gameManager.GameLossPanel().display();
	}
}
