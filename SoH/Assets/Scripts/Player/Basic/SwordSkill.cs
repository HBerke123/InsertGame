using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSkill : MonoBehaviour
{
    public float maxyscale = 4;
    public float minyscale = 1;
    public float distance = 3.5f;
    public float totaltime = 1.5f;
    public int softness = 60;
    public GameObject SkillBox;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            StartCoroutine(SkillStart());
        }
    }

    public IEnumerator SkillStart()
    {
        float th = Time.time;
        GameObject SBox = Instantiate(SkillBox, this.transform.position, new Quaternion(0, 0, 0, 0));
        for (int cur = 0; cur < softness; cur++)
        {
            SBox.transform.localScale = new Vector3( 0.5f, minyscale + (maxyscale - minyscale) * cur / softness, 1);
            SBox.transform.position = new Vector3(SBox.transform.position.x + distance / softness, SBox.transform.position.y, SBox.transform.position.z);
            yield return new WaitForSeconds(totaltime / softness);
        }
        Debug.Log(Time.time - th);
        Destroy(SBox);
    }
}