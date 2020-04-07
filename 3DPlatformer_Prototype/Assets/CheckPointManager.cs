using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    public static CheckPointManager instance;
    
    private Transform currentSpawnPoint;
    
    private Transform m_player;

    private void Start()
    {
        instance = this;
    }

    public void SetSpawnPoint(Transform p_spawnPoint)
    {
        currentSpawnPoint = p_spawnPoint;
    }

    public void ResetPlayerPosition()
    {
        if (m_player == null)
        {
            m_player = GameObject.FindGameObjectWithTag("Player").transform;
        }
        
        m_player.position = currentSpawnPoint.position;
    }

}