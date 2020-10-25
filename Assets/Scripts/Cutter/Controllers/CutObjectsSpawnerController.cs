using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutObjectsSpawnerController : BaseObject
{
    [Header("Base")]
    public FruitsSpawnerSettings spawnSettings;
    public Camera usedCamera;
    private float spawnTimer = 0;
    private float currentTarget = 0;

    public override void init()
    {
        base.init();
        computeNextTimeTarget();

        Physics2D.gravity = spawnSettings.gravity;
    }

    public void spawnNext()
    {
        //pobieramy losowy obiekt z listy do stworzenia
        GameObject obj = spawnSettings.getRandomObject();
        GameObject spawned = Instantiate(obj);
        CutElementObject elem = spawned.GetComponent<CutElementObject>();

        //najpierw ustawiamy pozycje
        Vector2 initForce;
        Vector2 initPos = spawnSettings.getSpawnPositionAndForceForCamera(usedCamera,out initForce);
        //pobieramy startowe force angular
        float initAngularForce = spawnSettings.getRandomSpawnAngularForce();

        initForce.x = initForce.x * Mathf.Abs((spawnSettings.gravity.y / 12.0f));
        initForce.y = initForce.y + Mathf.Abs((spawnSettings.gravity.y / 12.0f)) * initForce.y;
        elem.init();

        //sustawiamy startowe parametry dla obiektu
        elem.setInitParams(initPos, initForce, initAngularForce,spawnSettings);

        //destroy after selected time
        Destroy(spawned, spawnSettings.lifeTime);

    }

    public override void onUpdate(float delta)
    {
        base.onUpdate(delta);

        spawnTimer += Time.deltaTime;
        if(spawnTimer>=currentTarget)
        {
            computeNextTimeTarget();
            spawnNext();
        }

    }

    private void computeNextTimeTarget()
    {
        spawnTimer = 0;
        currentTarget = Random.Range(spawnSettings.nextSpawnMin, spawnSettings.nextSpawnMax);
    }

}
