using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Events;

public class Fruit : MonoBehaviour
{
    public GameObject whole;
    public GameObject sliced;

    private Rigidbody fruitRigidbody;
    private Collider fruitCollider;
    private ParticleSystem juiceParticleEffects;

    public UnityEvent OnFruitSlice;

    [SerializeField] private int customFruitScore = 1;
    [SerializeField] private float sliceForceMultiplier = 2;

    private void Awake()
    {
        fruitRigidbody = GetComponent<Rigidbody>();
        fruitCollider = GetComponent<Collider>();
        juiceParticleEffects = GetComponentInChildren<ParticleSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Blade blade = other.gameObject.GetComponent<Blade>();

            Slice(blade.direction, blade.transform.position, blade.minSliceForce, blade.maxSliceForce);
            blade.CheckCombo(this.gameObject.transform.position);
        }
    }

    private void Slice(Vector3 sliceDirection, Vector3 slicePosition, float minSliceForce, float maxSliceForce)
    {
        ScoreManager.Instance.IncreaseScore(customFruitScore);

        whole.SetActive(false);
        sliced.SetActive(true);

        fruitCollider.enabled = false;
        juiceParticleEffects.Play();

        float angle = Mathf.Atan2(sliceDirection.y, sliceDirection.x) * Mathf.Rad2Deg;
        sliced.transform.rotation = Quaternion.Euler(0f, 0f, angle);

        Rigidbody[] slices = GetComponentsInChildren<Rigidbody>();
        foreach(Rigidbody slice in slices)
        {
            slice.linearVelocity = fruitRigidbody.linearVelocity;
            Vector3 randomDiretion = new Vector3(Random.Range(-1, 1), 1, Random.Range(-1, 1));

            slice.AddForceAtPosition(randomDiretion + sliceDirection * Random.Range(minSliceForce, maxSliceForce) * sliceForceMultiplier, slicePosition, ForceMode.Impulse);
            // slice.AddTorque(randomDiretion + sliceDirection * Random.Range(minSliceForce, maxSliceForce), ForceMode.Impulse);
        }

        CustomGravity[] customGravities = GetComponentsInChildren<CustomGravity>();
        foreach (CustomGravity customGravity in customGravities)
        {
            customGravity.enabled = true;
            customGravity.SetupNormalMovementDirection(fruitRigidbody.linearVelocity);
        }
    }
}
