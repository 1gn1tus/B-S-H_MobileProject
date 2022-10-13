using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityFlipper : MonoBehaviour
{
    #region ref

    private GameObject player;
    private GravityManager gravityM;

    #endregion

    [Range(0,30)]public float gravityMultiplier;
    private bool doOnce = true;
    private bool reDo = true;

    private void Awake()
    {
        gravityM = GameObject.FindObjectOfType<GravityManager>();
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
            gravityM.IsGravityFlipped =! gravityM.IsGravityFlipped;
            doOnce = false;
            reDo = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.layer == LayerMask.NameToLayer("Wall"))
       {
          player.layer = LayerMask.NameToLayer("Player");
          StartCoroutine(CanFlip());
       }
    }

    private IEnumerator CanFlip()
    {
        if (!reDo)
        {
            yield return new WaitForSeconds(1f);
            doOnce = true;
            reDo = true;
        }  
    }

}
        
