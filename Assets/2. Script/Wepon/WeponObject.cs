using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WeponObject: ScriptableObject
{
    public string weponName;
    public float damage;
    public float speed;
    public float frequency;
    public float numProjectiles;
}
