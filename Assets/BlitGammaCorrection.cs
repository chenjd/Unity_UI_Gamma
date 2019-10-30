using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode, ImageEffectAllowedInSceneView]
public class BlitGammaCorrection : MonoBehaviour {

    
    public Shader m_BlitShader;
    private Material m_BlitMat;
    

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (m_BlitMat == null)
        {
            m_BlitMat = new Material(m_BlitShader);
        }
        
        Graphics.Blit(source, destination, m_BlitMat);
    }
}
