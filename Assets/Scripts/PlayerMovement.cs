using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public Animator animator;
    private Vector2 input;
    private bool isMoving;
    public LayerMask interactableLayer;

    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void HandleUpdate()
    {
        if (!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            if (input.x != 0)
                input.y = 0;

            if (input != Vector2.zero)
            {
                animator.SetFloat("horizontal", input.x);
                animator.SetFloat("vertical", input.y);

                var targetPosition = transform.position;
                targetPosition.x += input.x;
                targetPosition.y += input.y;
                if (IsWalkable(targetPosition))
                    StartCoroutine(Move(targetPosition));
            }
        }

        if (Input.GetKeyDown(KeyCode.Z))
            Interact();
    }

    IEnumerator Move(Vector3 targetPosition)
    {
        isMoving = true;
        animator.SetBool("isWalking", true);

        while ((targetPosition - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                targetPosition,
                speed * Time.deltaTime
            );
            yield return null;
        }
        transform.position = targetPosition;
        isMoving = false;
        animator.SetBool("isWalking", false);
    }


    void Interact()
    {
        var facingDir = new Vector3(animator.GetFloat("horizontal"), animator.GetFloat("vertical"));
        var interactPos = transform.position + facingDir;

        var collider = Physics2D.OverlapCircle(interactPos, 0.2f, interactableLayer);
        if (collider != null)
        {
            collider.GetComponent<Interactable>()?.Interact();
        }
    }

    private bool IsWalkable(Vector3 position)
    {
        if (Physics2D.OverlapCircle(position, 0.2f, interactableLayer))
        {
            return false;
        }
        return true;
    }
}
