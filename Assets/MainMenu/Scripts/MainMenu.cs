using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public void NewGame() {
        Debug.Log("Start New Game");

        StartCoroutine(LoadGameScene());
    }

    public void ExitGame() {
        Application.Quit();
    }

    private IEnumerator LoadGameScene() {
        Debug.Log("Load Game scene async");

        AsyncOperation async = SceneManager.LoadSceneAsync("Game");
        yield return async;
    }
}
