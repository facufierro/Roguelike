
using Cinemachine;
using UnityEngine;
using UnityEngine.Tilemaps;
public class FloorGenerator : MonoBehaviour
{
    public RuleTile FloorTile, WallTile;
    public GameObject Player;
    public GameObject[] Enemy;
    public Tilemap FloorTilemap, WallTilemap;

    private Vector2Int MapSize;
    private int RoomCount;
    private Vector2Int[] RoomCenter;

    private void Awake()
    {

        MapSize = new Vector2Int(64, 64);
        RoomCount = Random.Range(6, 10);
        RoomCenter = new Vector2Int[RoomCount];

    }
    void Start()
    {

        CreateRooms();
        CreateCorridors();
        Player = Instantiate(Player, new Vector2(RoomCenter[0].x, RoomCenter[0].y + 0.5f), Quaternion.identity);
        CinemachineVirtualCamera Camera = FindObjectOfType<CinemachineVirtualCamera>();
        Camera.Follow = Player.transform;


    }
    private void Update()
    {

    }
    private void CreateRooms()
    {

        for (int i = 0; i < RoomCount; i++)
        {
            Vector2Int RoomSize = new Vector2Int(Random.Range(8, 12), Random.Range(8, 12));
            Vector2Int Offset = new Vector2Int(Random.Range(RoomSize.x, MapSize.x - RoomSize.x), Random.Range(RoomSize.y, MapSize.y - RoomSize.y));

            for (int y = 0; y < RoomSize.y; y++)
            {
                for (int x = 0; x < RoomSize.x; x++)
                {
                    WallTilemap.SetTile(new Vector3Int(x + Offset.x, y + Offset.y, 1), WallTile);
                    FloorTilemap.SetTile(new Vector3Int(x + Offset.x, y + Offset.y, 1), FloorTile);
                    if (y == RoomSize.y / 2 && x == RoomSize.x / 2)
                    {
                        RoomCenter[i] = new Vector2Int(Offset.x + RoomSize.x / 2, Offset.y + RoomSize.y / 2);
                    }
                }
            }
            if (i > 0)
                SpawnEnemies(i);
        }
    }

    private void CreateCorridors()
    {
        for (int i = 0; i < RoomCenter.Length; i++)
        {
            if (i + 1 < RoomCenter.Length)
            {
                Vector2Int CorridorLength = RoomCenter[i + 1] - RoomCenter[i];


                if (RoomCenter[i + 1].y > RoomCenter[i].y)
                {
                    //Draw East then North
                    if (RoomCenter[i + 1].x > RoomCenter[i].x)
                    {
                        for (int x = 0; x <= Mathf.Abs(CorridorLength.x); x++)
                        {
                            for (int j = -1; j < 3; j++)
                            {
                                WallTilemap.SetTile(new Vector3Int(RoomCenter[i].x + x, RoomCenter[i].y + j, 1), WallTile);
                                FloorTilemap.SetTile(new Vector3Int(RoomCenter[i].x + x, RoomCenter[i].y + j, 1), FloorTile);
                            }
                        }
                        for (int y = 0; y <= Mathf.Abs(CorridorLength.y); y++)
                        {
                            for (int j = -2; j < 1; j++)
                            {
                                WallTilemap.SetTile(new Vector3Int(RoomCenter[i].x + CorridorLength.x + j, RoomCenter[i].y + y, 1), WallTile);
                                FloorTilemap.SetTile(new Vector3Int(RoomCenter[i].x + CorridorLength.x + j, RoomCenter[i].y + y, 1), FloorTile);
                            }
                        }
                    }
                    else//Draw West then North
                    {
                        for (int x = 0; x <= Mathf.Abs(CorridorLength.x); x++)
                        {
                            for (int j = -1; j < 3; j++)
                            {
                                WallTilemap.SetTile(new Vector3Int(RoomCenter[i].x - x, RoomCenter[i].y + j, 1), WallTile);
                                FloorTilemap.SetTile(new Vector3Int(RoomCenter[i].x - x, RoomCenter[i].y + j, 1), FloorTile);
                            }
                        }
                        for (int y = 0; y <= Mathf.Abs(CorridorLength.y); y++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                WallTilemap.SetTile(new Vector3Int(RoomCenter[i].x - Mathf.Abs(CorridorLength.x) + j, RoomCenter[i].y + y, 1), WallTile);
                                FloorTilemap.SetTile(new Vector3Int(RoomCenter[i].x - Mathf.Abs(CorridorLength.x) + j, RoomCenter[i].y + y, 1), FloorTile);
                            }
                        }
                    }


                }
                else
                {
                    if (RoomCenter[i + 1].x > RoomCenter[i].x) //Draw EAST then SOUTH
                    {
                        for (int x = 0; x <= Mathf.Abs(CorridorLength.x); x++)
                        {
                            for (int j = 0; j < 4; j++)
                            {
                                WallTilemap.SetTile(new Vector3Int(RoomCenter[i].x + x, RoomCenter[i].y + j, 1), WallTile);
                                FloorTilemap.SetTile(new Vector3Int(RoomCenter[i].x + x, RoomCenter[i].y + j, 1), FloorTile);
                            }

                        }
                        for (int y = 0; y <= Mathf.Abs(CorridorLength.y); y++)
                        {
                            for (int j = -2; j < 1; j++)
                            {
                                WallTilemap.SetTile(new Vector3Int(RoomCenter[i].x + CorridorLength.x + j, RoomCenter[i].y - y, 1), WallTile);
                                FloorTilemap.SetTile(new Vector3Int(RoomCenter[i].x + CorridorLength.x + j, RoomCenter[i].y - y, 1), FloorTile);
                            }

                        }
                    }
                    else //DRAW WEST THEN SOUTH
                    {
                        for (int x = 0; x <= Mathf.Abs(CorridorLength.x); x++)
                        {
                            for (int j = 0; j < 4; j++)
                            {
                                WallTilemap.SetTile(new Vector3Int(RoomCenter[i].x - x, RoomCenter[i].y + j, 1), WallTile);
                                FloorTilemap.SetTile(new Vector3Int(RoomCenter[i].x - x, RoomCenter[i].y + j, 1), FloorTile);
                            }

                        }

                        for (int y = 0; y <= Mathf.Abs(CorridorLength.y); y++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                WallTilemap.SetTile(new Vector3Int(RoomCenter[i].x - Mathf.Abs(CorridorLength.x) + j, RoomCenter[i].y - y, 1), WallTile);
                                FloorTilemap.SetTile(new Vector3Int(RoomCenter[i].x - Mathf.Abs(CorridorLength.x) + j, RoomCenter[i].y - y, 1), FloorTile);
                            }

                        }
                    }


                }
            }
        }
    }

    private void SpawnEnemies(int RoomIndex)
    {
        int EnemyCount = Random.Range(0, 4);
        Vector2 Offset = new Vector2(Random.Range(1, 3), Random.Range(1, 3));

        for (int i = 0; i < EnemyCount; i++)
        {
            Instantiate(Enemy[0], new Vector2((int)(Random.Range(RoomCenter[RoomIndex].x + Offset.x, RoomCenter[RoomIndex].x - Offset.x)), (int)(Random.Range(RoomCenter[RoomIndex].y + Offset.y, RoomCenter[RoomIndex].y - Offset.y)) + 0.5f), Quaternion.identity);
        }
    }
}