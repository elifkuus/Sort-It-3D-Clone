using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isGameEnded = false;

    [SerializeField] private GameObject confettiFx;
    [SerializeField] private GameObject levelCompletedUI;

    [SerializeField] private float restartDelay = 2f;


    public void LevelCompleted()
    {
        levelCompletedUI.SetActive(true);
    }

    public void GameEnded()
    {

        if (!isGameEnded)
        {
            isGameEnded = true;
            Debug.Log("Game End");

            LevelFinishFx();

            LevelCompleted();
        }
    }

    public void LevelFinishFx()
    {
        Instantiate(confettiFx, new Vector3(0.32f, 12f, -10f), Quaternion.identity);
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

 
}
