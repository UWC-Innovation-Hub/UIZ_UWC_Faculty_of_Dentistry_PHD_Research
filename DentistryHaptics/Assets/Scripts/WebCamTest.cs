using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NUnit.Framework;
using UnityEngine;

public class WebCamTest : MonoBehaviour
{
    private WebCamTexture camTexture;

    private ARXVideoConfig videoConfig;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        videoConfig = GetComponent<ARXVideoConfig>();  
        if (WebCamTexture.devices == null)
        {
            Debug.Log("No devices");
        }

        List<ARXVideoConfig.ARVideoSourceInfoT> aRVideoSourceInfoTs = videoConfig.GetVideoSourceInfoList(videoConfig.ToString());
        foreach (var aRVideoSourceInfo in aRVideoSourceInfoTs)
            Debug.Log($"SOURCE INFO: Name: {aRVideoSourceInfo.name}, UID: {aRVideoSourceInfo.UID}");
    }
}
