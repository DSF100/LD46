using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareOnDestroy : MonoBehaviour
{
    public ParticleSystem Death;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        FindObjectOfType<AudioManager>().Play("explosion");
        Instantiate(Death, transform.GetChild(0).transform.position, Quaternion.identity);
    }
}
