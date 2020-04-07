using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointTrigger : MonoBehaviour
{
    public Transform m_SpawnPoint; //Spawn point

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CheckPointManager.instance.SetSpawnPoint(m_SpawnPoint);
        }
    }
}
