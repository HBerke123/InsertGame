using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObtainSkills : MonoBehaviour
{
    public bool obtainedSound;
    public bool obtainedGun;
    public bool obtainedSwordSkill;

    private void Update()
    {
        if (obtainedSound)
        {
            this.GetComponentInChildren<SoundDomain>().enabled = true;
            this.GetComponentInChildren<SoundUse>().enabled = true;
            this.GetComponentInChildren<ScreamUse>().enabled = true;
        }
        else
        {
            this.GetComponentInChildren<SoundDomain>().enabled = false;
            this.GetComponentInChildren<SoundUse>().enabled = false;
            this.GetComponentInChildren<ScreamUse>().enabled = false;
        }

        if (obtainedGun) 
        {
            this.GetComponentInChildren<GunShot>().enabled = true;
        }
        else
        {
            this.GetComponentInChildren<GunShot>().enabled = false;
        }

        if (obtainedSwordSkill)
        {
            this.GetComponentInChildren<SwordSkill>().enabled = true;
        }
        else 
        {
            this.GetComponentInChildren<SwordSkill>().enabled = false;
        }
    }
}
