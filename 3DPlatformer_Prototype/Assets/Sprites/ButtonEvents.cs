using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonEvents : MonoBehaviour
{
    public ShadowManager m_shadowManager;
    public ShadowSolutionStorer storer;
    
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

    public void SwitchScene(string name)
    {
        SceneManager.LoadScene(name);
    }
    
    public void GameStart(string shadowtype)
    {
        SceneManager.LoadScene("GameScene");

        switch (shadowtype)
        {
            case "NOSHADOW":   { storer.startType = SHADOWTYPE.NOSHADOW; break; }
            case "SOFTSHADOW": { storer.startType = SHADOWTYPE.SOFTSHADOW; break; }
            case "HARDSHADOW": { storer.startType = SHADOWTYPE.HARDSHADOW; break; }
            case "BLOBSHADOW": { storer.startType = SHADOWTYPE.BLOBSHADOW; break; }
        }
    }
    
    public void Quit()
    {
        Application.Quit();
    }

    private void Update()
    {
        if (m_shadowManager == null)
        {
            return;
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            m_shadowManager.ChangeShadowType(SHADOWTYPE.NOSHADOW);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            m_shadowManager.ChangeShadowType(SHADOWTYPE.SOFTSHADOW);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            m_shadowManager.ChangeShadowType(SHADOWTYPE.HARDSHADOW);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            m_shadowManager.ChangeShadowType(SHADOWTYPE.BLOBSHADOW);
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            SwitchScene("StartScene");
        }
    }
}