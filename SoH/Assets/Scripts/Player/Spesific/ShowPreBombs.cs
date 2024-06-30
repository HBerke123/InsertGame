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
            this.GetComponent<PreBombGroup>().PreBombs[i].transform.localPosition = new Vector3(GroupBombGroups[0].transform.position.x + , , 0);
        }
        
    }
}
