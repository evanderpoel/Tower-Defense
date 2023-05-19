using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;


public class TurretDisplay : MonoBehaviour
{
    public TurretScriptableObject turret;
    
    [SerializeField] private GameObject hoverBox;
    [SerializeField] private TMP_Text hoverBoxName;
    [SerializeField] private TMP_Text hoverBoxDamage;
    [SerializeField] private TMP_Text hoverBoxInfo;
    [SerializeField] private TMP_Text turretName;



    private void OnEnable()
    {
        hoverBoxName.text = turret.turretName;
        turretName.text = turret.turretName;
        hoverBoxDamage.text = turret.turretDamage.ToString();
        hoverBoxInfo.text = turret.turretInfo;
    }

    private void OnMouseOver()
    {
        Debug.Log("Mouse Over");
        hoverBox.SetActive(true);
    }

    private void OnMouseEnter()
    {
        Debug.Log("Mouse Enter");
    }
}
