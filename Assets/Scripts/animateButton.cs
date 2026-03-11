using UnityEngine;
using DG.Tweening;

public class animateButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Click()
    {
        transform.DOPunchScale(Vector3.one * 0.2f, 0.3f);
    }
}
