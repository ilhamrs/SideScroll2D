using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set;}

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Awake()
    {
        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
        }
        else
        {
            anim.SetTrigger("die");
            GetComponent<PlayerMovement>().enabled = false;
        }
    }

    public void takeDamageEnemy(float damage)
    {
        currentHealth = currentHealth - damage;

        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
        }
        else
        {
            anim.SetTrigger("die");
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    public void addHealth(float healthValue)
    {
        currentHealth = Mathf.Clamp(currentHealth + healthValue, 0, startingHealth);
    }
}
