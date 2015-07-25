using UnityEngine;
using System.Collections;

public class arenaColliderController : MonoBehaviour 
{
    public GameObject collidedArena;

	void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.tag == "Arena block") collidedArena = obj.gameObject;
    }
}
