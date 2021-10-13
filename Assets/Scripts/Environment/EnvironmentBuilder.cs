using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnvironmentBuilder : MonoBehaviour
{

    public EnviromentData enviromentData;
    
    public Transform ground;
    public Transform groundObject;
    public Transform platform;
    public Transform platformObject;
    public GameObject tilePrefab;
    public GameObject newestTile;

    public float buildSpeed = 0.1f;

    private Coroutine builderRoutine;

    public void StartBuilding()
    {
        builderRoutine = StartCoroutine(Builder());
    }

    IEnumerator Builder()
    {
        int rand = Random.Range(0, 2);

        int numTiles;

        WaitForSeconds wait;

        if (rand == 0)
        {
            numTiles = Random.Range(5, 10);
            wait = new WaitForSeconds((float) numTiles * buildSpeed - Time.deltaTime / 2);
            StartCoroutine(BuildGround(wait, numTiles));
        }
        else if (rand == 1)
        {
            numTiles = Random.Range(3, 6);
            wait = new WaitForSeconds((float) numTiles * buildSpeed - Time.deltaTime / 2);
            StartCoroutine(BuildPlatforms(wait, numTiles));
        }

        yield return new WaitForSeconds(0f);
        builderRoutine = null;
    }

    IEnumerator BuildGround(WaitForSeconds wait, int numTiles)
    {
        int randTile;
        int randDist;
        for (int i = 0; i < numTiles; i++){

            randTile = Random.Range(0, enviromentData.groundTiles.Length);
            
            if (newestTile == null)
            {
                newestTile = CreateTile(randTile, 0f, enviromentData.groundTiles, ground.position);
            }
            else if (i == 0)
            {
                randDist = Random.Range(5, 8);
                newestTile = CreateTile(randTile, 0f, enviromentData.groundTiles, new Vector3(newestTile.transform.position.x, ground.position.y, 0f)  + Vector3.right * (float)randDist);
            }
            else
            {
                newestTile = CreateTile(randTile, 0f, enviromentData.groundTiles, newestTile.transform.position + Vector3.right);
            }
            
            randTile = Random.Range(0, enviromentData.undergroundTiles.Length);
            
            CreateTile(randTile, 1f, enviromentData.undergroundTiles, newestTile.transform.position);
            
            randTile = Random.Range(0, enviromentData.undergroundTiles.Length);
            
            CreateTile(randTile, 2f, enviromentData.undergroundTiles, newestTile.transform.position);

            randTile = Random.Range(0, enviromentData.undergroundTiles.Length);

            CreateTile(randTile, 3f, enviromentData.undergroundTiles, newestTile.transform.position);


        }
        yield return wait;

    if (builderRoutine == null)
        {
            builderRoutine = StartCoroutine(Builder());
        }
    }

    GameObject CreateTile(int randTile, float positionCount, TileData[] tileSet, Vector3 referencePosition)
    {
        GameObject newTile = Instantiate(tilePrefab, referencePosition + Vector3.down * positionCount, Quaternion.identity);
        newTile.GetComponent<EnvironmentTile>().UpdateTile(tileSet[randTile]);
        
        return newTile;
    }

    IEnumerator BuildPlatforms(WaitForSeconds wait, int numTiles)
    {
        int randTile;
        int randDist;
        for (int i = 0; i < numTiles; i++){

            randTile = Random.Range(0, enviromentData.groundTiles.Length);
            
            if (newestTile == null)
            {
                newestTile = CreateTile(randTile, 0f, enviromentData.groundTiles, platform.position);
            }
            else if (i == 0)
            {
                randDist = Random.Range(1, 8);

                if (newestTile.transform.position.y - platform.position.y <= 2f)
                {
                    newestTile = CreateTile(randTile, 0f, enviromentData.groundTiles, newestTile.transform.position + Vector3.up * 2f + Vector3.right * (float)randDist);
                }
                else
                {
                    newestTile = CreateTile(randTile, 0f, enviromentData.groundTiles, newestTile.transform.position + Vector3.up * -2f + Vector3.right * (float)randDist);
                }
            }
            else
            {
                newestTile = CreateTile(randTile, 0f, enviromentData.groundTiles, newestTile.transform.position + Vector3.right);
            }


        }

        yield return wait;
        if (builderRoutine == null)
        {
            builderRoutine = StartCoroutine(Builder());
        }
    }
}
