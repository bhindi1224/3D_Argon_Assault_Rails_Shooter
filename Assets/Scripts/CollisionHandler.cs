using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        print("Trigger collision with - " + other);
        StartDeathSequence();
    }

    private void StartDeathSequence()
    {
        print("Player dying");
        SendMessage("PlayerDeath");
    }
}
