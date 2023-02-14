using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveController : MonoBehaviour
{
    public GameObject LivePoint;

    private List<GameObject> live = new List<GameObject>();
    public HeroController herocontroller;
    // Start is called before the first frame update
    void Start()
    {
        for (int x =0; x<herocontroller.live; x++)
        {
            CreateLivePoint(x);
        }
    }

    void CreateLivePoint(int x)
    {
        GameObject live_point = Instantiate(LivePoint, transform);
        live_point.transform.position = new Vector3(transform.position.x + x * 2f, transform.position.y);
        live.Add(live_point);
    }
    // Update is called once per frame
    void Update()
    {
        if (live.Count > herocontroller.live)
        {
            for (int i = live.Count - 1; i >= herocontroller.live; i--)
            {
                Destroy(live[i]);
                live.RemoveAt(i);
            }
        }
        else if (live.Count < herocontroller.live)
        {
            for(int i = live.Count; i < herocontroller.live; i++)
            {
                CreateLivePoint(i);
            }
        }
    }
}
