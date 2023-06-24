using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance { get; private set; }
    public List<Transform> tile;
    public List<DataMusic> DataMusic;
    public List<float> DataMusicList;
    public List<Transform> spawnTransformList;
    public List<float> jumpDistances;
    private void Awake()
    {
        Instance = this;
        if (DataMusic == null) DataMusic = new List<DataMusic>();
        spawnTransformList = new List<Transform>();
        jumpDistances = new List<float>();
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("Main");

    }
    
}
