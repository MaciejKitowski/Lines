using UnityEngine;
using System.Collections;

public class OffmeshlinkController : MonoBehaviour 
{
    public OffmeshlinkDetector detector;
    public OffMeshLink meshLeft, meshRight, meshUp, meshDown;
	
	void Start () 
    {
        detector = gameObject.transform.GetChild(0).gameObject.GetComponent<OffmeshlinkDetector>();
	}
	
	void Update () 
    {
        //Generate offmeshlinks
        //Right
        if (detector.targetRight.collidedObject != null && meshRight == null)
        {
            meshRight = gameObject.AddComponent<OffMeshLink>();

            meshRight.autoUpdatePositions = true;
            meshRight.biDirectional = false;
            meshRight.startTransform = gameObject.transform;
            meshRight.endTransform = detector.targetRight.collidedObject.transform.GetChild(0).transform;
        }

        //Left
        if (detector.targetLeft.collidedObject != null && meshLeft == null)
        {
            meshLeft = gameObject.AddComponent<OffMeshLink>();

            meshLeft.autoUpdatePositions = true;
            meshLeft.biDirectional = false;
            meshLeft.startTransform = gameObject.transform;
            meshLeft.endTransform = detector.targetLeft.collidedObject.transform.GetChild(0).transform;
        }

        //Up
        if (detector.targetUp.collidedObject != null && meshUp == null)
        {
            meshUp = gameObject.AddComponent<OffMeshLink>();

            meshUp.autoUpdatePositions = true;
            meshUp.biDirectional = false;
            meshUp.startTransform = gameObject.transform;
            meshUp.endTransform = detector.targetUp.collidedObject.transform.GetChild(0).transform;
        }

        //Down
        if (detector.targetDown.collidedObject != null && meshDown == null)
        {
            meshDown = gameObject.AddComponent<OffMeshLink>();

            meshDown.autoUpdatePositions = true;
            meshDown.biDirectional = false;
            meshDown.startTransform = gameObject.transform;
            meshDown.endTransform = detector.targetDown.collidedObject.transform.GetChild(0).transform;
        }
	}
}
