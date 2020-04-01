using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SHADOWTYPE
{
    NOSHADOW,
    SOFTSHADOW,
    HARDSHADOW,
    BLOBSHADOW
}

public class ShadowManager : MonoBehaviour
{
    public Light m_DirLight;        //Directional light
    public GameObject m_blobShadow; // blob shadow

    public SHADOWTYPE currentType;
    
    //Entrance method to change the shadow type
    public void ChangeShadowType(SHADOWTYPE p_type)
    {
        if (currentType == p_type)    //if it's the same then dont do anything
        {    
            return;
        }

        currentType = p_type;
        
        switch (p_type)
        {
            case SHADOWTYPE.NOSHADOW:   { ChangeToNoShadow();   break; }
            case SHADOWTYPE.SOFTSHADOW: { ChangeToSoftShadow(); break; }
            case SHADOWTYPE.HARDSHADOW: { ChangeToHardShadow(); break; }
            case SHADOWTYPE.BLOBSHADOW: { ChangeToBlobShadow(); break; }
        }
    }

    private void ChangeToNoShadow()
    {
        m_DirLight.shadows = LightShadows.None;
        m_blobShadow.SetActive(false);
    }
    
    private void ChangeToSoftShadow()
    {
        m_DirLight.shadows = LightShadows.Soft;
        m_blobShadow.SetActive(false);
    }
    
    private void ChangeToHardShadow()
    {
        m_DirLight.shadows = LightShadows.Hard;
        m_blobShadow.SetActive(false);
    }
    
    private void ChangeToBlobShadow()
    {
        m_DirLight.shadows = LightShadows.None;
        m_blobShadow.SetActive(true);
    }
}