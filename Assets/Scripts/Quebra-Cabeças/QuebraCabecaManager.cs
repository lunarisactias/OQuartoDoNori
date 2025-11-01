using Cinemachine;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class QuebraCabecaManager : MonoBehaviour
{
    [Header("Game Elements")]
    [UnityEngine.Range(2, 10)]
    [SerializeField] private int difficulty = 4;
    [SerializeField] private Transform gameHolder;
    [SerializeField] private Transform piecePrefab;

    [Header("UI Elements")]
    [SerializeField] private List<Texture2D> imageTextures;
    [SerializeField] private Transform levelSelectPanel;
    [SerializeField] private Image levelSelectPrefab;
    [SerializeField] private GameObject playAgainButton;
    [SerializeField] private GameObject backButton;

    private List<Transform> pieces;
    private Vector2Int dimensions;
    private float width, height;

    private Transform draggingPiece = null;
    private Vector3 offset;

    private int piecesCorrect;

    public Camera cam;

    public GameObject QC, quartoSemColisao, quartoComColisao, Nori;
    private string date, playerName;

    float elapsedTime = 0f;

    bool measureTime = false;


    private void Start()
    {
        playerName = GameManager.Instance.playerName;
        foreach (Texture2D texture in imageTextures) 
        {
            Image image = Instantiate(levelSelectPrefab, levelSelectPanel);
            image.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
            image.GetComponent<Button>().onClick.AddListener(delegate { StartGame(texture); });
        }
    }

    private void Update()
    {
        if (QC.activeSelf)
        {
            StartTimer();
        }
        if (!QC.activeSelf)
        {
            StopTimer();
        }
        if (measureTime)
        {
            elapsedTime += Time.unscaledDeltaTime;
        }

        Debug.Log("Tempo no Quebra-Cabeças: " + elapsedTime);

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit)
            {
                draggingPiece = hit.transform;
                offset = draggingPiece.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
                offset += Vector3.back;
            }
        }

        if (draggingPiece && Input.GetMouseButtonUp(0))
        {
            SnapAndDisableIfCorrect();
            draggingPiece.position += Vector3.forward;
            draggingPiece = null;
        }

        if (draggingPiece)
        {
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            newPosition += offset;
            draggingPiece.position = newPosition;
        }
    }

    public void StartGame(Texture2D qbTexture)
    {
        backButton.SetActive(true);
        levelSelectPanel.gameObject.SetActive(false);
        pieces = new List<Transform>();
        dimensions = GetDimensions(qbTexture, difficulty);
        CreateQBPieces(qbTexture);
        Scatter();
        UpdateBorder();
        piecesCorrect = 0;
    }

    Vector2Int GetDimensions(Texture2D qbTexture, int difficulty)
    {
        Vector2Int dimensions = Vector2Int.zero;
        if (qbTexture.width < qbTexture.height)
        {
            dimensions.x = difficulty;
            dimensions.y = (difficulty * qbTexture.height) / qbTexture.width;
        }
        else
        {
            dimensions.x = (difficulty * qbTexture.width) / qbTexture.height;
            dimensions.y = difficulty;
        }

        return dimensions;
    }

    void CreateQBPieces (Texture2D qbTexture)
    {
        height = 1f / dimensions.y;
        float aspect = (float)qbTexture.width / qbTexture.height;
        width = aspect / dimensions.x;

        for (int row = 0; row < dimensions.y; row++)
        {
            for (int col = 0; col < dimensions.x; col++)
            {
                Transform piece = Instantiate(piecePrefab, gameHolder);
                piece.localPosition = new Vector3(
                    (-width * dimensions.x / 2) + (width * col) + (width / 2),
                    (-height * dimensions.y / 2) + (height * row) + (height / 2),
                    -1);
                piece.localScale = new Vector3(width, height, 1f);

                piece.name = $"Peça {(row * dimensions.x) + col}";
                pieces.Add(piece);

                float width1 = 1f / dimensions.x;
                float height1 = 1f / dimensions.y;

                Vector2[] uv = new Vector2[4];
                uv[0] = new Vector2(width1 * col, height1 * row);
                uv[1] = new Vector2(width1 * (col + 1), height1 * row);
                uv[2] = new Vector2(width1 * col, height1 * (row + 1));
                uv[3] = new Vector2(width1 * (col + 1), height1 * (row + 1));

                Mesh mesh = piece.GetComponent<MeshFilter>().mesh;
                mesh.uv = uv;
                piece.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", qbTexture);
            }
        }
    }

    private void Scatter()
    {
        float orthoHeight = Camera.main.orthographicSize;
        float screenAspect = (float)Screen.width / Screen.height;
        float orthoWidth = (screenAspect * orthoHeight);
        float pieceWidth = width * gameHolder.localScale.x;
        float pieceHeight = height * gameHolder.localScale.y;
        orthoHeight -= (pieceHeight + .7f);
        orthoWidth -= (pieceWidth + .7f);

        foreach (Transform piece in pieces)
        {
            float x = UnityEngine.Random.Range(-orthoWidth, orthoWidth);
            float y = UnityEngine.Random.Range(-orthoHeight, orthoHeight);
            piece.position = new Vector3((x + cam.transform.position.x), (y + cam.transform.position.y), -1);
        }
    }

    private void UpdateBorder()
    {
        LineRenderer lineRenderer = gameHolder.GetComponent<LineRenderer>();
        float halfWidth = (width * dimensions.x) / 2f;
        float halfHeight = (height * dimensions.y) / 2f;
        float borderZ = 0f;

        lineRenderer.SetPosition(0, new Vector3(-halfWidth, halfHeight, borderZ));
        lineRenderer.SetPosition(1, new Vector3(halfWidth, halfHeight, borderZ));
        lineRenderer.SetPosition(2, new Vector3(halfWidth, -halfHeight, borderZ));
        lineRenderer.SetPosition(3, new Vector3(-halfWidth, -halfHeight, borderZ));

        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;

        lineRenderer.enabled = true;
    }

    private void SnapAndDisableIfCorrect()
    {
        int pieceIndex = pieces.IndexOf(draggingPiece);
        int col = pieceIndex % dimensions.x;
        int row = pieceIndex / dimensions.x;

        Vector2 targetPosition = new((-width * dimensions.x / 2) + (width * col) + (width / 2),
                                     (-height * dimensions.y / 2) + (height * row) + (height / 2));

        if (Vector2.Distance(draggingPiece.localPosition, targetPosition) < (width / 2))
        {
            draggingPiece.localPosition = targetPosition;
            draggingPiece.GetComponent<BoxCollider2D>().enabled = false;
            piecesCorrect++;
            if (piecesCorrect == pieces.Count)
            {
                playAgainButton.SetActive(true);
            }
        }
    }

    public void RestartGame()
    {
        foreach (Transform piece in pieces)
        {
            Destroy(piece.gameObject);
        }
        pieces.Clear();
        gameHolder.GetComponent<LineRenderer>().enabled = false;
        playAgainButton.SetActive(false);
        levelSelectPanel.gameObject.SetActive(true);
        backButton.SetActive(false);
    }
    public void ExitGame()
    {
        if (pieces != null)
        {
            foreach (Transform piece in pieces)
            {
                Destroy(piece.gameObject);
            }
            pieces.Clear();
        }
        gameHolder.GetComponent<LineRenderer>().enabled = false;
        playAgainButton.SetActive(false);
        levelSelectPanel.gameObject.SetActive(true);
        quartoComColisao.SetActive(true);
        quartoSemColisao.SetActive(false);
        Nori.GetComponent<Collider2D>().enabled = true;
        Nori.GetComponent<Player>().moveSpeed = 2;
        Nori.GetComponent<Animator>().enabled = true;
        StopTimer();
        QC.SetActive(false);
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
        Directory.CreateDirectory(Application.persistentDataPath + "\\Quebra-Cabeças");
        int elapsedTimeInt = (int)elapsedTime;
        string elapsedTimeString = "Tempo no quebra-cabeças: " + elapsedTimeInt.ToString() + " segundos.";
        File.WriteAllText(Application.persistentDataPath + "\\Quebra-Cabeças\\" + playerName + " " + GameManager.Instance.date + ".txt", elapsedTimeString);
    }
}

