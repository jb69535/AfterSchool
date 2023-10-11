using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class pathRecorder : MonoBehaviour
{
    private List<string> positions = new List<string>();

    void Start()
    {
        // Start the RecordPosition coroutine when the script starts
        StartCoroutine(RecordPosition());
    }

    IEnumerator RecordPosition()
    {
        // Infinite loop to continue recording positions
        while (true)
        {
            // Record the x, z positions
            var position = transform.position;
            positions.Add($"{position.x},{position.z}");

            // Wait for 1 second before recording the next position
            yield return new WaitForSeconds(1f);
        }
    }

    private void OnApplicationQuit()
    {
        // Get the path of the Game data folder
        string path = Application.dataPath + "/path_positions.txt";

        // Ensure directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(path));

        using (StreamWriter sw = new StreamWriter(path))
        {
            foreach (var pos in positions)
            {
                sw.WriteLine(pos);
            }
        }
    }
}