using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapsWalk : MonoBehaviour
{
    private Rigidbody2D rbEnemy;

    [SerializeField] private float speed;
    [SerializeField] private float waitTurn;

    // Start is called before the first frame update
    void Start()
    {
        rbEnemy = GetComponent<Rigidbody2D>();
        StartCoroutine(Walk());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Walk()
    {
        while (true)
        {
            rbEnemy.velocity = new Vector2(1 * speed, rbEnemy.velocity.y);
            transform.localScale = Vector3.one;
            yield return new WaitForSeconds(waitTurn);

            rbEnemy.velocity = new Vector2(-1 * speed, rbEnemy.velocity.y);
            transform.localScale = new Vector3(-1, 1, 1);
            yield return new WaitForSeconds(waitTurn);
        }
    }
}
