using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chain : MonoBehaviour
{
    public float startY;
    float difference;

    private void Start()
    {
        startY = this.transform.position.y;
        difference = Mathf.Abs(startY - this.transform.parent.position.y);
    }

    private void Update()
    {
        this.transform.localPosition = new Vector2(this.transform.localPosition.x, (startY - this.transform.parent.position.y + difference) / 4);
        this.GetComponent<SpriteRenderer>().size = new Vector2(this.GetComponent<SpriteRenderer>().size.x, (Mathf.Abs(startY - this.transform.parent.position.y) + difference) / 2);
    }
}