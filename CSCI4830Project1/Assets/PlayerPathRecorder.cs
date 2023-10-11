using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPathRecorder : MonoBehaviour
{
    public List<Vector3> path = new List<Vector3>();
    public float recordInterval = 0.5f;
    public Vector3 origin;
    public float worldWidth;
    public float worldHeight;

    public void ComputeWorldBounds()
    {
        if (path.Count == 0) return;

        float minX = path[0].x;
        float maxX = path[0].x;
        float minZ = path[0].z;
        float maxZ = path[0].z;

        foreach (Vector3 point in path)
        {
            if (point.x < minX) minX = point.x;
            if (point.x > maxX) maxX = point.x;
            if (point.z < minZ) minZ = point.z;
            if (point.z > maxZ) maxZ = point.z;
        }

        origin = new Vector3(minX, 0, minZ);
        worldWidth = maxX - minX;
        worldHeight = maxZ - minZ;
    }

    private void Start()
    {
        StartCoroutine(RecordPath());
    }

    private IEnumerator RecordPath()
    {
        while (true)
        {
            path.Add(transform.position);
            yield return new WaitForSeconds(recordInterval);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
