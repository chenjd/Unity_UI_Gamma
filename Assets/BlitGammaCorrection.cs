using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode, ImageEffectAllowedInSceneView]
public class BlitGammaCorrection : MonoBehaviour {

    
    public Shader m_BlitShader;
    public Camera m_Cam;
    private Material m_BlitMat;

    void Update()
    {
        if(m_Cam == null)
        {
            m_Cam = GetComponent<Camera>();
        }
        m_Cam.enabled = PlayerSettings.colorSpace == ColorSpace.Linear;
    }
    

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (m_BlitMat == null)
        {
            m_BlitMat = new Material(m_BlitShader);
        }
        
        Graphics.Blit(source, destination, m_BlitMat);
    }
}
