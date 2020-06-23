using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{

    [Range(0f, 2f)] float currentSpeed = 1f;
    GameObject currentTarget;

    //cached components
    Animator animator;

    private void Awake()
    {
        FindObjectOfType<LevelController>().AttackerSpawned();

    }
    private void OnDestroy()
    {
        LevelController levelController = FindObjectOfType<LevelController>();

        if(levelController != null)
        {
            levelController.AttackerKilled();
        }

    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        CharacterMovement();
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if (!currentTarget)
        {
            animator.SetBool("isAttacking", false);
        }

    }


    private void CharacterMovement()
    {
        transform.Translate(Vector2.left * Time.deltaTime * currentSpeed);
    }

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }


    public void Attack(GameObject target)
    {
        animator.SetBool("isAttacking", true);
        currentTarget = target;
    }


    public void StrikeCurrentTarget(float damage)
    {

        if (!currentTarget) { return; }

        Health health = currentTarget.GetComponent<Health>();
        if (health)
        {
            health.DealDamage(damage);
        }

    }






}
