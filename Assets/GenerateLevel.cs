using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GenerateLevel : MonoBehaviour
{
    public GameObject[] section;
    public int Pos = 50;
    public bool creatingSection = false;
    public int secNum;



    void Update()
    {

        if (creatingSection == false)
        {
            creatingSection = true;
            StartCoroutine(GenerateSection());
        }
    }

    IEnumerator GenerateSection()
    {
        secNum = Random.Range(0, 5);
        Instantiate(section[secNum],
        new Vector3(639.39f, 650.8f, Pos), Quaternion.identity);
        Pos += 200;
        yield return new WaitForSeconds(2);
        creatingSection = false;

    }

}