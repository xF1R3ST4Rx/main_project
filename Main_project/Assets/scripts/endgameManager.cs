using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class endgameManager : MonoBehaviour
{
    [SerializeField] private Button restart; 
    void Start()
    {
        // Add an onClick listener to the restart button
        if (restart != null)
        {
            restart.onClick.AddListener(RestartGame);
        }
    }

    void RestartGame()
    {
        SceneManager.LoadScene("Level 1");
    }
}
