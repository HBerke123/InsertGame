using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcesOnEnemy : MonoBehaviour
{
    public Vector2 Force;
    public float resistance;

    private void Update()
    {
        if (Force.x > 0)
        {
            Force.x -= resistance * Force.x;
        }
        else if (Force.x < 0.001)
        {
            Force.x = 0;
        }

        if (Force.y > 0)
        {
            Force.y -= resistance * Force.x;
        }
        else if (Force.y < 0.001)
        {
            Force.y = 0;
        }
    }
}
