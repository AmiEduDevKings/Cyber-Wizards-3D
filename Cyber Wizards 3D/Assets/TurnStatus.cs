using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TurnStatus : MonoBehaviour {

    public UnityEvent Event;

    public void StartTurn() {
        Event.Invoke();
    }
}
