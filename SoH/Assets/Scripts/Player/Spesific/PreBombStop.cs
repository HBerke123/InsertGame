using UnityEngine;

public class PreBombStop : MonoBehaviour
{
    /*public GameObject owningGroup;
    public float totalTime;
    float th;

    private void Start()
    {
        th = Time.time;
    }

    private void FixedUpdate()
    {
        if (Time.time - th > totalTime)
        {
            Destroy(this.GetComponent<Rigidbody2D>());
            this.transform.SetParent(owningGroup.transform);
            this.transform.localPosition = this.transform.position;
            this.GetComponent<SpriteRenderer>().enabled = true;
            owningGroup.GetComponent<PreBombGroup>().SetBomb(this.gameObject);
            Destroy(this);
        }
    }*/
}