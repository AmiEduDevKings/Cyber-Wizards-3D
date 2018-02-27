using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {

    public int rows;
    public int cols;
    public GameObject tilePrefab;

    float xOffset;
    float zOffset;

    void Start() {
        for (int x = 0; x < cols; x++) {
            zOffset = 0;
            xOffset += tilePrefab.GetComponent<Renderer>().bounds.size.x;
            for (int z = 0; z < rows; z++) {
                zOffset += tilePrefab.GetComponent<Renderer>().bounds.size.z;
                GameObject tileObject = Instantiate(tilePrefab, transform.position, Quaternion.identity);
                tileObject.transform.SetParent(transform);

                Tile t = tileObject.GetComponent<Tile>();

                t.X = x;
                t.Z = z;

                tileObject.transform.position = new Vector3(xOffset, 0, zOffset);
            }
        }
    }
}
