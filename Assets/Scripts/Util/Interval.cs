using UnityEngine;

[System.Serializable]
public class Interval {
    public float from;
    public float to;

    public float Min { get { return Mathf.Min(from, to); } }
    public float Max { get { return Mathf.Max(from, to); } }
    public float RandomValue { get { return Random.Range(Min, Max); } }
}