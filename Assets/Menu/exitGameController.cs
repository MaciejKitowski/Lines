using UnityEngine;
using System.Collections;

public class exitGameController : MonoBehaviour 
{
    public bool active;

    void Start()
    {
        setActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) setActive(false);
    }
	
    public void setActive(bool status)
    {
        active = status;
        gameObject.SetActive(status);
        Debug.Log("Display exit game - " + status);
    }

    public void button_Yes() { Application.Quit(); }
    public void button_No() { setActive(false); }
}
