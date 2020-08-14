
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;


public enum LogType
{
    INFO,
    WARNING,
    ERROR
}

public static class Logging 
{
    [Conditional("DEBUG_LOG_ON")]
    public static void Log(string message_,LogType type= LogType.INFO)
    {
        UnityEngine.Debug.Log(message_);
    }

}
