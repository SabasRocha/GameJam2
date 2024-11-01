using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnObjManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public GameObject[] candysPrefabs;
    public  GameObject spawnPos1;
    public GameObject  spawnPos2;
    public GameObject  spawnPos3;
    private float startDelay = 2, repeatDelay = 1.5f, candysOffSet = 2.1f;
    int prefabIndex1, prefabIndex2, prefabIndex3, prefabCandyIndex1, prefabChoiceIndex;
    private PlayerControllerTest playerControllertest;
    private SpawnObjManager spawnObjManager;

    void Start()
    {
        playerControllertest = GameObject.Find("Player").GetComponent<PlayerControllerTest>();
        spawnObjManager = GameObject.Find("SpawnObjManager").GetComponent<SpawnObjManager>();
        InvokeRepeating("SpawnObstacules", startDelay, repeatDelay);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacules()
    {
        if (playerControllertest.gameOver != true)
        {
            prefabChoiceIndex = Random.Range(0, 8);

            prefabIndex1 = Random.Range(0, obstaclePrefabs.Length);
            prefabIndex2 = Random.Range(0, obstaclePrefabs.Length);
            prefabCandyIndex1 = Random.Range(0, candysPrefabs.Length);

            switch (prefabChoiceIndex)
            {
                case 0:
                    Instantiate(obstaclePrefabs[prefabIndex1], spawnPos1.transform.position, Quaternion.Euler(-90, 0, -180));
                    Instantiate(obstaclePrefabs[prefabIndex2], spawnPos2.transform.position, Quaternion.Euler(-90, 0, -180));
                    Instantiate(candysPrefabs[prefabCandyIndex1], new Vector3(spawnPos3.transform.position.x, spawnPos3.transform.position.y + candysOffSet, spawnPos3.transform.position.z), Quaternion.Euler(-90, 0, 0));
                    break;
                case 1:
                    Instantiate(obstaclePrefabs[prefabIndex1], spawnPos1.transform.position, Quaternion.Euler(-90, 0, -180));
                    Instantiate(obstaclePrefabs[prefabIndex2], spawnPos2.transform.position, Quaternion.Euler(-90, 0, -180));
                    Instantiate(obstaclePrefabs[prefabIndex3], spawnPos3.transform.position, Quaternion.Euler(-90, 0, -180));
                    break;
                case 2:
                    Instantiate(candysPrefabs[prefabCandyIndex1], new Vector3(spawnPos1.transform.position.x, spawnPos1.transform.position.y + candysOffSet, spawnPos1.transform.position.z), Quaternion.Euler(-90, 0, 0));
                    Instantiate(obstaclePrefabs[prefabIndex1], spawnPos2.transform.position, Quaternion.Euler(-90, 0, -180));
                    Instantiate(obstaclePrefabs[prefabIndex2], spawnPos3.transform.position, Quaternion.Euler(-90, 0, -180));
                    break;
                case 3:
                    Instantiate(obstaclePrefabs[prefabIndex1], spawnPos1.transform.position, Quaternion.Euler(-90, 0, -180));
                    Instantiate(obstaclePrefabs[prefabIndex2], spawnPos2.transform.position, Quaternion.Euler(-90, 0, -180));
                    Instantiate(obstaclePrefabs[prefabIndex3], spawnPos3.transform.position, Quaternion.Euler(-90, 0, -180));
                    break;
                case 5:

                    Instantiate(obstaclePrefabs[prefabIndex1], spawnPos1.transform.position, Quaternion.Euler(-90, 0, -180));
                    Instantiate(candysPrefabs[prefabCandyIndex1], new Vector3(spawnPos2.transform.position.x, spawnPos2.transform.position.y + candysOffSet, spawnPos2.transform.position.z), Quaternion.Euler(-90, 0, 0));
                    Instantiate(obstaclePrefabs[prefabIndex2], spawnPos3.transform.position, Quaternion.Euler(-90, 0, -180));
                    break;
                case 6:
                    Instantiate(obstaclePrefabs[prefabIndex1], spawnPos1.transform.position, Quaternion.Euler(-90, 0, -180));
                    Instantiate(obstaclePrefabs[prefabIndex2], spawnPos2.transform.position, Quaternion.Euler(-90, 0, -180));
                    Instantiate(obstaclePrefabs[prefabIndex3], spawnPos3.transform.position, Quaternion.Euler(-90, 0, -180));
                    break;
                case 7:
                    Instantiate(obstaclePrefabs[prefabIndex1], spawnPos1.transform.position, Quaternion.Euler(-90, 0, -180));
                    Instantiate(obstaclePrefabs[prefabIndex2], spawnPos2.transform.position, Quaternion.Euler(-90, 0, -180));
                    Instantiate(obstaclePrefabs[prefabIndex3], spawnPos3.transform.position, Quaternion.Euler(-90, 0, -180));
                    break;
                default:
                    break;
            }
            
            
           
            
        }
        else
        {
            Time.timeScale = 0f;
        }
    }
}
