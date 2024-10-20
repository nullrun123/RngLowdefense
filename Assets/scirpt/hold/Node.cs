using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughtMoney;
    public Vector3 positionOffest;

    [Header("Optinal")]
    public GameObject turret;

    private Renderer rend;
    private Color startcolor;
    public TurretBlueprint blueprint;
    //shop
    buildManager buildManager;

 
    
    void Start()
    {
        rend = GetComponent<Renderer>();
        startcolor = rend.material.color;

        //shop
        buildManager = buildManager.instance;
    }


    //buy
    public Vector3 GetbuildPosition()
    {
        return transform.position + positionOffest;
    }



    void OnMouseDown()
    {
        //shop
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        //shop
        if (!buildManager.CanBuild)
            return;

        if (turret != null)
        {
            SoundManager1_1.instance.PlaySoundWithCooldown(0.5f);
            Debug.Log("Can't");
            
            return;
        }

        buildManager.BuildTurretOn(this);

    }
    void OnMouseEnter()
    {

        //shop
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        //shop
        if (!buildManager.CanBuild)
            return;

        if (buildManager.HasMoney)
        {
            //hover
            rend.material.color = hoverColor;
        }
        else
        {
            //merge not use
            rend.material.color = notEnoughtMoney;
        }

    

    }

  
   
    void OnMouseExit()
    {
        //not hover
        rend.material.color = startcolor;
    }

}
