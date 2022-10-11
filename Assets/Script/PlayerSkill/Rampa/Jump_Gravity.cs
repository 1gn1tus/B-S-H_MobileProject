using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump_Gravity : MonoBehaviour
{
    #region jumpGravity prop

    public float jumpForce;

    #endregion

    #region ref

    private GameObject gameM;
    private GameObject player;

    #endregion

    public bool test;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gameM = GameObject.FindObjectOfType<GravityManager>().gameObject;
    }

    void Update()
    {
        if (test)
        {
            if(gameM.GetComponent<GravityManager>().IsGravityFlipped == false)
            {
                JumpGravity();
            }

            else
            {
                JumpAntiGravity();
            }
           
            test = false;
        }
    }

    public void JumpGravity()
    {
        player.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce * Time.deltaTime,ForceMode2D.Impulse);
    }

    public void JumpAntiGravity()
    {
        player.GetComponent<Rigidbody2D>().AddForce(Vector2.down * jumpForce * Time.deltaTime,ForceMode2D.Impulse);
    }
}
