using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayControl : MonoBehaviour
{
    Camera cam;
    public LayerMask layerMask;

    [SerializeField] private GameObject[] flasks;
    [SerializeField] private GameObject[] balls;

    [SerializeField] private int maxChild = 4;

    private bool isSelected = false;

    private GameObject childBallObj;


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {
        InputRayCast();

    }
    private void InputRayCast()
    {
        //Draw Ray
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 30f;
        mousePos = cam.ScreenToWorldPoint(mousePos);
        Debug.DrawRay(transform.position, mousePos - transform.position, Color.blue);

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, layerMask))
            {
                //Debug.Log(hit.transform.name);
                //Debug.Log(hit.transform.position.x);
                if (!isSelected)
                {
                    childBallObj = ChildBall(6f, hit.transform.childCount, hit.transform.gameObject);
                    isSelected = true;

                }
                else
                {
                    ChangeBallPos(hit.transform.position.x, hit.transform.childCount, childBallObj, hit.transform.gameObject);
                    isSelected = false;
                }

            }
        }


    }

    private GameObject ChildBall(float pos, int hitChildCount, GameObject objectHit)
    {

        GameObject childObj = objectHit.transform.GetChild(hitChildCount - 1).gameObject;
        childObj.transform.position = new Vector3(childObj.transform.position.x, pos, childObj.transform.position.z);

        childObj.gameObject.GetComponent<Rigidbody>().useGravity = false;

        return childObj;

    }

    private void ChangeBallPos(float pos, int hitChildCount, GameObject childObj, GameObject hitObj)
    {
        Vector3 initialCoordinate = childObj.transform.position;
        childObj.transform.position = new Vector3(pos, 6f, childObj.transform.position.z);

        if (hitObj.transform.childCount < maxChild)
        {
            childObj.gameObject.GetComponent<Rigidbody>().useGravity = true;
            childObj.gameObject.transform.parent = hitObj.transform;

        }
        else
        {
            childObj.transform.position = initialCoordinate;
            childObj.gameObject.GetComponent<Rigidbody>().useGravity = true;

        }


    }



}
