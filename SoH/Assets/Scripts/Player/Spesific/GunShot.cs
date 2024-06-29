using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShot : MonoBehaviour
{
    public GameObject Bomb;
    public GameObject SoundWave;
    public float ttime;
    public float reloadtime;
    public float ceregaintime;
    public float bombforce;
    public float cooldown;
    public float minsize;
    public float maxsize;
    public float twtime;
    public int cecost;
    int ammo = 3;
    bool reloading = false;
    float th = 0;

    void Update()
    {
        if ((this.GetComponentInParent<PrimaryItems>().itemEquipped == "Gun") && !reloading)
        {
            if (Input.GetMouseButtonDown(0) && (ammo > 0) && (Time.time - th > cooldown))
            {
                SendBomb();
                th = Time.time;
            }
            else if (Input.GetMouseButtonDown(0) && (ammo == 0))
            {
                StartCoroutine(Reload());
            }
        }
    }

    void SendBomb()
    {
        GameObject SBox = Instantiate(Bomb, this.transform.position, new Quaternion(0, 0, 0, 0));
        SBox.GetComponent<Rigidbody2D>().AddForce(Vector2.right * bombforce, ForceMode2D.Impulse);
        SBox.GetComponent<BombExplode>().TotalTime = ttime;
        SBox.GetComponent<BombExplode>().minsize = minsize;
        SBox.GetComponent<BombExplode>().maxsize = maxsize;
        SBox.GetComponent<BombExplode>().ttime = twtime;
        SBox.GetComponent<BombExplode>().SoundWave = SoundWave;
        ammo--;
    }

    IEnumerator Reload()
    {
        reloading = true;
        this.GetComponentInParent<CEDrainage>().LoseCE(cecost);
        StartCoroutine(RegainCE());
        yield return new WaitForSecondsRealtime(reloadtime);
        reloading = false;
        th = 0;
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
