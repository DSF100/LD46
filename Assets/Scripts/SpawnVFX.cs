using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpawnVFX : MonoBehaviour
{
    public Vector3 scaleSize;

    // Start is called before the first frame update
    void Start()
    {
        transform.DOScale(scaleSize, 1);
        Destroy(gameObject, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
