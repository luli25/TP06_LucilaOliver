using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [SerializeField]
    private Vector2 movementSpeed;
    private Vector2 offset;
    private Material material;

    //private Rigidbody2D playerRb;

    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
        //playerRb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //offset = (playerRb.velocity.x * 0.1f) * movementSpeed * Time.deltaTime;
        offset = movementSpeed * Time.deltaTime;
        material.mainTextureOffset += offset;
    }
}
