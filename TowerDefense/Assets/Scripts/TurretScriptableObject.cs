using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/TurretsObject", order = 1)]
public class TurretScriptableObject : ScriptableObject
{
    public string turretName;
    public float turretDamage;
    public string turretInfo;

    public GameObject turretPrefab;

    public GameObject cannotPlaceTurretPrefab;

    public GameObject canPlaceTurretPrefab;

}
