using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour
{
    public UnityEvent newSelectionEvent;
    public CollectionSO allSprites;
    public PlayerConfigData playerConfig;
    public GameObject characterPrefab;
    // Start is called before the first frame update
    void Start()
    {
        GameObject newSprite;
        for (int i = 0; i < allSprites.collectables.Count; i++)
        {
            newSprite = Instantiate(characterPrefab);
            newSprite.GetComponent<SelectableCharacter>().InitializeCharacter(allSprites.collectables[i]);
            newSprite.GetComponent<Button>().interactable = allSprites.collectables[i].collected;
            newSprite.transform.SetParent(transform);
        }
    }

    public void NewSelectionMade(CharacterData cData)
    {
        playerConfig.visualData = cData;
        newSelectionEvent.Invoke();
    }
    
}
