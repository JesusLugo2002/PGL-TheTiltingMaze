using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class TableController : MonoBehaviour
{

    public float rotationSpeed;
    public float clampAngle;

    private float currentRotX = 0f;
    private float currentRotZ = 0f;

    private Vector2 moveDirection;

    public InputActionReference move;
    public InputActionReference restart;

    private void OnEnable()
    {
        restart.action.started += RestartGame;
    }

    private void OnDisable()
    {
        restart.action.started -= RestartGame;
    }

    private void RestartGame(InputAction.CallbackContext callback)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Update()
    {
        moveDirection = move.action.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        currentRotX += moveDirection.x * rotationSpeed * Time.deltaTime;
        currentRotZ += moveDirection.y * rotationSpeed * Time.deltaTime;

        currentRotX = Mathf.Clamp(currentRotX, -clampAngle, clampAngle);
        currentRotZ = Mathf.Clamp(currentRotZ, -clampAngle, clampAngle);

        transform.rotation = Quaternion.Euler(currentRotX, 0f, currentRotZ);
    }
}
