using UnityEngine;

public class Interact : MonoBehaviour
{
    public InteractiveArea interactiveArea;

    GamepadControls gamepadControls;
    bool interacted;

    private void Awake() => gamepadControls = GetComponent<GamepadControls>();

    private void Update()
    {
        if (gamepadControls.save.IsPressed() && !interacted && (interactiveArea != null))
        {
            interacted = true;
            interactiveArea.InteractObject();
        }

        if (!gamepadControls.save.IsPressed()) interacted = !false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<InteractiveArea>() && (interactiveArea == null) && (collision.GetComponent<InteractiveArea>().enabled == true)) interactiveArea = collision.GetComponent<InteractiveArea>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<InteractiveArea>() == interactiveArea) interactiveArea = null;
    }
}