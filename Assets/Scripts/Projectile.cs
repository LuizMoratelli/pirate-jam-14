using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    float speed;
    int damage;
    Rigidbody2D _rigidBody;

    public void Setup(float timeToDestroy, float speed, int damage)
    {
        this.speed = speed;
        this.damage = damage;
        Destroy(gameObject, timeToDestroy);
    }

    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (speed != 0)
        {
            _rigidBody.velocity = transform.up * speed * Time.fixedDeltaTime * 60;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = collision.GetComponent<Enemy>();

        if (enemy == null) return;

        enemy.TakeDamage(damage);
    }
}