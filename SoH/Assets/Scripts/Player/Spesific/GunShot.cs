using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShot : MonoBehaviour
{
    public List<GameObject> lastBombs = new();
    public GameObject preBombShower;
    public GameObject preBomb;
    public GameObject bomb;
    public float soundTime;
    public float damage;
    public float htime;
    public float reloadtime;
    public float ceregaintime;
    public float minbombforce;
    public float maxbombforce;
    public float cooldown;
    public float minsize;
    public float maxsize;
    public int cecost;
    int ammo = 3;
    bool explosed;
    bool started;
    bool reloading;
    float th = 0;
    float hth = 0;

    private void Start()
    {
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
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && (this.GetComponentInParent<PrimaryItems>().itemEquipped == "Gun"))
        {
            explosed = true;

            for (int i = 0; i < lastBombs.Count; i++)
            {
                lastBombs[i].GetComponent<BombExplode>().Explode();
            }
        }

        if ((this.GetComponentInParent<PrimaryItems>().itemEquipped == "Gun") && !reloading)
        {  
            if (lastBombs.Count == 0)
            {
                if (Input.GetMouseButtonDown(0) && (ammo > 0) && (th == 0))
                {
                    started = true;
                    explosed = false;
                    hth = Time.time;
                    preBombShower.GetComponent<PreBombGroup>().showing = true;
                    preBombShower.GetComponent<PreBombGroup>().ShowGroup();
                    preBombShower.GetComponent<ShowPreBombs>().ShowBombs();
                }
            }

            if (!explosed)
            {
                if ((Input.GetMouseButtonUp(0) || (hth == 0)) && (ammo > 0) && (th == 0) && started)
                {
                    started = false;
                    this.GetComponentInParent<MakeSound>().AddTime(soundTime);
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
            }
        }
    }

    void SendBomb(float bombForce)
    {
        float distanceX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - this.transform.position.x;
        float distanceY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - this.transform.position.y;
        float distance = Mathf.Sqrt(Mathf.Pow(distanceX, 2) + Mathf.Pow(distanceY, 2));
        GameObject SBox = Instantiate(bomb, this.transform.position, Quaternion.identity);
        lastBombs.Add(SBox);
        SBox.GetComponent<Rigidbody2D>().velocity = new Vector2(distanceX / distance, distanceY / distance) * (minbombforce + (maxbombforce - minbombforce) * bombForce);
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
        SBox.GetComponent<Rigidbody2D>().velocity = Vector2.right * (minbombforce + (maxbombforce - minbombforce) * bombForce);
        SBox.GetComponent<PreBombStop>().totalTime = time / 10;
        Debug.Log(SBox.GetComponent<Rigidbody2D>().velocity.ToString() + " " + SBox.GetComponent<PreBombStop>().totalTime.ToString());
        Destroy(SBox.GetComponent<ShowPreBomb>());
    }

    IEnumerator Reload()
    {
        reloading = true;
        this.GetComponentInParent<CEDrainage>().LoseCE(cecost);
        StartCoroutine(RegainCE());
        yield return new WaitForSecondsRealtime(reloadtime);
        reloading = false;
        ammo = 3;
    }

    IEnumerator RegainCE()
    {
        for (int i = 0; i < cecost; i++)
        {
            yield return new WaitForSecondsRealtime(ceregaintime / cecost);
            this.GetComponentInParent<CEDrainage>().GainCE(1);
        }
    }
}
