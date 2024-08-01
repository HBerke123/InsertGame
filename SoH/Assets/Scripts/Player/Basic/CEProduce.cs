using System.Collections;
using UnityEngine;

public class CEProduce : MonoBehaviour
{
    public float delayAmount;
    public float cEproduceCd;
    public int cEproduceVa;
    float dth;
    float th;

    private void FixedUpdate()
    {
        if ((Time.time - th > cEproduceCd) && (delayAmount == 0))
        {
            this.GetComponent<CEDrainage>().GainCE(cEproduceVa);
            th = Time.time;
        }

        if ((dth == 0) && (delayAmount > 0))
        {
            dth = Time.time;
        }
        else if (Time.time - dth > delayAmount)
        {
            delayAmount = 0;
            dth = 0;
        }
    }
}
