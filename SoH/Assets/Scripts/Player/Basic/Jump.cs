using UnityEngine;
using System.Collections.Generic;

public class Jump : MonoBehaviour
{
    readonly List<float> reloadTimes = new();

    [SerializeField] GroundDetection jumpBox;

    public bool screaming;
    public bool stick;
    public float soundTime;
    public float jumpforce;
    public float jumptime;
    public float cEDelay;
    public float cost;
    public float reloadTime;

    bool jumping;
    bool jumped;
    float stime;
    MenuOpener menuOpener;
    GamepadControls gamepadControls;
    Rigidbody2D rb;
    CEDrainage ced;
    ForcesOnObject foo;
    CEProduce cep;
    MakeSound ms;
    Crouching c;
    Animator a;

    private void Awake()
    {
        menuOpener = GetComponent<MenuOpener>();
        gamepadControls = GetComponent<GamepadControls>();
        rb = GetComponent<Rigidbody2D>();
        ced = GetComponent<CEDrainage>();
        foo = GetComponent<ForcesOnObject>();
        cep = GetComponent<CEProduce>();
        ms = GetComponent<MakeSound>();
        c = GetComponent<Crouching>();
        a = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < reloadTimes.Count; i++)
        {
            if (Time.time > reloadTimes[i])
            {
                reloadTimes.RemoveAt(i);

                if (ced.cE < ced.maxCE / 2) ced.GainCE(1);
            }
        }
    }

    private void Update()
    {
        if (!menuOpener.isMenuOpen)
        {
            a.SetBool("Grounded", jumpBox.detected || GetComponentInChildren<PlatformDetection>().detected);

            if (gamepadControls.jumping.IsPressed() && (jumpBox.detected || GetComponentInChildren<PlatformDetection>().detected) && !stick && (foo.Force.y == 0) && !c.isCrouching && !jumping && !jumped)
            {
                jumped = true;
                jumping = true;
                a.SetBool("Jumping", true);
                ced.LoseCE(cost);
                ms.AddTime(soundTime);
                cep.delayAmount = Mathf.Max(cep.delayAmount, cEDelay);
                stime = Time.time;
                rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);

                for (int i = 1; i < cost + 1; i++) reloadTimes.Add(Time.time + reloadTime / cost * i);
            }
            else if (gamepadControls.jumping.IsPressed() && (jumpBox.detected || GetComponentInChildren<PlatformDetection>().detected) && !stick && (foo.Force == Vector2.zero) && !jumping && !jumped) c.Crouch();
            else if (!gamepadControls.jumping.IsPressed() || (Time.time - stime > jumptime))
            {
                a.SetBool("Jumping", false);
                jumping = false;
            }

            if (!gamepadControls.jumping.IsPressed() && (jumpBox.detected || GetComponentInChildren<PlatformDetection>().detected)) jumped = false;
        }
    }
}