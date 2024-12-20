using UnityEngine;

public class BlocksOnObject : MonoBehaviour
{
    public float blockTime;
    public bool isBlocked;
    public bool fallBlock;
    public GroundDetection groundDetection;

    float th;

    public void AddBlock(float amount)
    {
        blockTime = Mathf.Max(blockTime, amount);
        th = 0;
    }

    private void FixedUpdate()
    {
        if ((th == 0) && (blockTime > 0))
        {
            th = Time.time;
            isBlocked = true;
        }

        if ((th != 0) && (Time.time - th > blockTime))
        {
            blockTime = 0;
            th = 0;
            isBlocked = false;
        }
     }

    private void Update()
    {
        if (fallBlock) if (groundDetection.detected) fallBlock = false;
            else
            {
                blockTime = Mathf.Max(0.5f, blockTime);
                th = 0;
            }
    }
}