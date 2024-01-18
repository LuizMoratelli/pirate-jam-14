using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyData", menuName = "enemies/newEnemy")]
public class EnemyData : ScriptableObject
{
    public string _id;
    public int hp;
    public int damage;
    public float time_to_spread;

    public virtual Vector2 SpreadPosition(Enemy data, Dictionary<Vector2, Enemy> dict_enemies)
    {
        var left = data.position - new Vector2(1, 0);
        var leftEnemy = dict_enemies.GetValueOrDefault(left, null);
        var right = data.position + new Vector2(1, 0);
        var rightEnemy = dict_enemies.GetValueOrDefault(right, null);
        List<Vector2> availablePositions = new List<Vector2>();

        if (leftEnemy == null)
        {
            availablePositions.Add(left);
        }

        if (rightEnemy == null)
        {
            availablePositions.Add(right);
        }

        // Workaround
        if (availablePositions.Count == 0)
        {
            return data.position;
        }

        var randomIndex = Random.Range(0, availablePositions.Count);
        
        return availablePositions[randomIndex];
    }
}
