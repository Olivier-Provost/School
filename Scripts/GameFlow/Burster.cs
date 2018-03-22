using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burster : MonoBehaviour
{
    List<LineRenderer> lineRenderers;
    List<LineInfo> lineInfos = new List<LineInfo>();
    Transform parent;

    public static readonly float BURST_TIME = 1f;

    public void Initialize(Transform _parent)
    {
        parent = _parent;
    }

    public void CreateBurstEffect(Vector3 endGoal, bool isRelativeToParent = true)
    {
        if (!isRelativeToParent)
            Debug.LogError("Warning, non-relative burst effect not implemented");
        Vector2 endpoint = (isRelativeToParent) ? endGoal : endGoal - parent.transform.position;

        GameObject newobj = new GameObject();
        newobj.transform.SetParent(parent);
        newobj.transform.localPosition = new Vector3();
        newobj.name = "BurstRenderer";

        LineRenderer lr = newobj.AddComponent<LineRenderer>();
        lr.useWorldSpace = !isRelativeToParent;
        lr.startWidth = .1f;
        lr.endWidth = lr.startWidth;

        LineInfo lineInfo = new LineInfo(newobj, lr, endpoint);
        lineInfos.Add(lineInfo);
    }

    public void Update()
    {
        float dt = Time.deltaTime;
        for (int i = lineInfos.Count - 1; i >= 0; i--)
        {
            LineInfo li = lineInfos[i];
            if (li.dt >= BURST_TIME)
            {
                GameObject.Destroy(li.go);
                lineInfos.RemoveAt(i);
            }
            else
            {
                li.dt += dt;
                li.lr.SetPosition(1, Vector3.Lerp(new Vector3(), li.endGoal, li.dt / BURST_TIME));
            }
        }
    }

    private class LineInfo
    {
        public GameObject go;
        public LineRenderer lr;
        public float dt;
        public Vector3 endGoal;

        public LineInfo(GameObject _go, LineRenderer _lr, Vector3 _endGoal)
        {
            go = _go;
            lr = _lr;
            endGoal = _endGoal;
        }
    }

}
