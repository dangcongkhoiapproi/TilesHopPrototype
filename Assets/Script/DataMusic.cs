using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataMusic : MonoBehaviour
{
    public int ID { get; set; }
    public List<float> NumberList { get; set; }

    public DataMusic(int id)
    {
        ID = id;
        NumberList = new List<float>();
    }

    
}
