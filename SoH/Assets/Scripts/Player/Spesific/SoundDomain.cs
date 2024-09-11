using UnityEngine;

public class SoundDomain : MonoBehaviour
{
    GameObject skillObject;
    GamepadControls gamepadControls;

    private void Start()
    {
        skillObject = GameObject.FindGameObjectWithTag("Domain");
        gamepadControls = GameObject.FindGameObjectWithTag("GamepadController").GetComponent<GamepadControls>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.R) && gamepadControls.soundDomain)
        {
            skillObject.GetComponent<SpriteRenderer>().enabled = true;
        }
        else if (!Input.GetKey(KeyCode.R) || !gamepadControls.soundDomain)
        {
            skillObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}