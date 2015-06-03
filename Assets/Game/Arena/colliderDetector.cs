using UnityEngine;
using System.Collections;

public class colliderDetector : MonoBehaviour 
{
    public GameObject collidedObject;

    void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.tag == "Arena block") collidedObject = obj.gameObject;
    }
}
