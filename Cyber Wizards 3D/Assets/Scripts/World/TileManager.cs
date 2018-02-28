using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TileManager : MonoBehaviour {

    public int rows;
    public int cols;

    public GameObject tilePrefab;
    public GameObject worldObject;

    public List<GameObject> Tiles { get; set; }

    float xOffset;
    float zOffset;

    private void Awake() {
        Tiles = new List<GameObject>();

        for (int x = 0; x < cols; x++) {
            zOffset = 0;
            for (int z = 0; z < rows; z++) {
                GameObject tileObject = Instantiate(tilePrefab, transform.position, Quaternion.identity);
                tileObject.transform.SetParent(worldObject.transform);
                Tiles.Add(tileObject);
                Tile t = tileObject.GetComponent<Tile>();
                t.X = x;
                t.Z = z;

                tileObject.transform.position = new Vector3(xOffset, -1, zOffset);
                zOffset += tilePrefab.GetComponent<Renderer>().bounds.size.z;
            }

            xOffset += tilePrefab.GetComponent<Renderer>().bounds.size.x;
        }

        worldObject.GetComponent<NavMeshSurface>().Bake();

    }

    void Start() {
    }

    public void SetPosition(int x, int z, GameObject obj) {
        foreach (GameObject g in Tiles) {
            Tile t = g.GetComponent<Tile>();

            if (t.X == x && t.Z == z) {
                obj.transform.position = new Vector3(t.X, 0, t.Z);
                return;
            }
        }

        Debug.LogWarning("No tile found in position: " + x + ", " + z);
    }

    public Vector3 GetPosition(int x, int z) {
        foreach (GameObject g in Tiles) {
            Tile t = g.GetComponent<Tile>();

            if (t.X == x && t.Z == z) {
                return new Vector3(t.X, 0, t.Z);
            }
        }

        return new Vector3(0, 0, 0);
        Debug.LogWarning("No tile found in position: " + x + ", " + z);

    }
}
