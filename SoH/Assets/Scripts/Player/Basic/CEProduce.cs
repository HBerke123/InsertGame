using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CEProduce : MonoBehaviour
{
    CEDrainage ced;
    public float CEproduceCd = 2;
    public int CEproduceVa = 1;

    public void Start()
    {
        ced = this.GetComponent<CEDrainage>();
        StartCoroutine(Pce());
    }

    IEnumerator Pce()
    {
        yield return new WaitForSecondsRealtime(CEproduceCd);
        ced.GainCE(CEproduceVa);
        StartCoroutine(Pce());
    }
}
