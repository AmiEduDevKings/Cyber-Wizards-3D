using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour {

    public static CombatManager instance;

    public List<GameObject> Characters;
    private GameObject[] charsIncombat;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else {
            instance = this;
        }

    }


    public void AddCharacter(GameObject character) {
        Characters.Add(character);
    }

    public void RemoveChracter(GameObject character) {
        Characters.Remove(character);
    }



    public void StartCombat() {
       
    }
}
