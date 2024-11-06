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
    public GameObject spawnPos1_1;
    public GameObject spawnPos2_2;
    public GameObject spawnPos3_3;
    private float startDelay = 1, repeatDelay = 3.5f, delayDecreaseRate = 0.05f, candysOffSet = 2.1f;
    int speed, prefabIndex1, prefabIndex2, prefabIndex3, prefabCandyIndex1, prefabChoiceIndex;
    private PlayerMovement playerMovement;
    private MoveForwardObj moveForwardObj;
    bool centinela = false;
    

    void Start()
    {
        prefabIndex1 = Random.Range(0, obstaclePrefabs.Length);
        prefabIndex2 = Random.Range(0, obstaclePrefabs.Length);
        prefabCandyIndex1 = Random.Range(0, candysPrefabs.Length);
        Instantiate(obstaclePrefabs[prefabIndex1], spawnPos1_1.transform.position, Quaternion.identity);
        Instantiate(obstaclePrefabs[prefabIndex2], spawnPos2_2.transform.position, Quaternion.identity);
        Instantiate(candysPrefabs[prefabCandyIndex1], new Vector3(spawnPos3_3.transform.position.x, spawnPos3_3.transform.position.y + candysOffSet, spawnPos3_3.transform.position.z), Quaternion.identity);

        playerMovement = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
        moveForwardObj = GameObject.FindWithTag("Road").GetComponent<MoveForwardObj>();
        StartCoroutine(SpawnObstacules());

    }

    public void SetPlayer()
    {
        playerMovement = GameObject.FindAnyObjectByType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindWithTag("Road").GetComponent<MoveForwardObj>() != null) 
        {
           moveForwardObj = GameObject.FindWithTag("Road").GetComponent<MoveForwardObj>();
        }
        
    }

    private void FixedUpdate()
    {
        if (moveForwardObj != null) 
        {
            speed = (int)moveForwardObj.globalSpeedPub;
        }
      
    }

     IEnumerator SpawnObstacules()
     {
        
        
        yield return new WaitForSeconds(startDelay);
        while (true)
        {
            repeatDelay = Mathf.Max(0.4f, repeatDelay - delayDecreaseRate);
            if (playerMovement.gameOver != true)
            {
                prefabChoiceIndex = Random.Range(0, 8);

                prefabIndex1 = Random.Range(0, obstaclePrefabs.Length);
                prefabIndex2 = Random.Range(0, obstaclePrefabs.Length);
                prefabCandyIndex1 = Random.Range(0, candysPrefabs.Length);

                switch (prefabChoiceIndex)
                {
                    case 0:
                        Instantiate(obstaclePrefabs[prefabIndex1], spawnPos1.transform.position, Quaternion.identity);
                        Instantiate(obstaclePrefabs[prefabIndex2], spawnPos2.transform.position, Quaternion.identity);
                        Instantiate(candysPrefabs[prefabCandyIndex1], new Vector3(spawnPos3.transform.position.x, spawnPos3.transform.position.y + candysOffSet, spawnPos3.transform.position.z), Quaternion.identity);
                        break;
                    case 1:
                        Instantiate(obstaclePrefabs[prefabIndex1], spawnPos1.transform.position, Quaternion.identity);
                        Instantiate(obstaclePrefabs[prefabIndex2], spawnPos2.transform.position, Quaternion.identity);
                        Instantiate(obstaclePrefabs[prefabIndex3], spawnPos3.transform.position, Quaternion.identity);
                        break;
                    case 2:
                        Instantiate(candysPrefabs[prefabCandyIndex1], new Vector3(spawnPos1.transform.position.x, spawnPos1.transform.position.y + candysOffSet, spawnPos1.transform.position.z), Quaternion.identity);
                        Instantiate(obstaclePrefabs[prefabIndex1], spawnPos2.transform.position, Quaternion.identity);
                        Instantiate(obstaclePrefabs[prefabIndex2], spawnPos3.transform.position, Quaternion.identity);
                        break;
                    case 3:
                        Instantiate(obstaclePrefabs[prefabIndex1], spawnPos1.transform.position, Quaternion.identity);
                        Instantiate(obstaclePrefabs[prefabIndex2], spawnPos2.transform.position, Quaternion.identity);
                        Instantiate(obstaclePrefabs[prefabIndex3], spawnPos3.transform.position, Quaternion.identity);
                        break;
                    case 5:

                        Instantiate(obstaclePrefabs[prefabIndex1], spawnPos1.transform.position, Quaternion.identity);
                        Instantiate(candysPrefabs[prefabCandyIndex1], new Vector3(spawnPos2.transform.position.x, spawnPos2.transform.position.y + candysOffSet, spawnPos2.transform.position.z), Quaternion.identity);
                        Instantiate(obstaclePrefabs[prefabIndex2], spawnPos3.transform.position, Quaternion.identity);
                        break;
                    case 6:
                        Instantiate(obstaclePrefabs[prefabIndex1], spawnPos1.transform.position, Quaternion.identity);
                        Instantiate(obstaclePrefabs[prefabIndex2], spawnPos2.transform.position, Quaternion.identity);
                        Instantiate(obstaclePrefabs[prefabIndex3], spawnPos3.transform.position, Quaternion.identity);
                        break;
                    case 7:
                        Instantiate(obstaclePrefabs[prefabIndex1], spawnPos1.transform.position, Quaternion.identity);
                        Instantiate(obstaclePrefabs[prefabIndex2], spawnPos2.transform.position, Quaternion.identity);
                        Instantiate(obstaclePrefabs[prefabIndex3], spawnPos3.transform.position, Quaternion.identity);
                        break;
                    default:
                        break;

                }


            }
            else
            {
                
            }
            yield return new WaitForSeconds(repeatDelay);
        }
     }
}
