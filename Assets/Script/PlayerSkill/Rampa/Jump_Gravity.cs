using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump_Gravity : MonoBehaviour
{
    #region jumpGravity prop

    private bool canJump = true;
    [System.NonSerialized]public float jumpTime;
    [System.NonSerialized]public float jumpHeight;
    private bool resetGravity = true;
    private bool resetAntiGravity = false;

    #endregion

    #region ref

    private GameObject gameM;

    #endregion

    public bool test;

    private void Awake()
    {
        gameM = GameObject.FindObjectOfType<GravityManager>().gameObject;
    }

    void Update()
    {
        if (test)
        {
            if(gameM.GetComponent<GravityManager>().IsGravityFlipped == false)
            {
                if (canJump)
                {
                    JumpGravity();
                }
            }

            else
            {
                if (canJump)
                {
                    JumpAntiGravity();
                }
            }
           
            test = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            canJump = true;
            this.gameObject.layer = LayerMask.NameToLayer("Default");
            if (resetGravity)
            {
                this.GetComponent<Rigidbody2D>().gravityScale = 1;
                resetGravity = false;
            }
            else if(resetAntiGravity)
            {
                resetAntiGravity = false;
                this.GetComponent<Rigidbody2D>().gravityScale = -1;
            }
        }
    }

    public void JumpGravity()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, this.transform.position + new Vector3(0, jumpHeight, 0), jumpTime * Time.deltaTime);
        canJump = false;
        this.GetComponent<Rigidbody2D>().gravityScale = 15;
        this.gameObject.layer = LayerMask.NameToLayer("NoPlayerCollision");
        resetGravity = true;
    }

    public void JumpAntiGravity()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, this.transform.position + new Vector3(0, -jumpHeight, 0), jumpTime * Time.deltaTime);
        canJump = false;
        this.GetComponent<Rigidbody2D>().gravityScale = -15;
        this.gameObject.layer = LayerMask.NameToLayer("NoPlayerCollision");
        resetAntiGravity = true;
    }
}
