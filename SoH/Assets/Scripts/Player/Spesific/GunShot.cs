using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShot : MonoBehaviour
{
    public List<GameObject> lastBombs = new();
    public GameObject arrow;
    public GameObject PreBombShower;
    public GameObject Bomb;
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
    public float bombForceY;
    public int cecost;
    int ammo = 3;
    bool explosed;
    bool started;
    bool reloading;
    float th = 0;
    float hth = 0;

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
                    PreBombShower.GetComponent<PreBombGroup>().showing = true;
                    PreBombShower.GetComponent<ShowPreBombs>().ShowBombs();
                }
            }

            if (!explosed)
            {
                if ((Input.GetMouseButtonUp(0) || (hth == 0)) && (ammo > 0) && (th == 0) && started)
                {
                    started = false;
                    this.GetComponentInParent<MakeSound>().AddTime(soundTime);
                    PreBombShower.GetComponent<PreBombGroup>().showing = false;
                    PreBombShower.GetComponent<ShowPreBombs>().StopShowing();

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

    void SendBomb(float bombforce)
    {
        arrow.transform.LookAt(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        GameObject SBox = Instantiate(Bomb, this.transform.position, Quaternion.identity);
        lastBombs.Add(SBox);

        if (arrow.transform.localRotation.eulerAngles.y < 180)
        {
            SBox.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Cos(-arrow.transform.localRotation.eulerAngles.x), Mathf.Sin(-arrow.transform.localRotation.eulerAngles.x)) * maxbombforce;
            this.transform.localScale = Vector3.one;
            this.transform.localRotation = Quaternion.Euler(0, 0, -arrow.transform.localRotation.eulerAngles.x);
        }
        else
        {
            SBox.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Cos(-arrow.transform.localRotation.eulerAngles.x), Mathf.Sin(-arrow.transform.localRotation.eulerAngles.x)) * maxbombforce;
            this.transform.localScale = Vector3.one - Vector3.right * 2;
            this.transform.localRotation = Quaternion.Euler(0, 0, arrow.transform.localRotation.eulerAngles.x);
        }

        SBox.GetComponent<BombExplode>().damageAmount = damage;
        ammo--;

        if (ammo == 0) 
        {
            StartCoroutine(Reload());
        }
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
