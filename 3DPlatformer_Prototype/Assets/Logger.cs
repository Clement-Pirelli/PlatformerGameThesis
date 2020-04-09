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
    public LevelInfo[] levels;
}

public class Logger
{
    public static void WriteLog(string name, LogInfo info)
    {
        string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), name);
        StreamWriter writer = new StreamWriter(path, append: true);
        float totalTime = .0f;


        writer.WriteLine();

        writer.WriteLine($"Playthrough at {DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt")}");

        foreach (var levelInfo in info.levels) 
        {
            totalTime += levelInfo.secondsSpent;

            writer.WriteLine($"Level name: {levelInfo.levelName}");
            writer.WriteLine($"Player jumped: {levelInfo.timesJumped} times");
            writer.WriteLine($"Time spent in the level: {levelInfo.secondsSpent} seconds");
            writer.WriteLine($"Player fell: {levelInfo.timesFell} times");

            writer.WriteLine();
        }

        writer.WriteLine("-----------------------------------------------");
        writer.WriteLine();
        writer.WriteLine($"Total time spent : {totalTime} seconds");
        
        //close file otherwise other applications won't be able to use it
        writer.Close();
    }
}
