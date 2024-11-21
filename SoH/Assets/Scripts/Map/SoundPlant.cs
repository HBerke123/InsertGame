using UnityEngine;

public class SoundPlant : MonoBehaviour
{
    /*public float soundTime;

    GameObject player;
    GamepadControls gamepadControls;

    private void Start()
    {
        gamepadControls = GameObject.FindGameObjectWithTag("GamepadController").GetComponent<GamepadControls>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<MakeSound>().totalSoundTime = Mathf.Max(soundTime, collision.GetComponent<MakeSound>().totalSoundTime);
        }
    }

    private void Update()
    {
        float distancex = this.transform.position.x - player.transform.position.x;
        float distancey = this.transform.position.y - player.transform.position.y + player.transform.lossyScale.y / 2;
        float distance = Mathf.Sqrt(Mathf.Pow(distancex, 2) + Mathf.Pow(distancey, 2));

        if (distance < 4)
        {
            player.GetComponentInChildren<SwordAttack>().plant = this.gameObject;

            if (gamepadControls.swordAttack)
            {
                Destroy(this.gameObject);
            }
        }
    }*/
}