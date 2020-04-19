using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareCollision : MonoBehaviour
{
    bool invin;

    // Start is called before the first frame update
    void Start()
    {
        invin = true;
        Invoke("removeInvin", 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!invin)
        {
            if (collision.gameObject.CompareTag("Obstacles"))
            {
                GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().Lost();
                Destroy(transform.parent.gameObject);
            }
        }
    }

    void removeInvin()
    {
        invin = false;
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
