using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPreBombs : MonoBehaviour
{
    public GameObject[] GroupBombGroups;
    public int GroupNum;

    public void ShowBombs()
    {
        for (int i = 0; i < 5; i++)
        {
            this.GetComponent<PreBombGroup>().preBombs[i].SetActive(true);
            this.GetComponent<PreBombGroup>().preBombs[i].GetComponent<ShowPreBomb>().StartShow();
        }
    }

    public void StopShowing()
    {
        for (int i = 0; i < 5; i++)
        {
            this.GetComponent<PreBombGroup>().preBombs[i].SetActive(false);
        }
    }
}
