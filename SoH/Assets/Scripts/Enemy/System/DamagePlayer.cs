using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public float blockTime;
    public float reloadTime;
    public float damageAmount;
    public bool destroyOnDamage;
    public bool destroyOnTouch;
    public bool isReloadable;
    public bool weakToDash;
    public bool canNotDamage;
    bool damaged;
    float rth;

    private void FixedUpdate()
    {
        if (isReloadable)
        {
            if ((rth != 0) && (Time.time - rth > reloadTime))
            {
                rth = Time.time;
                damaged = false;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground") && destroyOnTouch)
        {
            Destroy(this.gameObject);
        }
         
        if (collision.CompareTag("Player") && !damaged && (!weakToDash || !collision.GetComponent<Dash>().dashing) && !canNotDamage)
        {
            rth = Time.time;
            damaged = true;
            collision.GetComponent<HealthDrainage>().TakeDamage(damageAmount);
            collision.GetComponent<BlocksOnObject>().blockTime = Mathf.Max(collision.GetComponent<BlocksOnObject>().blockTime, blockTime);

            if (destroyOnDamage)
            {
                Destroy(this.gameObject);
            }
        }
    }
}