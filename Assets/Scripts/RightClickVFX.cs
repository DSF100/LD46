using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RightClickVFX : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        transform.DOScale(new Vector3(0, 0, 0), 1);
        Destroy(gameObject, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
