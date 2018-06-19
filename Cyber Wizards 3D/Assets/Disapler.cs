using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disapler : MonoBehaviour {

    private bool joo = false;

    public GameObject objekti;
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.I)) {
            if (joo)
            {
                objekti.SetActive(false);
                joo = false;
            }
            else {
                objekti.SetActive(true);
                joo = true;
            }
        }

	}
}
