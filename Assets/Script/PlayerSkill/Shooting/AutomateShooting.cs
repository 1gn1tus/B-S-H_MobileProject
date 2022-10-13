using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomateShooting : MonoBehaviour
{
    #region Projectiles Properties

    private bool canSpawn = true;

    public float projectileSpawnRate; // upgradable

    [Range(0,50)]public float ProjectileSpeed; // upgradable

    [System.NonSerialized] public bool projectileDirOrizzontal;

    #endregion

    #region gameObject

    public GameObject projectile_Prefab;

    public GameObject shootingSource;

    public GameObject shootingSourceOrizzontal;

    public GameObject projectileContainer;

    #endregion

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
        if (!projectileDirOrizzontal)
        {
            Instantiate(projectile_Prefab, shootingSource.transform.position, projectile_Prefab.transform.rotation,projectileContainer.transform);
            canSpawn = true;
        }

        else
        {
            Instantiate(projectile_Prefab, shootingSourceOrizzontal.transform.position, projectile_Prefab.transform.rotation,projectileContainer.transform);
            canSpawn = true;
        } 
     }
}
