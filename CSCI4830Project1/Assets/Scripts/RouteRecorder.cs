using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class RouteRecorder : MonoBehaviour
{
    private List<string> positions = new List<string>();

    void Update()
    {
        // Record the x, z positions in each frame
        var position = transform.position;
        positions.Add($"{position.x},{position.z}");
    }

    private void OnApplicationQuit()
    {
        using (StreamWriter sw = new StreamWriter("/Users/hmac/Desktop/path_positions.txt"))
        {
            foreach (var pos in positions)
            {
                sw.WriteLine(pos);
            }
        }
    }

}
