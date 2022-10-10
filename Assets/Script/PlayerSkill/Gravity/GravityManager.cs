using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityManager : MonoBehaviour
{
    #region ref
    [SerializeField]
    private GameObject shootingSource;
    private GameObject player;
    public float gravityIntensity;

    #endregion

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    // Start is called before the first frame update
    void Start()
    {
        player.GetComponent<Move>().enabled = false;
        player.GetComponent<Rigidbody2D>().gravityScale = gravityIntensity;
    }

    // Update is called once per frame
    void Update()
    {
        shootingSource.transform.position = new Vector3(player.transform.position.x + 1.5f, player.transform.position.y, 0);
    }
}
