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
        newGame();
    }

    void Update () {
        if (Input.GetButtonDown("Cancel")) exitPanel.display();

        if (Input.GetKeyDown(KeyCode.Alpha0)) addPoints();
        else if (Input.GetKeyDown(KeyCode.Alpha1)) addPoints(1);
        else if (Input.GetKeyDown(KeyCode.Alpha2)) addPoints(2);
        else if (Input.GetKeyDown(KeyCode.L)) gameLost();
        else if (Input.GetKeyDown(KeyCode.H)) lostPanel.hide();
        else if (Input.GetKeyDown(KeyCode.E)) exitPanel.display();
        else if (Input.GetKeyDown(KeyCode.R)) exitPanel.hide();
    }

    public void newGame() {
        spawner.randNewTiles();
        points = 0;
        pointsText.text = points.ToString();
        GameObject.FindGameObjectWithTag("Arena").GetComponent<Arena>().removeAllTiles();
        lostPanel.hide();
        spawner.spawn();
    }

    public void addPoints(int extraTiles = 0) {
        int pointsToAdd = 0;

        if (extraTiles == 0) pointsToAdd = pointsPerRow;
        else pointsToAdd = extraTiles * extraTilesMultiplier * pointsPerRow;

        Debug.Log(string.Format("Add {0} points with {1} extra tiles.", pointsToAdd, extraTiles));
        points += pointsToAdd;

        pointsText.text = points.ToString();
    }

    public void gameLost() {
        Debug.Log("Game Lost");

        lostPanel.display(points, false);
    }
}
