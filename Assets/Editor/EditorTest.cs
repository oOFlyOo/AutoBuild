using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.Build.Content;
using UnityEngine;

public class EditorTest
{
    private static string DefaultBuildPath
    {
        get
        {
            return Path.GetDirectoryName(Application.dataPath) + "/AutoTool/Build/AutoBuild";
        }
    }
    
    private static Dictionary<string, string> DueArguments()
    {
        var args = System.Environment.GetCommandLineArgs();
        var paramDict = new Dictionary<string, string>();

        string command = null;
        foreach (var arg in args)
        {
            if (arg.StartsWith("-"))
            {
                command = arg;
            }
            else
            {
                if (string.IsNullOrEmpty(command))
                {
                    continue;                    
                }
                
                paramDict[command] = paramDict.ContainsKey(command) ? paramDict[command] + " " + arg : arg;
            }
        }

        return paramDict;
    }

    private static string GetBuildPath(Dictionary<string, string> paramDict)
    {
        string path;
        if (!paramDict.TryGetValue("-buildPath", out path))
        {
            path = DefaultBuildPath;
        }

        return path;
    }
    
    [MenuItem("Test/Build")]
    private static void Build()
    {
        var paramDict = DueArguments();
        var buildPath = GetBuildPath(paramDict);
        Debug.Log(buildPath);

        BuildPipeline.BuildPlayer(EditorBuildSettings.scenes, buildPath, EditorUserBuildSettings.activeBuildTarget,
            BuildOptions.Development | BuildOptions.ShowBuiltPlayer | BuildOptions.CompressWithLz4);
    }
}
