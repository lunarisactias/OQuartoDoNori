using TMPro.Examples;
using UnityEngine;
using Cinemachine;
using Unity.VisualScripting;

public class LineGenerator : MonoBehaviour
{
    public GameObject linePrefab;
    public Canvas canvasCaderno;

    public Line activeLine;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (canvasCaderno != null) 
            {
                GameObject newLine = Instantiate(linePrefab, canvasCaderno.transform);
                activeLine = newLine.GetComponent<Line>();
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            activeLine = null;
        }

        if (activeLine != null)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos = Camera.main.transform.InverseTransformPoint(mousePos) * .875f;
            mousePos.x += .875f;
            mousePos.y -= 1.68f;
            activeLine.UpdateLine(mousePos);   
        }
    }

    private void OnDisable()
    {
        activeLine = null;
    }
}
