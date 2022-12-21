using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public SpriteRenderer playerSprite;
    public float moveSpeed = 2f;

    private Camera mainCamera;
    private float rightScreenEdge;
    private float leftScreenEdge;
    private float playerSpriteHalfWidth;

    
    void Start()
    {
        
        mainCamera = Camera.main;
       
        Vector2 screenTopRightCorner = new Vector2(Screen.width, Screen.height);
        Vector2 topRightCornerInWorldSpace = mainCamera.ScreenToWorldPoint(screenTopRightCorner);
        rightScreenEdge = topRightCornerInWorldSpace.x;
       
        Vector2 screenBottomLeftCorner = new Vector2(0f, 0f);
        Vector2 bottomLeftCornerInWorldSpace = mainCamera.ScreenToWorldPoint(screenBottomLeftCorner);
        leftScreenEdge = bottomLeftCornerInWorldSpace.x;

        
        playerSpriteHalfWidth = playerSprite.bounds.size.x * 0.5f;
    }  
    void Update()
    {      
        float hlInput = Input.GetAxis("Horizontal");
      
        float rightLimit = rightScreenEdge - playerSpriteHalfWidth;
        float leftLimit = leftScreenEdge + playerSpriteHalfWidth;
      
        Vector2 currentPos = transform.position;
       
        if (hlInput > 0f && transform.position.x < rightLimit)
        {
            
            Vector2 newPos = currentPos + new Vector2(1f, 0f);

            
            transform.position = Vector2.MoveTowards(currentPos, newPos, moveSpeed * Time.deltaTime);
        }      
        else if (hlInput < 0f && transform.position.x > leftLimit)
        {
            Vector2 newPos = currentPos - new Vector2(1f, 0f);
            transform.position = Vector2.MoveTowards(currentPos, newPos, moveSpeed * Time.deltaTime);
        }
    }
}
