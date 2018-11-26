using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour {

    private float screenWidthInPoints;


    public GameObject[] availableObjects;
    public List<GameObject> objects;

    public float objectsMinDistance = 5.0f;
    public float objectsMaxDistance = 10.0f;

    public float objectsMinY = -1.4f;
    public float objectsMaxY = 1.4f;

    public float objectsMinRotation = -45.0f;
    public float objectsMaxRotation = 45.0f;


    // Use this for initialization
    void Start () {
        float height = 2.0f * Camera.main.orthographicSize;
        screenWidthInPoints = height * Camera.main.aspect;

        StartCoroutine(GeneratorCheck());

    }

    // Update is called once per frame
    void Update () {
		
	}


    void AddObject(float lastObjectX)
    {

        int randomIndex = Random.Range(0, availableObjects.Length);
        GameObject obj = (GameObject)Instantiate(availableObjects[randomIndex]);
        float objectPositionX = lastObjectX + Random.Range(objectsMinDistance, objectsMaxDistance);
        float randomY = Random.Range(objectsMinY, objectsMaxY);
        obj.transform.position = new Vector3(objectPositionX, randomY, 0);
        //if (obj.tag != "Trap" && obj.tag != "TrapCeiling")
        //{
            float rotation = Random.Range(objectsMinRotation, objectsMaxRotation);
            obj.transform.rotation = Quaternion.Euler(Vector3.forward * rotation);
        //}
        objects.Add(obj);
    }



    void GenerateObjectsIfRequired()
    {
        float playerX = transform.position.x;
        float removeObjectsX = playerX - screenWidthInPoints;
        float addObjectX = playerX  + screenWidthInPoints;
        float farthestObjectX = 25;
        List<GameObject> objectsToRemove = new List<GameObject>();
        foreach (var obj in objects)
        {
            float objX = obj.transform.position.x;
            farthestObjectX = Mathf.Max(farthestObjectX, objX);
            if (objX < removeObjectsX)
            {
                objectsToRemove.Add(obj);
            }
            //if (obj.tag == "TrapCeiling")
            //{
            //    obj.transform.position = new Vector3(objX, 4.7f);
            //}
        }
        foreach (var obj in objectsToRemove)
        {
            objects.Remove(obj);
            Destroy(obj);
        }
        if (farthestObjectX < addObjectX)
        {
            AddObject(farthestObjectX);
        }
    }


    private IEnumerator GeneratorCheck()
    {
        while (true)
        {

            GenerateObjectsIfRequired();
            yield return new WaitForSeconds(0.25f);
        }
    }


}
