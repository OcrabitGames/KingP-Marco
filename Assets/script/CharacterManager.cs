using TMPro;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public Pins pinsDB;
    public int selection = 0;
    public SpriteRenderer spriteRenderer;
    public TMP_Text nameLabel;

    private void Start()
    {
        UpdateCharacter();
    }
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
        } else {
            selection = 0;
        }
        UpdateCharacter();
    }
    
    public void Previous()
    {
        if (selection > 0) {
            selection--;
        } else {
            selection = pinsDB.GetCount()-1;
        }
        UpdateCharacter();
    }
}
