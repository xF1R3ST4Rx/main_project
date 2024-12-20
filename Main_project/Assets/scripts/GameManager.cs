using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] List<GameObject> collectables = new List<GameObject>();
    [SerializeField] TextMeshProUGUI levelUI;
    [SerializeField] SoundManager hooray;
    private int currentSceneIndex;
    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        levelUI.text = "Level: " + (SceneManager.GetActiveScene().buildIndex+1);
    }
    void Update()
    {
        for (int i = collectables.Count - 1; i >= 0; i--)
        {
            if (getPosition(player).x == collectables[i].transform.position.x && getPosition(player).y == collectables[i].transform.position.y)
            {
                Destroy(collectables[i]);
                collectables.Remove(collectables[i]);
                hooray.PlaySound();
            }
        }
        if (collectables.Count == 0)
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
    }
        Vector2 getPosition(GameObject player)
        {
            Vector2 pos = player.transform.position;
            return pos;
        }
        

    
}