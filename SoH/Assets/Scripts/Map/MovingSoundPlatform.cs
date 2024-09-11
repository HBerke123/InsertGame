using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSoundPlatform : MonoBehaviour
{
    public GameObject soundExplosion;
    public GameObject otherObject;
    public float speed;
    public float hittingSpeed;
    public float startDistance;
    bool hitted;

    private void Update()
    {
        float distancex = otherObject.transform.position.x - this.transform.position.x;
        float distancey = otherObject.transform.position.y - this.transform.position.y;
        float distance = Mathf.Sqrt(Mathf.Pow(distancex, 2) + Mathf.Pow(distancey, 2));

        if (hitted)
        {
            if (distance >= startDistance)
            {
                hitted = false;
            }
            else
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(distancex / distance, distancey / distance) * -speed;
                otherObject.GetComponent<Rigidbody2D>().velocity = new Vector2(distancex / distance, distancey / distance) * speed;
            }
        }
        else
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(distancex / distance, distancey / distance) * hittingSpeed;
            otherObject.GetComponent<Rigidbody2D>().velocity = new Vector2(distancex / distance, distancey / distance) * -hittingSpeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == otherObject)
        {
            hitted = true;
            Instantiate(soundExplosion, Vector3.Lerp(transform.position, otherObject.transform.position, 0.5f), Quaternion.identity);
        }
    }
}