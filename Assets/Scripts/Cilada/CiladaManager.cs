using UnityEngine;
using System.IO;

public class CiladaManager : MonoBehaviour
{
    [Header("Encaixes e pe�as")]
    public GameObject encaixesParent;
    public GameObject pieceParent;
    [SerializeField] private GameObject[] encaixes;
    [SerializeField] private GameObject[] pieces;

    [Header("Prefab das pe�as")]
    [SerializeField]
    public GameObject piecePrefabA;
    public GameObject piecePrefabB;
    public GameObject piecePrefabC;
    public GameObject piecePrefabD;
    public GameObject piecePrefabE;
    public GameObject piecePrefabF;
    public GameObject piecePrefabG;
    public GameObject piecePrefabH;
    public GameObject piecePrefabI;
    public GameObject piecePrefabJ;
    public GameObject piecePrefabK;
    public GameObject piecePrefabL;
    public GameObject piecePrefabM;
    public GameObject piecePrefabN;

    [Header("UI")]
    public GameObject winPanel;

    private Transform draggingPiece = null;
    private Vector3 offset;
    bool measureTime = false;
    float elapsedTime = 0f;
    public GameObject CL;
    private string playerName;

    public static CiladaManager Instance { get; private set; }

    private bool isRotating = false;
    private float targetRotation = 0f;
    private float rotationSpeed = 480f;

    private void Start()
    {
        playerName = GameManager.Instance.playerName;

        ResetPieces();

        encaixes = new GameObject[encaixesParent.transform.childCount];
        for (int i = 0; i < encaixesParent.transform.childCount; i++)
        {
            encaixes[i] = encaixesParent.transform.GetChild(i).gameObject;
        }

    }

    private void OnEnable()
    {
        Instance = this;
    }
    private void Update()
    {
        if (CL.activeSelf)
        {
            StartTimer();
        }
        if (!CL.activeSelf)
        {
            StopTimer();
        }
        if (measureTime)
        {
            elapsedTime += Time.unscaledDeltaTime;
        }

        Debug.Log("Tempo no Cilada: " + elapsedTime);
        GrabPiece();
        Rotate();
        Snap();
        AnimateRotation();
        DisablePiecesCollision();
    }

    public void GrabPiece()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit)
            {
                Debug.Log("Hit");
                draggingPiece = hit.transform;
                offset = draggingPiece.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
                offset += Vector3.back;
                isRotating = false;

                foreach (SpriteRenderer sr in draggingPiece.GetComponentsInChildren<SpriteRenderer>())
                {
                    sr.sortingOrder = 100;
                }
            }
        }

        if (draggingPiece && !isRotating)
        {
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            newPosition += offset;
            draggingPiece.position = newPosition;
        }

        if (draggingPiece != null && Input.GetMouseButtonUp(0))
        {
            foreach (SpriteRenderer sr in draggingPiece.GetComponentsInChildren<SpriteRenderer>())
            {
                sr.sortingOrder = 5;
            }
        }
    }
    public void Rotate()
    {
        if (draggingPiece && !isRotating)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(1))
            {
                targetRotation = draggingPiece.eulerAngles.z + 90f;
                isRotating = true;
            }
        }
    }

    private void AnimateRotation()
    {
        if (draggingPiece && isRotating)
        {
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            newPosition += offset;
            draggingPiece.position = newPosition;

            float currentZ = draggingPiece.eulerAngles.z;
            float newZ = Mathf.MoveTowardsAngle(currentZ, targetRotation, rotationSpeed * Time.deltaTime);
            draggingPiece.rotation = Quaternion.Euler(0, 0, newZ);

            if (Mathf.Abs(Mathf.DeltaAngle(newZ, targetRotation)) < 0.1f)
            {
                draggingPiece.rotation = Quaternion.Euler(0, 0, targetRotation);
                isRotating = false;
            }
        }
    }

    public void Snap()
    {
        if (draggingPiece == null || isRotating)
            return;

        if (Input.GetMouseButtonUp(0))
        {
            float snapDistance = 0.5f;
            bool allChildrenCanSnap = true;
            GameObject[] encaixesOcupados = new GameObject[encaixes.Length];

            for (int i = 0; i < draggingPiece.childCount; i++)
            {
                Transform pieceChild = draggingPiece.GetChild(i);
                bool childCanSnap = false;

                for (int j = 0; j < encaixes.Length; j++)
                {
                    GameObject encaixe = encaixes[j];
                    if (encaixe == null) continue;
                    float dist = Vector2.Distance(pieceChild.position, encaixe.transform.position);

                    bool encaixeOcupado = false;
                    foreach (GameObject p in pieces)
                    {
                        if (p == null) continue;
                        for (int k = 0; k < p.transform.childCount; k++)
                        {
                            Transform otherChild = p.transform.GetChild(k);
                            if (otherChild == pieceChild) continue;
                            if (Vector2.Distance(otherChild.position, encaixe.transform.position) < 0.01f)
                            {
                                encaixeOcupado = true;
                                break;
                            }
                        }
                        if (encaixeOcupado) break;
                    }

                    if (pieceChild.tag == encaixe.tag && dist <= snapDistance && !encaixeOcupado)
                    {
                        childCanSnap = true;
                        encaixesOcupados[j] = pieceChild.gameObject;
                        break;
                    }
                }

                if (!childCanSnap)
                {
                    allChildrenCanSnap = false;
                    break;
                }
            }

            if (allChildrenCanSnap)
            {
                for (int i = 0; i < draggingPiece.childCount; i++)
                {
                    Transform pieceChild = draggingPiece.GetChild(i);

                    for (int j = 0; j < encaixes.Length; j++)
                    {
                        GameObject encaixe = encaixes[j];
                        if (encaixe == null) continue;
                        float dist = Vector2.Distance(pieceChild.position, encaixe.transform.position);

                        if (pieceChild.tag == encaixe.tag && dist <= snapDistance && encaixesOcupados[j] == pieceChild.gameObject)
                        {
                            pieceChild.position = encaixe.transform.position;
                            break;
                        }
                    }
                }

                if (draggingPiece.childCount > 0)
                {
                    Vector3 center = Vector3.zero;
                    for (int i = 0; i < draggingPiece.childCount; i++)
                    {
                        center += draggingPiece.GetChild(i).position;
                    }
                    center /= draggingPiece.childCount;

                    Vector3 parentOffset = center - draggingPiece.position;
                    draggingPiece.position = center;

                    for (int i = 0; i < draggingPiece.childCount; i++)
                    {
                        draggingPiece.GetChild(i).position -= parentOffset;
                    }
                }
                draggingPiece = null;
            }
            else
            {
                if (draggingPiece != null)
                {
                    Vector3 pos = draggingPiece.position;
                    pos.z = 0f;
                    draggingPiece.position = pos;
                }
                draggingPiece = null;
            }
        }
    }
    private void DisablePiecesCollision()
    {
        if (pieces == null || pieces.Length == 0)
            return;

        bool allSnapped = true;

        foreach (GameObject piece in pieces)
        {
            if (piece == null) continue;

            for (int i = 0; i < piece.transform.childCount; i++)
            {
                Transform pieceChild = piece.transform.GetChild(i);
                bool isSnapped = false;

                foreach (GameObject encaixe in encaixes)
                {
                    if (encaixe == null) continue;

                    if (Vector2.Distance(pieceChild.position, encaixe.transform.position) < 0.01f &&
                        pieceChild.tag == encaixe.tag)
                    {
                        isSnapped = true;
                        break;
                    }
                }

                if (!isSnapped)
                {
                    allSnapped = false;
                    break;
                }
            }

            if (!allSnapped)
                break;
        }

        if (allSnapped && pieces != null && pieces.Length > 0)
        {
            foreach (GameObject piece in pieces)
            {
                if (piece == null) continue;

                Collider2D[] colliders = piece.GetComponentsInChildren<Collider2D>();
                foreach (Collider2D collider in colliders)
                {
                    collider.enabled = false;
                }
            }

            if (winPanel != null)
            {
                winPanel.SetActive(true);
            }
        }
    }
    public void ResetPieces()
    {
        foreach (Transform child in pieceParent.transform)
        {
            Destroy(child.gameObject);
        }
        pieces = new GameObject[0];
    }

    public void Game1()
    {
        ResetPieces();
        SpawnPieces(new (GameObject, int)[]
        {
            (piecePrefabA, 2),
            (piecePrefabB, 1),
            (piecePrefabC, 1),
            (piecePrefabD, 2),
            (piecePrefabE, 1),
            (piecePrefabF, 1),
            (piecePrefabG, 1),
            (piecePrefabI, 1),
            (piecePrefabK, 1),
            (piecePrefabN, 1)
        });
    }


    public void Game2()
    {
        ResetPieces();
        SpawnPieces(new (GameObject, int)[]
        {
            (piecePrefabA, 1),
            (piecePrefabB, 2),
            (piecePrefabC, 1),
            (piecePrefabD, 1),
            (piecePrefabE, 1),
            (piecePrefabF, 2),
            (piecePrefabI, 1),
            (piecePrefabJ, 1),
            (piecePrefabK, 1),
            (piecePrefabM, 1)
        });
    }

    public void Game3()
    {
        ResetPieces();
        SpawnPieces(new (GameObject, int)[]
        {
            (piecePrefabA, 1),
            (piecePrefabB, 3),
            (piecePrefabC, 2),
            (piecePrefabD, 2),
            (piecePrefabE, 1),
            (piecePrefabF, 2),
            (piecePrefabL, 1),
            (piecePrefabN, 1)
        });
    }

    public void Game4()
    {
        ResetPieces();
        SpawnPieces(new (GameObject, int)[]
        {
            (piecePrefabA, 2),
            (piecePrefabB, 1),
            (piecePrefabC, 1),
            (piecePrefabD, 1),
            (piecePrefabE, 1),
            (piecePrefabF, 2),
            (piecePrefabG, 1),
            (piecePrefabJ, 1),
            (piecePrefabM, 1),
            (piecePrefabN, 1)
        });
    }

    public void Game5()
    {
        ResetPieces();
        SpawnPieces(new (GameObject, int)[]
        {
            (piecePrefabA, 2),
            (piecePrefabB, 2),
            (piecePrefabC, 2),
            (piecePrefabD, 1),
            (piecePrefabF, 1),
            (piecePrefabG, 1),
            (piecePrefabJ, 1),
            (piecePrefabL, 1),
            (piecePrefabN, 1)
        });
    }

    public void Game6()
    {
        ResetPieces();
        SpawnPieces(new (GameObject, int)[]
        {
            (piecePrefabA, 2),
            (piecePrefabB, 2),
            (piecePrefabC, 3),
            (piecePrefabD, 1),
            (piecePrefabE, 1),
            (piecePrefabF, 2),
            (piecePrefabI, 1),
            (piecePrefabJ, 1)
        });
    }

    public void Game7()
    {
        ResetPieces();
        SpawnPieces(new (GameObject, int)[]
        {
            (piecePrefabA, 3),
            (piecePrefabB, 1),
            (piecePrefabC, 2),
            (piecePrefabD, 1),
            (piecePrefabE, 2),
            (piecePrefabF, 2),
            (piecePrefabH, 1),
            (piecePrefabJ, 1)
        });
    }

    public void Game8()
    {
        ResetPieces();
        SpawnPieces(new (GameObject, int)[]
        {
            (piecePrefabA, 3),
            (piecePrefabB, 3),
            (piecePrefabC, 3),
            (piecePrefabD, 1),
            (piecePrefabF, 1),
            (piecePrefabG, 1),
            (piecePrefabH, 1)
        });
    }

    public void Game9()
    {
        ResetPieces();
        SpawnPieces(new (GameObject, int)[]
        {
            (piecePrefabA, 4),
            (piecePrefabB, 1),
            (piecePrefabC, 2),
            (piecePrefabD, 1),
            (piecePrefabE, 2),
            (piecePrefabF, 1),
            (piecePrefabH, 1),
            (piecePrefabM, 1)
        });
    }

    public void Game10()
    {
        ResetPieces();
        SpawnPieces(new (GameObject, int)[]
        {
            (piecePrefabB, 3),
            (piecePrefabD, 2),
            (piecePrefabE, 1),
            (piecePrefabF, 2),
            (piecePrefabK, 1),
            (piecePrefabL, 1),
            (piecePrefabM, 1),
            (piecePrefabN, 1)
        });
    }

    private void SpawnPieces((GameObject prefab, int count)[] pieceConfigs)
    {
        float spacing = 1.5f;
        int totalPieces = 0;
        foreach (var (_, count) in pieceConfigs) totalPieces += count;

        int rowCount = (totalPieces + 1) / 2;
        int topRowCount = totalPieces / 2;
        int bottomRowCount = totalPieces - topRowCount;

        Vector3 camPos = Camera.main.transform.position;
        float startXTop = camPos.x + (-((topRowCount - 1) * spacing) / 2f);
        float startXBottom = camPos.x + (-((bottomRowCount - 1) * spacing) / 2f);
        float yTop = camPos.y + 2.4f;
        float yBottom = camPos.y - 2.4f;

        int topPlaced = 0;
        int bottomPlaced = 0;

        Vector2[] spawnPositions = new Vector2[totalPieces];
        int posIndex = 0;
        foreach (var (prefab, count) in pieceConfigs)
        {
            for (int i = 0; i < count; i++)
            {
                Vector2 pos;
                if (topPlaced < topRowCount)
                {
                    pos = new Vector2(startXTop + spacing * topPlaced, yTop);
                    topPlaced++;
                }
                else
                {
                    pos = new Vector2(startXBottom + spacing * bottomPlaced, yBottom);
                    bottomPlaced++;
                }
                spawnPositions[posIndex++] = pos;
            }
        }

        int spawnIdx = 0;
        foreach (var (prefab, count) in pieceConfigs)
        {
            for (int i = 0; i < count; i++)
            {
                Instantiate(prefab, spawnPositions[spawnIdx], Quaternion.identity, pieceParent.transform);
                spawnIdx++;
            }
        }

        pieces = new GameObject[pieceParent.transform.childCount];
        for (int i = 0; i < pieceParent.transform.childCount; i++)
        {
            pieces[i] = pieceParent.transform.GetChild(i).gameObject;
        }

    }

    private void OnDestroy()
    {
        WriteStuffToFile();
        ResetTimer();
    }
    void StartTimer()
    {
        measureTime = true;
    }

    void StopTimer()
    {
        measureTime = false;
    }

    void ResetTimer()
    {
        elapsedTime = 0f;
    }
    private void WriteStuffToFile()
    {
        Directory.CreateDirectory(Application.persistentDataPath + "\\Cilada");
        int elapsedTimeInt = (int)elapsedTime;
        string elapsedTimeString = "Tempo no Cilada: " + elapsedTimeInt.ToString() + " segundos.";
        File.WriteAllText(Application.persistentDataPath + "\\Cilada\\" + playerName + " " + GameManager.Instance.date + ".txt", elapsedTimeString);
    }
}
