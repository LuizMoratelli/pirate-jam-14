using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityData : ScriptableObject
{
    public string id;
    public int damage;
    public float speed;
    public GameObject projectile;
    public float timeToDestroy;
    public float delayBetweenProjectiles;


    public virtual void Trigger(Vector3 spawnPoint, Vector3 targetPoint)
    {

    }
}
