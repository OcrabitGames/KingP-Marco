using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "Object", menuName = "Scriptable Objects/Object")]
public class Object : ScriptableObject
{
    public Pins pinsDB;
    public int selection = 0;
    public new string name;
    public SpriteRenderer spriteRenderer;
    public TMP_Text nameLabel;
    public GameObject[] items;

    void UpdateCharacter()
    {
        var current = pinsDB.GetPin(selection);
        spriteRenderer.sprite = current.prefab.GetComponent<SpriteRenderer>().sprite;
        nameLabel.SetText(current.name);
    }

    public void Next()
    {
        var numberPins = pinsDB.GetCount();
        if (selection < numberPins-1) {
            selection++;
        }

        UpdateCharacter();
    }
    
    public void Previous()
    {
        if (selection > 0) {
            selection--;
        }

        UpdateCharacter();
    }

}
