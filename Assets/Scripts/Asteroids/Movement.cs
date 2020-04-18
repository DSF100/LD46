using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;

    private Camera myMainCamera;

    // Start is called before the first frame update
    void Start()
    {
        myMainCamera = Camera.main;

        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(1000, -1000));
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y - transform.localScale.y / 2 - 0.1 >= myMainCamera.orthographicSize)
        {
            transform.position = new Vector3(transform.position.x, -myMainCamera.orthographicSize + 0.1f, transform.position.z);
        }

        if (transform.position.y + transform.localScale.y / 2 + 0.1 <= -myMainCamera.orthographicSize)
        {
            transform.position = new Vector3(transform.position.x, myMainCamera.orthographicSize - 0.1f, transform.position.z);
        }

        if (transform.position.x - transform.localScale.x / 2 - 0.1 >= myMainCamera.orthographicSize * myMainCamera.aspect)
        {
            transform.position = new Vector3(-myMainCamera.orthographicSize * myMainCamera.aspect + 0.1f, transform.position.y, transform.position.z);
        }

        if (transform.position.x + transform.localScale.x / 2 + 0.1 <= -myMainCamera.orthographicSize * myMainCamera.aspect)
        {
            transform.position = new Vector3(myMainCamera.orthographicSize * myMainCamera.aspect - 0.1f, transform.position.y, transform.position.z);
        }
    }
}
