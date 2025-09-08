using UnityEngine;

[CreateAssetMenu(fileName = "new Combo Text Color", menuName = "Combo Text Color")]
public class SO_TextColors : ScriptableObject
{
    public int sliceComboInt;

    public Color textGradientColor = new Color(1, 1, 1, 1);
    public Color textSecondaryGradientColor = new Color(1, 1, 1, 1);

    public Color textOutlineColor = new Color(1, 1, 1, 1);
}
