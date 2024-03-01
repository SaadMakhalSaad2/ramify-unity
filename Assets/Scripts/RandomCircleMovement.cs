using System.Collections;
using UnityEngine;

public class RandomCircleMovement : MonoBehaviour
{
    public float radius = 5.0f; // Configurable radius for random movement within a circle
    public float moveSpeed = 5.0f; // Speed at which the character moves to the new position
    private Vector2 targetPosition;
    private bool isMoving = false; // Track whether the character is moving
    public Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        MoveToNewPosition(); // Start the first move
    }

    void MoveToNewPosition()
    {
        // Generate a new target position within the circle
        targetPosition = GenerateRandomPosition();
        // Start moving towards the new target position
        StartCoroutine(MoveAndPause());
    }

    IEnumerator MoveAndPause()
    {
        isMoving = true; // Set moving state to true
        animator.SetBool("isWalking", true);

        // Move towards the target position
        while (Vector2.Distance(transform.position, targetPosition) > 0.1f)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                targetPosition,
                moveSpeed * Time.deltaTime
            );
            yield return null; // Wait for the next frame
        }

        isMoving = false; // Set moving state to false
        animator.SetBool("isWalking", false);

        // Wait for a random time between 2 to 5 seconds
        yield return new WaitForSeconds(Random.Range(2f, 5f));

        // After the wait, start moving to a new position
        MoveToNewPosition();
    }

    Vector2 GenerateRandomPosition()
    {
        float angle = Random.Range(0f, 360f) * Mathf.Deg2Rad;
        float x = Mathf.Cos(angle) * radius;
        float y = Mathf.Sin(angle) * radius;
        
        animator.SetFloat("horizontal", x);
        animator.SetFloat("vertical", y);
        return new Vector2(x, y) + (Vector2)transform.position;
    }
}
