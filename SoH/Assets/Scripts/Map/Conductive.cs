using System.Collections.Generic;
using UnityEngine;

public class Conductive : MonoBehaviour
{
    [SerializeField] GameObject soundWave;
    [SerializeField] Conductive otherEnd;
    [SerializeField] bool isEnter;
    [SerializeField] int direction;

    public List<GameObject> waves = new();
    List<GameObject> sended = new();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Sound") && isEnter && !sended.Contains(collision.gameObject))
        {
            if ((direction == 0) && (collision.GetComponent<ForceEnemies>().direction == 2) || (direction == 1) && (collision.GetComponent<ForceEnemies>().direction == 3) || (direction == 2) && (collision.GetComponent<ForceEnemies>().direction == 0) || (direction == 3) && (collision.GetComponent<ForceEnemies>().direction == 1))
            {
                waves.Add(null);
                Destroy(collision.gameObject);
            }
        }
    }

    private void Update()
    {
        if (waves.Count > 0)
        {
            otherEnd.Enter(waves[0]);
            waves.RemoveAt(0);
        }
    }

    public void Enter(GameObject wave)
    {
        if (isEnter)
        {
            GameObject SBox = Instantiate(soundWave, transform.position, Quaternion.identity);
            sended.Add(SBox);
            SBox.GetComponent<ForceEnemies>().direction = direction;
            SBox.GetComponent<SkillEnd>().TotalTime -= Time.time - SBox.GetComponent<SkillEnd>().th;

            switch (direction) 
            {
                case 0:
                    SBox.GetComponent<Rigidbody2D>().velocity = Vector2.up * 15;
                    SBox.transform.rotation = new Quaternion(0, 0, Mathf.Sqrt(50), Mathf.Sqrt(50));
                    break;
                case 1:
                    SBox.GetComponent<Rigidbody2D>().velocity = Vector2.right * 15;
                    break;
                case 2:
                    SBox.GetComponent<Rigidbody2D>().velocity = Vector2.down * 15;
                    SBox.transform.rotation = new Quaternion(0, 0, Mathf.Sqrt(50), Mathf.Sqrt(50));
                    break;
                case 3:
                    SBox.GetComponent<Rigidbody2D>().velocity = Vector2.left * 15;
                    break;
            }
        }
        else waves.Add(wave);
    }
}