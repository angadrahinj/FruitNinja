using TMPro;
using UnityEngine;

public class ComboText : MonoBehaviour
{
    private TextMeshPro textMeshPro;

    [SerializeField] private TextMeshPro plus;
    [SerializeField] private TextMeshPro comboIntText;


    [SerializeField] private SO_TextColors[] comboTextColors;

    private void Awake()
    {
        textMeshPro = GetComponent<TextMeshPro>();
    }

    public void SetUpTextColors(int comboInt)
    {
        textMeshPro.text = comboInt + " Fruit \n Combo";
        plus.text = "+";
        comboIntText.text = comboInt.ToString();

        SO_TextColors textColorsSO = FigureOutTextColorsBasedOnComboInt(comboInt);

        if (textColorsSO)
        {
            // In case it's off
            textMeshPro.enableVertexGradient = true;
            plus.enableVertexGradient = true;
            comboIntText.enableVertexGradient = true;

            // Gradient
            textMeshPro.colorGradient = new VertexGradient
            (
                textColorsSO.textGradientColor,
                textColorsSO.textGradientColor,
                textColorsSO.textSecondaryGradientColor,
                textColorsSO.textSecondaryGradientColor
            );

            // Since the + is a seperate text object
            plus.colorGradient = new VertexGradient
            (
                textColorsSO.textGradientColor,
                textColorsSO.textGradientColor,
                textColorsSO.textSecondaryGradientColor,
                textColorsSO.textSecondaryGradientColor
            );
            
            // Big Number used a bigger font size so it is also another object
            comboIntText.colorGradient = new VertexGradient
            (
                textColorsSO.textGradientColor,
                textColorsSO.textGradientColor,
                textColorsSO.textSecondaryGradientColor,
                textColorsSO.textSecondaryGradientColor
            );

            // Outline
            textMeshPro.outlineColor = textColorsSO.textOutlineColor;
            plus.outlineColor = textColorsSO.textOutlineColor;
            comboIntText.outlineColor = textColorsSO.textOutlineColor;

        }
    }

    public SO_TextColors FigureOutTextColorsBasedOnComboInt(int comboInt)
    {
        foreach (SO_TextColors textColorSO in comboTextColors)
        {
            if (comboInt == textColorSO.sliceComboInt)
            {
                return textColorSO;
            }
        }

        // 10+ combo 
        return comboTextColors[comboTextColors.Length - 1];
    }
}
