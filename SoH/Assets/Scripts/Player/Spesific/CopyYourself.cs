using UnityEngine;

public class CopyYourself : MonoBehaviour
{
    [SerializeField] GameObject stone;
    [SerializeField] GroundDetection jumpBox;

    GamepadControls gamepadControls;
    GameObject clone;
    bool pressed;

    private void Start() => gamepadControls = GetComponent<GamepadControls>();

    private void Update()
    {
        if (gamepadControls.copy.IsPressed() && !pressed && jumpBox.detected)
        {
            pressed = true;

            if (clone != null) Destroy(clone);

            clone = Instantiate(stone, GetComponent<Collider2D>().bounds.center, Quaternion.identity);

            if (GetComponent<Crouching>().isCrouching) clone.transform.localScale = new(clone.transform.localScale.x, 1.2f, 0);
        }
        else if (!gamepadControls.copy.IsPressed())  pressed = false;
    }
}
