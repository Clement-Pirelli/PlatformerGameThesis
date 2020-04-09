using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AXIS
{
    X,Y,Z
}

public class PlatformRotator : MonoBehaviour
{
    public float m_speed = 20;

    public AXIS m_axis = AXIS.X;
    
    void FixedUpdate()
    {
        Vector3 t_axis = new Vector3(1, 0, 0);
        
        switch (m_axis)
        {
            case AXIS.X:
            {
                t_axis = new Vector3(1, 0, 0);
                break;
            } 
            case AXIS.Y:
            {
                t_axis = new Vector3(0, 1, 0);
                break;
            }  
            case AXIS.Z:
            {
                t_axis = new Vector3(0, 0, 1);
                break;
            }        
        }
        
        transform.Rotate(t_axis, m_speed * Time.deltaTime);
    }
}
