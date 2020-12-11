using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTetris : MonoBehaviour
{
    public GameObject[] Tetris;
    // Start is called before the first frame update
    void Start()
    {
        NewTetris();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewTetris()
    {
        Instantiate(Tetris[Random.Range(0, Tetris.Length)], transform.position, Quaternion.identity);
    }
}
