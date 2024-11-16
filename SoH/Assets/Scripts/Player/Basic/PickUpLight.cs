using UnityEngine;

public class PickUpLight : MonoBehaviour
{
    /*public GameObject chimeLight;

    GamepadControls gamepadControls;
    bool interacted;

    private void Start()
    {
        gamepadControls = GameObject.FindGameObjectWithTag("GamepadController").GetComponent<GamepadControls>();
    }

    private void Update()
    {
        if ((chimeLight != null) && gamepadControls.save.IsPressed() && !interacted)
        {
            interacted = true;
            chimeLight.transform.position = this.transform.position + Vector3.up * chimeLight.transform.lossyScale.y / 2;
            chimeLight.GetComponent<SpriteRenderer>().enabled = true;
            chimeLight = null;
        }

        if (!gamepadControls.save.IsPressed()) interacted = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (gamepadControls.save.IsPressed() && (collision.GetComponent<ChimeLight>() != null) && (chimeLight == null) && !interacted)
        {
            interacted = true;
            chimeLight = collision.gameObject;
            chimeLight.GetComponent<SpriteRenderer>().enabled = false;
        }
    }*/
}