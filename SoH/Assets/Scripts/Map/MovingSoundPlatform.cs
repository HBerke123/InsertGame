using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSoundPlatform : MonoBehaviour
{
    public GameObject soundExplosion;
    public GameObject firstObject;
    public GameObject secondObject;
    public float speed;
    public float hittingSpeed;
    float startDistance;
    bool hitted;

    private void Start()
    {
        float distancex = secondObject.transform.position.x - firstObject.transform.position.x;
        float distancey = secondObject.transform.position.y - firstObject.transform.position.y;
        float distance = Mathf.Sqrt(Mathf.Pow(distancex, 2) + Mathf.Pow(distancey, 2));
        startDistance = distance;
    }

    private void Update()
    {
        float distancex = secondObject.transform.position.x - firstObject.transform.position.x;
        float distancey = secondObject.transform.position.y - firstObject.transform.position.y;
        float distance = Mathf.Sqrt(Mathf.Pow(distancex, 2) + Mathf.Pow(distancey, 2));

        

        if (firstObject.GetComponent<BoxCollider2D>().IsTouching(secondObject.GetComponent<BoxCollider2D>()))
        {
            hitted = true;
        }

        if (!hitted)
        {
            secondObject.GetComponent<Rigidbody2D>().velocity = new Vector3(distancex, distancey) * -1;
            firstObject.GetComponent<Rigidbody2D>().velocity = new Vector3(distancex, distancey);
        }
        else
        {
            if (firstObject.GetComponent<BoxCollider2D>().Distance(secondObject.GetComponent<BoxCollider2D>()).distance >= startDistance)
            {
                hitted = false;
            }
            else
            {
                secondObject.GetComponent<Rigidbody2D>().velocity = new Vector3(distancex, distancey);
                firstObject.GetComponent<Rigidbody2D>().velocity = new Vector3(distancex, distancey) * -1;
            }
        }
    }
}