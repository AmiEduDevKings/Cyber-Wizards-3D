using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Spell", menuName = "Spells/Spell", order = 1)]
public class Spell : ScriptableObject {

    public int spellDamage { get; private set; }
    public int spellSpeed;
    public ParticleSystem spellEffect;

}
