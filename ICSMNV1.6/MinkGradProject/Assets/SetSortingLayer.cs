using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class SetSortingLayer : MonoBehaviour
{
    public Renderer killZone;
    public string MySortingLayer;
    public int MySortingOrderInLayer;

   // public LineRenderer killZone;
    public Vector3 startLine;
    public Vector3 endLine;
    // Use this for initialization
    void Start()
    {
        if (killZone == null)
            killZone = this.GetComponent<Renderer>();

        startLine = new Vector3(0, transform.position.y, -1);
        endLine = new Vector3(transform.position.x * 2, transform.position.y, -1);
        //  killZone.SetPosition(0, startLine);
        //  killZone.SetPosition(1, endLine);
        //    Material whiteDiffuseMat = new Material(Shader.Find("Unlit/Texture"));
        //  killZone.material = whiteDiffuseMat;
       // killZone.material.color = Color.red;
        //killZone.material.endColor = Color.red;

        //  Debug.DrawLine(startLine, endLine, Color.red, 20, false);
    }

    // Update is called once per frame
    void Update()
    {
        if (killZone == null)
            killZone = this.GetComponent<Renderer>();
        killZone.sortingLayerName = MySortingLayer;
        killZone.sortingOrder = MySortingOrderInLayer;

        //Debug.Log(MyRenderer.sortingLayerName + " " + MyRenderer.sortingOrder);
    }
}