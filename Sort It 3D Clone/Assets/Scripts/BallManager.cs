using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    [SerializeField] private Material[] ballColors;
    [SerializeField] private GameObject[] balls;

    private void Start()
    {
        RandomBallColor();
    }
    private void RandomBallColor()
    {
        switch (balls.Length)
        {
            case 6:
                for (int i = 0; i < balls.Length; i++)
                {
                    int randColor = i % 2;

                    balls[i].gameObject.GetComponent<Renderer>().material = ballColors[randColor];
                }
                break;
            default:
                break;
        }
    }



}
