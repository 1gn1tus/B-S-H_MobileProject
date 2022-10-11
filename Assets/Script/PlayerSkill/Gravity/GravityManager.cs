using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityManager : MonoBehaviour
{
    #region ref
    [SerializeField]
    private GameObject shootingSource;
    private GameObject player;
    [System.NonSerialized] public bool IsGravityFlipped;
    public float gravityIntensity;
    public float jumpIntensity;
    public float gravityMultiplier;
    
    #endregion

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    // Start is called before the first frame update
    void Start()
    {
        player.GetComponent<Move>().enabled = false;
        player.AddComponent<MoveVertical>();
        player.GetComponent<MoveVertical>().Touchspeed = 60;
        player.GetComponent<JumpBehaviour>().enabled = false;
        player.AddComponent<Jump_Gravity>();
        player.GetComponent<Jump_Gravity>().jumpForce = jumpIntensity;
        player.AddComponent<GravityFlipper>();
        player.GetComponent<GravityFlipper>().gravityMultiplier = this.gravityMultiplier;
        player.GetComponent<AutomateShooting>().projectileDirOrizzontal = true;
        player.GetComponent<Rigidbody2D>().gravityScale = gravityIntensity;
    }

    // Update is called once per frame
    void Update()
    {
        shootingSource.transform.position = new Vector3(player.transform.position.x + 1.5f, player.transform.position.y, 0);
    }
}
