using UnityEngine;

public class Goal : MonoBehaviour
{

    public GameObject scoringController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            scoringController.SendMessage("GoalScored", gameObject.tag);
        }
    }
}
