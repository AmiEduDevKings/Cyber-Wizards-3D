using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour {

    public int health;
    public int actionPoints;

    public void TakeDamage(int amount) {
        health -= amount;
    }
}
