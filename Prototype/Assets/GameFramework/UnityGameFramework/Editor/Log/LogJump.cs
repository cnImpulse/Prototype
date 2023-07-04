using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditorInternal;
using UnityEngine;

public class LogJump
{
    private static string CustomLog = "GameFrameworkLog.cs";
    private static readonly Regex LogRegex = new Regex(@"\(at (.+)\:(\d+)\)\r?\n");

    [OnOpenAsset(0)]
    public static bool DoubleClickLog(int instanceId, int line)
    {
        var trackInfo = GetStackTrace();
        if (string.IsNullOrEmpty(trackInfo))
            return false;

        if (!trackInfo.Contains(CustomLog))
            return false;

        Match match = LogRegex.Match(trackInfo);
        for (int i = 0; i < 3; i++)
        {
            match = match.NextMatch();
            if (!match.Success) return false;
        }

        var file = match.Groups[1].Value;
        var lineId = int.Parse(match.Groups[2].Value);

        // 上一级目录
        var projectRootPath = Path.GetFullPath(Path.Combine(Application.dataPath, "../"));
        InternalEditorUtility.OpenFileAtLineExternal(Path.Combine(projectRootPath, file), lineId);
        return true;
    }

    private static string GetStackTrace()
    {
        var editorWindowAssembly = typeof(EditorWindow).Assembly;
        var consoleWindowType = editorWindowAssembly.GetType("UnityEditor.ConsoleWindow");

        var consoleWindowFieldInfo = consoleWindowType.GetField(
            "ms_ConsoleWindow", BindingFlags.Static | BindingFlags.NonPublic);

        var consoleWindow = consoleWindowFieldInfo.GetValue(null) as EditorWindow;

        if (consoleWindow != EditorWindow.focusedWindow)
        {
            return null;
        }

        var activeTextFieldInfo = consoleWindowType.GetField(
            "m_ActiveText", BindingFlags.Instance | BindingFlags.NonPublic);

        return (string)activeTextFieldInfo.GetValue(consoleWindow);
    }
}
