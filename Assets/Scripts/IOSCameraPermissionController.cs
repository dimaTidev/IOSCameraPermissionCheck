using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IOSCameraPermissionController : MonoBehaviour
{
        static IOSCameraPermissionController s_Instance;
        
        Action<bool> m_Callback;
        Coroutine m_Coroutine;
        
        public static bool HasUserCameraAuthorization => Application.HasUserAuthorization(UserAuthorization.WebCam);
        
        public static IOSCameraPermissionController CreateOrGetInstance()
        {
            if (s_Instance == null)
            {
                s_Instance = new GameObject().AddComponent<IOSCameraPermissionController>();
            }

            return s_Instance;
        }
        
        void OnDestroy()
        {
            s_Instance = null;
        }

        public void RequestPermissionForCamera(Action<bool> callback)
        {
            m_Callback += callback;
            
            if(m_Coroutine == null)
                m_Coroutine = StartCoroutine(RequestPermission());
        }

        IEnumerator RequestPermission()
        {
            yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);
            m_Callback?.Invoke(HasUserCameraAuthorization);
            m_Callback = null;
            m_Coroutine = null;

            Debug.Log($"HasUserCameraAuthorization result: {HasUserCameraAuthorization}");
        }
        
        // Reference to solution https://stackoverflow.com/questions/30010334/open-settings-application-on-unity-ios
        public void OpenSystemSettings(Action<bool> callback)
        {
            m_Callback += callback;
            
            try
            {
               // string url = IOSPermissionSettings.GetSettingsURL();
               // Application.OpenURL(url);
            }
            catch (Exception ex)
            {
                Debug.LogException(ex);
                m_Callback?.Invoke(false);
            }
        }
        
        void OnApplicationFocus(bool hasFocus)
        {
            // Call only when user come back to the app
            if (hasFocus)
            {
                m_Callback?.Invoke(HasUserCameraAuthorization);
                m_Callback = null;
            }
        }
}
