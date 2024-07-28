using UnityEngine;

public class Platform : MonoBehaviour
{
    public float uplimit;
    public float downlimit;
    public float speed;
    bool up = true;

    private void FixedUpdate()
    {
        if ((this.transform.position.y < uplimit) && up) transform.position += Vector3.up * speed;
        else up = false;
        if ((this.transform.position.y > downlimit) && !up) transform.position += Vector3.down * speed;
        else up = true;
    }
}
