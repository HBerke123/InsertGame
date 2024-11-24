using System.Collections.Generic;
using UnityEngine;

public class TurningManager : MonoBehaviour
{
    public List<GameObject> waves = new();
    public bool isHorizontal;

    private void Start()
    {
        if (transform.rotation == Quaternion.identity) isHorizontal = false;
        else isHorizontal = true;
    }

    private void Update()
    {
        for (int i = 0; i < waves.Count; i++)
        {
            if (waves[i] == null) waves.RemoveAt(i);
        }
    }
}
