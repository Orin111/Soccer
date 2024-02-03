using UnityEngine;

public class Keeper : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    public float movementRange = 5.0f; // Adjust this to control how far the goalkeeper can move
    public string ballTag = "Ball";

    private CharacterController controller;
    private Transform ball;
    private bool movingForward = true;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        ball = GameObject.FindGameObjectWithTag(ballTag)?.transform;
    }

    void Update()
    {
        if (ball != null)
        {
            // Move goalkeeper forward and backward within the defined range
            float verticalMovement = movingForward ? 1.0f : -1.0f;
            Vector3 movement = new Vector3(0, 0, verticalMovement) * movementSpeed * Time.deltaTime;

            controller.Move(movement);

            // Look at the ball
            transform.LookAt(ball);
            transform.rotation = new Quaternion(0, transform.rotation.y, 0, transform.rotation.w);

            // Check if the goalkeeper has reached the movement range and change direction
            if (transform.position.z >= movementRange / 2 && movingForward)
            {
                movingForward = false;
            }
            else if (transform.position.z <= -movementRange / 2 && !movingForward)
            {
                movingForward = true;
            }
        }
    }
}