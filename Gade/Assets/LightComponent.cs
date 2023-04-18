using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightComponent : MonoBehaviour
{
    public Light lightComponent;
    public float intensityRange = 990f;
    public float intensityMin = 10f;
    public float intensitySpeed = 100f;

    // Start is called before the first frame update
    void Start()
    {
        lightComponent = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        float intensity = Mathf.PingPong(Time.time * intensitySpeed, intensityRange) + intensityMin;
        lightComponent.intensity = intensity;
    }
}
