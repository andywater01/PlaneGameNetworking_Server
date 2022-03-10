using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneData : MonoBehaviour
{
    private bool isFinished;
    private string time;
    PlaneMove pm;

    // Start is called before the first frame update
    void Start()
    {
        pm = this.gameObject.GetComponent<PlaneMove>();
    }

    // Update is called once per frame
    void Update()
    {
        isFinished = pm.GetisFinished();
        time = pm.GetTime();
    }

    public string GetFinalTime()
    {
        return time;
    }

    public bool GetFinished()
    {
        return isFinished;
    }
}
