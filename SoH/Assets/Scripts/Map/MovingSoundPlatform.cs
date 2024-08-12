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
        if (hitted)
        {
            if (Mathf.Abs(this.transform.position.y - otherObject.transform.position.y) >= startDistance)
            {
                hitted = false;
            }
            else
            {
                this.GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
                otherObject.GetComponent<Rigidbody2D>().velocity = Vector2.down * speed;
            }
        }
        else
        {
            this.GetComponent<Rigidbody2D>().velocity = Vector2.down * hittingSpeed;
            otherObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * hittingSpeed;
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
