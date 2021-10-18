using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
            newSprite.transform.parent = transform;
        }
    }

    public void NewSelectionMade(CharacterData cData)
    {
        playerConfig.visualData = cData;
        newSelectionEvent.Invoke();
    }
    
}
