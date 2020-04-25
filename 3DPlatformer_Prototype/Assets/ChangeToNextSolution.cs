using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeToNextSolution : MonoBehaviour
{
    public string nextSolution;
    public ShadowSolutionStorer storer;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switch (nextSolution)
            {
                case "EXIT":
                {
                    Application.Quit();
                    break;
                }
                case "NOSHADOW":
                {
                    storer.startType = SHADOWTYPE.NOSHADOW;
                    break;
                }
            }
        }
        
        SceneManager.LoadScene("NoShadowScene");
    }
}
