using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEnemy : MonoBehaviour
{
    GameObject player;
    public GameObject soundWave;
    public float waveSpeed;
    public float waveTime;
    public float speed;
    public float moveRangex;
    public float rangex;
    public float shootFrequency;
    float th;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        if ((th != 0) && (Time.time - th > shootFrequency) && (this.GetComponent<ForcesOnEnemy>().Force.x == 0))
        {
            if (Mathf.Abs(this.transform.position.x - player.transform.position.x) < rangex)
            {
            }
            th = 0;
        }
    }
}
