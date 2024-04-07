using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpStapler : MonoBehaviour
{
    public GameObject StaplerOnPlayer;

    void Start()
    {
        StaplerOnPlayer.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(Input.GetKey(KeyCode.E))
            {
                this.gameObject.SetActive(false);

                StaplerOnPlayer.SetActive(true);
            }
        }
    }

    
}
