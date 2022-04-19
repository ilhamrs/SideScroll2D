using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private int damage;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private float cooldownTimer = Mathf.Infinity;
    [SerializeField] private float range;
    [SerializeField] private float distanceCollider;
    public BoxCollider2D boxCollider;
    private Animator anim;
    private Health playerHealth;
    public bool checkPlayerNearby;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer += Time.deltaTime;

        if (checkPlayer())
        {
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;

                anim.SetTrigger("meleeAttack");
            }
        }
        checkPlayerNearby = checkPlayer();
    }

    private bool checkPlayer()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + -transform.right * range * transform.localScale.x * distanceCollider, 
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z), 
            0, 
            Vector2.left, 
            0,  
            playerLayer);

        if (hit.collider !=null)
        {
            playerHealth = hit.transform.GetComponent<Health>();
        }
        
        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(
            boxCollider.bounds.center + -transform.right * range * transform.localScale.x * distanceCollider, 
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    private void damagePlayer()
    {
        if (checkPlayer())
        {
            playerHealth.takeDamage(damage);
        }
    }
}
