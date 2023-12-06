using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    #region Assign Lights
    public GameObject RoomA1a;
    public GameObject RoomA1b;
    public GameObject RoomA2a;
    public GameObject RoomA2b;
    public GameObject RoomA3a;
    public GameObject RoomA3b;

    public GameObject RoomB1a;
    public GameObject RoomB1b;
    public GameObject RoomB2a;
    public GameObject RoomB2b;
    public GameObject RoomB3a;
    public GameObject RoomB3b;
    public GameObject RoomB4a;
    public GameObject RoomB4b;
    public GameObject RoomB5a;
    public GameObject RoomB5b;
    public GameObject RoomB6a;
    public GameObject RoomB6b;
    public GameObject RoomB7a;
    public GameObject RoomB7b;
    public GameObject RoomB8a;
    public GameObject RoomB8b;
    public GameObject RoomB9a;
    public GameObject RoomB9b;
    public GameObject RoomB10a;
    public GameObject RoomB10b;
    public GameObject RoomB11a;
    public GameObject RoomB11b;
    public GameObject RoomB12a;
    public GameObject RoomB12b;
    public GameObject RoomB13a;
    public GameObject RoomB13b;
    public GameObject RoomB14a;
    public GameObject RoomB14b;
    public GameObject RoomB15a;
    public GameObject RoomB15b;
    public GameObject RoomB16a;
    public GameObject RoomB16b;
    public GameObject RoomB17a;
    public GameObject RoomB17b;
    public GameObject RoomB18a;
    public GameObject RoomB18b;
    public GameObject RoomB19a;
    public GameObject RoomB19b;
    public GameObject RoomB20a;
    public GameObject RoomB20b;
    public GameObject RoomB21a;
    public GameObject RoomB21b;
    public GameObject RoomB22a;
    public GameObject RoomB22b;
    public GameObject RoomB23a;
    public GameObject RoomB23b;
    public GameObject RoomB24a;
    public GameObject RoomB24b;

    public GameObject RoomC1a;
    public GameObject RoomC1b;
    public GameObject RoomC2a;
    public GameObject RoomC2b;
    public GameObject RoomC3a;
    public GameObject RoomC3b;
    public GameObject RoomC4a;
    public GameObject RoomC4b;
    public GameObject RoomC5a;
    public GameObject RoomC5b;
    public GameObject RoomC6a;
    public GameObject RoomC6b;
    public GameObject RoomC7a;
    public GameObject RoomC7b;
    public GameObject RoomC8a;
    public GameObject RoomC8b;

    public GameObject RoomD1a;
    public GameObject RoomD1b;
    public GameObject RoomD2a;
    public GameObject RoomD2b;
    public GameObject RoomD3a;
    public GameObject RoomD3b;
    public GameObject RoomD4a;
    public GameObject RoomD4b;
    public GameObject RoomD5a;
    public GameObject RoomD5b;
    public GameObject RoomD6a;
    public GameObject RoomD6b;
    public GameObject RoomD7a;
    public GameObject RoomD7b;
    public GameObject RoomD8a;
    public GameObject RoomD8b;

    public GameObject SRoom1a;
    public GameObject SRoom1b;
    public GameObject SRoom2a;
    public GameObject SRoom2b;
    #endregion

    public enum LightStates
    {
        LightOn,
        LightOff
    }

    public bool RoomAOn = true;
    public bool RoomBOn = true;
    public bool RoomCOn = true;
    public bool RoomDOn = true;
    public bool Storage1On = true;
    public bool Storage2On = true;

    List<GameObject> roomA = new List<GameObject>();
    List<GameObject> roomB = new List<GameObject>();
    List<GameObject> roomC = new List<GameObject>();
    List<GameObject> roomD = new List<GameObject>();
    List<GameObject> sRoom1 = new List<GameObject>();
    List<GameObject> sRoom2 = new List<GameObject>();

    public LightStates RoomA;
    public LightStates RoomB;
    public LightStates RoomC;
    public LightStates RoomD;
    public LightStates StorageRoom1;
    public LightStates StorageRoom2;

    public void Awake()
    {
        roomA = new List<GameObject>() { RoomA1a, RoomA2a, RoomA3a, RoomA1b, RoomA2b, RoomA3b };
        roomB = new List<GameObject>() { RoomB1a, RoomB1b, RoomB2a, RoomB2b, RoomB3a, RoomB3b, RoomB4a, RoomB4b, RoomB5a, RoomB5b, RoomB6a, RoomB6b, RoomB7a, RoomB7b, RoomB8a, RoomB8b, RoomB9a, RoomB9b, RoomB10a, RoomB10b,
            RoomB11a, RoomB11b, RoomB12a, RoomB12b, RoomB13a, RoomB13b, RoomB14a, RoomB14b, RoomB15a, RoomB15b, RoomB16a, RoomB16b, RoomB17a, RoomB17b, RoomB18a, RoomB18b, RoomB19a, RoomB19b, RoomB20a, RoomB20b,
            RoomB21a, RoomB21b, RoomB22a, RoomB22b, RoomB23a, RoomB23b, RoomB24a, RoomB24b };
        roomC = new List<GameObject>() { RoomC1a, RoomC1b, RoomC2a, RoomC2b, RoomC3a, RoomC3b, RoomC4a, RoomC4b, RoomC5a, RoomC5b, RoomC6a, RoomC6b, RoomC7a, RoomC7b, RoomC8a, RoomC8b };
        roomD = new List<GameObject>() { RoomD1a, RoomD1b, RoomD2a, RoomD2b, RoomD3a, RoomD3b, RoomD4a, RoomD4b, RoomD5a, RoomD5b, RoomD6a, RoomD6b, RoomD7a, RoomD7b, RoomD8a, RoomD8b };
        sRoom1 = new List<GameObject>() { SRoom1a, SRoom1b};
        sRoom2 = new List<GameObject>() { SRoom2a, SRoom2b };

        RoomA = LightStates.LightOn;
        RoomB = LightStates.LightOn;
        RoomC = LightStates.LightOn;
        RoomD = LightStates.LightOn;
        StorageRoom1 = LightStates.LightOn;
        StorageRoom2 = LightStates.LightOn;
    }

    void TurnLightsOn(List<GameObject> room, ref bool On)
    {
        if (!On)
        {
            foreach (GameObject L in room) L.SetActive(true);
            On = true;
        }
    }

    void TurnLightsOff(List<GameObject> room, ref bool On)
    {
        if (On)
        {
            foreach (GameObject L in room) L.SetActive(false);
            On = false;
        }
    }

    void Update()
    {
        switch (RoomA)
        {
            case LightStates.LightOn:
                TurnLightsOn(roomA, ref RoomAOn);
                break;
            case LightStates.LightOff:
                TurnLightsOff(roomA, ref RoomAOn);
                break;
            default:
                break;
        }
        switch (RoomB)
        {
            case LightStates.LightOn:
                TurnLightsOn(roomB, ref RoomBOn);
                break;
            case LightStates.LightOff:
                TurnLightsOff(roomB, ref RoomBOn);
                break;
            default:
                break;
        }
        switch (RoomC)
        {
            case LightStates.LightOn:
                TurnLightsOn(roomC, ref RoomCOn);
                break;
            case LightStates.LightOff:
                TurnLightsOff(roomC, ref RoomCOn);
                break;
            default:
                break;
        }
        switch (RoomD)
        {
            case LightStates.LightOn:
                TurnLightsOn(roomD, ref RoomDOn);
                break;
            case LightStates.LightOff:
                TurnLightsOff(roomD, ref RoomDOn);
                break;
            default:
                break;
        }
        switch (StorageRoom1)
        {
            case LightStates.LightOn:
                TurnLightsOn(sRoom1, ref Storage1On);
                break;
            case LightStates.LightOff:
                TurnLightsOff(sRoom1, ref Storage1On);
                break;
            default:
                break;
        }
        switch (StorageRoom2)
        {
            case LightStates.LightOn:
                TurnLightsOn(sRoom2, ref Storage2On);
                break;
            case LightStates.LightOff:
                TurnLightsOff(sRoom2, ref Storage2On);
                break;
            default:
                break;
        }
    }
}


