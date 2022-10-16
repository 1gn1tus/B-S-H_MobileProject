using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DIrectLineWIthShoot : MonoBehaviour,IEnemyBehaviour
{
    #region prop

    [SerializeField]
    public Vector3 DirectionToFollow;
    [SerializeField]
    public float Speed;

    #endregion

    [System.NonSerialized] public bool isThisEnemyActive = false;
    [System.NonSerialized] public int HordeCounter = 1;
    private GameObject player;
    private GameObject gameM;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gameM = GameObject.FindObjectOfType<EnemyHordeBehaviour>().gameObject;
    }

    private void Update()
    {
        if (isThisEnemyActive)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, DirectionToFollow, Speed * Time.deltaTime);
            Vector3 dir = player.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 270;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            if (this.transform.position == DirectionToFollow)
            {
                gameM.GetComponent<EnemyHordeBehaviour>().UploadHordeEnemyCounter(HordeCounter);
                this.gameObject.SetActive(false); 
            }
        }
    }   

    public bool isThisEnemyBehaviourActive()
    {
        isThisEnemyActive = true;
        return isThisEnemyActive;
    }

    public void enemyActiveSelf()
    {
        this.HordeCounter = 0;
    }
}
