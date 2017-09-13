using UnityEngine;

public class Game : MonoBehaviour {
    [SerializeField] private int pointsPerRow = 15;
    [SerializeField] private int extraTilesMultiplier = 2;
    [SerializeField] private TileSpawner _spawner;
    private int points = 0;

    public TileSpawner spawner { get { return _spawner; } }

	void Update () {
        if (Input.GetKeyDown(KeyCode.Alpha0)) addPoints();
        else if (Input.GetKeyDown(KeyCode.Alpha1)) addPoints(1);
        else if (Input.GetKeyDown(KeyCode.Alpha2)) addPoints(2);
    }

    public void addPoints(int extraTiles = 0) {
        int pointsToAdd = 0;

        if (extraTiles == 0) pointsToAdd = pointsPerRow;
        else pointsToAdd = extraTiles * extraTilesMultiplier * pointsPerRow;

        Debug.Log(string.Format("Add {0} points with {1} extra tiles.", pointsToAdd, extraTiles));
        points += pointsToAdd;
    }
}
