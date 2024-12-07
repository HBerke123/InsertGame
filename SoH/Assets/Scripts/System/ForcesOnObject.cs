using UnityEngine;

public class ForcesOnObject : MonoBehaviour
{
    public Vector2 Force;
    public float resistance;

    float th;

    private void Update()
    {
        if (CompareTag("Domain") || CompareTag("StonePlayer")) GetComponent<Rigidbody2D>().velocity = Force;
    }

    private void FixedUpdate()
    {
        if ((th != 0) && (Time.time - th > 0.1f / resistance))
        {
            if ((Force.x > resistance) || (Force.x < -resistance))  Force.x -= resistance * Force.x;
            else if ((Force.x < resistance) || (Force.x > -resistance)) Force.x = 0;

            if ((Force.y > resistance - Physics2D.gravity.y) || (Force.y < Physics2D.gravity.y - resistance)) Force.y -= Force.y -= (resistance - Physics2D.gravity.y) * Force.y;
            else if ((Force.y < resistance - Physics2D.gravity.y) || (Force.y > Physics2D.gravity.y - resistance)) Force.y = 0;

            th = Time.time;
        }
        else if ((th == 0) && (Force != Vector2.zero)) th = Time.time;
    }
}