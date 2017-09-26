using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameLost : MonoBehaviour {
    [SerializeField] private GameObject highScoreText;
    [SerializeField] private Text pointsValue;
    [SerializeField] private float highScoreFlickerDelay = 0.5f;

    public void Display(int points, bool isHighScore) {
        Debug.Log("Display Game Lost panel");

        gameObject.SetActive(true);
        pointsValue.text = points.ToString();
        if (isHighScore) StartCoroutine(NewHighScore());
    }

    public void Hide() {
        Debug.Log("Hide Game Lost panel");

        gameObject.SetActive(false);
    }

    public void BackToMenu() {
        Debug.Log("Back to menu");

        StartCoroutine(LoadMainMenuScene());
    }

    private IEnumerator NewHighScore() {
        Debug.Log("Display New High Score text");

        while(this.isActiveAndEnabled) {
            highScoreText.SetActive(!highScoreText.activeInHierarchy);
            yield return new WaitForSeconds(highScoreFlickerDelay);
        }
    }

    private IEnumerator LoadMainMenuScene() {
        Debug.Log("Load Main Menu scene async");

        AsyncOperation async = SceneManager.LoadSceneAsync("MainMenu");
        yield return async;
    }
}
