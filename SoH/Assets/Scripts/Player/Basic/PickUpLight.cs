using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpLight : MonoBehaviour
{
    public GameObject chimeLight;
    GamepadControls gamepadControls;
    bool interacted;

    private void Start()
    {
        gamepadControls = GameObject.FindGameObjectWithTag("GamepadController").GetComponent<GamepadControls>();
    }

    private void Update()
    {
        if ((chimeLight != null) && (Input.GetKey(KeyCode.O) || gamepadControls.save) && !interacted)
        {
            interacted = true;
            chimeLight.transform.position = this.transform.position + Vector3.up * chimeLight.transform.lossyScale.y / 2;
            chimeLight.GetComponent<SpriteRenderer>().enabled = true;
            chimeLight = null;
        }

        if (!Input.GetKey(KeyCode.O) && !gamepadControls.save)
        {
            interacted = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((Input.GetKey(KeyCode.O) || gamepadControls.save) && (collision.GetComponent<ChimeLight>() != null) && (chimeLight == null) && !interacted)
        {
            interacted = true;
            chimeLight = collision.gameObject;
            chimeLight.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
