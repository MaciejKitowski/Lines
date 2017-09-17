using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLost : MonoBehaviour {
    [SerializeField] private GameObject highScoreText;
    [SerializeField] private Text pointsValue;
    [SerializeField] private float highScoreFlickerDelay = 0.5f;

    public void display(int points, bool isHighScore) {
        gameObject.SetActive(true);
        pointsValue.text = points.ToString();
        if (isHighScore) StartCoroutine(newHighScore());
    }

    public void hide() {
        gameObject.SetActive(false);
    }

    private IEnumerator newHighScore() {
        while(this.isActiveAndEnabled) {
            highScoreText.SetActive(!highScoreText.activeInHierarchy);
            yield return new WaitForSeconds(highScoreFlickerDelay);
        }
    }
}
