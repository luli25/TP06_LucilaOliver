using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField]
    private LayerMask playerMask;

    public bool isGrounded = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!Utilities.CheckLayerInMask(playerMask, collision.gameObject.layer))
        {
            isGrounded = true;
        }
    }
}
