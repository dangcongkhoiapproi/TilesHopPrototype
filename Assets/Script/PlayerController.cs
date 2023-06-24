using DG.Tweening;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public delegate void MoveDelegate();
    public event MoveDelegate OnIndexIncrease;
    [SerializeField]
    private int speed;
    [SerializeField]
    private float JumpPower;
    [SerializeField]
    private int numJumps;
    [SerializeField]
    private float Duration;
    [SerializeField]
    private bool snaping;
    private int index;
    private bool jumping;
    public void Init()
    {


        Sequence mySequence = DOTween.Sequence();
        foreach (Transform t in DataManager.Instance.spawnTransformList)
        {
            foreach (var duration in DataManager.Instance.DataMusicList)
            {
                
            }
            
        }
        int index = DataManager.Instance.spawnTransformList.Count;
        for (int i = 0; i < index; i++) {
            var Jump = this.transform.DOJump(DataManager.Instance.spawnTransformList[i].transform.position, JumpPower, numJumps, DataManager.Instance.DataMusicList[i], snaping);
            mySequence.Append(Jump);
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
        
    //    if (other.CompareTag("Tile"))
    //    {
    //        if (!jumping)
    //        {
    //            jumping = true;
    //            if (index < DataManager.Instance.spawnTransformList.Count - 1)
    //            {
    //                Move();
    //                index++;
    //                jumping = false;
    //            }
    //            Debug.Log("Object A collided with Object B");
    //        }
            

            
            
           
    //    }
    //}
    //private void Move()
    //{
    //    if (index <= DataManager.Instance.spawnTransformList.Count)
    //    {
    //        Vector3 Distance = new Vector3(0f, 0f, DataManager.Instance.jumpDistances[index]);
    //        this.transform.DOJump(Distance, JumpPower, numJumps, DataManager.Instance.DataMusicList[index], snaping);
    //        Debug.Log("khoi.dev"+DataManager.Instance.DataMusicList[index]);
    //    }
    //}
}
