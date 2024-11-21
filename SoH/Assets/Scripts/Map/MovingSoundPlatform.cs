using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovingSoundPlatform : MonoBehaviour
{
    public GameObject soundExplosion;
    public GameObject firstObject;
    public GameObject secondObject;
    GameObject explosion;
    public float firstSpeed;
    public float secondSpeed;
    public float firstHSpeed;
    public float secondHSpeed;
    public bool lockX;
    public bool lockY;
    public bool withDistance;
    float startDistance;
    bool firstHit;
    bool secondHit;
    public bool sounding;
    public PlatformDetection firstUpHit;
    public PlatformDetection secondUpHit;
    public PlatformDetection firstDownHit;
    public PlatformDetection secondDownHit;

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
        float firstx = firstObject.transform.position.x - transform.position.x;
        float firsty = firstObject.transform.position.y - transform.position.y;
        float first = Mathf.Sqrt(Mathf.Pow(firstx, 2) + Mathf.Pow(firsty, 2));
        float secondx = secondObject.transform.position.x - transform.position.x;
        float secondy = secondObject.transform.position.y - transform.position.y;
        float second = Mathf.Sqrt(Mathf.Pow(secondx, 2) + Mathf.Pow(secondy, 2));

        if (firstDownHit.GetComponent<SpesificDetection>().detected && secondDownHit.GetComponent<SpesificDetection>().detected)
        {
            float scale = 5 * Mathf.Max(firstObject.transform.lossyScale.x, firstObject.transform.lossyScale.y, secondObject.transform.lossyScale.x, secondObject.transform.lossyScale.y);
            firstHit = true;
            secondHit = true;

            if ((explosion == null) && sounding)
            {
                explosion = Instantiate(soundExplosion, (firstObject.transform.position + secondObject.transform.position) / 2, Quaternion.identity);
                explosion.GetComponent<GrowingProjectile>().maxxscale = scale;
                explosion.GetComponent<GrowingProjectile>().maxyscale = scale;
            }
        }
        else if (firstDownHit.detected)
        {
            firstHit = true;
        }
        else if (secondDownHit.detected)
        {
            secondHit = true;
        }
        else if (firstUpHit.detected)
        {
            firstHit = false;
        }
        else if (secondUpHit.detected)
        {
            secondHit = false;
        }

        if (!firstHit)
        {
            if ((distancex == 0) || lockX)
            {
                firstObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, distancey / Mathf.Abs(distancey)) * firstHSpeed;
            }
            else if ((distancey == 0) || lockY)
            {
                firstObject.GetComponent<Rigidbody2D>().velocity = new Vector3(distancex / Mathf.Abs(distancex), 0) * firstHSpeed;
            }
            else
            {
                firstObject.GetComponent<Rigidbody2D>().velocity = new Vector3(distancex / Mathf.Abs(distancex), distancey / Mathf.Abs(distancey)) * firstHSpeed;
            }
        }
        else
        {
            if ((first >= (startDistance / 2)) && withDistance)
            {
                firstObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
            else
            {
                if ((distancex == 0) || lockX)
                {
                    firstObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, distancey / Mathf.Abs(distancey)) * -firstSpeed;
                }
                else if ((distancey == 0) || lockY)
                {
                    firstObject.GetComponent<Rigidbody2D>().velocity = new Vector3(distancex / Mathf.Abs(distancex), 0) * -firstSpeed;
                }
                else
                {
                    firstObject.GetComponent<Rigidbody2D>().velocity = new Vector3(distancex / Mathf.Abs(distancex), distancey / Mathf.Abs(distancey)) * -firstSpeed;
                }
            }
        }

        if (!secondHit)
        {
            if ((distancex == 0) || lockX)
            {
                secondObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, distancey / Mathf.Abs(distancey)) * -secondHSpeed;
            }
            else if ((distancey == 0) || lockY)
            {
                secondObject.GetComponent<Rigidbody2D>().velocity = new Vector3(distancex / Mathf.Abs(distancex), 0) * -secondHSpeed;
            }
            else
            {
                secondObject.GetComponent<Rigidbody2D>().velocity = new Vector3(distancex / Mathf.Abs(distancex), distancey / Mathf.Abs(distancey)) * -secondHSpeed;
            }
        }
        else
        {
            if ((second >= (startDistance / 2)) && withDistance)
            {
                secondObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
            else
            {
                if ((distancex == 0) || lockX)
                {
                    secondObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, distancey / Mathf.Abs(distancey)) * secondSpeed;
                }
                else if ((distancey == 0) || lockY)
                {
                    secondObject.GetComponent<Rigidbody2D>().velocity = new Vector3(distancex / Mathf.Abs(distancex), 0) * secondSpeed;
                }
                else
                {
                    secondObject.GetComponent<Rigidbody2D>().velocity = new Vector3(distancex / Mathf.Abs(distancex), distancey / Mathf.Abs(distancey)) * secondSpeed;
                }
            }
        }

        if (withDistance && (first >= (startDistance / 2)) && (second >= (startDistance / 2)))
        {
            firstHit = false;
            secondHit = false;
        }
    }
}