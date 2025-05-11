using UnityEngine;

public class StartLine : MonoBehaviour
{
    public enum Line
    {
        Start,
        Mid
    }

    public Line line;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);

        if (!other.CompareTag("Player")) return;

        if(line == Line.Start)
        {
            Debug.Log("Passed start");
            GameManager.Instance.startLinePassed = true;
            GameManager.Instance.CheckLine(line.ToString());
        }
        else if(line == Line.Mid)
        {
            GameManager.Instance.midLinePassed = true;
            GameManager.Instance.CheckLine(line.ToString());
        }
    }
}
