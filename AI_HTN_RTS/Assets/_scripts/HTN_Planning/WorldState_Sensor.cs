using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// World Properties
public struct WorldProperties
{
    public int WS_Player_Num;
    public int WS_Player_Gold_Num;
    public int WS_Player_Rock_Num;
    public int WS_Player_Wood_Num;
    public Vector3 WS_Player_Location;
    public bool WS_isPlayer_Free;
    public bool WS_isG1Empty;
    public bool WS_isG2Empty;
    public bool WS_isR1Empty;
    public bool WS_isR2Empty;
    public bool WS_isT1Empty;
    public bool WS_isT2Empty;
    public int WS_Factory_Num;
}

public enum Location
{
    BaseLoc = 0,
    G1Loc,
    G2Loc,
    R1Loc,
    R2Loc,
    T1Loc,
    T2Loc
}

public enum Resource
{
    Gold,
    Rock,
    Wood
}

public enum Buildings
{
    Factory
}

public class WorldState_Sensor : MonoBehaviour
{

    WorldProperties WorldProperty;
    WorldProperties PlayerProperty;
    List<Vector3> AbsoluteLocation = new List<Vector3>();
    bool change;

    public WorldProperties GetWorldProperty() { return WorldProperty; }
    public void SetWorldProperty_GoldNum(int num) { WorldProperty.WS_Player_Gold_Num = num; }
    public void SetWorldProperty_RockNum(int num) { WorldProperty.WS_Player_Rock_Num = num; }
    public void SetWorldProperty_WoodNum(int num) { WorldProperty.WS_Player_Wood_Num = num; }
    public void SetWorldProperty_G1Empty(bool val) { WorldProperty.WS_isG1Empty = val; }
    public void SetWorldProperty_G2Empty(bool val) { WorldProperty.WS_isG2Empty = val; }
    public void SetWorldProperty_R1Empty(bool val) { WorldProperty.WS_isR1Empty = val; }
    public void SetWorldProperty_R2Empty(bool val) { WorldProperty.WS_isR2Empty = val; }
    public void SetWorldProperty_T1Empty(bool val) { WorldProperty.WS_isT1Empty = val; }
    public void SetWorldProperty_T2Empty(bool val) { WorldProperty.WS_isT2Empty = val; }
    public void SetWorldProperty_PlayerLocation(Location loc) { WorldProperty.WS_Player_Location = AbsoluteLocation[(int)loc]; }
    public void SetWorldProperty_FactoryNum(int num) { WorldProperty.WS_Factory_Num = num; }
    public WorldProperties GetPlayerProperty() { return PlayerProperty; }
    public Vector3 GetAbsoluteLocation(Location index) { return AbsoluteLocation[(int)index]; }

    void Awake()
    {
        // Base
        AbsoluteLocation.Add(new Vector3(150.0f, 0.0f, 150.0f));
        // G1
        AbsoluteLocation.Add(new Vector3(4.0f, 0.0f, 24.0f));
        // G2
        AbsoluteLocation.Add(new Vector3(21.0f, 0.0f, 18.0f));
        // R1
        AbsoluteLocation.Add(new Vector3(14.0f, 0.0f, 7.0f));
        // R2
        AbsoluteLocation.Add(new Vector3(19.0f, 0.0f, 28.0f));
        // W1
        AbsoluteLocation.Add(new Vector3(4.0f * 5.0f, 0.0f, 24.0f * 5.0f));
        // W2
        AbsoluteLocation.Add(new Vector3(26.0f*5.0f, 0.0f, 6.0f*5.0f));
    }

    // Use this for initialization
    void Start ()
    {

        WorldProperty.WS_Player_Num = 1;
        WorldProperty.WS_Player_Gold_Num = 0;
        WorldProperty.WS_Player_Rock_Num = 0;
        WorldProperty.WS_Player_Wood_Num = 0;
        WorldProperty.WS_Player_Location = AbsoluteLocation[(int)Location.BaseLoc];
        WorldProperty.WS_isG1Empty = false;
        WorldProperty.WS_isG2Empty = false;
        WorldProperty.WS_isR1Empty = false;
        WorldProperty.WS_isR2Empty = false;
        WorldProperty.WS_isT1Empty = false;
        WorldProperty.WS_isT2Empty = false;
        WorldProperty.WS_isPlayer_Free = true;
        WorldProperty.WS_Factory_Num = 0;

        PlayerProperty.WS_Player_Num = 1;
        PlayerProperty.WS_Player_Gold_Num = 0;
        PlayerProperty.WS_Player_Rock_Num = 0;
        PlayerProperty.WS_Player_Wood_Num = 0;
        PlayerProperty.WS_Player_Location = AbsoluteLocation[(int)Location.BaseLoc];
        PlayerProperty.WS_isG1Empty = false;
        PlayerProperty.WS_isG2Empty = false;
        PlayerProperty.WS_isR1Empty = false;
        PlayerProperty.WS_isR2Empty = false;
        PlayerProperty.WS_isT1Empty = false;
        PlayerProperty.WS_isT2Empty = false;
        PlayerProperty.WS_isPlayer_Free = true;
        PlayerProperty.WS_Factory_Num = 0;

        change = false;
    }

    // Update Sensors
    void LateUpdate()
    {
        // Reset change
        change = false;

        // All Update
        UpdatePlayerCount();
        UpdateGoldNum();
        UpdateRockNum();
        UpdateWoodNum();
        UpdatePlayerLocation();
        UpdateG1();
        UpdateG2();
        UpdateR1();
        UpdateR2();
        UpdateT1();
        UpdateT2();
        UpdatePlayerFree();
        UpdateFactoryNum();
    }

    // Sensors
    void UpdatePlayerCount()
    {
        WorldProperty.WS_Player_Num = GameObject.FindGameObjectsWithTag("Player").Length;
        if (PlayerProperty.WS_Player_Num != WorldProperty.WS_Player_Num)
            change = true;
        PlayerProperty.WS_Player_Num = WorldProperty.WS_Player_Num;
    }

    void UpdateGoldNum()
    {
        if (PlayerProperty.WS_Player_Gold_Num != WorldProperty.WS_Player_Gold_Num)
            change = true;
        PlayerProperty.WS_Player_Gold_Num = WorldProperty.WS_Player_Gold_Num;
    }

    void UpdateRockNum()
    {
        if (PlayerProperty.WS_Player_Rock_Num != WorldProperty.WS_Player_Rock_Num)
            change = true;
        PlayerProperty.WS_Player_Rock_Num = WorldProperty.WS_Player_Rock_Num;
    }

    void UpdateWoodNum()
    {
        if (PlayerProperty.WS_Player_Wood_Num != WorldProperty.WS_Player_Wood_Num)
            change = true;
        PlayerProperty.WS_Player_Wood_Num = WorldProperty.WS_Player_Wood_Num;
    }

    void UpdatePlayerLocation()
    {
        PlayerProperty.WS_Player_Location = WorldProperty.WS_Player_Location;
    }

    void UpdateG1()
    {
        if (PlayerProperty.WS_Player_Location == AbsoluteLocation[(int)Location.G1Loc])
        {
            if (PlayerProperty.WS_isG1Empty != WorldProperty.WS_isG1Empty)
                change = true;
            PlayerProperty.WS_isG1Empty = WorldProperty.WS_isG1Empty;
        }
    }

    void UpdateG2()
    {
        if (PlayerProperty.WS_Player_Location == AbsoluteLocation[(int)Location.G2Loc])
        {
            if (PlayerProperty.WS_isG2Empty != WorldProperty.WS_isG2Empty)
                change = true;
            PlayerProperty.WS_isG2Empty = WorldProperty.WS_isG2Empty;
        }
    }

    void UpdateR1()
    {
        if (PlayerProperty.WS_Player_Location == AbsoluteLocation[(int)Location.R1Loc])
        {
            if (PlayerProperty.WS_isR1Empty != WorldProperty.WS_isR1Empty)
                change = true;
            PlayerProperty.WS_isR1Empty = WorldProperty.WS_isR1Empty;
        }
    }

    void UpdateR2()
    {
        if (PlayerProperty.WS_Player_Location == AbsoluteLocation[(int)Location.R2Loc])
        {
            if (PlayerProperty.WS_isR2Empty != WorldProperty.WS_isR2Empty)
                change = true;
            PlayerProperty.WS_isR2Empty = WorldProperty.WS_isR2Empty;
        }
    }

    void UpdateT1()
    {
        if (PlayerProperty.WS_Player_Location == AbsoluteLocation[(int)Location.T1Loc])
        {
            if (PlayerProperty.WS_isT1Empty != WorldProperty.WS_isT1Empty)
                change = true;
            PlayerProperty.WS_isT1Empty = WorldProperty.WS_isT1Empty;
        }
    }

    void UpdateT2()
    {
        if (PlayerProperty.WS_Player_Location == AbsoluteLocation[(int)Location.T2Loc])
        {
            if (PlayerProperty.WS_isT2Empty != WorldProperty.WS_isT2Empty)
                change = true;
            PlayerProperty.WS_isT2Empty = WorldProperty.WS_isT2Empty;
        }
    }
    void UpdatePlayerFree()
    {
        PlayerProperty.WS_isPlayer_Free = WorldProperty.WS_isPlayer_Free;
    }

    void UpdateFactoryNum()
    {
        PlayerProperty.WS_Factory_Num = WorldProperty.WS_Factory_Num;
    }


    // Check if any sensor changes
    public bool CheckSensorChange() { return change; }
}
