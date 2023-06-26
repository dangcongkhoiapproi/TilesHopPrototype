using DG.Tweening;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public class PlayerController : MonoBehaviour
{
    //automode
    [SerializeField]
    private float JumpPower;
    [SerializeField]
    private int numJumps;
    [SerializeField]
    private bool snaping;
    private int index;
    private bool jumping;
    private Sequence mySequence;
    public float horizontalMoveDistance = 1f;

    //Manual
    [SerializeField] float force = 5.0f;
    [SerializeField] float durationAnim = 0.33f;

    private new Rigidbody rigidbody;
    private new Renderer renderer;
    private bool _isInitialized = false;


    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
       // renderer = GetComponent<Renderer>();
    }
    private void Start()
    {
        rigidbody.isKinematic = true;
        //renderer.sharedMaterial.DOFade(1.0f, 0.0f);
    }
    private void Update()
    {
        if (_isInitialized)
            Move();
    }
    //auto
    //public void Init()
    //{


    //    Sequence mySequence = DOTween.Sequence();
    //    foreach (Transform t in DataManager.Instance.spawnTransformList)
    //    {
    //        foreach (var duration in DataManager.Instance.DataMusicList)
    //        {

    //        }

    //    }
    //    int index = DataManager.Instance.spawnTransformList.Count;
    //    for (int i = 0; i < index; i++)
    //    {
    //        Vector3 Distance = new Vector3(0f, 0f, DataManager.Instance.spawnTransformList[i].transform.position.z);
    //        var Jump = this.transform.DOJump(Distance, JumpPower, numJumps, DataManager.Instance.DataMusicList[i], snaping);
    //        mySequence.Append(Jump);
    //    }
    //}

    //manual
    public void Init(GameManager gameMgr)
    {
        rigidbody.isKinematic = false;
        //rigidbody.velocity = Vector3.up * force * Time.deltaTime;
        rigidbody.velocity = new Vector3(0, force, 0);

        _isInitialized = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (_isInitialized)
        {
            if (other.CompareTag("Tile"))
            {
                Jump();
            }
        }
    }
    private void Move()
    {
        if (Input.GetMouseButton(0))
        {
            var inputValue = Input.GetAxis("Mouse X");
            if (inputValue > 0)
            {
                // Mouse moved left.
                rigidbody.AddForce(new Vector3(1, 0, 0));
            }
            else if (inputValue < 0)
            {
                // Mouse moved right.
                rigidbody.AddForce(new Vector3(-1, 0, 0));
            }
        }
    }

    private void Jump()
    {
        // Get the gravity value.
        var magnitude = Physics.gravity.magnitude;
        // Calculate the vertical speed.
        var speed = Mathf.Sqrt(2 * force * magnitude);
        CalculateHangTime(magnitude);
        // Jump.
        rigidbody.velocity = new Vector3(0, speed * 0.5f, 0);
    }
    private void CalculateHangTime(float magnitude)
    {
        // Get the gravity value.


        // Calculate the initial falling speed.
        var initialFallSpeed = magnitude * 0.5f;

        // Calculate hang time.
        var hangTime = (2 * initialFallSpeed) / magnitude;

        Debug.Log("Hang time: " + hangTime + " seconds");
    }
    private float CalculateHangTime1(float magnitude)
    {
        // Get the gravity value.


        // Calculate the initial falling speed.
        var initialFallSpeed = magnitude * 0.5f;

        // Calculate hang time.
        var hangTime = (2 * initialFallSpeed) / magnitude;

        Debug.Log("Hang time: " + hangTime + " seconds");

        return magnitude;
    }

}
