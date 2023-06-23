using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ReadMusicMap : MonoBehaviour
{
    [SerializeField]
    List<MusicMap> musicMaps;
    public static List<DataMusic> DataMusic;
    int index;
    void Start()
    {
       
       index = 1;
        ReadFile();
        
    }

    void ReadFile()
    {
        if (DataMusic == null)
        {
            DataMusic = new List<DataMusic>();
        }
        foreach (var map in musicMaps)
        {
            DataMusic musicConfig = new DataMusic(index);
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
                        
                        musicConfig.NumberList.Add(number);

                       
                    }
                }
               
            }
            else
            {
                Debug.LogError("File does not exist at path: " + filePath);
            }
            //DataManager.Instance.DataMusic.Add(musicConfig);
            DataMusic.Add(musicConfig);
            index++;
        }
    }
}
