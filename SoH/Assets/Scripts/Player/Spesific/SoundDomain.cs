using UnityEngine;

public class SoundDomain : MonoBehaviour
{
    public GameObject skillObject;
    GamepadControls gamepadControls;

    private void Start()
    {
        gamepadControls = GameObject.FindGameObjectWithTag("GamepadController").GetComponent<GamepadControls>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            skillObject.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.R))
        {
            skillObject.SetActive(false);
        }
    }
}
