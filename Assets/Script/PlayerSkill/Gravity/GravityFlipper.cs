using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityFlipper : MonoBehaviour
{
    #region ref

    private GameObject player;

    #endregion

    [Range(0,30)]public float gravityMultiplier;
    private bool doOnce = true;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        if (Input.touchCount == 2 && doOnce)
        {
            player.GetComponent<Rigidbody2D>().gravityScale = player.GetComponent<Rigidbody2D>().gravityScale * (gravityMultiplier * -1);
            player.GetComponent<Rigidbody2D>().gravityScale = Mathf.Clamp(player.GetComponent<Rigidbody2D>().gravityScale, -30, 30);
            player.layer = LayerMask.NameToLayer("NoPlayerCollision");
            // spriteRenderer
            doOnce = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.layer == LayerMask.NameToLayer("Wall"))
       {
          player.layer = LayerMask.NameToLayer("Default");
          doOnce = true;
       }
    }
}
        
