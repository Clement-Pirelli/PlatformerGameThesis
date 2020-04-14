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
    public Light m_PlayerLight;     //Only cast light on player
    public GameObject m_blobShadow; // blob shadow

    public SHADOWTYPE currentType;

    public LayerMask m_includePlayer;
    public LayerMask m_excludePlayer;

    public static ShadowManager instance;

    public ShadowSolutionStorer storer;
    
    private void Start()
    {
        instance = this;

        ChangeShadowType(storer.startType);
    }

    //Entrance method to change the shadow type
    public void ChangeShadowType(SHADOWTYPE p_type)
    {
        if (currentType == p_type)    //if it's the same then dont do anything
        {    
            return;
        }
        else if (currentType == SHADOWTYPE.NOSHADOW || currentType == SHADOWTYPE.BLOBSHADOW)
        {
            m_DirLight.cullingMask = m_includePlayer;

            m_PlayerLight.enabled = false;
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
        m_DirLight.cullingMask = m_excludePlayer;
        m_PlayerLight.enabled = true;
        
        //m_DirLight.shadows = LightShadows.None;
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
        m_DirLight.cullingMask = m_excludePlayer;
        m_PlayerLight.enabled = true;
        
        //m_DirLight.shadows = LightShadows.None;
        m_blobShadow.SetActive(true);
    }
}