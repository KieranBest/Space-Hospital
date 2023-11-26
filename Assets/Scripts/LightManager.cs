using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    public Light RoomA1a;
    public Light RoomA1b;
    public Light RoomA2a;
    public Light RoomA2b;
    public Light RoomA3a;
    public Light RoomA3b;

    public bool RoomALight = true;

    private float aboveLightStrength = 0.5f;
    private float belowLightStrength = 1.5f;
    private float LightOff = 0f;

    List<Light> roomAa = new List<Light>();
    List<Light> roomAb = new List<Light>();

    public void Awake()
    {
        List<Light> roomAa = new List<Light>() { RoomA1a, RoomA2a, RoomA3a};
        List<Light> roomAb = new List<Light>() {  RoomA1b, RoomA2b, RoomA3b};
    }


    private void Update()
    {
        if (RoomALight)
        {
            foreach (var L in roomAa) L.intensity = aboveLightStrength;
            foreach (var L in roomAb) L.intensity = belowLightStrength;
        }
        else
        {
            foreach (var L in roomAa) L.intensity = LightOff;
            foreach (var L in roomAb) L.intensity = LightOff;
        }
    }
}


