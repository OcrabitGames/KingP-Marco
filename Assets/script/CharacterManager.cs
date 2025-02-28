using TMPro;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public Pins pinsDB;
    public static int selection = 0;
    public SpriteRenderer spriteRenderer;
    public TMP_Text nameLabel;
    private AudioSource _buttonSound;

    private void Start()
    {
        UpdateCharacter();
        _buttonSound = GetComponent<AudioSource>();
    }
    
    void UpdateCharacter()
    {
        var current = pinsDB.GetPin(selection);
        spriteRenderer.sprite = current.prefab.GetComponent<SpriteRenderer>().sprite;
        nameLabel.SetText(current.name);
    }

    public void Next()
    {
        _buttonSound.Play();
        
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
        _buttonSound.Play();

        if (selection > 0) {
            selection--;
        } else {
            selection = pinsDB.GetCount()-1;
        }
        UpdateCharacter();
    }
    
}
