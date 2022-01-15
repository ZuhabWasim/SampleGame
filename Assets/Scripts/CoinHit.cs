using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CoinHit : MonoBehaviour
{
    public ScoreManager ScoreManager; // Getting access to the script
    
    private void Start()
    {
        ScoreManager = FindObjectOfType<ScoreManager>();
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            Destroy(this.gameObject);
            
            ScoreManager.UpdateScore();
        }
    }
}
