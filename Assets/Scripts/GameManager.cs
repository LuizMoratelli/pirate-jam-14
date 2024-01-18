using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private Dictionary<Vector2, Enemy> dict_enemies = new Dictionary<Vector2, Enemy>();
    public GameObject[] initial_enemies;
    public GameObject enemy_prefab;

    public Dictionary<Vector2, Enemy> DictEnemies => dict_enemies;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        foreach (var initialEnemy in initial_enemies)
        {
            var enemy = initialEnemy.GetComponent<Enemy>();
            enemy.position = new Vector2(initialEnemy.transform.position.x, initialEnemy.transform.position.y);
            dict_enemies.Add(enemy.position, enemy);

        }
    }

    public void Spread(Vector2 position, Enemy enemy)
    {
        // TODO: validar se está no limite do mapa (exemplo, min position = -20, max position =20)

        GameObject newObject = Instantiate(enemy_prefab, new Vector3(position.x, position.y, 0), Quaternion.identity);
        var newEnemy = newObject.GetComponent<Enemy>();
        newEnemy.data = enemy.data;
        newEnemy.SetData();
        newEnemy.position = position;
        dict_enemies.Add(position, newEnemy);
    }

    public void RemoveEnemy(Vector2 position)
    {
        dict_enemies.Remove(position);
    }

    // Função para remover inimigos do dictionary
}