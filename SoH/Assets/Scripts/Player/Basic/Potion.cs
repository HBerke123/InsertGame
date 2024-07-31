using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    public float healAmount;
    public float cEAmount;
    public bool hasPotion;
    bool drinking;

    private void Update()
    {
        if (hasPotion && Input.GetKeyDown(KeyCode.F) && !drinking && !this.GetComponentInChildren<SwordAttack>().ready && !this.GetComponentInChildren<SoundUse>().started && !this.GetComponentInChildren<ScreamUse>().screaming && !this.GetComponentInChildren<GunShot>().started && (this.GetComponent<ForcesOnObject>().Force == Vector2.zero) && !this.GetComponent<BlocksOnObject>().isBlocked)
        {
            drinking = true;
            this.GetComponent<CEDrainage>().GainCE(cEAmount);
            this.GetComponent<HealthDrainage>().Heal(healAmount);
            hasPotion = false;
        }
    }
}
