using UnityEngine;
using UnityEngine.UI;

public class UIPermissions : MonoBehaviour
{
    public Text m_TextLog;


    private void OnEnable()
    {
        Application.logMessageReceived += LogCallback;
    }
    
    //Called when there is an exception
    void LogCallback(string condition, string stackTrace, LogType type)
    {
        m_TextLog.text += $"\n {type}: {condition}";
    }

    void OnDisable()
    {
        Application.logMessageReceived -= LogCallback;
    }

    public void RequestPermission()
    {
        IOSCameraPermissionController.CreateOrGetInstance().RequestPermissionForCamera(RequestPermissionResult);
    }
    
    void RequestPermissionResult(bool result)
    {
        Debug.Log($"request result is: {result}");
    }
    
    public void CheckPermission()
    {
        Debug.Log($"check result is: {IOSCameraPermissionController.HasUserCameraAuthorization}");
    }
    
    public void CheckPermissionByPlugin()
    {
        Debug.Log("CheckPermission = " + iOSCameraPermission.CheckPermission());
    }


    public void OpenSettings()
    {
        IOSPermissionSettings.OpenSettings();
    }
}
