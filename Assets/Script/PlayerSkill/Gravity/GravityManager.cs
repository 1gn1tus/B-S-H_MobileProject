using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityManager : MonoBehaviour
{
    #region ref
    private GameObject player;
    [SerializeField]
    private GameObject shootingSource;
    [SerializeField]
    private GameObject shootingSourceVertical;
    [Range(0, 200)] public float TouchspeedVerticalManager;

    [System.NonSerialized] public bool IsGravityFlipped;
    public float gravityIntensity;
    public float jumpH;
    public float JumpT;
    public float gravityMultiplier;
    
    #endregion

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
  
    void Start()
    {
        player.GetComponent<Move>().enabled = false;
        player.AddComponent<MoveVertical>();
        player.GetComponent<MoveVertical>().TouchspeedVertical = this.TouchspeedVerticalManager;
        player.GetComponent<MoveVertical>().JoystickSpeed = 15;
        player.GetComponent<JumpBehaviour>().enabled = false;
        player.AddComponent<Jump_Gravity>();
        player.GetComponent<Jump_Gravity>().jumpTime = JumpT;
        player.GetComponent<Jump_Gravity>().jumpHeight = jumpH;
        player.AddComponent<GravityFlipper>();
        player.GetComponent<GravityFlipper>().gravityMultiplier = this.gravityMultiplier;
        player.GetComponent<AutomateShooting>().projectileDirOrizzontal = true;
        player.GetComponent<Rigidbody2D>().gravityScale = gravityIntensity;
        shootingSource.SetActive(false);
        shootingSourceVertical.SetActive(true);
    }
}
