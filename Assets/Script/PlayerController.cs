using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using static UnityEditor.Progress;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private int speed;
    [SerializeField]
    private float JumpPower;
    [SerializeField]
    private int numJumps;
    //[SerializeField]
    //private float Duration;
    [SerializeField]
    private bool snaping;
    List<Transform> a;
    List<float> b;
    void Start()
    {
        a= new List<Transform>();
        b= new List<float>();
        a = DataManager.Instance.spawnTransformList;
        b = DataManager.Instance.DataMusicList;
        
        Sequence mySequence = DOTween.Sequence();

        foreach (Transform item in a)
        {


            var Jump = this.transform.DOJump(item.transform.position, JumpPower, numJumps, 1f, snaping);
            mySequence.Append(Jump);
            //Debug.Log("hello");

        }

        //var Jump = this.transform.DOJump(new Vector3(0,0f,10), JumpPower, numJumps, 10f, snaping);
        //mySequence.Append(Jump);
    }


}
