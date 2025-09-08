using System;
using UnityEngine;
using UnityEngine.Rendering;
using TMPro;
using UnityEditor.Search;

public class TestComboTextSpawner : MonoBehaviour
{
    public GameObject comboTextPrefab;
    [SerializeField] int testSliceCombo;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;

            GameObject comboTextGameObject = Instantiate(comboTextPrefab, mousePosition, Quaternion.identity);
            comboTextGameObject.GetComponent<ComboText>().SetUpTextColors(testSliceCombo);
            // comboTextGameObject.GetComponent<TextMeshPro>().text = testSliceCombo + " Fruit \n Combo";
            Destroy(comboTextGameObject, 1f);
        }
    }
}
