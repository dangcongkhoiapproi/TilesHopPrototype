using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject Ball;
    public Button Play;
    private void OnEnable()
    {
        Play.onClick.AddListener(OnClickPlay);
    }

   

    private void OnDisable()
    {
        Play.onClick.RemoveListener(OnClickPlay);
    }
    private void OnClickPlay()
    {
        Ball.GetComponent<PlayerController>().Init();
       Ball.GetComponent<Rigidbody>().isKinematic = false;
        audioSource.Play();
    }
}
