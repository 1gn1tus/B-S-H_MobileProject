using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAbility : MonoBehaviour
{
    public float coolDown;
    public float canShootAgain;
    private bool canUseSpecialAbility = true;
    private AutomateShooting automateShooting;
    private SpecialAbilityManager specialAbilityManager;

    private void Awake()
    {
        automateShooting = this.gameObject.GetComponent<AutomateShooting>();
        specialAbilityManager = GameObject.FindObjectOfType<SpecialAbilityManager>();
    }

    void Update()
    {
        if (canUseSpecialAbility)
        {
            if (Input.touchCount > 0)
            {
                if (Input.GetTouch(0).tapCount == 2)
                {
                    automateShooting.enabled = false;
                    specialAbilityManager.UseCurrentAbility();
                    StartCoroutine(UseAbiltyAgain());
                    StartCoroutine(UseShootingAgain());
                    canUseSpecialAbility = false;
                }
            }
        }
    }

    private IEnumerator UseShootingAgain()
    {
        yield return new WaitForSeconds(canShootAgain);
        automateShooting.enabled = true;

    }

    private IEnumerator UseAbiltyAgain()
    {
        yield return new WaitForSeconds(coolDown);
        canUseSpecialAbility = true;

    }
}
