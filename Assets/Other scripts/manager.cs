using UnityEngine;
using System.Collections;

public class manager : MonoBehaviour 
{
    //Animations controller
    public static void displayObject(ref GameObject obj)
    {
        obj.SetActive(true);
        obj.GetComponent<Animator>().SetTrigger("display");
    }

    public static void hideObject(ref GameObject obj)
    {
        obj.GetComponent<Animator>().SetTrigger("hide");
    }

    public static bool readyToHide(ref GameObject obj)
    {
        if (obj.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("readyToHide")) return true;
        else return false;
    }

    public static bool isIdle(ref GameObject obj)
    {
        if (obj.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Idle")) return true;
        else return false;
    }
}
