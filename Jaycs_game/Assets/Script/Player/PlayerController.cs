using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;
    
    [SerializeField] private float moveSpeed;
    private Vector2 _playerMovement;

    private float _doubleClickTimeThreshold = 0.3f;
    private float _lastClickTime = 0f;
    
    private void Start()
    {
        Application.targetFrameRate = 120;
    }

    private void Update()
    {
        PlayDashAnimation();
        PlayerMoveAndAnimation();
    }
    
    private void PlayerMoveAndAnimation()
    {
        _playerMovement = Vector2.zero;
    
        if (Input.GetKey(KeyCode.W)) 
        {
            playerAnimator.SetBool("isRunningUp", true);
            _playerMovement.y += 1;
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            playerAnimator.SetBool("isRunningUp", false);
            playerAnimator.SetBool("isDashUp", false);
        }

        if (Input.GetKey(KeyCode.S)) 
        {
            playerAnimator.SetBool("isRunningDown", true);
            _playerMovement.y -= 1;
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            playerAnimator.SetBool("isRunningDown", false);
            playerAnimator.SetBool("isDashDown", false);
        }

        if (Input.GetKey(KeyCode.A)) 
        {
            playerAnimator.SetBool("isRunningLeft", true);
            _playerMovement.x -= 1;
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            playerAnimator.SetBool("isRunningLeft", false);
            playerAnimator.SetBool("isDashLeft", false);
        }
    
        if (Input.GetKey(KeyCode.D)) 
        {
            playerAnimator.SetBool("isRunningRight", true);
            _playerMovement.x += 1;
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            playerAnimator.SetBool("isRunningRight", false);
            playerAnimator.SetBool("isDashRight", false);
        }

        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            playerAnimator.SetBool("isRunningDown" ,false);
            playerAnimator.SetBool("isRunningRight", true);
        } 
        
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            playerAnimator.SetBool("isRunningDown" ,false);
            playerAnimator.SetBool("isRunningLeft", true);
        } 
        
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            playerAnimator.SetBool("isRunningUp" ,false);
            playerAnimator.SetBool("isRunningRight", true);
        } 
        
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            playerAnimator.SetBool("isRunningUp" ,false);
            playerAnimator.SetBool("isRunningLeft", true);
        } 

        
        if (_playerMovement != Vector2.zero) {
            this.transform.Translate(_playerMovement * moveSpeed * Time.deltaTime);
        }
    }

    private void PlayDashAnimation()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            // Check if the time difference between the last click and the current click is within the threshold
            if (Time.time - _lastClickTime <= _doubleClickTimeThreshold)
            {
                // It's a double-click!
                _playerMovement.y += 2;
                playerAnimator.SetBool("isDashUp", true);
                Debug.Log("Double-clicked W button");
                // Perform your desired action for a double-click here
            }
            else 
            {
                // It's a single click
                Debug.Log("Single-clicked W button");
            }

            // Update the last click time
            _lastClickTime = Time.time;
            StartCoroutine(StopPlayingAnimation("isDashUp", false));
        }
        
        if (Input.GetKeyDown(KeyCode.S))
        {
            // Check if the time difference between the last click and the current click is within the threshold
            if (Time.time - _lastClickTime <= _doubleClickTimeThreshold)
            {
                // It's a double-click!
                _playerMovement.y -= 2;
                playerAnimator.SetBool("isDashDown", true);
                Debug.Log("Double-clicked S button");
                // Perform your desired action for a double-click here
            }
            else 
            {
                // It's a single click
                Debug.Log("Single-clicked S button");
            }

            // Update the last click time
            _lastClickTime = Time.time;
            StartCoroutine(StopPlayingAnimation("isDashDown", false));
        }
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            // Check if the time difference between the last click and the current click is within the threshold
            if (Time.time - _lastClickTime <= _doubleClickTimeThreshold)
            {
                // It's a double-click!
                _playerMovement.x += 2;
                playerAnimator.SetBool("isDashRight", true);
                Debug.Log("Double-clicked D button");
                // Perform your desired action for a double-click here
            }
            else 
            {
                // It's a single click
                Debug.Log("Single-clicked D button");
            }

            // Update the last click time
            _lastClickTime = Time.time;
            StartCoroutine(StopPlayingAnimation("isDashRight", false));
        }
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            // Check if the time difference between the last click and the current click is within the threshold
            if (Time.time - _lastClickTime <= _doubleClickTimeThreshold)
            {
                // It's a double-click!
                _playerMovement.x -= 2;
                playerAnimator.SetBool("isDashLeft", true);
                Debug.Log("Double-clicked A button");
                // Perform your desired action for a double-click here
            }
            else 
            {
                // It's a single click
                Debug.Log("Single-clicked A button");
            }

            // Update the last click time
            _lastClickTime = Time.time;
            StartCoroutine(StopPlayingAnimation("isDashLeft", false));
        }
        
        /*if (_playerMovement != Vector2.zero) {
            this.transform.Translate(_playerMovement * moveSpeed * Time.deltaTime);
        }*/
    }

    IEnumerator StopPlayingAnimation(string nameOfAnimation, bool state)
    {
        yield return new WaitForSeconds(0.5f);
        
        playerAnimator.SetBool(nameOfAnimation, state);
    }
}
