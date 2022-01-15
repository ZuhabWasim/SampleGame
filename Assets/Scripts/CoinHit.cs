using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CoinHit : MonoBehaviour
{
    public ScoreManager ScoreManager; // Getting access to the script
    private Rigidbody _rigidbody;
    private Transform _transform;
    private Vector3 _coinVector;
    private int _x;
    private int _z;
    private void Start()
    {
        ScoreManager = FindObjectOfType<ScoreManager>();
        _x = UnityEngine.Random.Range(-5, 5);
        _z = UnityEngine.Random.Range(0, 9);
        Debug.Log(_x);
        Debug.Log(_z);
        _rigidbody = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();
        _transform.position = new Vector3 (_x, (float)1.8, _z);


    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ball")
        {
            Destroy(this.gameObject);

            ScoreManager.UpdateScore();
        }
    }
}