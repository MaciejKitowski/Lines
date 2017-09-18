using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameLost : MonoBehaviour {
    [SerializeField] private GameObject highScoreText;
    [SerializeField] private Text pointsValue;
    [SerializeField] private float highScoreFlickerDelay = 0.5f;

    public void display(int points, bool isHighScore) {
        Debug.Log("Display Game Lost panel");

        gameObject.SetActive(true);
        pointsValue.text = points.ToString();
        if (isHighScore) StartCoroutine(newHighScore());
    }

    public void hide() {
        Debug.Log("Hide Game Lost panel");

        gameObject.SetActive(false);
    }

    private IEnumerator newHighScore() {
        Debug.Log("Display New High Score text");

        while(this.isActiveAndEnabled) {
            highScoreText.SetActive(!highScoreText.activeInHierarchy);
            yield return new WaitForSeconds(highScoreFlickerDelay);
        }
    }
}
