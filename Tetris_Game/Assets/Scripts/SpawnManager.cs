using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> blocks;

    public Transform spawnPoint;

    private GameObject dir;

    private float timer;
    

    float fall = 0;

    public float fallingSpeed;
    private void Start()
    {
        dir = Instantiate(blocks[0], spawnPoint);
    }
    void Update()
    {
        CheckUserInput();
    }
    void FixedUpdate()
    {
        ApplyGravity();
    }
    void CheckUserInput()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            dir.transform.position += new Vector3(1, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            dir.transform.position += new Vector3(-1, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            dir.transform.Rotate(0, 0, 90);
        }
        else if ((Input.GetKeyDown(KeyCode.DownArrow) || Time.time - fall >= fallingSpeed) && dir.transform.position.y > 3)
        {
            Debug.Log(dir.transform.position.y);
            dir.transform.position += new Vector3(0, -1, 0);
            fall = Time.time;
        }
    }

    public void ApplyGravity()
    {
        if (!dir.GetComponent<tetris>().gravityApply)
        {
            if ((timer += Time.deltaTime) > 0.2f)
            {
                dir.transform.position += new Vector3(0, -1, 0);
                timer = 0.0f;
            }
        }
        else
        {
            dir=Instantiate(blocks[0], spawnPoint);
        }
    }
}
