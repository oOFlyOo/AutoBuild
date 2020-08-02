using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EditorTest
{
    private const string Default
    
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
                paramDict[command] = paramDict.ContainsKey(command) ? paramDict[command] + " " + arg : arg;
            }
        }

        return paramDict;
    }
    
    [MenuItem("Test/Build")]
    private static void Build()
    {
        var parmDict = DueArguments();
        
    }
}
