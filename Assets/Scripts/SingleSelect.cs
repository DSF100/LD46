using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleSelect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        transform.GetChild(1).gameObject.SetActive(true);

        if (Input.GetMouseButtonDown(0))
        {
            foreach (GameObject G in GameObject.FindGameObjectsWithTag("Player"))
            {
                G.GetComponentInChildren<Selected>().selected = false;
            }
            gameObject.GetComponent<Selected>().selected = true;
        }
    }

    private void OnMouseExit()
    {
        transform.GetChild(1).gameObject.SetActive(false);
    }
}
