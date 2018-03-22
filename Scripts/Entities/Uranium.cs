using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uranium : MonoBehaviour
{
    Burster burster;

    void Start()
    {
        TimerManager.Instance.AddTimer(EmitSingleBurst, GV.GetRandom(GV.URANIUM_BURST_TIME));
        burster = gameObject.AddComponent<Burster>();
        burster.Initialize(transform);
    }

    void EmitBurst()
    {
        int burstCount = GV.GetRandom(GV.URANIUM_BURST_AMT, true);
        for (int i = 0; i < burstCount; i++)
            EmitSingleBurst();
        TimerManager.Instance.AddTimer(EmitBurst, GV.GetRandom(GV.URANIUM_BURST_TIME));
    }

    void EmitSingleBurst()
    {
        float burstRange = GV.GetRandom(GV.URANIUM_BURST_RANGE);
        Vector3 randDir = Random.onUnitSphere;
        int layerMaskValue = (1 << LayerMask.NameToLayer("Entities")); // | (1 << LayerMask.NameToLayer("SomeOtherLayer"));
        RaycastHit[] rhs = Physics.RaycastAll(transform.position, randDir, burstRange, layerMaskValue);
        foreach (RaycastHit rh in rhs)
        {
            if (transform == rh.transform)
                Debug.Log("Stop hitting yourself");
            switch (rh.transform.tag)
            {
                case "Blood":
                case "Lipid":
                case "Virus":
                    Debug.Log(string.Format("Object {0} was destroyed", rh.transform.gameObject.tag));
                    GameObject.Destroy(rh.transform.gameObject);
                    break;
            }
        }
        burster.CreateBurstEffect(randDir * burstRange);
    }
}
