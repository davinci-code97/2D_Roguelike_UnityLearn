using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BoardManager : MonoBehaviour
{
    public class CellData {
        public bool Passable;
    }

    [SerializeField] private Tilemap tilemap;
    [SerializeField] private float boardWidth;
    [SerializeField] private float boardHeight;
    [SerializeField] private Tile[] groundTileArray;
    [SerializeField] private Tile[] wallTileArray;

    private Tile tile;
    private CellData[,] BoardData;

    void Start()
    {
        OnInit();
    }

    
    void Update()
    {
        
    }

    void OnInit() {
        for (int y = 0; y < boardHeight; y++) {
            for (int x = 0; x < boardWidth; x++) {
                if (x == 0 || y == 0 || x == boardWidth - 1 || y == boardHeight - 1) {
                    tile = wallTileArray[Random.Range(0, wallTileArray.Length)];
                    BoardData[x, y].Passable = false;
                }
                else {
                    tile = groundTileArray[Random.Range(0, groundTileArray.Length)];
                    BoardData[x, y].Passable = true;
                }
                tilemap.SetTile(new Vector3Int(x, y, 0), tile);
            }
        }
    }


}
