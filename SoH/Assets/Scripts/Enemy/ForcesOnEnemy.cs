using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcesOnEnemy : MonoBehaviour
{
    public Vector2 Force;
    public float resistance;

    private void Update()
    {
        if (Force.x > 0.1)
        {
            Force.x -= resistance * Force.x;
        }
        else if (Force.x < 0.1)
        {
            Force.x = 0;
        }

        if (Force.y > 0.1)
        {
            Force.y -= resistance * Force.y;
        }
        else if (Force.y < 0.1)
        {
            Force.y = 0;
        }
    }
}
