using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SequentialTxtReader : MonoBehaviour
{
    public static SequentialTxtReader Instance {get;set;}
    public string folderPath; 
    public List<string> fileNames; 

    void Start()
    {
        folderPath = "Assets/Resources/MusicMap";
        ReadSequentialFiles();
    }

   public void ReadSequentialFiles()
    {
       
        if (Directory.Exists(folderPath))
        {
           
            string[] filepaths = Directory.GetFiles(folderPath, "*.txt");

            
            System.Array.Sort(filepaths);

            
            foreach (string filepath in filepaths)
            {
                string filename = Path.GetFileName(filepath);
            }

            
            foreach (string filename in fileNames)
            {
                Debug.Log("Filename: " + filename);
            }
        }
        else
        {
            Debug.LogError("Folder does not exist at path: " + folderPath);
        }
    }
}
