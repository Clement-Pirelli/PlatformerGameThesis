using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    
public enum LEVEL
{
    None,
    EASY,
    MEDIUM,
    DIFFICULT
}

public class DataCollector : MonoBehaviour
{
    public static DataCollector instance;

    public LEVEL m_currentLevel = LEVEL.EASY;

    public int m_TimesJumped = 0;
    public int m_TimesFallen = 0;
    public float m_TimeSpent = 0;
    
    public int m_TotalTimesJumped = 0;
    public int m_TotalTimesFallen = 0;
    public float m_TotalTimeSpent = 0;

    public bool m_enableCounting = false; //On the intersaction of each level, we give player a small break

    public string m_fileName = "Result";
    
    private void Start()
    {
        instance = this;
    }

    void Update()
    {
        if (m_enableCounting == true)
        {
            m_TotalTimeSpent += Time.deltaTime;
            m_TimeSpent += Time.deltaTime;
        }
    }

    public void AddTumpCounter()
    {
        if (m_enableCounting == true)
        {
            m_TotalTimesJumped += 1;
            m_TimesJumped      += 1;
        }
    }
    
    public void AddDeathCounter()
    {
        m_TotalTimesFallen += 1;
        m_TimesFallen      += 1;
    }

    public void ResetData()
    {
        m_TimesJumped = 0;
        m_TimesFallen = 0;
        m_TimeSpent = 0.0f;
    }

    public void PrintLevelInfo(LEVEL p_level)
    {
        m_currentLevel = p_level;
        
        if (p_level == LEVEL.EASY)
        {
            Logger.WriteStartLog(m_fileName);
        }
        
        Logger.writeLevelLog(m_fileName, new LevelInfo(m_TimeSpent, p_level.ToString(), m_TimesJumped, m_TimesFallen));
        
        if (p_level == LEVEL.DIFFICULT)
        {
            Logger.WriteEndLog(m_fileName, new LogInfo(m_TotalTimeSpent, m_TotalTimesJumped, m_TotalTimesFallen));
        }
    }
}
