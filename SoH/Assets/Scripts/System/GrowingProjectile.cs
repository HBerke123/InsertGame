using UnityEngine;

public class GrowingProjectile : MonoBehaviour
{
    public float TotalTime;
    public float maxyscale;
    public float minyscale;
    public float maxxscale;
    public float minxscale;
    public bool xScale;
    public bool yScale;
    float xSize;
    float ySize;
    float th;

    private void Start()
    {
        ySize = this.transform.localScale.y;
        xSize = this.transform.localScale.x;
        th = Time.time;
    }

    void Update()
    {
        if (xScale)
        {
            if (yScale)
            {
                this.transform.localScale = new Vector3(minxscale + maxxscale * (Time.time - th) / TotalTime, minyscale + maxyscale * (Time.time - th) / TotalTime, 1);
            }
            else
            {
                this.transform.localScale = new Vector3(minxscale + maxxscale * (Time.time - th) / TotalTime, ySize);
            }
        }
        else
        {
            if (yScale)
            {
                this.transform.localScale = new Vector3(xSize, minyscale + maxyscale * (Time.time - th) / TotalTime, 1);
            }
            else
            {
                this.transform.localScale = new Vector3(xSize, ySize, 1);
            }
        }
    }
}