using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverInteraction : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float interactionRange = 2f; // Range within which the player can interact with the lever
    public GearRotation gearRotation; // Reference to the GearRotation script

    private bool leverActivated = false; // Keep track of lever state

    void Update()
    {
        // Check if the player is within interaction range and pressing 'E'
        if (Vector3.Distance(transform.position, player.position) <= interactionRange && Input.GetKeyDown(KeyCode.E))
        {
            // Toggle lever state
            leverActivated = !leverActivated;

            // Notify GearRotation script to start or stop rotation
            if (leverActivated)
            {
                gearRotation.StartRotation();
            }
            
        }
    }
}
