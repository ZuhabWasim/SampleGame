using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBall : MonoBehaviour
{
    private GameObject _ballObject;

    private Transform _ballTransform;
    
    private Vector3 _ballSpawnLocation = new Vector3(0.3f,2.97f,-3.96f);
    private Rigidbody _rigidbody;
    
    // Start is called before the first frame update
    void Start()
    {
        _ballObject = GameObject.Instantiate(Resources.Load("Ball"), _ballSpawnLocation, 
            Quaternion.identity) as GameObject;

        _ballTransform = _ballObject.transform;
        _rigidbody = _ballObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
