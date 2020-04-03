using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandTrigger : MonoBehaviour
{
    //To move the player alone when step on the moving platform
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.SetParent(transform);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.SetParent(null);
        }
    }
}
