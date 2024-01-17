using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    public float maxvalue;
    public float curvalue;
    Vector3 location;
    Vector3 scale;
    RectTransform rt;

    private void Start()
    {
        rt = this.GetComponent<RectTransform>();
        location = rt.anchoredPosition;
        scale = rt.localScale;
    }

    private void Update()
    {
        Vector3 plocation = location;
        Vector3 pscale = scale;
        plocation.x = location.x + (curvalue - maxvalue) / 2;
        pscale.x = curvalue;
        rt.anchoredPosition = plocation;
        rt.localScale = pscale;  
    }
}
