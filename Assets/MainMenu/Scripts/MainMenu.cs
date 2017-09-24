using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public void newGame() {
        Debug.Log("Start New Game");

        StartCoroutine(loadGameScene());
    }

    public void exitGame() {
        Application.Quit();
    }

    private IEnumerator loadGameScene() {
        Debug.Log("Load Game scene async");

        AsyncOperation async = SceneManager.LoadSceneAsync("Game");
        yield return async;
    }
}
