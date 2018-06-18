using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    public GameObject Target;
    public int damage;
    public int damagebonus = 0;
    Stats stats;

    public float HitRange;

    private void Start()
    {
        stats = GetComponent<Stats>();
    }
    public void AttackToEnemy() {
        Debug.Log(name + "attacktoenemy");
        if (stats.currentActionPoints > 0)
        {
            if(Vector3.Distance(Target.transform.position, gameObject.transform.position) <= HitRange)
            {
                Target.GetComponent<Stats>().TakeDamage(damage + damagebonus);
                damagebonus = 0;
            }
        }
    }

    public void BoostDamage() {
        Debug.Log(name + "boostdamage");
        damagebonus = 100;
    }
    
}
