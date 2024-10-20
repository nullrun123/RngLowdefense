using System;
using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class buildManager1 : MonoBehaviour
{

    public static buildManager1 instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }

    public GameObject WaterSlow;
    public GameObject LavaSlow;
    public GameObject BuildEffect1;
    private TurretBlueprint turretToBuild1;

    //Canbuild buy
    public bool CanBuild1 { get { return turretToBuild1 != null; } }

    //merge not use
    public bool HasMoney1 { get { return PlayerState.money >= turretToBuild1.cost; } }
    public void BuildTurretOn1(Node1 node1)
    {
        int c = PlayerPrefs.GetInt(turretToBuild1.prefab.name);

        if(c < 1)
        {
            SoundManager1_1.instance.PlaySoundWithCooldown(0.3f);
            Debug.Log("Not enough");
            Debug.Log(c.ToString());
            Debug.Log(turretToBuild1.prefab.name);
            return;
        }
        //buy (not use to merge)
        c--;

        PlayerPrefs.SetInt(turretToBuild1.prefab.name,c);
       
        GameObject turret1 = (GameObject)Instantiate(turretToBuild1.prefab, node1.GetbuildPosition1(), Quaternion.identity);
        SoundManager1.instance.PlaySoundWithCooldown(0.23f);
        node1.turret1 = turret1;

        //effect build
        GameObject effect1 = (GameObject)Instantiate(BuildEffect1, node1.GetbuildPosition1(), Quaternion.identity);
        Destroy(effect1, 5f);
    }
    //buy
    public void SelectTurretTobuild1(TurretBlueprint turret1)
    {
        turretToBuild1 = turret1;
    }

}
