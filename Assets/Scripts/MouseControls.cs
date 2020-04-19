using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseControls : MonoBehaviour
{
    private Camera myMainCamera;

    public Image selectBox;

    Vector3 startingPos;

    Vector3 marker1;
    Vector3 marker2;

    public GameObject rightClickVfx;

    bool vfx;

    // Start is called before the first frame update
    void Start()
    {
        myMainCamera = Camera.main; // Camera.main is expensive ; cache it here
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("yep");
            vfx = true;
            
            foreach (GameObject P in GameObject.FindGameObjectsWithTag("Player"))
            {
                if (P.transform.GetComponentInChildren<Selected>().selected)
                {
                    if (vfx)
                    {
                        Instantiate(rightClickVfx, new Vector3(myMainCamera.ScreenToWorldPoint(Input.mousePosition).x, myMainCamera.ScreenToWorldPoint(Input.mousePosition).y, 0), Quaternion.identity);
                        vfx = false;
                    }

                    P.transform.GetChild(1).position = new Vector3(myMainCamera.ScreenToWorldPoint(Input.mousePosition).x, myMainCamera.ScreenToWorldPoint(Input.mousePosition).y, 0);
                }
            }

            vfx = true;
        }
    }

    private void OnMouseOver()
    {
        
    }

    void OnMouseDown()
    {
        Vector3 MousePosition = myMainCamera.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(Input.mousePosition);
        Debug.Log(MousePosition);

        selectBox.gameObject.SetActive(true);
        selectBox.rectTransform.position = Input.mousePosition;

        startingPos = Input.mousePosition;
        marker1 = myMainCamera.ScreenToWorldPoint(Input.mousePosition);
    }

    void OnMouseDrag()
    {
        Vector2 size = new Vector2(Input.mousePosition.x - startingPos.x, Input.mousePosition.y - startingPos.y);
        //selectBox.rectTransform.position = new Vector3(startingPos.x + size.x/2, startingPos.y + size.y/2, startingPos.z);
        selectBox.rectTransform.position = new Vector3(startingPos.x, startingPos.y, startingPos.z);

        Debug.Log(size);

        if(size.y < 0 && size.x < 0)
        {
            selectBox.rectTransform.rotation = Quaternion.Euler(new Vector3(180, 180, 0));
        }
        else if(size.y > 0 && size.x < 0)
        {
            selectBox.rectTransform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }
        else if(size.y < 0 && size.x > 0)
        {
            selectBox.rectTransform.rotation = Quaternion.Euler(new Vector3(180, 0, 0));
        }
        else
        {
            selectBox.rectTransform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }

        selectBox.rectTransform.sizeDelta = new Vector2(Mathf.Abs(size.x), Mathf.Abs(size.y));

        marker2 = myMainCamera.ScreenToWorldPoint(Input.mousePosition);


        foreach (GameObject P in GameObject.FindGameObjectsWithTag("Player"))
        {
            Transform Trans = P.transform.GetChild(0).transform;

            if ((Trans.position.x > marker2.x && Trans.position.x < marker1.x) || (Trans.position.x < marker2.x && Trans.position.x > marker1.x))
            {
                if ((Trans.position.y > marker2.y && Trans.position.y < marker1.y) || (Trans.position.y < marker2.y && Trans.position.y > marker1.y))
                {
                    P.transform.GetChild(0).GetComponent<Selected>().selected = true;
                }
                else
                {
                    P.transform.GetChild(0).GetComponent<Selected>().selected = false;
                }
            }
            else
            {
                P.transform.GetChild(0).GetComponent<Selected>().selected = false;
            }
        }
    }

    private void OnMouseUp()
    {
        resetSelectionBox();

        Vector3 MousePosition = myMainCamera.ScreenToWorldPoint(Input.mousePosition);
    }

    private void resetSelectionBox()
    {
        selectBox.rectTransform.position = new Vector3(0, 0, 0);
        selectBox.rectTransform.sizeDelta = new Vector2(0, 0);
        selectBox.rectTransform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        selectBox.gameObject.SetActive(false);
    }
}
