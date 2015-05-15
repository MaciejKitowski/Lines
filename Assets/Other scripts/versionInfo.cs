using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class versionInfo : MonoBehaviour 
{
    public string gameVersion;
    Text text;
	
	void Start () 
    {
        text = gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
        text.text = gameVersion;
	}
}
