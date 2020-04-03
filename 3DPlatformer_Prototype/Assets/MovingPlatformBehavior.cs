using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformBehavior : MonoBehaviour
{
    public List<Transform> m_paths = new List<Transform>();
    public Transform m_platform;
    public int m_currentDestination = 0;

    public float m_speed = 5f;
    private void Start()
    {
        m_platform = transform.Find("Platform");
        Transform path = transform.Find("Paths");
        
        for (int i = 0; i < path.childCount; i++)
        {
            m_paths.Add(path.GetChild(i).transform);
        }
    }

    void FixedUpdate()
    {
        //move to destination by speed
        m_platform.position = Vector3.MoveTowards(m_platform.position, m_paths[m_currentDestination].position, m_speed * Time.deltaTime);
        
        //if reached destination, then move the target transform index to the next
        if (m_platform.position == m_paths[m_currentDestination].position)
        {
            m_currentDestination++;
            
            //if reached the end, move the index to 0
            if (m_currentDestination >= transform.Find("Paths").childCount)
            {
                m_currentDestination = 0;
            }
        }
    }
}
