using Unity.Mathematics;
using UnityEngine;

public class CopyYourself : MonoBehaviour
{
    [SerializeField] GameObject stone;

    GameObject clone;
    bool pressed;

    private void Update()
    {
        if (Input.GetKey(KeyCode.V) && !pressed)
        {
            pressed = true;

            if (clone != null) Destroy(clone);

            clone = Instantiate(stone, GetComponent<Collider2D>().bounds.center, Quaternion.identity);

            if (GetComponent<Crouching>().isCrouching) clone.transform.localScale = new(clone.transform.localScale.x, 1.2f, 0);
        }
        else if (!Input.GetKey(KeyCode.V)) 
        {
            pressed = false;
        }
    }
}
