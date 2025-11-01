using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PianoAnimacao : MonoBehaviour
{
    [SerializeField] GameObject lowC;
    [SerializeField] GameObject lowD;
    [SerializeField] GameObject lowE;
    [SerializeField] GameObject lowF;
    [SerializeField] GameObject lowG;
    [SerializeField] GameObject lowA;
    [SerializeField] GameObject lowB;
    [SerializeField] GameObject lowCs;
    [SerializeField] GameObject lowDs;
    [SerializeField] GameObject lowFs;
    [SerializeField] GameObject lowGs;
    [SerializeField] GameObject lowAs;

    [SerializeField] GameObject highC;
    [SerializeField] GameObject highD;
    [SerializeField] GameObject highE;
    [SerializeField] GameObject highF;
    [SerializeField] GameObject highG;
    [SerializeField] GameObject highA;
    [SerializeField] GameObject highB;
    [SerializeField] GameObject highCs;
    [SerializeField] GameObject highDs;
    [SerializeField] GameObject highFs;
    [SerializeField] GameObject highGs;
    [SerializeField] GameObject highAs;

    public Sprite lowCPressed;
    public Sprite lowCNormal;
    public Sprite lowDPressed;
    public Sprite lowDNormal;
    public Sprite lowEPressed;
    public Sprite lowENormal;
    public Sprite lowFPressed;
    public Sprite lowFNormal;
    public Sprite lowGPressed;
    public Sprite lowGNormal;
    public Sprite lowAPressed;
    public Sprite lowANormal;
    public Sprite lowBPressed;
    public Sprite lowBNormal;
    public Sprite lowCsPressed;
    public Sprite lowCsNormal;
    public Sprite lowDsPressed;
    public Sprite lowDsNormal;
    public Sprite lowFsPressed;
    public Sprite lowFsNormal;
    public Sprite lowGsPressed;
    public Sprite lowGsNormal;
    public Sprite lowAsPressed;
    public Sprite lowAsNormal;
    public Sprite highCPressed;
    public Sprite highCNormal;
    public Sprite highDPressed;
    public Sprite highDNormal;
    public Sprite highEPressed;
    public Sprite highENormal;
    public Sprite highFPressed;
    public Sprite highFNormal;
    public Sprite highGPressed;
    public Sprite highGNormal;
    public Sprite highAPressed;
    public Sprite highANormal;
    public Sprite highBPressed;
    public Sprite highBNormal;
    public Sprite highCsPressed;
    public Sprite highCsNormal;
    public Sprite highDsPressed;
    public Sprite highDsNormal;
    public Sprite highFsPressed;
    public Sprite highFsNormal;
    public Sprite highGsPressed;
    public Sprite highGsNormal;
    public Sprite highAsPressed;
    public Sprite highAsNormal;


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            lowC.GetComponent<Image>().sprite = lowCPressed;
        }
        else if (Input.GetKeyUp(KeyCode.Q))
        {
            lowC.GetComponent<Image>().sprite = lowCNormal;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            lowD.GetComponent<Image>().sprite = lowDPressed;
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            lowD.GetComponent<Image>().sprite = lowDNormal;
        }
        //end key
        if (Input.GetKeyDown(KeyCode.E))
        {
            lowE.GetComponent<Image>().sprite = lowEPressed;
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            lowE.GetComponent<Image>().sprite = lowENormal;
        }
        //end key
        if (Input.GetKeyDown(KeyCode.R))
        {
            lowF.GetComponent<Image>().sprite = lowFPressed;
        }
        else if (Input.GetKeyUp(KeyCode.R))
        {
            lowF.GetComponent<Image>().sprite = lowFNormal;
        }
        //end key
        if (Input.GetKeyDown(KeyCode.T))
        {
            lowG.GetComponent<Image>().sprite = lowGPressed;
        }
        else if (Input.GetKeyUp(KeyCode.T))
        {
            lowG.GetComponent<Image>().sprite = lowGNormal;
        }
        //end key
        if (Input.GetKeyDown(KeyCode.Y))
        {
            lowA.GetComponent<Image>().sprite = lowAPressed;
        }
        else if (Input.GetKeyUp(KeyCode.Y))
        {
            lowA.GetComponent<Image>().sprite = lowANormal;
        }
        //end key
        if (Input.GetKeyDown(KeyCode.U))
        {
            lowB.GetComponent<Image>().sprite = lowBPressed;
        }
        else if (Input.GetKeyUp(KeyCode.U))
        {
            lowB.GetComponent<Image>().sprite = lowBNormal;
        }
        //end key
        if (Input.GetKeyDown(KeyCode.I))
        {
            highC.GetComponent<Image>().sprite = highCPressed;
        }
        else if (Input.GetKeyUp(KeyCode.I))
        {
            highC.GetComponent<Image>().sprite = highCNormal;
        }
        //end key
        if (Input.GetKeyDown(KeyCode.O))
        {
            highD.GetComponent<Image>().sprite = highDPressed;
        }
        else if (Input.GetKeyUp(KeyCode.O))
        {
            highD.GetComponent<Image>().sprite = highDNormal;
        }
        //end key
        if (Input.GetKeyDown(KeyCode.P))
        {
            highE.GetComponent<Image>().sprite = highEPressed;
        }
        else if (Input.GetKeyUp(KeyCode.P))
        {
            highE.GetComponent<Image>().sprite = highENormal;
        }
        //end key
        if (Input.GetKeyDown(KeyCode.LeftBracket))
        {
            highF.GetComponent<Image>().sprite = highFPressed;
        }
        else if (Input.GetKeyUp(KeyCode.LeftBracket))
        {
            highF.GetComponent<Image>().sprite = highFNormal;
        }
        //end key
        if (Input.GetKeyDown(KeyCode.RightBracket))
        {
            highG.GetComponent<Image>().sprite = highGPressed;
        }
        else if (Input.GetKeyUp(KeyCode.RightBracket))
        {
            highG.GetComponent<Image>().sprite = highGNormal;
        }
        //end key
        if (Input.GetKeyDown(KeyCode.Return))
        {
            highA.GetComponent<Image>().sprite = highAPressed;
        }
        else if (Input.GetKeyUp(KeyCode.Return))
        {
            highA.GetComponent<Image>().sprite = highANormal;
        }
        if (Input.GetKeyDown(KeyCode.Keypad7))
        {
            highB.GetComponent<Image>().sprite = highBPressed;
        }
        else if (Input.GetKeyUp(KeyCode.Keypad7))
        {
            highB.GetComponent<Image>().sprite = highBNormal;
        }
        //end key
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            lowCs.GetComponent<Image>().sprite = lowCsPressed;
        }
        else if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            lowCs.GetComponent<Image>().sprite = lowCsNormal;
        }
        //end key
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            lowDs.GetComponent<Image>().sprite = lowDsPressed;
        }
        else if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            lowDs.GetComponent<Image>().sprite = lowDsNormal;
        }
        //end key
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            lowFs.GetComponent<Image>().sprite = lowFsPressed;
        }
        else if (Input.GetKeyUp(KeyCode.Alpha5))
        {
            lowFs.GetComponent<Image>().sprite = lowFsNormal;
        }
        //end key
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            lowGs.GetComponent<Image>().sprite = lowGsPressed;
        }
        else if (Input.GetKeyUp(KeyCode.Alpha6))
        {
            lowGs.GetComponent<Image>().sprite = lowGsNormal;
        }
        //end key
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            lowAs.GetComponent<Image>().sprite = lowAsPressed;
        }
        else if (Input.GetKeyUp(KeyCode.Alpha7))
        {
            lowAs.GetComponent<Image>().sprite = lowAsNormal;
        }
        //end key
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            highCs.GetComponent<Image>().sprite = highCsPressed;
        }
        else if (Input.GetKeyUp(KeyCode.Alpha9))
        {
            highCs.GetComponent<Image>().sprite = highCsNormal;
        }
        //end key
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            highDs.GetComponent<Image>().sprite = highDsPressed;
        }
        else if (Input.GetKeyUp(KeyCode.Alpha0))
        {
            highDs.GetComponent<Image>().sprite = highDsNormal;
        }
        //end key
        if (Input.GetKeyDown(KeyCode.Minus))
        {
            highFs.GetComponent<Image>().sprite = highFsPressed;
        }
        else if (Input.GetKeyUp(KeyCode.Minus))
        {
            highFs.GetComponent<Image>().sprite = highFsNormal;
        }
        //end key
        if (Input.GetKeyDown(KeyCode.Equals))
        {
            highGs.GetComponent<Image>().sprite = highGsPressed;
        }
        else if (Input.GetKeyUp(KeyCode.Equals))
        {
            highGs.GetComponent<Image>().sprite = highGsNormal;
        }
        //end key
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            highAs.GetComponent<Image>().sprite = highAsPressed;
        }
        else if (Input.GetKeyUp(KeyCode.Backspace))
        {
            highAs.GetComponent<Image>().sprite = highAsNormal;
        }
    }
}
