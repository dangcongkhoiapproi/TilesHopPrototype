using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance { get; private set; }
    public List<Transform> tile;
    public List<DataMusic> DataMusic;
    private void Start()
    {
        Instance = this;
        DataMusic = new List<DataMusic>(); 
    }
    
}
