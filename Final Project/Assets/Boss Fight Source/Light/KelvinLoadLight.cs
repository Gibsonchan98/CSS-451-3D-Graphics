using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KelvinLoadLight : MonoBehaviour
{
    public KelvinPointLight ALight;

    void OnPreRender()
    {
        ALight.LoadLightToShader();
    }
}
