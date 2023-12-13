using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisualController : MonoBehaviour
{
    [SerializeField]
    GameObject directedGraph;

    [SerializeField]
    GameObject circleGraph;

    [SerializeField]
    GameObject heatMap;

    [SerializeField]
    Button heatmapButton;

    [SerializeField]
    Button directedButton;

    [SerializeField]
    Button circleButton;

    public void OpenHeatMap()
    {
        directedGraph.SetActive(false);
        circleGraph.SetActive(false);
        heatMap.SetActive(true);
    }

    public void OpenDirectedGraph()
    {
        directedGraph.SetActive(true);
        circleGraph.SetActive(false);
        heatMap.SetActive(false);
    }

    public void OpenCircleGraph()
    {
        directedGraph.SetActive(false);
        circleGraph.SetActive(true);
        heatMap.SetActive(false);
    }
}
