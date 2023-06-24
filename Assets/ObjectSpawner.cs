using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public static ObjectSpawner Instance { get; private set; }
    public GameObject objectPrefab;
    public float minSpawnDelay = 1f; 
    public float maxSpawnDelay = 3f; 
    public float spawnHeight = 0f; 

    private float[] spawnTimes; 
    List<float> spawnList;
    private int currentIndex = 0;

    private void Start()
    {
        Instance = this;
        spawnList = new List<float>();
        spawnTimes = new float[80];

        foreach (float item in DataManager.Instance.DataMusicList)
        {
            spawnList.Add(item);
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

        if(DataManager.Instance.spawnTransformList.Count > 0 )
        {
            Transform a = DataManager.Instance.spawnTransformList[DataManager.Instance.spawnTransformList.Count - 1];
            GameObject newObject = Instantiate(objectPrefab, new Vector3(0f, spawnHeight, (a.position.z+1)+ spawnTimes[currentIndex]*5), Quaternion.identity);
            DataManager.Instance.spawnTransformList.Add(newObject.transform);
        }
        else
        {
            GameObject newObject = Instantiate(objectPrefab, new Vector3(0f, spawnHeight, 0f), Quaternion.identity);
            DataManager.Instance.spawnTransformList.Add(newObject.transform);
        }
        
        

        

        currentIndex++;


        if (currentIndex >= spawnTimes.Length)
        {
            Debug.Log("Spawn tile success");
            return;
        }


        float spawnDelay = Random.Range(minSpawnDelay, maxSpawnDelay);

       
        Invoke("SpawnObject", 0f);
    }
}
