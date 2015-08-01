using UnityEngine;
using System.Collections;

public class displayDebugMenu : MonoBehaviour 
{
	void OnMouseDown()
    {
        if (!Manager.debugMenu.active) Manager.debugMenu.setActive(true);
    }
}
