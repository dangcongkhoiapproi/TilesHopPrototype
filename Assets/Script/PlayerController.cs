using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
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

    void Start()
    {

        
        Sequence mySequence = DOTween.Sequence();
        foreach (Transform t in  Tile.Instance.tile)
        {
            var Jump =  this.transform.DOJump(t.transform.position, JumpPower,numJumps,Duration,snaping);
            mySequence.Append(Jump);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
