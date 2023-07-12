using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;
    
    [SerializeField] private float moveSpeed;
    private Vector2 _playerMovement;

    private void Update()
    {
        PlayerMove();
    }
    
    private void PlayerMove()
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
        }

        if (Input.GetKey(KeyCode.S)) 
        {
            playerAnimator.SetBool("isRunningDown", true);
            _playerMovement.y -= 1;
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            playerAnimator.SetBool("isRunningDown", false);
        }

        if (Input.GetKey(KeyCode.A)) 
        {
            playerAnimator.SetBool("isRunningLeft", true);
            _playerMovement.x -= 1;
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            playerAnimator.SetBool("isRunningLeft", false);
        }
    
        if (Input.GetKey(KeyCode.D)) 
        {
            playerAnimator.SetBool("isRunningRight", true);
            _playerMovement.x += 1;
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            playerAnimator.SetBool("isRunningRight", false);
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
}
