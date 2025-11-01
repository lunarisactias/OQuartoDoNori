using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public GameObject Color1;
    public GameObject Color2;
    public GameObject Color3;
    public GameObject Color4;
    public GameObject Color5;
    public GameObject Color6;
    public GameObject Color7;
    public GameObject Color8;
    public GameObject Color9;
    public GameObject Color10;
    public GameObject Color11;
    public GameObject Color12;
    public GameObject Color13;
    public GameObject Color14;
    public GameObject Color15;
    public GameObject Color16;
    public GameObject Color17;
    public GameObject Color18;
    public GameObject Eraser;
    int count;
    GameObject Line;
    LineRenderer Renderer;

    LineGenerator lineGenerator;

    private void Start()
    {
        lineGenerator = FindAnyObjectByType<LineGenerator>();
        count = 5;
        lineGenerator.linePrefab.GetComponent<LineRenderer>().sortingOrder = count;
    }
    private void Update()
    {
        
    }

    public void ChangeToColor1()
    {
        count++;
        Line = Color1;
        Renderer = Line.GetComponent<LineRenderer>();
        Renderer.sortingOrder = count;
        
        lineGenerator.linePrefab = Color1;
        
    }
    public void ChangeToColor2()
    {
        count++;
        Line = Color2;
        Renderer = Line.GetComponent<LineRenderer>();
        Renderer.sortingOrder = count;

        lineGenerator.linePrefab = Color2;
    }
    public void ChangeToColor3()
    {
        count++;
        Line = Color3;
        Renderer = Line.GetComponent<LineRenderer>();
        Renderer.sortingOrder = count;
        lineGenerator.linePrefab = Color3;
    }
    public void ChangeToColor4()
    {
        count++;
        Line = Color4;
        Renderer = Line.GetComponent<LineRenderer>();
        Renderer.sortingOrder = count;
        lineGenerator.linePrefab = Color4;
        Renderer.sortingOrder = count;  
    }
    public void ChangeToColor5()
    {
        count++;
        Line = Color5;
        Renderer = Line.GetComponent<LineRenderer>();
        Renderer.sortingOrder = count;
        lineGenerator.linePrefab = Color5;
        Renderer.sortingOrder = count;
    }
    public void ChangeToColor6()
    {
        count++;
        Line = Color6;
        Renderer = Line.GetComponent<LineRenderer>();
        Renderer.sortingOrder = count;
        lineGenerator.linePrefab = Color6;
        Renderer.sortingOrder = count;
    }
    public void ChangeToColor7()
    {
        count++;
        Line = Color7;
        Renderer = Line.GetComponent<LineRenderer>();
        Renderer.sortingOrder = count;
        lineGenerator.linePrefab = Color7;
    }
    public void ChangeToColor8()
    {
        count++;
        Line = Color8;
        Renderer = Line.GetComponent<LineRenderer>();
        Renderer.sortingOrder = count;
        lineGenerator.linePrefab = Color8;
    }
    public void ChangeToColor9()
    {
        count++;
        Line = Color9;
        Renderer = Line.GetComponent<LineRenderer>();
        Renderer.sortingOrder = count;
        lineGenerator.linePrefab = Color9;
    }
    public void ChangeToColor10()
    {
        count++;
        Line = Color10;
        Renderer = Line.GetComponent<LineRenderer>();
        Renderer.sortingOrder = count;
        lineGenerator.linePrefab = Color10;
    }
    public void ChangeToColor11()
    {
        count++;
        Line = Color11;
        Renderer = Line.GetComponent<LineRenderer>();
        Renderer.sortingOrder = count;
        lineGenerator.linePrefab = Color11;
    }
    public void ChangeToColor12()
    {
        count++;
        Line = Color12;
        Renderer = Line.GetComponent<LineRenderer>();
        Renderer.sortingOrder = count;
        lineGenerator.linePrefab = Color12;
    }
    public void ChangeToColor13()
    {
        count++;
        Line = Color13;
        Renderer = Line.GetComponent<LineRenderer>();
        Renderer.sortingOrder = count;
        lineGenerator.linePrefab = Color13;
    }
    public void ChangeToColor14()
    {
        count++;
        Line = Color14;
        Renderer = Line.GetComponent<LineRenderer>();
        Renderer.sortingOrder = count;
        lineGenerator.linePrefab = Color14;
    }
    public void ChangeToColor15()
    {
        count++;
        Line = Color15;
        Renderer = Line.GetComponent<LineRenderer>();
        Renderer.sortingOrder = count;
        lineGenerator.linePrefab = Color15;
    }
    public void ChangeToColor16()
    {
        count++;
        Line = Color16;
        Renderer = Line.GetComponent<LineRenderer>();
        Renderer.sortingOrder = count;
        lineGenerator.linePrefab = Color16;
    }
    public void ChangeToColor17()
    {
        count++;
        Line = Color17;
        Renderer = Line.GetComponent<LineRenderer>();
        Renderer.sortingOrder = count;
        lineGenerator.linePrefab = Color17;
    }
    public void ChangeToColor18()
    {
        count++;
        Line = Color18;
        Renderer = Line.GetComponent<LineRenderer>();
        Renderer.sortingOrder = count;
        lineGenerator.linePrefab = Color18;
    }
    public void ChangeToEraser()
    {
        count++;
        Line = Eraser;
        Renderer = Line.GetComponent<LineRenderer>();
        Renderer.sortingOrder = count;
        lineGenerator.linePrefab = Eraser;
    }
}
