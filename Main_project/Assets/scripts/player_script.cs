using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testScript_changelater : MonoBehaviour
{
    [SerializeField] GameObject car;
    [SerializeField] int grid;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = car.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.position = new Vector2(car.transform.position.x, car.transform.position.y + grid);
        }
         else if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position = new Vector2(car.transform.position.x-grid, car.transform.position.y);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            transform.position = new Vector2(car.transform.position.x, car.transform.position.y - grid);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position = new Vector2(car.transform.position.x + grid, car.transform.position.y );
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
            UnityEngine.Debug.Log("Enter");
            UnityEngine.Debug.Log("Enter");
    }
}
