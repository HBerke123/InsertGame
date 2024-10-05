using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointRecorder : MonoBehaviour
{
    public Vector3 saveLocation;

    public void SaveCheckpoint(Vector3 location)
    {
        saveLocation = location;
    }

   public void LoadCheckpoint()
    {
        this.transform.position = saveLocation;
    }
}
