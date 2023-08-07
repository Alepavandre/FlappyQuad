using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StatsData", menuName = "ScriptableObjects/Stats", order = 1)]
public class Stats : ScriptableObject
{
    public float border = 3.94f;

    public float quadMinDistance = 1f;
    public float quadMaxDistance = 5f;
    public float quadMinSpeed = 1f;
    public float quadMaxSpeed = 4f;
    public float quadLivingTime = 5f;

    public float bonusSpeed = 3f;
}
