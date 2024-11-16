using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [SerializeField]
    private Vector2 movementSpeed;

    [SerializeField]
    private Rigidbody2D playerRb;

    private Vector2 offset;
    private Material material;

    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    private void Update()
    {
        offset = (playerRb.velocity.x * 0.1f) * movementSpeed * Time.deltaTime;
        material.mainTextureOffset += offset;
    }
}
