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
        if (detector.targetRight.collidedObject != null && meshRight == null) generateOffmesh(ref meshRight, detector.targetRight); //Right
        if (detector.targetLeft.collidedObject != null && meshLeft == null) generateOffmesh(ref meshLeft, detector.targetLeft); //Left
        if (detector.targetUp.collidedObject != null && meshUp == null) generateOffmesh(ref meshUp, detector.targetUp); //Up
        if (detector.targetDown.collidedObject != null && meshDown == null) generateOffmesh(ref meshDown, detector.targetDown); //Down

        //Turn off gameobjects for optimization
        detector.targetRight.gameObject.SetActive(false);
        detector.targetLeft.gameObject.SetActive(false);
        detector.targetUp.gameObject.SetActive(false);
        detector.targetDown.gameObject.SetActive(false);
            
	}

    void generateOffmesh(ref OffMeshLink offMesh, colliderDetector Side)
    {
        offMesh = gameObject.AddComponent<OffMeshLink>();
        offMesh.autoUpdatePositions = true;
        offMesh.biDirectional = false;
        offMesh.startTransform = gameObject.transform;
        offMesh.endTransform = Side.collidedObject.transform.GetChild(0).transform;
    }
}
