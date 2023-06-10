using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Wave", order = 1)]
public class WaveScriptableObject : ScriptableObject
{
    [SerializeField] private List<GameObject> enemies;
    [SerializeField] private int enemy0Count;
    [SerializeField] private int enemy1Count;
    [SerializeField] private int enemy2Count;
}
