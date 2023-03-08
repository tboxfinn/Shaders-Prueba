using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGrass : MonoBehaviour
{
    public GameObject grassPrefab;
    public int grassSize = 20;
    public GameObject player;
    public Material mat;

    void Start()
    {
        for(int z =- grassSize; z<= grassSize; z++)
        {
            for (int x = -grassSize; x <= grassSize; x++)
            {
                Vector3 position = new Vector3(x / 4.0f + Random.Range(-0.5f, 0.5f), 0, z / 4.0f + Random.Range(-0.5f, 0.5f));
                GameObject grass = Instantiate(grassPrefab, position, Quaternion.identity);
                grass.transform.localScale = new Vector3(1, Random.Range(0.8f, 1.2f), 1);
            }
        }
    }

    private void Update()
    {
        mat.SetVector("_TramplePosition",player.transform.position);
    }
}
