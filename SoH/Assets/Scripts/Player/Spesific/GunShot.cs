using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShot : MonoBehaviour
{
    readonly List<float> reloadTimes = new();
    public List<GameObject> lastBombs = new();
    public GameObject[] preBombGroups;
    public GameObject preBombShower;
    public GameObject preBomb;
    public GameObject bomb;
    public float soundTime;
    public float damage;
    public float htime;
    public float reloadTime;
    public float cERegaintime;
    public float minbombforce;
    public float maxbombforce;
    public float cooldown;
    public float minsize;
    public float maxsize;
    public float delayTime;
    public int cECost;
    public bool started;
    int ammo = 3;
    bool shooted;
    bool explosed;
    bool reloading;
    float th;
    float hth;
    CEDrainage ced;
    SwordAttack sa;
    SoundUse su;
    BlocksOnObject boo;
    Crouching c;
    ScreamUse su2;
    Potion p;
    MakeSound ms;
    CEProduce cep;
    SpriteRenderer sr;
    CrouchingDetection cd;
    GamepadControls gamepadControls;

    private void Start()
    {
        gamepadControls = GameObject.FindGameObjectWithTag("GamepadController").GetComponent<GamepadControls>();
        sr = this.GetComponentInParent<SpriteRenderer>();
        cep = this.GetComponentInParent<CEProduce>();
        ms = this.GetComponentInParent<MakeSound>();
        p = this.GetComponentInParent<Potion>();
        su2 = this.GetComponent<ScreamUse>();
        c = this.GetComponentInParent<Crouching>();
        boo = this.GetComponentInParent<BlocksOnObject>();
        su = this.GetComponent<SoundUse>();
        sa = this.GetComponent<SwordAttack>();
        ced = this.GetComponentInParent<CEDrainage>();
        cd = c.GetComponentInChildren<CrouchingDetection>();

        for (int i = 0; i < 2; i++)
        {
            for (int j = 1; j < 6; j++)
            {
                SendPreBomb(i, j);
            }
        }
    }

    void FixedUpdate()
    {
        if ((th != 0) && (Time.time - th > cooldown))
        {
            th = 0;
        }

        if ((hth != 0) && (Time.time - hth > htime))
        {
            hth = 0;
        }

        for (int i = 0; i < reloadTimes.Count; i++)
        {
            if (Time.time > reloadTimes[i])
            {
                reloadTimes.RemoveAt(i);

                if (ced.cE < ced.maxCE / 2)
                {
                    ced.GainCE(1);
                }
            }
        }
    }

    private void Update()
    {
        if ((Input.GetMouseButton(1) || gamepadControls.gunShot) && !shooted)
        {
            explosed = false;

            for (int i = 0; i < lastBombs.Count; i++)
            {
                lastBombs[i].GetComponent<BombExplode>().Explode();
                explosed = true;
                shooted = true;
            }
        }

        if (!reloading)
        {
            if (lastBombs.Count == 0)
            {
                if ((Input.GetMouseButton(1) || gamepadControls.gunShot) && !shooted && (ammo > 0) && (th == 0) && !explosed && !su.started && !boo.isBlocked && !sa.ready && !c.isCrouching && !su2.screaming && !p.drinking && !started)
                {
                    shooted = true;
                    started = true;
                    explosed = false;
                    hth = Time.time;
                    preBombShower.GetComponent<PreBombGroup>().showing = true;
                    preBombShower.GetComponent<PreBombGroup>().ShowGroup();
                    preBombShower.GetComponent<ShowPreBombs>().ShowBombs();
                }
                else if ((Input.GetMouseButton(1) || gamepadControls.gunShot) && !shooted && (ammo > 0) && (th == 0) && !explosed && !su.started && !boo.isBlocked && !sa.ready && cd.isSafe && !su2.screaming && !p.drinking && !c.changing)
                {
                    c.Crouch();
                }
            }

            if ((Input.GetMouseButtonUp(1) || !gamepadControls.gunShot || (hth == 0)) && (ammo > 0) && (th == 0) && started)
            {
                started = false;
                ms.AddTime(soundTime);
                preBombShower.GetComponent<PreBombGroup>().showing = false;
                preBombShower.GetComponent<ShowPreBombs>().StopShowing();

                if (hth == 0)
                {
                    SendBomb(1);
                }
                else
                {
                    SendBomb((Time.time - hth) / htime);
                }

                th = Time.time;
                hth = 0;
            }

            if ((Input.GetMouseButtonUp(1) || !gamepadControls.gunShot) && shooted)
            {
                shooted = false;
            }
        }
    }

    void SendBomb(float bombForce)
    {
        float distanceX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - this.transform.position.x;
        float distanceY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - this.transform.position.y;
        float distance = Mathf.Sqrt(Mathf.Pow(distanceX, 2) + Mathf.Pow(distanceY, 2));
        GameObject SBox = Instantiate(bomb, this.transform.position, Quaternion.identity);
        cep.delayAmount = Mathf.Max(cep.delayAmount, delayTime);
        lastBombs.Add(SBox);

        if (gamepadControls.gunDirection == Vector2.zero)
        {
            if (!sr.flipX)
            {
                if ((gamepadControls.gunDirection.x / Mathf.Abs(gamepadControls.gunDirection.x)) == 1)
                {
                    SBox.GetComponent<Rigidbody2D>().velocity = new Vector2(gamepadControls.gunDirection.x, gamepadControls.gunDirection.y) * (minbombforce + (maxbombforce - minbombforce) * bombForce);
                }
                else
                {
                    SBox.GetComponent<Rigidbody2D>().velocity = new Vector2(0, gamepadControls.gunDirection.y) * (minbombforce + (maxbombforce - minbombforce) * bombForce);
                }
            }
            else
            {
                if ((distanceX / Mathf.Abs(distanceX)) == 1)
                {
                    SBox.GetComponent<Rigidbody2D>().velocity = new Vector2(0, gamepadControls.gunDirection.y) * (minbombforce + (maxbombforce - minbombforce) * bombForce);
                }
                else
                {
                    SBox.GetComponent<Rigidbody2D>().velocity = new Vector2(gamepadControls.gunDirection.x, gamepadControls.gunDirection.y) * (minbombforce + (maxbombforce - minbombforce) * bombForce);
                }
            }
        }
        else
        {
            if (!sr.flipX)
            {
                if ((distanceX / Mathf.Abs(distanceX)) == 1)
                {
                    SBox.GetComponent<Rigidbody2D>().velocity = new Vector2(distanceX / distance, distanceY / distance) * (minbombforce + (maxbombforce - minbombforce) * bombForce);
                }
                else
                {
                    SBox.GetComponent<Rigidbody2D>().velocity = new Vector2(0, distanceY / distanceY) * (minbombforce + (maxbombforce - minbombforce) * bombForce);
                }
            }
            else
            {
                if ((distanceX / Mathf.Abs(distanceX)) == 1)
                {
                    SBox.GetComponent<Rigidbody2D>().velocity = new Vector2(0, distanceY / distanceY) * (minbombforce + (maxbombforce - minbombforce) * bombForce);
                }
                else
                {
                    SBox.GetComponent<Rigidbody2D>().velocity = new Vector2(distanceX / distance, distanceY / distance) * (minbombforce + (maxbombforce - minbombforce) * bombForce);
                }
            }
        }

        SBox.GetComponent<BombExplode>().damageAmount = damage;
        ammo--;

        if (ammo == 0)
        {
            StartCoroutine(Reload());
        }
    }

    void SendPreBomb(int bombForce, int time)
    {
        GameObject SBox = Instantiate(preBomb, Vector3.zero, Quaternion.identity);
        SBox.GetComponent<PreBombStop>().owningGroup = preBombGroups[bombForce];
        SBox.GetComponent<Rigidbody2D>().velocity = Vector2.right * (minbombforce + (maxbombforce - minbombforce) * bombForce);
        SBox.GetComponent<PreBombStop>().totalTime = time * 0.1f;
        Destroy(SBox.GetComponent<ShowPreBomb>());
    }

    IEnumerator Reload()
    {
        reloading = true;
        ced.LoseCE(cECost);
        cep.delayAmount = Mathf.Max(cep.delayAmount, delayTime);

        for (int i = 1; i < cECost + 1; i++)
        {
            reloadTimes.Add(Time.time + cERegaintime / cECost * i);
        }

        yield return new WaitForSecondsRealtime(reloadTime);
        reloading = false;
        ammo = 3;
    }
}
