using UnityEngine;
using System.Collections;

public class OffmeshlinkControllerVertical : MonoBehaviour 
{
    public OffmeshlinkDetector detector;
    public OffMeshLink meshUp, meshDown;
    private int ID;

	void Start () 
    {
        detector = gameObject.transform.GetChild(0).gameObject.GetComponent<OffmeshlinkDetector>();
        int.TryParse(gameObject.transform.parent.name, out ID);
	}
	
	void Update () 
    {
        //Generate offmeshlinks
	    if((detector.targetUp.collidedObject != null && meshUp == null) || (detector.targetDown.collidedObject != null && meshDown == null))
        {
            if((ID % 10 == 6) || (ID % 10 == 7) || (ID % 10 == 8) || (ID % 10 == 9) || (ID % 10 == 0))
            {
                if (detector.targetUp.collidedObject != null && meshUp == null) generateOffmesh(ref meshUp, detector.targetUp, 3, 4); //Up
                if (detector.targetDown.collidedObject != null && meshDown == null) generateOffmesh(ref meshDown, detector.targetDown, 4, 3); //Down
            }
        }

        //Reset off mesh links
        if((ID % 10 == 6) || (ID % 10 == 7) || (ID % 10 == 8) || (ID % 10 == 9) || (ID % 10 == 0))
        {
            gameObject.transform.GetChild(3).gameObject.SetActive(false);
            gameObject.transform.GetChild(3).gameObject.SetActive(true);

            gameObject.transform.GetChild(4).gameObject.SetActive(false);
            gameObject.transform.GetChild(4).gameObject.SetActive(true);
        }

        //Destroy detector gameObjects for optimization
        Destroy(detector.colliderUp);
        Destroy(detector.colliderDown);
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
