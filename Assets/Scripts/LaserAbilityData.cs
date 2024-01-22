using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewLaserAbility", menuName = "Abilities/Laser Ability")]
public class LaserAbilityData : AbilityData
{

    public override void Trigger(Vector3 spawnPoint, Vector3 targetPoint)
    {
        Debug.Log(targetPoint);
        base.Trigger(spawnPoint, targetPoint);
        var goProjectile = Instantiate(projectile, new Vector2(targetPoint.x , targetPoint.y), Quaternion.identity);
        goProjectile.GetComponent<Projectile>().Setup(timeToDestroy, speed, damage);
        
        goProjectile.transform.up = new Vector2(targetPoint.x - spawnPoint.x, targetPoint.y - spawnPoint.y);
    }
}