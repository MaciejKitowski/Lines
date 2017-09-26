using UnityEngine;

public class ExitGame : MonoBehaviour {
    public void Display() {
        Debug.Log("Display Exit Game panel");

        gameObject.SetActive(true);
    }

    public void Hide() {
        Debug.Log("Hide Exit Game panel");

        gameObject.SetActive(false);
    }
}
