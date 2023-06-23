using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectPrefab;
    public float minSpawnDelay = 1f; 
    public float maxSpawnDelay = 3f; 
    public float spawnHeight = 0f; 

    private float[] spawnTimes; 
    List<float> spawnList;
    private int currentIndex = 0; 
    List<Transform> spawnTransformList;
    private void Start()
    {
        spawnTransformList = new List<Transform>();
        spawnList = new List<float>();
        spawnTimes = new float[80];
        foreach (DataMusic item in ReadMusicMap.DataMusic)
        {
            foreach (var time in item.NumberList)
            {
                spawnList.Add(time);
            }
        }
        
        //float[] spawnTimesList = { 1.5f, 2.8f, 4.2f, 5.5f, 2.8f, 4.2f, 5.5f, 2.8f, 4.2f, 5.5f, 2.8f, 4.2f, 5.5f, 2.8f, 4.2f, 5.5f, 2.8f, 4.2f, 5.5f, 2.8f, 4.2f, 5.5f };
        for (int i = 0; i < spawnList.Count; i++)
        {
            spawnTimes[i] = spawnList[i];
        }
        //spawnTimes = spawnTimesList;

        
        Invoke("SpawnObject", spawnTimes[currentIndex]);
    }

    private void SpawnObject()
    {
        
        float spawnZ = Random.Range(0f, 100f);

        if(spawnTransformList.Count > 0 )
        {
            Transform a = spawnTransformList[spawnTransformList.Count - 1];
            GameObject newObject = Instantiate(objectPrefab, new Vector3(0f, spawnHeight, (a.position.z+1)+ spawnTimes[currentIndex]*5), Quaternion.identity);
            spawnTransformList.Add(newObject.transform);
        }
        else
        {
            GameObject newObject = Instantiate(objectPrefab, new Vector3(0f, spawnHeight, spawnZ), Quaternion.identity);
            spawnTransformList.Add(newObject.transform);
        }
        
        

        

        currentIndex++; 

        
        if (currentIndex >= spawnTimes.Length)
        {
            Debug.Log("");
            return;
        }

        
        float spawnDelay = Random.Range(minSpawnDelay, maxSpawnDelay);

       
        Invoke("SpawnObject", spawnTimes[currentIndex] - spawnTimes[currentIndex - 1] + spawnDelay);
    }
}
