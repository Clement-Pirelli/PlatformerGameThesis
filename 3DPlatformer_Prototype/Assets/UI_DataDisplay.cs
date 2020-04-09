using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_DataDisplay : MonoBehaviour
{
    public Text m_text;
    
    void Update()
    {
        DataCollector co = DataCollector.instance;

        LEVEL level = LEVEL.None;    //hard code
        if (co.m_currentLevel != LEVEL.DIFFICULT)
        {
            level = co.m_currentLevel + 1;
        }
        m_text.text =   $"Level  : {level}\n"
                      + $"Times Jumped: {co.m_TimesJumped}\n"
                      + $"Times Fallen: {co.m_TimesFallen}\n"
                      + $"Times Spent:  {co.m_TimeSpent.ToString("F1")}\n"
                      + "\n"
                      + $"Total Jumped: {co.m_TotalTimesJumped}\n"
                      + $"Total Fallen: {co.m_TotalTimesFallen}\n"
                      + $"Total Times spent: {co.m_TotalTimeSpent.ToString("F1")}\n";
    }
}
