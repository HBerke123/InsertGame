using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    public float drinkTime;
    public float healAmount;
    public float cEAmount;
    public bool hasPotion;
    bool drinking;
    float th;

    private void FixedUpdate()
    {
        if ((th != 0) && (Time.time - th > drinkTime))
        {
            this.GetComponent<CEDrainage>().GainCE(cEAmount);
            this.GetComponent<HealthDrainage>().Heal(healAmount);
            drinking = false;
            hasPotion = false;
            th = 0;
        }
    }

    private void Update()
    {
        if (hasPotion && Input.GetKeyDown(KeyCode.F) && !drinking && !this.GetComponentInChildren<SwordAttack>().ready && !this.GetComponentInChildren<SoundUse>().started && !this.GetComponentInChildren<ScreamUse>().screaming && !this.GetComponentInChildren<GunShot>().started && (this.GetComponent<ForcesOnObject>().Force == Vector2.zero) && !this.GetComponent<BlocksOnObject>().isBlocked)
        {
            drinking = true;
            th = Time.time;
        }

        if (drinking && Input.GetKeyUp(KeyCode.F))
        {
            drinking = false;
            th = 0;
        }
    }
}
