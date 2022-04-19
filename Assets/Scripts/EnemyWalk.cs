using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalk : MonoBehaviour
{
    private Rigidbody2D rbEnemy;
    private Animator enemyAnim;
    private EnemyMelee enemyMelee;
    private bool checkPlayer;
    [SerializeField] private float speed;
    [SerializeField] private float waitTurn;
    // Start is called before the first frame update
    void Start()
    {
        rbEnemy = GetComponent<Rigidbody2D>();
        enemyAnim = GetComponent<Animator>();
        enemyMelee = GetComponent<EnemyMelee>();
        StartCoroutine(Walk());
    }

    // Update is called once per frame
    void Update()
    {
        checkPlayer = enemyMelee.checkPlayerNearby;
    }

    IEnumerator Walk()
    {
        while (!checkPlayer)
        {
            enemyAnim.SetBool("isMove", true);

            rbEnemy.velocity = new Vector2(1 * speed, rbEnemy.velocity.y);
            transform.localScale = Vector3.one;
            yield return new WaitForSeconds(waitTurn);

            rbEnemy.velocity = new Vector2(-1 * speed, rbEnemy.velocity.y);
            transform.localScale = new Vector3(-1, 1, 1);
            yield return new WaitForSeconds(waitTurn);
        }
    }
}
