using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    //code i used:-https://www.youtube.com/watch?v=Lm7Uh88uQM8
    private Animator animtor;
    [SerializeField] int damage;
    [SerializeField] float attackRange;
    [SerializeField] Transform attackPointRight;
    [SerializeField] Transform attackPointLeft;
    [SerializeField] LayerMask enemyLayer;
    private SpriteRenderer spriteRenderer;

    public float cooldownTime = .5f;
    private float cooldownTimer = 0f;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animtor = GetComponent<Animator>();
    }

    void Update()
    {
        if (cooldownTimer <= 0)
        {
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                Attack();
                cooldownTimer = cooldownTime;
            }
        }
        else 
        {
            cooldownTimer -= Time.deltaTime;
        }
    }

    void Attack() 
    {
        animtor.SetTrigger("meleeAttack");

        Transform currentAttackPoint;
        if (spriteRenderer.flipX)
        {
            currentAttackPoint = attackPointLeft;
        }
        else 
        {
            currentAttackPoint = attackPointRight;
        }

        Collider2D[] enemies = Physics2D.OverlapCircleAll(currentAttackPoint.position, attackRange, enemyLayer);

        for (int i = 0; i < enemies.Length; i++) 
        {
            Enemy health = enemies[i].GetComponent<Enemy>();
            if (health != null) 
            {
                health.TakeDamageEnemy(damage);
            }
        }
    }
}