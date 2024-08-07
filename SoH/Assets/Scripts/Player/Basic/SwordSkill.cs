using UnityEngine;

public class SwordSkill : MonoBehaviour
{
    public float damage;
    public float maxyscale;
    public float minyscale;
    public float speed;
    public float totaltime;
    public float forcePower;
    public GameObject SkillBox;
    GameObject SBox;

    public void SkillStart(int direction)
    {
        SBox = Instantiate(SkillBox, new Vector3(this.transform.position.x + direction * this.transform.parent.lossyScale.x / 2, this.transform.position.y, 0), Quaternion.identity);
        SBox.GetComponent<Rigidbody2D>().velocity = new Vector2(speed * direction, 0);
        SBox.GetComponent<SkillEnd>().TotalTime = totaltime;
        SBox.GetComponent<GrowingProjectile>().TotalTime = totaltime;
        SBox.GetComponent<GrowingProjectile>().minyscale = minyscale;
        SBox.GetComponent<GrowingProjectile>().maxyscale = maxyscale;
        SBox.GetComponent<DamageEnemies>().damageAmount = damage;

        if (direction == -1)
        {
            SBox.GetComponent<ForceEnemies>().direction = 3;
        }
        else
        {
            SBox.GetComponent<ForceEnemies>().direction = 1;
        }

        SBox.GetComponent<ForceEnemies>().forcePower = forcePower;
    }
}