using UnityEngine;

public class SoundInfluence : MonoBehaviour
{
    public float soundTime;
    public float smallForcePower;
    public float bigForcePower;
    public float totaltime;
    public float speed;
    
    float th = 0;
    GameObject SBox;

    [SerializeField] GameObject BigWave;
    [SerializeField] GameObject SmallWave;

    private void Update()
    {
        if ((th > 0) && (Time.time - th >= totaltime))
        {
            Destroy(SBox);
            th = 0;
        }
    }

    public void SendWave(int direction, bool isforce)
    {
        GetComponentInParent<MakeSound>().AddTime(soundTime);
        th = Time.time;

        if (isforce)
        {
            SBox = Instantiate(BigWave, GetComponent<BoxCollider2D>().bounds.center, Quaternion.identity);
            SBox.GetComponent<SkillEnd>().TotalTime = totaltime;

            if (direction == 1) SBox.GetComponent<Rigidbody2D>().velocity = speed * Vector2.right;
            else SBox.GetComponent<Rigidbody2D>().velocity = speed * Vector2.left;

            SBox.GetComponent<ForceEnemies>().direction = direction;
            SBox.GetComponent<ForceEnemies>().forcePower = bigForcePower;
        }
        else
        {
            SBox = Instantiate(SmallWave, GetComponent<BoxCollider2D>().bounds.center, Quaternion.identity);
        
            if ((direction == 0) || (direction == 2)) SBox.transform.localRotation = new Quaternion(0, 0, Mathf.Sqrt(50), Mathf.Sqrt(50));

            SBox.GetComponent<SkillEnd>().TotalTime = totaltime;

            switch (direction)
            {
                case 0:
                    SBox.GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
                    break;
                case 1:
                    SBox.GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
                    break;
                case 2:
                    SBox.GetComponent<Rigidbody2D>().velocity = Vector2.down * speed;
                    break;
                case 3:
                    SBox.GetComponent<Rigidbody2D>().velocity = Vector2.left * speed;
                    break;
            }

            SBox.GetComponent<ForceEnemies>().direction = direction;
            SBox.GetComponent<ForceEnemies>().forcePower = smallForcePower;
        }
    }
}