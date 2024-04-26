using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrabbable : MonoBehaviour
{
    private Rigidbody objectRigidbody;
    private Transform objectGrabPointTransform;
    private bool isGrabbed = false; // Κατάσταση εάν το αντικείμενο είναι κρατημένο

    private void Awake()
    {
        objectRigidbody = GetComponent<Rigidbody>();
    }

    public void Grab(Transform objectGrabPointTransform)
    {
        this.objectGrabPointTransform = objectGrabPointTransform;
        objectRigidbody.useGravity = false;
        isGrabbed = true; // Το αντικείμενο κρατιέται
    }

    public void Drop()
    {
        this.objectGrabPointTransform = null;
        objectRigidbody.useGravity = true;
        isGrabbed = false; // Το αντικείμενο δεν κρατιέται πια
    }

    public bool IsGrabbed()
    {
        return isGrabbed;
    }

    private void FixedUpdate()
    {
        if (isGrabbed)
        {
            // Απενεργοποίηση της φυσικής όταν το αντικείμενο είναι κρατημένο
            objectRigidbody.velocity = Vector3.zero;
            objectRigidbody.angularVelocity = Vector3.zero;
        }

        if (objectGrabPointTransform != null)
        {
            // Ορισμός της θέσης απευθείας αντί για μετάβαση με Lerp
            objectRigidbody.MovePosition(objectGrabPointTransform.position);
        }
    }
}
