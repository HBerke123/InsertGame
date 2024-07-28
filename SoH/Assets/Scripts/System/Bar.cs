using UnityEngine;

public class Bar : MonoBehaviour
{
    public float maxValue;
    public float curValue;
    float startX;
    float maxX;

    private void Start()
    {
        startX = this.transform.localPosition.x;
        maxX = this.GetComponent<SpriteRenderer>().size.x;
    }

    private void Update()
    {
        float percentage = curValue / maxValue;
        if (percentage < 0)
        {
            percentage = 0;
        }
        else if (percentage > 1)
        {
            percentage = 1;
        }

        this.GetComponent<SpriteRenderer>().size = new Vector2(maxX * percentage, this.GetComponent<SpriteRenderer>().size.y);
        this.transform.localPosition = new Vector3((startX - (1 - percentage) * this.transform.localScale.x * maxX) / 2, this.transform.localPosition.y, 0);
    }
}
