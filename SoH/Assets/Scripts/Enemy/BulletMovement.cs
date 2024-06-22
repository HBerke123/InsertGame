using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(BulletStop());
    }

    IEnumerator BulletStop()
    {
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
    }
}
