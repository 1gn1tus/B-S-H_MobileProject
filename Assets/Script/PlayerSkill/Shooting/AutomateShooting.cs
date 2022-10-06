using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomateShooting : MonoBehaviour
{
    #region Projectiles Properties

    private bool canSpawn = true;

    public float projectileSpawnRate; // upgradable

    [Range(0,50)]public float ProjectileSpeed; // upgradable

    #endregion

    public GameObject projectile_Prefab;

    public GameObject shootingSource;

    private void Update()
    {
        if (canSpawn)
        {
            canSpawn = false;
            StartCoroutine(ProjectileSpawn());
        }
    }

    private IEnumerator ProjectileSpawn()
    {
        yield return new WaitForSeconds(projectileSpawnRate);
        GameObject projectileObject = Instantiate(projectile_Prefab, shootingSource.transform.position, projectile_Prefab.transform.rotation,shootingSource.transform);
        canSpawn = true;
     }
}
