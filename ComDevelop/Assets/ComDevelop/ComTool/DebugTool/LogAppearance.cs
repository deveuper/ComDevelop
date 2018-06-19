/// <summary>
/// Using this component to drag on any game object
/// </summary>
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace ComDevelop.DebugTool
{
    /// <summary>
    /// 将Debug文字写到GUI中
    /// </summary>
    public class LogAppearance : MonoBehaviour
    {
        struct Log
        {
            public string message;
            public string stackTrace;
            public LogType type;
        }
        readonly List<Log> logs = new List<Log>();
        string content = "";
        // Use this for initialization
        void OnEnable()
        {
            Application.logMessageReceived += HandleLog;
        }
        public void HandleLog(string message, string stackTrace, LogType type)
        {
            logs.Add(new Log
            {
                message = message,
                stackTrace = stackTrace,
                type = type,
            });
            content += message + "\n";
        }

        void OnGUI()
        {
            GUI.Box(new Rect(10, 10, 500, 100), content);
        }
    }
}