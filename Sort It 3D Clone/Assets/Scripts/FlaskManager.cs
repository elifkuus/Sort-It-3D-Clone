using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlaskManager : MonoBehaviour
{
    [SerializeField] private GameObject[] flasks;
    [SerializeField] private int maxScore = 4;
    [SerializeField] private int maxChild = 3;


    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        FlaskControl();
    }
    private void FlaskControl()
    {
        int score = 0;

        for (int i = 0; i < flasks.Length; i++)
        {
            if (flasks[i].transform.childCount == maxChild)
            {

                for (int j = 0; j < maxChild - 1; j++)
                {
                    if (flasks[i].transform.GetChild(j).GetComponentInChildren<Renderer>().material.name == flasks[i].transform.GetChild(j + 1).GetComponentInChildren<Renderer>().material.name)
                    {
                        score++;
                    }
                    else
                    {
                        score--;
                    }
                }

            }
            if (score == maxScore)
            {
                GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().GameEnded();
            }

        }

    }

}
