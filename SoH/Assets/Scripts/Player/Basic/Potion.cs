using UnityEngine;

public class Potion : MonoBehaviour
{
    /*public float drinkTime;
    public float healAmount;
    public float cEAmount;
    public bool hasPotion;
    public bool drinking;
    public AudioClip drinkingSound;

    float th;
    AudioSource as1;
    GamepadControls gamepadControls;
    HealthDrainage hd;
    CEDrainage ced;
    SwordAttack sa;
    SoundUse su;
    ScreamUse su2;
    GunShot gs;
    BlocksOnObject boo;
    Animator a;
    Crouching c;
    MenuOpener mo;

    private void Start()
    {
        mo = GameObject.FindGameObjectWithTag("GamepadController").GetComponent<MenuOpener>();
        as1 = this.GetComponent<AudioSource>();
        gamepadControls = GameObject.FindGameObjectWithTag("GamepadController").GetComponent<GamepadControls>();
        c = this.GetComponent<Crouching>();
        a = this.GetComponent<Animator>();
        boo = this.GetComponent<BlocksOnObject>();
        gs = this.GetComponentInChildren<GunShot>();
        su2 = this.GetComponentInChildren<ScreamUse>();
        su = this.GetComponentInChildren<SoundUse>();
        sa = this.GetComponentInChildren<SwordAttack>();
        ced = this.GetComponent<CEDrainage>();
        hd = this.GetComponent<HealthDrainage>();
    }

    private void FixedUpdate()
    {
        if ((Time.time - th > drinkTime) && drinking)
        {
            drinking = false;
            a.SetBool("Drinking", false);
        }
    }

    private void Update()
    {
        if (!mo.isMenuOpen)
        {
            if (hasPotion && (Input.GetKey(KeyCode.F) || gamepadControls.potion) && !drinking && !sa.ready && !su.started && !su2.screaming && !gs.started && !boo.isBlocked && !c.isCrouching)
            {
                as1.PlayOneShot(drinkingSound);
                a.SetBool("Drinking", true);
                drinking = true;
                ced.GainCE(cEAmount);
                hd.Heal(healAmount);
                hasPotion = false;
                th = Time.time;
            }
            else if (hasPotion && (Input.GetKey(KeyCode.F) || gamepadControls.potion) && !drinking && !sa.ready && !su.started && !su2.screaming && !gs.started && !boo.isBlocked)
            {
                c.Crouch();
            }
        }
    }*/
}