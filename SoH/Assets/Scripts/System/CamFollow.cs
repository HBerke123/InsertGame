using UnityEngine;

public class CamFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset = new(0, 2, -10);
    [SerializeField] float camSpeed;
    [SerializeField] GameObject point;

    GamepadControls gamepadControls;

    public GameObject area;
    public bool isScoping;
    public bool lockIX;
    public bool lockIY;
    public bool lockDX;
    public bool lockDY;

    private void Awake() => gamepadControls = GameObject.FindGameObjectWithTag("Player").GetComponent<GamepadControls>();

    void Update()
    {
        if (isScoping)
        {
            Vector2 direction = Vector2.zero;

            if (gamepadControls.up.IsPressed() && (point.transform.position.y < area.GetComponent<BoxCollider2D>().bounds.max.y)) direction.y = 1;
            else if (gamepadControls.down.IsPressed() && (point.transform.position.y > area.GetComponent<BoxCollider2D>().bounds.min.y)) direction.y = -1;
            else direction.y = 0;

            if (gamepadControls.right.IsPressed() && (point.transform.position.x < area.GetComponent<BoxCollider2D>().bounds.max.x)) direction.x = 1;
            else if (gamepadControls.left.IsPressed() && (point.transform.position.x > area.GetComponent<BoxCollider2D>().bounds.min.x)) direction.x = -1;
            else direction.x = 0;

            GetComponent<Rigidbody2D>().velocity = direction * camSpeed;
        }
        else
        {
            Vector3 location = target.position + offset;

            if (((location.x > transform.position.x) && lockIX) || ((location.x < transform.position.x) && lockDX)) location.x = transform.position.x;

            if (((location.y > transform.position.y) && lockIY) || ((location.y < transform.position.y) && lockDY)) location.y = transform.position.y;

            GetComponent<Rigidbody2D>().velocity = new(Mathf.Pow(location.x - transform.position.x, 3), Mathf.Pow(location.y - transform.position.y, 3));
        }
    }
}