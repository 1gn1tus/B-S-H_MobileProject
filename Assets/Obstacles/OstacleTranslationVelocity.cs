using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OstacleTranslationVelocity : MonoBehaviour
{
    [SerializeField]
    private float speedX;
    [SerializeField]
    private float speedY;
    [SerializeField]
    private float DestroyDistance;

    private void Update()
    {
        if ((this.transform.position.y) < DestroyDistance)
        {
            Destroy(this.gameObject);
        }

        this.transform.Translate(Vector3.down * speedY * Time.deltaTime);
        this.transform.Translate(Vector3.left * speedX * Time.deltaTime);
    }
}
