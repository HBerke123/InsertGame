using UnityEngine;

public class CEDrainage : MonoBehaviour
{
    public float cE, maxCE;
    public Bar cEBar;

    public void Start()
    {
        cEBar = GameObject.FindGameObjectWithTag("CEBar").GetComponent<Bar>();
        cE = 500;
        UpdateCEBar();
    }

    public void LoseCE(float amount)
    {
        cE -= amount;
        UpdateCEBar();
    }

    public void GainCE(float amount)
    {
        cE += amount;
        UpdateCEBar();
    }

    void Update()
    {
        if ((cE <= 0) || (cE >= maxCE))
        {
            this.GetComponent<HealthDrainage>().Death();
        }
    }

    public void UpdateCEBar()
    {
        cEBar.maxValue = maxCE;
        cEBar.curValue = cE;
    }
}