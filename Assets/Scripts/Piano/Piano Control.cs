using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyControl : MonoBehaviour
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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            lowC.SetActive(false);
            lowC.SetActive(true);
        }
        //end key
        if (Input.GetKeyDown(KeyCode.W))
        {
            lowD.SetActive(false);
            lowD.SetActive(true);
        }
        //end key
        if (Input.GetKeyDown(KeyCode.E))
        {
            lowE.SetActive(false);
            lowE.SetActive(true);
        }
        //end key
        if (Input.GetKeyDown(KeyCode.R))
        {
            lowF.SetActive(false);
            lowF.SetActive(true);
        }
        //end key
        if (Input.GetKeyDown(KeyCode.T))
        {
            lowG.SetActive(false);
            lowG.SetActive(true);
        }
        //end key
        if (Input.GetKeyDown(KeyCode.Y))
        {
            lowA.SetActive(false);
            lowA.SetActive(true);
        }
        //end key
        if (Input.GetKeyDown(KeyCode.U))
        {
            lowB.SetActive(false);
            lowB.SetActive(true);
        }
        //end key
        if (Input.GetKeyDown(KeyCode.I))
        {
            highC.SetActive(false);
            highC.SetActive(true);
        }
        //end key
        if (Input.GetKeyDown(KeyCode.O))
        {
            highD.SetActive(false);
            highD.SetActive(true);
        }
        //end key
        if (Input.GetKeyDown(KeyCode.P))
        {
            highE.SetActive(false);
            highE.SetActive(true);
        }
        //end key
        if (Input.GetKeyDown(KeyCode.LeftBracket))
        {
            highF.SetActive(false);
            highF.SetActive(true);
        }
        //end key
        if (Input.GetKeyDown(KeyCode.RightBracket))
        {
            highG.SetActive(false);
            highG.SetActive(true);
        }
        //end key
        if (Input.GetKeyDown(KeyCode.Return))
        {
            highA.SetActive(false);
            highA.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Keypad7))
        {
            highB.SetActive(false);
            highB.SetActive(true);
        }
        //end key
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            lowCs.SetActive(false);
            lowCs.SetActive(true);
        }
        //end key
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            lowDs.SetActive(false);
            lowDs.SetActive(true);
        }
        //end key
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            lowFs.SetActive(false);
            lowFs.SetActive(true);
        }
        //end key
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            lowGs.SetActive(false);
            lowGs.SetActive(true);
        }
        //end key
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            lowAs.SetActive(false);
            lowAs.SetActive(true);
        }
        //end key
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            highCs.SetActive(false);
            highCs.SetActive(true);
        }
        //end key
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            highDs.SetActive(false);
            highDs.SetActive(true);
        }
        //end key
        if (Input.GetKeyDown(KeyCode.Minus))
        {
            highFs.SetActive(false);
            highFs.SetActive(true);
        }
        //end key
        if (Input.GetKeyDown(KeyCode.Equals))
        {
            highGs.SetActive(false);
            highGs.SetActive(true);
        }
        //end key
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            highAs.SetActive(false);
            highAs.SetActive(true);
        }
        //end key
    }

    public void LowPressC()
    {
        lowC.SetActive(false);
        lowC.SetActive(true);
    }
    public void LowPressD()
    {
        lowD.SetActive(false);
        lowD.SetActive(true);
    }
    public void LowPressE()
    {
        lowE.SetActive(false);
        lowE.SetActive(true);
    }
    public void LowPressF()
    {
        lowF.SetActive(false);
        lowF.SetActive(true);
    }
    public void LowPressG()
    {
        lowG.SetActive(false);
        lowG.SetActive(true);
    }
    public void LowPressA()
    {
        lowA.SetActive(false);
        lowA.SetActive(true);
    }
    public void LowPressB()
    {
        lowB.SetActive(false);
        lowB.SetActive(true);
    }
    public void LowPressCs()
    {
        lowCs.SetActive(false);
        lowCs.SetActive(true);
    }
    public void LowPressDs()
    {
        lowDs.SetActive(false);
        lowDs.SetActive(true);
    }
    public void LowPressFs()
    {
        lowFs.SetActive(false);
        lowFs.SetActive(true);
    }
    public void LowPressGs()
    {
        lowGs.SetActive(false);
        lowGs.SetActive(true);
    }
    public void LowPressAs()
    {
        lowAs.SetActive(false);
        lowAs.SetActive(true);
    }
    public void HighPressC()
    {
        highC.SetActive(false);
        highC.SetActive(true);
    }
    public void HighPressD()
    {
        highD.SetActive(false);
        highD.SetActive(true);
    }
    public void HighPressE()
    {
        highE.SetActive(false);
        highE.SetActive(true);
    }
    public void HighPressF()
    {
        highF.SetActive(false);
        highF.SetActive(true);
    }
    public void HighPressG()
    {
        highG.SetActive(false);
        highG.SetActive(true);
    }
    public void HighPressA()
    {
        highA.SetActive(false);
        highA.SetActive(true);
    }
    public void HighPressB()
    {
        highB.SetActive(false);
        highB.SetActive(true);
    }
    public void HighPressCs()
    {
        highCs.SetActive(false);
        highCs.SetActive(true);
    }
    public void HighPressDs()
    {
        highDs.SetActive(false);
        highDs.SetActive(true);
    }
    public void HighPressFs()
    {
        highFs.SetActive(false);
        highFs.SetActive(true);
    }
    public void HighPressGs()
    {
        highGs.SetActive(false);
        highGs.SetActive(true);
    }
    public void HighPressAs()
    {
        highAs.SetActive(false);
        highAs.SetActive(true);
    }

    public void StartSong()
    {
        StartCoroutine(AutoSong());
    }


    IEnumerator AutoSong()
    {
        yield return new WaitForSeconds(0.3f);
        lowC.SetActive(false);
        lowC.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        lowG.SetActive(false);
        lowG.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        highC.SetActive(false);
        highC.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        highG.SetActive(false);
        highG.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        highG.SetActive(false);
        highG.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        highF.SetActive(false);
        highF.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        highE.SetActive(false);
        highE.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        highD.SetActive(false);
        highD.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        lowD.SetActive(false);
        lowD.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        lowG.SetActive(false);
        lowG.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        highC.SetActive(false);
        highC.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        highD.SetActive(false);
        highD.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        highD.SetActive(false);
        highD.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        highE.SetActive(false);
        highE.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        highF.SetActive(false);
        highF.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        highE.SetActive(false);
        highE.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        lowE.SetActive(false);
        lowE.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        lowA.SetActive(false);
        lowA.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        lowB.SetActive(false);
        lowB.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        highC.SetActive(false);
        highC.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        highD.SetActive(false);
        highD.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        highE.SetActive(false);
        highE.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        highF.SetActive(false);
        highF.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        highE.SetActive(false);
        highE.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        highD.SetActive(false);
        highD.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        highC.SetActive(false);
        highC.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        lowB.SetActive(false);
        lowB.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        highC.SetActive(false);
        highC.SetActive(true);
    }
}
