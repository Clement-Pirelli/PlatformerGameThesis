using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTextOnClick : MonoBehaviour
{
    public Text target;
    public GameObject startButton;
    
    public void OnClick()
    {
        target.text = GetComponent<Text>().text;
        startButton.SetActive(true);
    }
}
