using UnityEngine;

public class ForcesOnObject : MonoBehaviour
{
    public Vector2 Force;
    public float resistance;
    float th;

    private void FixedUpdate()
    {
        if ((th != 0) && (Time.time - th > 0.1f))
        {
            if ((Force.x > 0.1) || ((Force.x < -0.1)))
            {
                Force.x -= resistance * Force.x;
            }
            else if ((Force.x < 0.1) || (Force.x > -0.1))
            {
                Force.x = 0;
            }

            if ((Force.y > 0.1) || ((Force.y < -0.1)))
            {
                Force.y -= resistance * Force.y;
            }
            else if ((Force.y < 0.1) || (Force.y > -0.1))
            {
                Force.y = 0;
            }

            th = Time.time;
        }
        else if ((th == 0) && (Force != Vector2.zero))
        {
            th = Time.time;
        }
    }
}
