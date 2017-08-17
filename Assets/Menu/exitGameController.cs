using UnityEngine;
using System.Collections;

public class exitGameController : utilities 
{
    public bool active;

    void Start() { setActive(false); }
    void Update() { if (Input.GetKeyDown(KeyCode.Escape)) setActive(false); }

    override public void setActive(bool state)
    {
        active = state;
        gameObject.SetActive(state);
    }

    public void button_Yes() { Application.Quit(); }
    public void button_No() { setActive(false); }
}
