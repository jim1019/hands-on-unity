using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCamera : MonoBehaviour
{

    public int shadowResolution = 1;
	public float ShadowBias = 0.005f;

	public Shader shadowCaster;

	Camera dirLightCamera;
    public Camera CreateDirLightCamera()
    {
        GameObject goLightCamera = new GameObject("Directional Light Camera");
		goLightCamera.transform.position = transform.position;
		goLightCamera.transform.rotation = transform.rotation;

        Camera LightCamera = goLightCamera.AddComponent<Camera>();
        LightCamera.backgroundColor = Color.white;
        LightCamera.clearFlags = CameraClearFlags.SolidColor;
        LightCamera.orthographic = true;
        LightCamera.orthographicSize = 6f;
        LightCamera.nearClipPlane = 0.3f;
        LightCamera.farClipPlane = 20;

        LightCamera.enabled = false;
        return LightCamera;
    }

    private RenderTexture Create2DTextureFor(Camera cam)
    {
        RenderTextureFormat rtFormat = RenderTextureFormat.Default;
        if (!SystemInfo.SupportsRenderTextureFormat(rtFormat))
            rtFormat = RenderTextureFormat.Default;

        var rt_2d = new RenderTexture(512 * shadowResolution, 512 * shadowResolution, 24, rtFormat);
        rt_2d.hideFlags = HideFlags.DontSave;

        Shader.SetGlobalTexture("_gShadowMapTexture", rt_2d);

        return rt_2d;
    }

    // Use this for initialization
    void Start()
    {
        var LightCamera = CreateDirLightCamera();
        if (!LightCamera.targetTexture)
            LightCamera.targetTexture = Create2DTextureFor(LightCamera);

		

		dirLightCamera = LightCamera;

		Shader.SetGlobalFloat("_gShadowBias", ShadowBias);
		Shader.SetGlobalFloat("_gShadowStrength", 0.5f);
		
		dirLightCamera.cullingMask = 1 << LayerMask.NameToLayer("Water");
		dirLightCamera.RenderWithShader(shadowCaster, "");
		
		Matrix4x4 projectionMatrix = GL.GetGPUProjectionMatrix(dirLightCamera.projectionMatrix, false);
		Shader.SetGlobalMatrix("_gWorldToShadow", projectionMatrix * dirLightCamera.worldToCameraMatrix);
    }

    // Update is called once per frame
    void Update()
    {
		
    }
}
