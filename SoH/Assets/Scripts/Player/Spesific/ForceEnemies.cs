using UnityEngine;

public class ForceEnemies : MonoBehaviour
{
    public bool soundForce;
    public bool destroyOnTouch;
    public int direction;
    public float forcePower;
    public float breakPerc;

    bool onPlayer = true;
    GameObject Player;

    private void Start() => Player = GameObject.FindGameObjectWithTag("Player");

    public void Force(GameObject enemy)
    {
        switch (direction)
        {
            case 0:
                enemy.GetComponent<ForcesOnObject>().Force = forcePower * Vector2.up;
                break;
            case 1:
                enemy.GetComponent<ForcesOnObject>().Force = forcePower * Vector2.right;
                break;
            case 2:
                enemy.GetComponent<ForcesOnObject>().Force = forcePower * Vector2.down;
                break;
            case 3:
                enemy.GetComponent<ForcesOnObject>().Force = forcePower * Vector2.left;
                break;
            default:
                float distancex = enemy.transform.position.x - transform.position.x;
                float distancey = enemy.transform.rotation.y - transform.rotation.y;
                float distance = Mathf.Sqrt(Mathf.Pow(distancex, 2) + Mathf.Pow(distancey, 2));
                enemy.GetComponent<ForcesOnObject>().Force = new Vector2(distancex / distance, distancey / distance) * forcePower;
                break;
        }
    }

    private void Update()
    {
        if (!GetComponent<Collider2D>().IsTouching(Player.GetComponent<Collider2D>()))
        {
            onPlayer = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Enemy":
                Force(collision.gameObject);

                if (destroyOnTouch) Destroy(gameObject);

                break;
            case "EnemySound":
                if (CompareTag("Sound"))
                {
                    Destroy(collision.gameObject);
                    Destroy(gameObject);
                }

                break;
            case "EnemyScream":
                if (CompareTag("Scream"))
                {
                    Destroy(collision.gameObject);
                    Destroy(gameObject);
                }

                break;
            case "Domain":
                Force(collision.gameObject);
                break;
            case "TurningTrigger":
                if ((!collision.GetComponentInParent<TurningManager>().isHorizontal && ((direction == 1) || (direction == 3))) || (collision.GetComponentInParent<TurningManager>().isHorizontal && ((direction == 0) || (direction == 2)))) collision.GetComponent<TurningTrigger>().Turn(gameObject);               
                break;
            case "Ground":
                if ((collision.GetComponent<SoundBreakable>() != null) && soundForce) collision.GetComponent<SoundBreakable>().Break();
                else if ((collision.GetComponent<SoundLever>() != null) && soundForce) collision.GetComponent<SoundLever>().ChangeStatment();

                Destroy(gameObject);
                break;
            case "StonePlayer":
                Force(collision.gameObject);
                collision.gameObject.GetComponent<SkillEnd>().TotalTime -= collision.gameObject.GetComponent<SkillEnd>().TotalTime * breakPerc;
                break;
            case "Player":
                if (!onPlayer) Force(collision.gameObject);
                
                break;
        }
    }
}