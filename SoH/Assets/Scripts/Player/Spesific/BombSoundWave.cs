using UnityEngine;

public class BombSoundWave : MonoBehaviour
{
    public float minsize;
    public float maxsize;
    float th;

    private void Start()
    {
        th = Time.time;
    }

    private void Update()
    {
        this.transform.localScale = Vector3.one * (minsize + (Time.time - th) / this.GetComponent<SkillEnd>().TotalTime * (maxsize - minsize));
    }
}
