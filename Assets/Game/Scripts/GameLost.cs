using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLost : MonoBehaviour {
    [SerializeField] private GameObject highScoreText;
    [SerializeField] private float highScoreFlickerDelay = 0.5f;

	void Start () {
	}
	
	void Update () {
	}

    private IEnumerator newHighScore() {
        while(this.isActiveAndEnabled) {
            highScoreText.SetActive(!highScoreText.activeInHierarchy);
            yield return new WaitForSeconds(highScoreFlickerDelay);
        }
    }
}
