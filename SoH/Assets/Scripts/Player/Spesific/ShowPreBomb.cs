using UnityEngine;

public class ShowPreBomb : MonoBehaviour
{
    public int groupnum;
    public int bombnum;
    public float ttime;
    float th = 0;

    public void StartShow()
    {
        this.transform.localPosition = new Vector3(this.GetComponentInParent<ShowPreBombs>().GroupBombGroups[0].GetComponent<PreBombGroup>().preBombs[bombnum].transform.localPosition.x, this.GetComponentInParent<ShowPreBombs>().GroupBombGroups[0].GetComponent<PreBombGroup>().preBombs[bombnum].transform.localPosition.y, 0);
        this.GetComponent<SpriteRenderer>().enabled = true;
        th = Time.time;
    }

    private void FixedUpdate()
    {
        if (Time.time - th > ttime)
        {
            this.GetComponent<SpriteRenderer>().enabled = false;
            this.gameObject.SetActive(false);
        }

        this.transform.localPosition = new Vector3(this.GetComponentInParent<ShowPreBombs>().GroupBombGroups[0].GetComponent<PreBombGroup>().preBombs[bombnum].transform.localPosition.x + (Time.time - th) / ttime * (this.GetComponentInParent<ShowPreBombs>().GroupBombGroups[1].GetComponent<PreBombGroup>().preBombs[bombnum].transform.localPosition.x - this.GetComponentInParent<ShowPreBombs>().GroupBombGroups[0].GetComponent<PreBombGroup>().preBombs[bombnum].transform.localPosition.x), this.GetComponentInParent<ShowPreBombs>().GroupBombGroups[0].GetComponent<PreBombGroup>().preBombs[bombnum].transform.localPosition.y, 0);
    }
}