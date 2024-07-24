using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPreBombs : MonoBehaviour
{
    public GameObject[] GroupBombGroups;
    public int GroupNum;

    private void Update()
    {
        if (this.GetComponentInParent<SpriteRenderer>().flipX) this.transform.localScale = new Vector3(-1, 1, 1);
        else this.transform.localScale = new Vector3(1, 1, 1);
    }

    public void ShowBombs()
    {
        for (int i = 0; i < 5; i++)
        {
            this.GetComponent<PreBombGroup>().PreBombs[i].SetActive(true);
            this.GetComponent<PreBombGroup>().PreBombs[i].GetComponent<ShowPreBomb>().StartShow();
        }
    }

    public void StopShowing()
    {
        for (int i = 0; i < 5; i++)
        {
            this.GetComponent<PreBombGroup>().PreBombs[i].SetActive(false);
        }
    }
}
