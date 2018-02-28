using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour {

    TileManager tm;
    NavMeshAgent nma;

    // Use this for initialization
    void Start() {
        tm = GameObject.Find("TileManager").GetComponent<TileManager>();

        tm.SetPosition(5, 5, gameObject);
        nma = gameObject.AddComponent<NavMeshAgent>();
        nma.acceleration = 300f;
        nma.speed = 3.5f;
        nma.angularSpeed = 500f;

        nma.SetDestination(tm.GetPosition(25, 25));
    }

    // Update is called once per frame
    void Update() {

    }
}
