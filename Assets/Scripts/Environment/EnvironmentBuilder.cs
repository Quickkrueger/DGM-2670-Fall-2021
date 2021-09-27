using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentBuilder : MonoBehaviour
{
    public Transform ground;
    public Transform groundObject;
    public Transform platform;
    public Transform platformObject;
    public GameObject tilePrefab;

    private Coroutine builderRoutine;

    private void Start()
    {
        builderRoutine = StartCoroutine(Builder(new WaitForSeconds(0.1f)));
    }

    IEnumerator Builder(WaitForSeconds wait)
    {
        int rand = Random.Range(0, 2);

            StartCoroutine(BuildGround(wait));
            
        yield return new WaitForSeconds(0f);
        builderRoutine = null;
    }

    IEnumerator BuildGround(WaitForSeconds wait)
    {
        for (int i = 0; i < 10; i++){
        
        Instantiate(tilePrefab, ground.position, ground.rotation);

        yield return wait;
        }

    if (builderRoutine == null)
        {
            builderRoutine = StartCoroutine(Builder(wait));
        }
    }

    IEnumerator BuildPlatforms(WaitForSeconds wait)
    {
        
        
        yield return wait;
        if (builderRoutine == null)
        {
            builderRoutine = StartCoroutine(Builder(wait));
        }
    }
}
