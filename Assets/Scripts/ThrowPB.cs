using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowPB : MonoBehaviour
{
    
    private Rigidbody _rigidbody;
    private Transform _transform;
    private float _rotationInputHorizontal;
    private float _rotationInputVertical;
    private Vector3 _ballRot;
    
    private bool _userThrowed;

    public float ballThrowingForce = 100f;

    [SerializeField]
    private MovePB movePBScript;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // works only because you have 1 MovePB
        // get component only works if the component is attached to the same object
        // the otyher option is to find the main reference to the object
        // in that case we dont have a reference and therefore getcomponent would only work in the same object
        // but find object always works unless we have more than one.
        // in whcih case you can apply to all by find objects of 
        movePBScript ??= FindObjectOfType<MovePB>();
        
        _rotationInputVertical = Input.GetAxis("Vertical");
        _rotationInputHorizontal = Input.GetAxis("Horizontal");
        _userThrowed = Input.GetButton("Jump");
    }

    private void FixedUpdate()
    {

        // target being the player, look at
        if (movePBScript != null)
        {
            _ballRot = movePBScript._userRot;
            _transform.rotation = Quaternion.Euler(_ballRot);
        }
        // _ballRot = _transform.rotation.eulerAngles;
        // _ballRot += new Vector3(_rotationInputVertical, _rotationInputHorizontal, 0);
        // _transform.rotation = Quaternion.Euler(_ballRot);

        if (_userThrowed)
        {
            _rigidbody.AddForce(movePBScript._transform.forward * 300);
            _userThrowed = false;
        }
    }
}
