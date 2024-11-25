using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opossum : MonoBehaviour
{
    [Header("Patrol")]

    [SerializeField]
    private EnemyData enemyData;

    [SerializeField]
    private Transform[] points;

    [SerializeField]
    private float minDistance;

    [SerializeField]
    private Animator animator;

    private int randomNumber;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        randomNumber = Random.Range(0, points.Length);
        spriteRenderer = GetComponent<SpriteRenderer>();
        Turn();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, points[randomNumber].position, enemyData.speed * Time.deltaTime);

        animator.Play("Walk", 0);

        if (Vector2.Distance(transform.position, points[randomNumber].position) < minDistance)
        {
            randomNumber = Random.Range(0, points.Length);
            Turn();
        }
    }

    private void Turn()
    {
        if (transform.position.x < points[randomNumber].position.x)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }
}
