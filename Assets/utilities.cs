using UnityEngine;
using System.Collections;

public class utilities : MonoBehaviour 
{
    virtual public void setActive(bool state)
    {
        gameObject.SetActive(state);
        if (state) Debug.Log("Display: " + gameObject.name);
        else Debug.Log("Hide: " + gameObject.name);
    }
}
