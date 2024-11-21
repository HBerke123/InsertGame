using UnityEngine;

public class SkillEnd : MonoBehaviour
{
    public float TotalTime;
    public GameObject parent;
    public bool isAttached;
    float th;

    private void Start()
    {
        th = Time.time;
    }

    private void Update()
    {
        if ((Time.time - th > TotalTime) || (isAttached && (parent == null)))
        {
            Destroy(this.gameObject);
        }
    }
}