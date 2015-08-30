using UnityEngine;
using System.Collections;

public class displayDebugMenu : MonoBehaviour 
{
	void OnMouseDown()
    {
        if (!gameManager.debugMenu.active) gameManager.debugMenu.setActive(true);
    }
}
