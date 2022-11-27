using TMPro;
using UnityEngine;

public class HUDConsole : MonoBehaviour {

    private const int MAX_SIZE = 2048;

    public TextMeshProUGUI textField;

    private string fullLog = string.Empty;

    private void Start() {
        Application.logMessageReceived += EventLogRecieved; 
    }

    private void OnDestroy() {
        Application.logMessageReceived -= EventLogRecieved;
    }

    public void ClearLog() {
        fullLog = string.Empty;
        textField.text = fullLog;
    }

    public void TestLog(){
        Debug.Log("Testing logging");
    }

    private void EventLogRecieved(string pMessage, string pStackTrace, LogType pType) {
        fullLog = $"[{pType}] {pMessage}\n{fullLog}";
        if (fullLog.Length > MAX_SIZE) {
            fullLog = fullLog.Substring(0, MAX_SIZE);
        }
        textField.text = fullLog;
    }
}
