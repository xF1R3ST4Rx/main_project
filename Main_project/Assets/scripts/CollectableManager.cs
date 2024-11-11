using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] List<GameObject> collectables = new List<GameObject>();
    [SerializeField] private List<GameObject> oilTiles = new List<GameObject>();
    bool slickmovement = false;
    [SerializeField] PlayerController playercontroller;
    private void Start()
    {

    }
    void Update()
    {
        for (int i = collectables.Count - 1; i >= 0; i--)
        {
            if (getPosition(player).x == collectables[i].transform.position.x && getPosition(player).y == collectables[i].transform.position.y)
            {
                Destroy(collectables[i]);
                collectables.Remove(collectables[i]);
            }
        }
        if (collectables.Count == 0)
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
    }
        Vector2 getPosition(GameObject player)
        {
            Vector2 pos = player.transform.position;
            return pos;
        }
    public bool oiledMove(Vector2 direction)
    {
        foreach (GameObject oilspot in oilTiles)
        {
            if (direction.x == oilspot.transform.position.x && direction.y == oilspot.transform.position.y)
            {
                return slickmovement = true; 
            }
            else if(slickmovement == true && playercontroller.CanMove(direction))
            {
                return slickmovement = true;
            }
            else
            {
                return slickmovement = false;
            }
        }
        return false;
    }
}