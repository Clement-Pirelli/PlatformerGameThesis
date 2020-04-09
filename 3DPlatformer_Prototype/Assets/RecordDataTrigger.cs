using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordDataTrigger : MonoBehaviour
{
    public LEVEL level = LEVEL.EASY;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DataCollector.instance.PrintLevelInfo(level + 1); //hard code..will change later
            GetComponent<Collider>().enabled = false;
        }
    }
}
