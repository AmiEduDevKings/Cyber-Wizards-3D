using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    public GameObject Target;
    public int damage;

    public void AttackToEnemy() {
        Target.GetComponent<Stats>().TakeDamage(damage);
    }
    
}
