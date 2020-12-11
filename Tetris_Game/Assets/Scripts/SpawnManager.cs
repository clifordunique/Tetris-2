using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> blocks;

    public Transform spawnPoint;

    private GameObject dir;

    private float timer;
    public bool swithTheBlock;
    private float previousTime;
    public float fallTime = 0.8f;

    public static int height = 20;
    public static int width = 10;

    float fall = 0;

    public float fallingSpeed;

    
    private void Start()
    {
        dir = Instantiate(blocks[0], spawnPoint);
        swithTheBlock = false;
    }
    void Update()
    {
        CheckUserInput();
        CheckThemSelves();
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
            if (dir.transform.position.x > 10.0f)
                dir.transform.position += new Vector3(-1, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            dir.transform.position += new Vector3(-1, 0, 0);
            if (dir.transform.position.x < 0.5f)
                dir.transform.position += new Vector3(1, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            dir.transform.Rotate(0, 0, 90);
        }
        else if ((Input.GetKeyDown(KeyCode.DownArrow) || Time.time - fall >= fallingSpeed) && dir.transform.position.y > 6)
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
            dir=Instantiate(blocks[0], spawnPoint);
    }

    void CheckThemSelves()
    {
        Ray ray = new Ray(new Vector3(dir.transform.position.x, dir.transform.position.y, dir.transform.position.z), Vector3.down);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            Debug.DrawLine(dir.transform.position, hit.point, Color.green);
            if(hit.transform.tag == "Block")
            {
                dir.GetComponent<tetris>().gravityApply = true;
            }
        }
    }

    //그냥 천천히 1칸씩 떨어지는 테트리스 
    //void Fall()
    //{
    //    if(Time.time - previousTime > fallTime)
    //    {
    //        transform.position += new Vector3(0, -1, 0);
    //        previousTime = Time.time;
    //    }
    //}

    //void Fall2()
    //{
    //    if(Time.time - previousTime > (Input.GetKey(KeyCode.DownArrow) ? fallTime / 10 : fallTime))
    //    {
    //        transform.position += new Vector3(0, -1, 0);
    //        previousTime = Time.time;
    //    }
    //}

    bool ValidMove()
    {
        foreach(Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);

            if(roundedX < 0 || roundedX >= width || roundedY < 0 || roundedY >= height)
            {
                return false;
            }
        }

        return true;
    }
}
