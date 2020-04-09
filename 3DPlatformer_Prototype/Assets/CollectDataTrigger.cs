using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectDataTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DataCollector.instance.m_enableCounting = false;
            DataCollector.instance.ResetData();
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DataCollector.instance.m_enableCounting = true;
            GetComponent<Collider>().enabled = false;
        }
    }
}
