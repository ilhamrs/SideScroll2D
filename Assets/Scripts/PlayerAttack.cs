using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    private Animator anim;
    private PlayerMovement playerMovement;
    private float cooldownTimer = Mathf.Infinity;

    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] projectiles;

    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private float range;
    [SerializeField] private float distanceCollider;
    public SoundManager soundManager;
    public CapsuleCollider2D capsuleCollider;
    private Health enemyHealth;
    private Ammo ammo;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        ammo = GetComponent<Ammo>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B) && cooldownTimer > attackCooldown)
        {
            AttackRange();
            
        }

        if (Input.GetKeyDown(KeyCode.V) && cooldownTimer > attackCooldown)
        {
            AttackMelee();

        }

        cooldownTimer += Time.deltaTime;
    }

    private void AttackRange()
    {
        if (ammo.getCurrentAmmo() > 0)
        {
            anim.SetTrigger("attackRange");
            cooldownTimer = 0;

            projectiles[checkProjectile()].transform.position = firePoint.position;
            projectiles[checkProjectile()].GetComponent<Projectile>().setDirection(Mathf.Sign(transform.localScale.x));

            ammo.fireAmmo();
            soundManager.shootSound();
        }
    }

    private void AttackMelee()
    {
        anim.SetTrigger("attackMelee");
        cooldownTimer = 0;

        if (checkEnemy())
        {
            enemyHealth.takeDamageEnemy(1);
        }
    }

    private void walk()
    {
        soundManager.walkSound();
    }

    private int checkProjectile()
    {
        for(int i = 0; i < projectiles.Length; i++)
        {
            if (!projectiles[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }

    private bool checkEnemy()
    {
        RaycastHit2D hit = Physics2D.BoxCast(capsuleCollider.bounds.center + transform.right * range * transform.localScale.x * distanceCollider,
            new Vector3(capsuleCollider.bounds.size.x * range, capsuleCollider.bounds.size.y, capsuleCollider.bounds.size.z),
            0,
            Vector2.left,
            0,
            enemyLayer);

        if (hit.collider != null)
        {
            enemyHealth = hit.transform.GetComponent<Health>();
        }

        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(
            capsuleCollider.bounds.center + transform.right * range * transform.localScale.x * distanceCollider,
            new Vector3(capsuleCollider.bounds.size.x * range, capsuleCollider.bounds.size.y, capsuleCollider.bounds.size.z));
    }
}
