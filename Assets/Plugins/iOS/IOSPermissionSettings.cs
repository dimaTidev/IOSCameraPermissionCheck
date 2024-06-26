using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class IOSPermissionSettings 
{
#if UNITY_IPHONE
        [DllImport ("__Internal")]
        public static extern string GetSettingsURL();

        [DllImport ("__Internal")]
        public static extern void OpenSettings();
#endif
}
