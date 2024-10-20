using System;
using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class buildManager : MonoBehaviour
{

    public static buildManager instance;
    
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }


  

   
    public GameObject standardTurretPrefab;
    public GameObject RocketStandardTurret;
  
    public GameObject BuildEffect;
    private TurretBlueprint turretToBuild;

  


    //Canbuild buy
    public bool CanBuild {  get {  return turretToBuild != null; } }    

    //merge not use
    public bool HasMoney {  get { return PlayerState.money >= turretToBuild.cost; } }
    public void BuildTurretOn(Node node)
    {
        int c = PlayerPrefs.GetInt(turretToBuild.prefab.name);

        if(c < 1)
        {
            SoundManager1_1.instance.PlaySoundWithCooldown(0.3f);
            Debug.Log("Not enough");
            Debug.Log(c.ToString());
            Debug.Log(turretToBuild.prefab.name);
           
            return;
        }
        //buy (not use to merge)
        c--;

        PlayerPrefs.SetInt(turretToBuild.prefab.name,c);

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetbuildPosition(), Quaternion.identity);
        SoundManager1.instance.PlaySoundWithCooldown(0.23f);
        node.turret = turret;
          

        //effect build
        GameObject effect = (GameObject)Instantiate(BuildEffect, node.GetbuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
    }

    //buy new

    public void SelectTurretTobuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
      
    }
    internal void BuildTurretOn(Node1 node1)
    {
        throw new NotImplementedException();
    }
}
