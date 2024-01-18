using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyData data;
    public int HP;
    public float TimeToSpread;
    public Vector2 position;

    private void Start()
    {
        SetData();

        if (TimeToSpread != 0)
        {
            StartCoroutine("Spread");
        }
    }

    public void SetData()
    {
        HP = data.hp;
        TimeToSpread = data.time_to_spread;
    }

    IEnumerator Spread()
    {
        yield return new WaitForSeconds(TimeToSpread);
        Vector2 spreadPosition = data.SpreadPosition(this, GameManager.Instance.DictEnemies);
        if (spreadPosition != position)
        {
            GameManager.Instance.Spread(spreadPosition, this);
        }
        StartCoroutine("Spread");
    }

    public void TakeDamage(int amount)
    {
        HP -= amount;
        if (HP <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        GameManager.Instance.RemoveEnemy(position);
        Destroy(gameObject, 0.1f);
    }
}


