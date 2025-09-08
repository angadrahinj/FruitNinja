using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BladeCombo : MonoBehaviour
{
    public GameObject comboTextPrefab;

    [SerializeField] private float timeBetweenSliceCombos = 0.25f;
    float timer = 0.125f;
    public int sliceCombo;

    private List<Vector3> fruitSlicePositions = new List<Vector3>();

    private void OnEnable()
    {
        timer = timeBetweenSliceCombos;
    }

    private void OnDisable()
    {
        if (sliceCombo >= 3)
        {
            Debug.Log("You got a combo of : " + sliceCombo);

            // Figuring out average position to spawn combo text
            Vector3 averagePosition = Vector3.zero;
            foreach (var position in fruitSlicePositions)
            {
                averagePosition += position;
            }
            averagePosition /= fruitSlicePositions.Count;

            // Spawning and destroying combo text
            GameObject comboTextGameObject = Instantiate(comboTextPrefab, averagePosition, Quaternion.identity);
            comboTextGameObject.GetComponent<ComboText>().SetUpTextColors(sliceCombo);
            Destroy(comboTextGameObject, 1f);

            // Update score
            ScoreManager.Instance.IncreaseScore(sliceCombo);
        }

        ResetCombo();
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            this.enabled = false;
        }
    }

    public void UpdateCombo(Vector3 fruitSlicePosition)
    {
        timer = timeBetweenSliceCombos;
        sliceCombo++;

        fruitSlicePositions.Add(fruitSlicePosition);
    }

    private void ResetCombo()
    {
        sliceCombo = 0;
        timer = timeBetweenSliceCombos;

        fruitSlicePositions.Clear();
    }
}
