using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPrincipaleCreator : MonoBehaviour {

    public float renderDist;

    public GameObject tronconGO;

    Dictionary<Vector2, MapPrincipaleTroncon> mapTroncon;


    private void Awake()
    {
        mapTroncon = new Dictionary< Vector2, MapPrincipaleTroncon > ();
    }

    // Use this for initialization
    void Start () {

        FindTronconToLoad();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FindTronconToLoad()
    {
        int xPos = (int)transform.position.x;
        int yPos = (int)transform.position.y;

        for (int LesX = xPos - MapPrincipaleTroncon.sizeX; LesX < xPos + (2 * MapPrincipaleTroncon.sizeX); LesX+=MapPrincipaleTroncon.sizeX)
        {
            for (int LesY = yPos - MapPrincipaleTroncon.sizeY; LesY < yPos + (2 * MapPrincipaleTroncon.sizeY); LesY += MapPrincipaleTroncon.sizeY)
            {

                MakeTronconAt(LesX, LesY);
            }
        }
    }

    void MakeTronconAt(int x, int y)
    {
        x = Mathf.FloorToInt(x / (float)MapPrincipaleTroncon.sizeX) * MapPrincipaleTroncon.sizeX;
        y = Mathf.FloorToInt(y / (float)MapPrincipaleTroncon.sizeY) * MapPrincipaleTroncon.sizeY;

        if(mapTroncon.ContainsKey(new Vector2(x,y)) == false)
        {
            GameObject go = Instantiate(tronconGO, new Vector3(x, y, 0f), Quaternion.identity);
            mapTroncon.Add(new Vector2(x, y), go.GetComponent<MapPrincipaleTroncon>());
        }

    }

    void DeleteTronconAt(int x, int y)
    {
        List<MapPrincipaleTroncon> deleteTroncon = new List<MapPrincipaleTroncon>(mapTroncon.Values);

        for (int LesX = 0; LesX < deleteTroncon.Count; LesX++)
        {
            float distance = Vector3.Distance(transform.position, deleteTroncon[LesX].transform.position);
            //rendu a 22:12 dans la video : https://www.youtube.com/watch?v=AitcC7J2WpY
        }

    }


}
