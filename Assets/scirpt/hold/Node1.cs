using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node1 : MonoBehaviour
{
    public Color hoverColor1;
    public Color notEnoughtMoney1;
    public Vector3 positionOffest1;

    [Header("Optinal")]
    public GameObject turret1;

    private Renderer rend1;
    private Color startcolor1;
    public TurretBlueprint blueprint1;
    //shop
    buildManager1 buildManager1;



    void Start()
    {
        rend1 = GetComponent<Renderer>();
        startcolor1 = rend1.material.color;

        //shop
        buildManager1 = buildManager1.instance;
    }


    //buy
    public Vector3 GetbuildPosition1()
    {
        return transform.position + positionOffest1;
    }



    void OnMouseDown()
    {
        //shop
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        //shop
        if (!buildManager1.CanBuild1)
            return;

        if (turret1 != null)
        {
            Debug.Log("Can't");
            return;
        }

        buildManager1.BuildTurretOn1(this);

    }
    void OnMouseEnter()
    {

        //shop
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        //shop
        if (!buildManager1.CanBuild1)
            return;

        if (buildManager1.HasMoney1)
        {
            //hover
            rend1.material.color = hoverColor1;
        }
        else
        {
            //merge not use
            rend1.material.color = notEnoughtMoney1;
        }



    }



    void OnMouseExit()
    {
        //not hover
        rend1.material.color = startcolor1;
    }

}
