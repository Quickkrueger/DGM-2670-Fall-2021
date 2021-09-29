using System.Collections;
using UnityEngine;

public class EnvironmentBuilder : MonoBehaviour
{

    public EnviromentData enviromentData;
    
    public Transform ground;
    public Transform groundObject;
    public Transform platform;
    public Transform platformObject;
    public GameObject tilePrefab;
    public GameObject newestTile;

    private Coroutine builderRoutine;

    private void Awake()
    {
        builderRoutine = StartCoroutine(Builder());
    }

    IEnumerator Builder()
    {
        int rand = Random.Range(0, 2);

        int numTiles = Random.Range(5, 10);

        WaitForSeconds wait = new WaitForSeconds((float) numTiles * 0.1f - Time.deltaTime);
        
        StartCoroutine(BuildGround(wait, numTiles));
            
        yield return new WaitForSeconds(0f);
        builderRoutine = null;
    }

    IEnumerator BuildGround(WaitForSeconds wait, int numTiles)
    {
        int randTile;
        for (int i = 0; i < numTiles; i++){

            randTile = Random.Range(0, enviromentData.groundTiles.Length);
            
            if (newestTile == null)
            {
                newestTile = CreateTile(randTile, 0f, enviromentData.groundTiles, ground.position);
            }
            else
            {
                newestTile = CreateTile(randTile, 0f, enviromentData.groundTiles, newestTile.transform.position + Vector3.right);
            }
            
            randTile = Random.Range(0, enviromentData.undergroundTiles.Length);
            
            CreateTile(randTile, 1f, enviromentData.undergroundTiles, newestTile.transform.position + Vector3.right);
            
            randTile = Random.Range(0, enviromentData.undergroundTiles.Length);
            
            CreateTile(randTile, 2f, enviromentData.undergroundTiles, newestTile.transform.position + Vector3.right);
            
            
        }
        yield return wait;

    if (builderRoutine == null)
        {
            builderRoutine = StartCoroutine(Builder());
        }
    }

    GameObject CreateTile(int randTile, float positionCount, TileData[] tileSet, Vector3 referencePosition)
    {
        GameObject newTile = Instantiate(tilePrefab, referencePosition + Vector3.down * positionCount, ground.rotation);
        newTile.GetComponent<EnvironmentTile>().UpdateTile(tileSet[randTile]);
        
        return newTile;
    }

    IEnumerator BuildPlatforms(WaitForSeconds wait)
    {
        
        
        yield return wait;
        if (builderRoutine == null)
        {
            builderRoutine = StartCoroutine(Builder());
        }
    }
}
