using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearTwoPlacement : MonoBehaviour
{
    public Transform player;
    public Transform gear; 
    public Transform placementPosition; // Θέση που θα τοποθετηθεί το γρανάζι
    public float interactionRange = 2f;
    public float teleportSpeed = 5f;

    private bool isTeleporting = false;
    private ObjectGrabbable objectGrabbable;

    void Start()
    {
        objectGrabbable = gear.GetComponent<ObjectGrabbable>();
    }
    
    void Update()
    {
        // Έλεγχος αν το γρανάζι είναι κοντά στον μηχανισμό και δεν το κρατάει ο παίκτης
        if (Vector3.Distance(gear.position, placementPosition.position) <= interactionRange && !objectGrabbable.IsGrabbed())
        {
            StartTeleportation();

            // Αλλαγή του rotation του γραναζιού
            gear.rotation = Quaternion.Euler(0f, 87.584f, 0f);
        }
    
        if (isTeleporting)
        {
            // Μετακίνηση του γραναζιού προς τη θέση του μηχανισμού
            gear.position = Vector3.MoveTowards(gear.position, placementPosition.position, teleportSpeed * Time.deltaTime);

            // Έλεγχος αν το γρανάζι έχει φτάσει στη θέση του μηχανισμού
            if (Vector3.Distance(gear.position, placementPosition.position) < 0.01f)
            {
                isTeleporting = false;

                // Απελευθέρωση του γραναζιού μετά την τηλεμεταφορά
                objectGrabbable.Drop();
            }
        }
    }

    private void StartTeleportation()
    {
        // Κράτηση του γραναζιού από τον παίκτη
        objectGrabbable.Grab(transform);

        // Έναρξη της διαδικασίας τηλεμεταφοράς
        isTeleporting = true;
    }
}
