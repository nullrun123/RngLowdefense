using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shop : MonoBehaviour
{
    //sell
    public TurretBlueprint StandardTurret;
    public TurretBlueprint RocketStandardTurret;
    public TurretBlueprint laserTurret;
    public TurretBlueprint WaterSlow;
    public TurretBlueprint LavaSlow;
    buildManager buildManager;
    buildManager1 buildManager1;
    void Start()
    {
        buildManager = buildManager.instance;
        buildManager1 = buildManager1.instance;
    }
    public void SelectStandardTurret()
    {
        Debug.Log("You got Turret");
        buildManager.SelectTurretTobuild(StandardTurret);
    }
    public void SelectRocketStandardTurret()
    {
        Debug.Log("You got Rocket");
        buildManager.SelectTurretTobuild(RocketStandardTurret);
    }
    public void SelectLaserStandardTurret()
    {
        Debug.Log("You got Laser");
        buildManager.SelectTurretTobuild(laserTurret);
    }
    public void SelectWaterSlow()
    {
        Debug.Log("You got Water");
        buildManager1.SelectTurretTobuild1(WaterSlow);
    }
    public void SelectLavaSlow()
    {
        Debug.Log("You got Lava");
        buildManager1.SelectTurretTobuild1(LavaSlow);
    }
}


