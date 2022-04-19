using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float timer;
    private float direction;
    private bool isHit;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private float projectileLifetime;
    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        projectileLifetime += Time.deltaTime;
        if (projectileLifetime > timer)
        {
            gameObject.SetActive(false);
        }

        if (isHit) return;

        float movementSpeed = speed * Time.deltaTime * direction;
        transform.Translate(movementSpeed, 0, 0);

        //projectileLifetime += Time.deltaTime;
        //if (projectileLifetime > 5)
        //{
        //    gameObject.SetActive(false);
        //}

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isHit = true;
        boxCollider.enabled = false;
        anim.SetTrigger("explode");

        if(collision.tag == "enemy")
        {
            collision.GetComponent<Health>().takeDamageEnemy(damage);
        }

        if(collision.tag == "Player")
        {
            collision.GetComponent<Health>().takeDamage(damage);
        }
        
    }

    public void setDirection(float projectileDirection)
    {
        projectileLifetime = 0;
        direction = projectileDirection;
        gameObject.SetActive(true);
        isHit = false;
        boxCollider.enabled = true;

        float localScaleX = transform.localScale.x;
        if(Mathf.Sign(localScaleX) != projectileDirection)
        {
            localScaleX = -localScaleX;
        }

        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);

    }

    private void deactivate()
    {
        gameObject.SetActive(false);
    }
}
