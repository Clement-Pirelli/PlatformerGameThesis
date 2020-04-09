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
}

public struct LogInfo 
{
    public float totalTime;
}

public class Logger
{
    public static void WriteEndLog(string name, LogInfo info)
    {
        string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), name);
        StreamWriter writer = new StreamWriter(path, append: true);

        writer.WriteLine("-----------------------------------------------");
        writer.WriteLine();
        writer.WriteLine($"Total time spent : {info.totalTime} seconds");
        
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
