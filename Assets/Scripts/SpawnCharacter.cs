using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCharacter : MonoBehaviour
{
    private GameObject _playerChar;
    private Transform _playerTransform;
    private Rigidbody _rigidbody;
    
    private Vector3 _charSpawnLocation = new Vector3(0.3f,2.97f,-3.96f);

    private const float RespawnHeight = -50f;

    public const int NumOfLives = 3;
    public int PlayerLivesLeft;

    public bool GameEnded = false;
    
    // Start is called before the first frame update
    private void Start()
    {
        // Spawns the character
        _playerChar = GameObject.Instantiate(Resources.Load("Character"), _charSpawnLocation, 
            Quaternion.identity) as GameObject; //Instantiate()
        
        _playerTransform = _playerChar.transform;
        _rigidbody = _playerChar.GetComponent<Rigidbody>();

        PlayerLivesLeft = NumOfLives;

    }

    // Update is called once per frame
    void Update()
    {
        // Manage the character
        if (_playerTransform.position.y < RespawnHeight)
        {
            if (PlayerLivesLeft > 0)
            {
                _playerTransform.position = _charSpawnLocation;
                _rigidbody.velocity = new Vector3(0, 0, 0);
                PlayerLivesLeft -= 1;
            }
            else
            {
                EndGame();
            }
      
        }
    }

    private void EndGame()
    {
        GameEnded = true;
        Time.timeScale = 0;
        Debug.Log("Game has ended.");
    }
}
