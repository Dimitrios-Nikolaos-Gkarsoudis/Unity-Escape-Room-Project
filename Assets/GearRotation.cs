using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearRotation : MonoBehaviour
{
    
    public GameObject GearOne;
    public GameObject GearTwo;
    public GameObject GearThree;
    public GameObject GearFour;
    public GameObject GearFive;

    private bool rotationStarted = false;
    
    void Update()
    {
        if (rotationStarted)
        {
            GearOne.transform.Rotate(0, 0, 0.2f);
            GearTwo.transform.Rotate(0, 0, -0.2f);
            GearThree.transform.Rotate(0, 0, 0.2f);
            GearFour.transform.Rotate(0, 0, -0.2f);
            GearFive.transform.Rotate(0, 0, 0.2f);
        }    
    }

    public void StartRotation()
    {
        rotationStarted = true;
    }
}
