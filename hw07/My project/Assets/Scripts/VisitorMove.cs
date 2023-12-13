using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisitorMove : MonoBehaviour
{
    [SerializeField]
    ReadJson readJson;

    [SerializeField]
    GameObject visitorPrefab;

    [SerializeField]
    GameObject visitorsParent;

    List<Visitor> visitors = new List<Visitor>();

    bool loadFinished = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        if (!loadFinished && readJson.userEmail.Count != 0)
        {
            CreateVisitors();
            loadFinished = true;
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            foreach(Visitor visitor in visitors)
            {
                visitor.UpdatePosition();
            }
        }
        foreach (Visitor visitor in visitors)
        {
            visitor.UpdateVistorPosition();
        }
    }

    void CreateVisitors()
    {
        foreach (string visitor in readJson.userEmail)
        {
            Debug.Log("Add a visitor");
            GameObject newVisitor = Instantiate(visitorPrefab);
            newVisitor.transform.parent = visitorsParent.transform;

            Visitor visit = new Visitor(readJson.dataDictionary[visitor], newVisitor);
            visitors.Add(visit);
        }
        //StartCoroutine(UpdateVisitorsPosition());
    }

    IEnumerator UpdateVisitorsPosition()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            foreach(Visitor visitor in visitors)
            {
                visitor.UpdatePosition();
            }
        }
    }
}
