using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameVersion : MonoBehaviour 
{
    private static string gameVersion = "0.2.4.6 pre-alpha";
    private static string lastUpdateTime = "06.04.2015";

    private Text versionText;

	void Start () 
    {
        versionText = gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
        versionText.text = gameVersion;
	}

    public static string getVersion()
    {
        return gameVersion;
    }

    public static string getLastUpdate()
    {
        return lastUpdateTime;
    }
}
