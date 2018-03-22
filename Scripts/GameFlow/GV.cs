using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GV : MonoBehaviour {

    public static readonly float PLAYER_THRUSTER_ACCEL = 2.5f;
    public static readonly float PLAYER_SPEED_MAX = 12;

    public static readonly Vector2 INFECTION_VIRUS_SPAWN_RANGE = new Vector2(1, 3);
    public static readonly float BLOOD_SPLIT_FORCE = 2f;
    public static readonly float BLOOD_SPEED_MAX = 12;

    public static readonly Vector2 URANIUM_BURST_RANGE = new Vector2(3, 6);
    public static readonly Vector2 URANIUM_BURST_TIME = new Vector2(.5f, 1);
    public static readonly Vector2Int URANIUM_BURST_AMT = new Vector2Int(1, 4);

    public static readonly float BURST_TIME = 3f;

    public static float GetRandom(Vector2 v2)
    {
        return Random.Range(v2.x, v2.y);
    }
	
    public static int GetRandom(Vector2Int v2, bool exclusive = true)
    {
        int addition = (exclusive) ? 0 : 1;
        return Random.Range(v2.x, v2.y + addition);
    }
}
