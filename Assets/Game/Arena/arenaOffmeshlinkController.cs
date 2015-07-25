using UnityEngine;
using System.Collections;

public class arenaOffmeshlinkController : MonoBehaviour 
{
    private arenaColliderController colRight, colLeft, colUp, colDown;
    private GameObject offMeshRight, offMeshLeft, offMeshUp, offMeshDown;
	
	void Start()
    {
        offMeshRight = gameObject.transform.GetChild(0).gameObject;
        offMeshLeft = gameObject.transform.GetChild(1).gameObject;
        offMeshUp = gameObject.transform.GetChild(2).gameObject;
        offMeshDown = gameObject.transform.GetChild(3).gameObject;

        colRight = gameObject.transform.GetChild(4).gameObject.transform.GetChild(0).gameObject.GetComponent<arenaColliderController>();
        colLeft = gameObject.transform.GetChild(4).gameObject.transform.GetChild(1).gameObject.GetComponent<arenaColliderController>();
        colUp = gameObject.transform.GetChild(4).gameObject.transform.GetChild(2).gameObject.GetComponent<arenaColliderController>();
        colDown = gameObject.transform.GetChild(4).gameObject.transform.GetChild(3).gameObject.GetComponent<arenaColliderController>();
    }

    void Update()
    {
        if (colRight != null || colLeft != null || colUp != null || colDown != null) setOffmeshLinks();
    }

	private void setOffmeshLinks()
    {
        if (colRight.collidedArena != null) createOffMesh(ref offMeshRight, ref colRight, 1);
        else Destroy(offMeshRight);

        if (colLeft.collidedArena != null) createOffMesh(ref offMeshLeft, ref colLeft, 0);
        else Destroy(offMeshLeft);

        if (colUp.collidedArena != null) createOffMesh(ref offMeshUp, ref colUp, 3);
        else Destroy(offMeshUp);

        if (colDown.collidedArena != null) createOffMesh(ref offMeshDown, ref colDown, 2);
        else Destroy(offMeshDown);

        Destroy(colRight.gameObject);
        Destroy(colLeft.gameObject);
        Destroy(colUp.gameObject);
        Destroy(colDown.gameObject);

    }

    private void createOffMesh(ref GameObject obj, ref arenaColliderController target, int targetChildNumber)
    {
        obj.AddComponent<OffMeshLink>();
        OffMeshLink buffer = obj.GetComponent<OffMeshLink>();

        buffer.autoUpdatePositions = true;
        buffer.biDirectional = false;
        buffer.startTransform = obj.transform;
        buffer.endTransform = target.collidedArena.transform.GetChild(0).gameObject.transform.GetChild(targetChildNumber).gameObject.transform;
    }
}
