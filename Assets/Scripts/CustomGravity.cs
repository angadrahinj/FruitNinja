using UnityEngine;

public class CustomGravity : MonoBehaviour
{
    Rigidbody rb;

    public float gravityScale = 1f;
    public float gravityMultiplier = 10f;
    public static float globalGravity = -9.81f;

    public Vector3 normalMovementDirection;


    private void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    public void SetupNormalMovementDirection(Vector3 originalMovementDirection)
    {
        normalMovementDirection = originalMovementDirection;
    }

    private void FixedUpdate()
    {
        Vector3 customGravity = Vector3.up * globalGravity * gravityScale * gravityMultiplier;
        rb.AddForce(new Vector3(normalMovementDirection.x, customGravity.y, normalMovementDirection.z), ForceMode.Acceleration);
    }
}
