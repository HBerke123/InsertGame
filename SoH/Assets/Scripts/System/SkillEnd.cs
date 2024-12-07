using UnityEngine;

public class SkillEnd : MonoBehaviour
{
    public float TotalTime;
    public float th;
    public GameObject parent;
    public bool isAttached;

    private void Start() => th = Time.time;

    private void Update()
    {
        if ((Time.time - th > TotalTime) || (isAttached && (parent == null))) Destroy(this.gameObject);
    }
}