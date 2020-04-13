using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

[System.Serializable]
public struct LevelInfo 
{
    public float secondsSpent;
    public string levelName;
    public int timesJumped;
    public int timesFell;

    public LevelInfo(float p_secondsSpent, string p_levelName,int p_timesJumped, int p_timesFell)
    {
        this.secondsSpent = p_secondsSpent;
        this.levelName = p_levelName;
        this.timesJumped = p_timesJumped;
        this.timesFell = p_timesFell;
    }
}

public struct LogInfo 
{
    public float totalTime;
    public int totalJumps;
    public int totalFells;

    public LogInfo(float p_totalTime, int p_totalJumps, int p_totalFells)
    {
        totalTime = p_totalTime;
        totalJumps = p_totalJumps;
        totalFells = p_totalFells;
    }
}

public class Logger
{
    public static void WriteEndLog(string name, LogInfo info)
    {
        string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), name);
        StreamWriter writer = new StreamWriter(path, append: true);

        writer.WriteLine("-----------------------------------------------");
        writer.WriteLine();
        writer.WriteLine($"Total time spent : {info.totalTime} seconds\n");
        writer.WriteLine($"Total time jumped : {info.totalJumps} times\n");
        writer.WriteLine($"Total time fell : {info.totalFells} times");
        
        //close file otherwise other applications won't be able to use it
        writer.Close();
    }


    public static void WriteStartLog(string name) 
    {
        string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), name);
        StreamWriter writer = new StreamWriter(path, append: true);

        writer.WriteLine();

        writer.WriteLine($"Playthrough at {DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt")}");

        writer.Close();
    }

    public static void writeLevelLog(string name, LevelInfo info)
    {
        string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), name);
        StreamWriter writer = new StreamWriter(path, append: true);


        writer.WriteLine($"Level name: {info.levelName}");
        writer.WriteLine($"Player jumped: {info.timesJumped} times");
        writer.WriteLine($"Time spent in the level: {info.secondsSpent} seconds");
        writer.WriteLine($"Player fell: {info.timesFell} times");

        writer.WriteLine();

        writer.Close();
    }
}
