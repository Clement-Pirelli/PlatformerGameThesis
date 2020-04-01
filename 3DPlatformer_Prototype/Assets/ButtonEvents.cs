using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEvents : MonoBehaviour
{
    public ShadowManager m_shadowManager;
    
    //The Onclick of button doesn't take enum, which I have to use the extra step....
    public void ChangeShadowType(string p_type)
    {
        switch (p_type)
        {
            case "NOSHADOW":   { m_shadowManager.ChangeShadowType(SHADOWTYPE.NOSHADOW); break; }
            case "SOFTSHADOW": { m_shadowManager.ChangeShadowType(SHADOWTYPE.SOFTSHADOW); break; }
            case "HARDSHADOW": { m_shadowManager.ChangeShadowType(SHADOWTYPE.HARDSHADOW); break; }
            case "BLOBSHADOW": { m_shadowManager.ChangeShadowType(SHADOWTYPE.BLOBSHADOW); break; }
        }
    }
}