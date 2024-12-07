using UnityEngine;

public class TelescopeHitbox : MonoBehaviour
{
    GamepadControls gamepadControls;
    bool pressed;
    GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gamepadControls = player.GetComponent<GamepadControls>();
    }

    private void Update()
    {
        if (gamepadControls.save.IsPressed() && !pressed) 
        {
            if (GetComponent<Collider2D>().IsTouching(player.GetComponent<Collider2D>()))
            {
                GetComponentInParent<TelescopeUse>().isScoping = !GetComponentInParent<TelescopeUse>().isScoping;
            }

            pressed = true;
        }
        else if (!gamepadControls.save.IsPressed()) pressed = false;
    }
}
