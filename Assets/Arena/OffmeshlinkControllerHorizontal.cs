using UnityEngine;
using System.Collections;

public class OffmeshlinkControllerHorizontal : MonoBehaviour 
{
    public OffmeshlinkDetector detector;
    public OffMeshLink meshLeft, meshRight;
    private int ID;
    
	void Start () 
    {
        detector = gameObject.transform.GetChild(0).gameObject.GetComponent<OffmeshlinkDetector>();
        int.TryParse(gameObject.transform.parent.name, out ID);
	}

	void Update () 
    {
        //Generate offmeshlinks
        if (detector.targetRight.collidedObject != null && meshRight == null && ((ID % 5 == 2) || (ID % 5 == 4))) generateOffmesh(ref meshRight, detector.targetRight, 1, 2); //Right
        if (detector.targetLeft.collidedObject != null && meshLeft == null && ((ID % 5 == 2) || (ID % 5 == 4))) generateOffmesh(ref meshLeft, detector.targetLeft, 2, 1); //Left

        //Reset off mesh links
        if (((ID % 5 == 2) || (ID % 5 == 4)))
        {
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
            gameObject.transform.GetChild(1).gameObject.SetActive(true);

            gameObject.transform.GetChild(2).gameObject.SetActive(false);
            gameObject.transform.GetChild(2).gameObject.SetActive(true);
        }

        //Destroy detector gameObjects for optimization
        Destroy(detector.colliderRight);
        Destroy(detector.colliderLeft);
	}

    private void generateOffmesh(ref OffMeshLink offMesh, colliderDetector Side, int startPos, int endPos)
    {
        offMesh = gameObject.transform.GetChild(startPos).gameObject.AddComponent<OffMeshLink>();
        offMesh.autoUpdatePositions = true;
        offMesh.biDirectional = true;
        offMesh.startTransform = gameObject.transform.GetChild(startPos).gameObject.transform;
        offMesh.endTransform = Side.collidedObject.transform.GetChild(0).gameObject.transform.GetChild(endPos).transform;
    }
}
