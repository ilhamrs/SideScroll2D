using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRange : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] projectiles;
    [SerializeField] private float delay;

    private Animator anim;
    private Health health;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        health = GetComponent<Health>();
        StartCoroutine(Shoot());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Shoot()
    {
        while (health.currentHealth > 0)
        {
            AttackRange();
            yield return new WaitForSeconds(delay);
        }
        
    }

    private void AttackRange()
    {
        anim.SetTrigger("isAttack");

        projectiles[checkProjectile()].transform.position = firePoint.position;
        projectiles[checkProjectile()].GetComponent<Projectile>().setDirection(Mathf.Sign(transform.localScale.x));
    }

    private int checkProjectile()
    {
        for (int i = 0; i < projectiles.Length; i++)
        {
            if (!projectiles[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }
}
