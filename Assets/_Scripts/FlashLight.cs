using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class FlashLight : MonoBehaviour
{
    public HDAdditionalLightData flashlight;

    public bool on;
    // Start is called before the first frame update
    void Start()
    {
        flashlight.intensity = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            on = !on;
        }

        flashlight.intensity = on ? Mathf.Lerp(flashlight.intensity, 30f, 30f * Time.deltaTime)
        : Mathf.Lerp(flashlight.intensity, 0f, 20f * Time.deltaTime);
    }
}
