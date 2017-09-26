using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour {
    [SerializeField] private int pointsPerRow = 15;
    [SerializeField] private int extraTilesMultiplier = 2;
    [SerializeField] private TileSpawner _spawner;
    [SerializeField] private GameLost lostPanel;
    [SerializeField] private ExitGame exitPanel;
    [SerializeField] private Text pointsText;
    private int points = 0;

    public TileSpawner spawner { get { return _spawner; } }

    void Start() {
        Debug.Log("Loaded scene Game");
        NewGame();
    }

    void Update () {
        if (Input.GetButtonDown("Cancel")) exitPanel.Display();

        if (Input.GetKeyDown(KeyCode.Alpha0)) AddPoints();
        else if (Input.GetKeyDown(KeyCode.Alpha1)) AddPoints(1);
        else if (Input.GetKeyDown(KeyCode.Alpha2)) AddPoints(2);
        else if (Input.GetKeyDown(KeyCode.L)) GameLost();
        else if (Input.GetKeyDown(KeyCode.H)) lostPanel.Hide();
        else if (Input.GetKeyDown(KeyCode.E)) exitPanel.Display();
        else if (Input.GetKeyDown(KeyCode.R)) exitPanel.Hide();
    }

    public void NewGame() {
        spawner.RandNewTiles();
        points = 0;
        pointsText.text = points.ToString();
        GameObject.FindGameObjectWithTag("Arena").GetComponent<Arena>().removeAllTiles();
        lostPanel.Hide();
        exitPanel.Hide();
        spawner.Spawn();
    }

    public void AddPoints(int extraTiles = 0) {
        int pointsToAdd = 0;

        if (extraTiles == 0) pointsToAdd = pointsPerRow;
        else pointsToAdd = extraTiles * extraTilesMultiplier * pointsPerRow;

        Debug.Log(string.Format("Add {0} points with {1} extra tiles.", pointsToAdd, extraTiles));
        points += pointsToAdd;

        pointsText.text = points.ToString();
    }

    public void GameLost() {
        Debug.Log("Game Lost");

        lostPanel.Display(points, false);
    }
}
