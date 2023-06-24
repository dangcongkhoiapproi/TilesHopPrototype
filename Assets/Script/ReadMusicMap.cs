using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ReadMusicMap : MonoBehaviour
{
    [SerializeField]
    List<MusicMap> musicMaps;
    List<DataMusic> music;
    public static ReadMusicMap Instance { get; private set; }
    
    void Start()
    {
       music = new List<DataMusic>();
       
        ReadFile();
        foreach (var item in music)
        {
            DataMusic a = new DataMusic();
            a.NumberList = item.NumberList;
            DataManager.Instance.DataMusic.Add(a);
        }
    }
    
    public void ReadFile()
    {
        
        foreach (var map in musicMaps)
        {
            DataMusic musicConfig = new DataMusic();
            var filePath = map.Path;
            if (File.Exists(filePath))
            {

                string fileContent = File.ReadAllText(filePath);


                string[] numberStrings = fileContent.Split(',');

                foreach (string numberString in numberStrings)
                {
                    float number;
                    if (float.TryParse(numberString, out number))
                    {

                        DataManager.Instance.DataMusicList.Add(number);
                    }
                }
               
            }
            else
            {
                Debug.LogError("File does not exist at path: " + filePath);
            }
            
            //DataMusic.Add(musicConfig);
           
        }
    }
}
