using UnityEngine;

public class Blade : MonoBehaviour
{
    #region Variables
    private Camera mainCamera;
    private Collider bladeCollider;
    private TrailRenderer bladeTrail;
    private BladeCombo bladeCombo;
    private bool slicing;

    public Vector3 direction { get; private set; }
    public float minSliceForce = 5f;
    public float maxSliceForce = 20f;
    public float minSliceVelocity = 0.01f;

    #endregion

    #region Unity Functions
    private void OnEnable()
    {
        StopSlicing();
    }

    private void OnDisable()
    {
        StopSlicing();
    }

    private void Awake()
    {
        mainCamera = Camera.main;
        bladeCollider = GetComponent<Collider>();

        bladeTrail = GetComponentInChildren<TrailRenderer>();
        bladeCombo = GetComponentInChildren<BladeCombo>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartSlicing();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopSlicing();
        }
        else if (slicing)
        {
            ContinueSlicing();
        }
    }
    #endregion

    public void CheckCombo(Vector3 fruitPosition)
    {
        if (bladeCombo.enabled)
        {
            bladeCombo.UpdateCombo(fruitPosition);
        }
        else
        {
            bladeCombo.enabled = true;
            bladeCombo.UpdateCombo(fruitPosition);
        }
    }

    #region Slicing Functions
    private void StartSlicing()
    {
        Vector3 newPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0;

        transform.position = newPosition;

        slicing = true;
        bladeCollider.enabled = true;
        bladeTrail.Clear();
        bladeTrail.enabled = true;
    }

    private void StopSlicing()
    {
        slicing = false;
        bladeCollider.enabled = false;
        bladeTrail.enabled = false;

        //OnDisable will check combo
        bladeCombo.enabled = false;
    }

    private void ContinueSlicing()
    {
        Vector3 newPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0;

        direction = newPosition - transform.position;

        //Just for if someone is holding the mouse but doesn't mean to slice
        float velocity = direction.magnitude / Time.deltaTime;
        bladeCollider.enabled = velocity > minSliceVelocity;

        transform.position = newPosition;
    }
    #endregion
}
