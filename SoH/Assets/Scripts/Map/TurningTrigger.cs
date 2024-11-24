using UnityEngine;

public class TurningTrigger : MonoBehaviour
{
    public void Turn(GameObject Wave)
    {
        if (!GetComponentInParent<TurningManager>().waves.Contains(Wave))
        {
            transform.parent.eulerAngles = transform.parent.eulerAngles + Vector3.forward * 90;
            GetComponentInParent<TurningManager>().waves.Add(Wave);
            GetComponentInParent<TurningManager>().isHorizontal = !GetComponentInParent<TurningManager>().isHorizontal;
        }
    }
}