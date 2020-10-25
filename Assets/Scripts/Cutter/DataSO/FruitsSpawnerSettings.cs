using UnityEngine;
[CreateAssetMenu(menuName = "Cutter/Settings/FruitsSpawnerSettings")]
public class FruitsSpawnerSettings : ScriptableObject
{
    public enum SpawnerType
    {
        STATIC,
        DOWN,
        UP,
        LEFT,
        RIGHT,
        ALL_DIRECTIONS
    }

    [Header("to spawn")]
    public GameObject[] toSpawn;
    [Header("Settings base")]
    public SpawnerType spawnType;
    public ForceMode2D forceMode;

    public float nextSpawnMin = 0.1f;
    public float nextSpawnMax = 1.0f;
    [Header("Forces per direction")]
    public Vector3 forceOnSpawnMin_UP;
    public Vector3 forceOnSpawnMax_UP;
    public Vector3 forceOnSpawnMin_DOWN;
    public Vector3 forceOnSpawnMax_DOWN;
    public Vector3 forceOnSpawnMin_LEFT;
    public Vector3 forceOnSpawnMax_LEFT;
    public Vector3 forceOnSpawnMin_RIGHT;
    public Vector3 forceOnSpawnMax_RIGHT;
    [Header("Angular Force")]
    public float minAngularForce;
    public float maxAngularForce;

    [Header("Settings Special")]
    public Vector2 gravity;
    public float lifeTime = 10;



    public GameObject getRandomObject()
    {
        return toSpawn[Random.Range(0, toSpawn.Length)];
    }

    public Vector2 getSpawnPositionAndForceForCamera(Camera cam, out Vector2 force)
    {
        if (spawnType == SpawnerType.ALL_DIRECTIONS)
        {
            //losujemy typ
            int randVal = Random.Range(0, 5);
            if (randVal == 0)
            {
                force = getRandomSpawnForce(SpawnerType.DOWN);
                return getPosFor(SpawnerType.DOWN, cam);
            }
            else if (randVal == 1)
            {
                force = getRandomSpawnForce(SpawnerType.LEFT);
                return getPosFor(SpawnerType.LEFT, cam);
            }
            else if (randVal == 2)
            {
                force = getRandomSpawnForce(SpawnerType.RIGHT);
                return getPosFor(SpawnerType.RIGHT, cam);
            }
            else
            {
                force = getRandomSpawnForce(SpawnerType.UP);
                return getPosFor(SpawnerType.UP, cam);
            }
        }
        else
        {
            force = getRandomSpawnForce(spawnType);
            return getPosFor(spawnType, cam);
        }
    }

    private Vector3 getPosFor(SpawnerType t, Camera c)
    {
        Vector3 result = Vector3.zero;
        float minX = 0.2f;
        float maxX = 0.8f;
        float minY = 0.3f;
        float maxY = 0.7f;
        switch (t)
        {
            case SpawnerType.DOWN:
                {
                    //pozycja pod ekranem
                    result.x = Random.Range(minX, maxX);
                    result.y = -0.07f;
                    result.z = 0;
                    result = c.ViewportToWorldPoint(result);
                    return result;
                }
            case SpawnerType.UP:
                {
                    //pozycja nad ekranem
                    result.x = Random.Range(minX, maxX);
                    result.y = 1.1f;
                    result.z = 0;
                    result = c.ViewportToWorldPoint(result);
                    return result;
                }
            case SpawnerType.LEFT:
                {
                    //pozycja po lewej
                    result.x = -0.1f;
                    result.y = Random.Range(minY, maxY);
                    result.z = 0;
                    result = c.ViewportToWorldPoint(result);
                    return result;
                }
            case SpawnerType.RIGHT:
                {
                    //pozycja po lewej
                    result.x = 1.1f;
                    result.y = Random.Range(minY, maxY);
                    result.z = 0;
                    result = c.ViewportToWorldPoint(result);
                    return result;
                }
            case SpawnerType.STATIC:
                {
                    //pozycja po lewej
                    result.x = Random.Range(0.1f, 0.9f);
                    result.y = Random.Range(0.1f, 0.9f);
                    result.z = 0;
                    result = c.ViewportToWorldPoint(result);
                    return result;
                }
            default: return result;
        }
    }

    public Vector2 getRandomSpawnForce(SpawnerType type_)
    {
        if(type_ == SpawnerType.DOWN)
        {
            return new Vector3(Random.Range(forceOnSpawnMin_DOWN.x, forceOnSpawnMax_DOWN.x), Random.Range(forceOnSpawnMin_DOWN.y, forceOnSpawnMax_DOWN.y), Random.Range(forceOnSpawnMin_DOWN.z, forceOnSpawnMax_DOWN.z));
        }
        else if(type_ == SpawnerType.LEFT)
        {
            return new Vector3(Random.Range(forceOnSpawnMin_LEFT.x, forceOnSpawnMax_LEFT.x), Random.Range(forceOnSpawnMin_LEFT.y, forceOnSpawnMax_LEFT.y), Random.Range(forceOnSpawnMin_LEFT.z, forceOnSpawnMax_LEFT.z));
        }
        else if(type_ == SpawnerType.RIGHT)
        {
            return new Vector3(Random.Range(forceOnSpawnMin_RIGHT.x, forceOnSpawnMax_RIGHT.x), Random.Range(forceOnSpawnMin_RIGHT.y, forceOnSpawnMax_RIGHT.y), Random.Range(forceOnSpawnMin_RIGHT.z, forceOnSpawnMax_RIGHT.z));
        }
        else if(type_ == SpawnerType.UP)
        {
            return new Vector3(Random.Range(forceOnSpawnMin_UP.x, forceOnSpawnMax_UP.x), Random.Range(forceOnSpawnMin_UP.y, forceOnSpawnMax_UP.y), Random.Range(forceOnSpawnMin_UP.z, forceOnSpawnMax_UP.z));
        }
        return Vector2.zero;
    }

    public float getRandomSpawnAngularForce()
    {
        return Random.Range(minAngularForce, maxAngularForce);
    }


}
