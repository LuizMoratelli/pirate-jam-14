using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 10;
    Rigidbody2D _rigidBody;
    PlayerInput _input;
    Vector2 _movementDirection;
    [SerializeField] List<AbilityData> abilities = new List<AbilityData>();
    [SerializeField] Transform projectilePoint;

    // TODO: change delay to be for each ability
    int abilityIndex = 0;
    float timeToNextTrigger = 0;
    bool isTriggering = false;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _input = GetComponent<PlayerInput>();

    }

    public void Move(InputAction.CallbackContext context)
    {
        _movementDirection = context.ReadValue<Vector2>();
    }

    public void TriggerAbility1(InputAction.CallbackContext context)
    {
        TriggerAbility(context, 0);
    }

    public void TriggerAbility2(InputAction.CallbackContext context)
    {
        TriggerAbility(context, 1);
    }

    void TriggerAbility(InputAction.CallbackContext context, int value)
    {
        if (value >= abilities.Count) return;

        if (context.action.WasPressedThisFrame())
        {
            isTriggering = true;
            abilityIndex = value;

        } else if (context.action.WasReleasedThisFrame())
        {
            isTriggering = false;
            timeToNextTrigger = 0;
        }

    }


    void Start()
    {

    }

    void Update()
    {
        TryTriggerAbility();
    }

    void TryTriggerAbility()
    {
        if (!isTriggering) return;

        Debug.Log(timeToNextTrigger);

        if (timeToNextTrigger > 0) {
            timeToNextTrigger -= Time.deltaTime;
        }
        else {
            var ability = abilities[abilityIndex];
            ability.Trigger(projectilePoint.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
            timeToNextTrigger = ability.delayBetweenProjectiles;
        }
        
    }

    private void FixedUpdate()
    {
        _rigidBody.velocity = _movementDirection * speed * Time.fixedDeltaTime * 60;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = collision.GetComponent<Enemy>();

        if (enemy == null) return;

        enemy.TakeDamage(1);
    }
}
