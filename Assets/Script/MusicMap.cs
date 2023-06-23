using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MusicMapData", menuName = "Scriptable Objects/Music Map Data", order = 1)]
public class MusicMap : ScriptableObject
{
    [SerializeField]
    private string _name;
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    [SerializeField]
    private string _path;
    public string Path
    {
        get { return _path; }
        set { _path = value; }
    }
}
