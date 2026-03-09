using UnityEngine;
using DG.Tweening;

public class JumpExample : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.DOJump(new Vector3(-0.7f, -11.78f, 0), .5f, 3, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
