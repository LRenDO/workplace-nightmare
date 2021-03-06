using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading.Tasks;
using UnityEngine.Events;

// This script flashes the lights on and off in the beginning ("Oh no the power is going out!")
// This script then checks for the fuseboxes being back on, and turns lights back on when all three
// fusebox levers have been pulled

public class PowerHandler : ItemInteraction
{
    private Light[] lights;
    public GameObject lightParent;
    public AudioSource breakingAudio;
    public GameObject FuseboxLever;      // has Pull Lever 0 script
    public GameObject FuseboxLeverTwo;    // has PullLever3 script
    public GameObject FuseboxLeverThree;    // has Pull Lever script
    public GameObject projectorScreen;
    public GameObject screenPlane;
    public Renderer planeRenderer;
    public UnityEvent PowerIsOn;

    protected override void Awake()
    {
        base.Awake();
        breakingAudio.enabled = false;
        PowerIsOn = new UnityEvent();
    }

    protected override void Start()
    {
        // Get the material from the projector object
        planeRenderer = screenPlane.GetComponent<Renderer>();
        lights = lightParent.GetComponentsInChildren<Light>(true);
        breakingAudio = GetComponent<AudioSource>();
 
        foreach (Light light in lights)
        {
            light.enabled = true;
        }

        StartFlickering();

    }
    
    protected override void Update()
    {
        lights = lightParent.GetComponentsInChildren<Light>(true);
        
        // if all levers have been pulled (reactivated)
        if (FuseboxLever.GetComponent<PullLever0>().pulledAlready && FuseboxLeverTwo.GetComponent<PullLever3>().pulledAlready && FuseboxLeverThree.GetComponent<PullLever>().pulledAlready)
        {
            foreach (Light light in lights)
            {
                light.enabled = true;
            }
            // also enable screen
            planeRenderer.enabled = false;
            InteractionComplete?.Invoke();
        }
    }

    public void StartFlickering ()
    {
        StartCoroutine(FlickerLights());
    }

    // Flickers the lights when the room is first entered
    IEnumerator FlickerLights()
    {
        yield return new WaitForSeconds(10f);
        
        // lights off until fuses are on
        foreach (Light light in lights)
        {
            light.enabled = false;
        }

        yield return new WaitForSeconds(1);

        // flicker the lights
        foreach (Light light in lights)
        {
            light.enabled = true;
        }
        
        yield return new WaitForSeconds(5);

        // flicker the lights
        foreach (Light light in lights)
        {
            light.enabled = false;
        }

        yield return new WaitForSeconds(0.5f);

        // flicker the lights
        foreach (Light light in lights)
        {
            light.enabled = true;
        }
        
        yield return new WaitForSeconds(3);

        // flicker the lights
        foreach (Light light in lights)
        {
            light.enabled = false;
        }

        // Quick blinks
        yield return new WaitForSeconds(0.15f);

        foreach (Light light in lights)
        {
            light.enabled = true;
        }
        
        yield return new WaitForSeconds(0.15f);

        foreach (Light light in lights)
        {
            light.enabled = false;
        }

        yield return new WaitForSeconds(0.15f);

        foreach (Light light in lights)
        {
            light.enabled = true;
        }
        
        yield return new WaitForSeconds(0.15f);

        foreach (Light light in lights)
        {
            light.enabled = false;
        }

        yield return new WaitForSeconds(0.15f);

        foreach (Light light in lights)
        {
            light.enabled = true;
        }
        
        yield return new WaitForSeconds(0.15f);

        foreach (Light light in lights)
        {
            light.enabled = false;
        }

        yield return new WaitForSeconds(0.05f);

        foreach (Light light in lights)
        {
            light.enabled = true;
        }
        
        yield return new WaitForSeconds(0.05f);

        foreach (Light light in lights)
        {
            light.enabled = false;
        }

        yield return new WaitForSeconds(0.05f);

        foreach (Light light in lights)
        {
            light.enabled = true;
        }
        
        yield return new WaitForSeconds(0.05f);

        foreach (Light light in lights)
        {
            light.enabled = false;
        }

        // Play bulb breaking sound
        breakingAudio.enabled = true;

        yield return null;
    }
}
