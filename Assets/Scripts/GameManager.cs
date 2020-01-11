using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//use scene manager
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }
}
