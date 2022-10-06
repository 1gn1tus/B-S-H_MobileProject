using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBehaviour : MonoBehaviour
{
    #region jump parameters

    [SerializeField]
    private float jumpTime;
    [SerializeField]
    private float jumpIncreaseMovementSpeed;
    [SerializeField]
    private float jumpLerpTime;
    [SerializeField]
    private float maxScaleX;
  
    private float normalScale;
    private const float scaleModifier = 0.1f;
    private bool jumpEnding = false;
    private bool canJump = false;

    #endregion

    #region player ref

    private GameObject player;
    private Move movement;

    #endregion

    public bool test;

    private void Awake()
    {
        movement = GameObject.FindObjectOfType<Move>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Start()
    {
        normalScale = this.gameObject.transform.localScale.x;
    }

    private void Update()
    {
        if (test)
        {
            Jump();
            test = false;
        }

        JumpEnd();
    }

    public void Jump()
    {
        player.GetComponent<Collider2D>().enabled = false;
        canJump = true;
        movement.Touchspeed = movement.Touchspeed + jumpIncreaseMovementSpeed;
        movement.JoystickSpeed = movement.JoystickSpeed + jumpIncreaseMovementSpeed;
        StartCoroutine(JumpLoop());
    }

    private IEnumerator JumpLoop()
    {
        yield return new WaitForSeconds(jumpTime);
        jumpEnding = true;
    }

    public void JumpEnd()
    {
        if (canJump)
        {
            this.transform.localScale = Scale(scaleModifier);
            if (this.transform.localScale.x >= maxScaleX)
            {
                canJump = false;
            }
        }
        else if (jumpEnding)
        {
            this.transform.localScale = Scale(-scaleModifier);
            if (this.transform.localScale.x <= normalScale)
            {
                jumpEnding = false;
                player.GetComponent<Collider2D>().enabled = true;
                movement.Touchspeed = movement.Touchspeed - jumpIncreaseMovementSpeed;
                movement.JoystickSpeed = movement.JoystickSpeed - jumpIncreaseMovementSpeed;
            }
        }
    }

    public Vector3 Scale(float scale)
    {
        Vector3 newScale = Vector3.Lerp(this.gameObject.transform.localScale, new Vector3(this.gameObject.transform.localScale.x + scale, this.gameObject.transform.localScale.y + scale, 0), jumpLerpTime * Time.deltaTime);
        return newScale;
    }
}
