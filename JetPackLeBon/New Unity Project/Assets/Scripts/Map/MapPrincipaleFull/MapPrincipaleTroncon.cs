using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPrincipaleTroncon : MonoBehaviour {

    public static int sizeX = 22;
    public static int sizeY = 8;

    MapPrincipaleFallowTile[,] mapPrincipaleFallowTile;

    public Sprite fullGrass;
    public Sprite fullEarth;
    public Sprite empty;


    private void Awake()
    {
        mapPrincipaleFallowTile = new MapPrincipaleFallowTile[sizeX, sizeY];

        for (int LesX = 0; LesX < sizeX; LesX ++)
        {
            for(int LesY = 0; LesY < sizeY; LesY++)
            {
                mapPrincipaleFallowTile[LesX, LesY] = new MapPrincipaleFallowTile(LesX + (int)transform.position.x, LesY + (int)transform.position.y, 0);

                GameObject tileGO = new GameObject("Tile_" + mapPrincipaleFallowTile[LesX,LesY] + "_" + mapPrincipaleFallowTile[LesX, LesY]);
                tileGO.transform.position = new Vector3(mapPrincipaleFallowTile[LesX, LesY].x, mapPrincipaleFallowTile[LesX, LesY].y, mapPrincipaleFallowTile[LesX, LesY].z);
                tileGO.transform.SetParent(this.transform, true);

                SpriteRenderer spriteRenderer = tileGO.AddComponent<SpriteRenderer>();
                spriteRenderer.sprite = fullGrass;
            }
        }
    }

}
