using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/TurretsObject", order = 1)]
public class TurretScriptableObject : ScriptableObject
{
    public string turretName;

    public GameObject turretPrefab;

}
