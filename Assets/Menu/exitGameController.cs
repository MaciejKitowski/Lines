using UnityEngine;
using System.Collections;

public class exitGameController : MonoBehaviour 
{
    public bool active;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Back button");
            setActive(false);
        }
    }
	
    public void setActive(bool status)
    {
        active = status;
        gameObject.SetActive(status);
    }

    public void button_Yes()
    {
        Debug.Log("Yes button");
        Application.Quit();
    }

    public void button_No()
    {
        Debug.Log("No button");
        setActive(false);
    }
}
