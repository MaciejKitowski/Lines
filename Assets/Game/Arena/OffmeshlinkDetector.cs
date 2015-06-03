using UnityEngine;
using System.Collections;

public class OffmeshlinkDetector : MonoBehaviour 
{
    public GameObject colliderLeft, colliderRight, colliderUp, colliderDown;
    public colliderDetector targetLeft, targetRight, targetUp, targetDown;
	
	void Start () 
    {
        colliderRight = gameObject.transform.GetChild(0).gameObject;
        colliderLeft = gameObject.transform.GetChild(1).gameObject;
        colliderUp = gameObject.transform.GetChild(2).gameObject;
        colliderDown = gameObject.transform.GetChild(3).gameObject;

        targetRight = colliderRight.GetComponent<colliderDetector>();
        targetLeft = colliderLeft.GetComponent<colliderDetector>();
        targetUp = colliderUp.GetComponent<colliderDetector>();
        targetDown = colliderDown.GetComponent<colliderDetector>();
	}

    void Update()
    {
        //Destroy OffmeshlinkDetector and disable gameObject for optimization
        if (gameObject.transform.childCount == 0)
        {
            Destroy(gameObject.GetComponent<OffmeshlinkDetector>());
            gameObject.SetActive(false);
        }
    }
}
