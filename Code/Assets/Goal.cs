using UnityEngine;

public class Goal : MonoBehaviour {
    public GameObject scoringController;
    public float scoringThreshold = 1.0f; 

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Ball")) {
            // Check if the ball is beyond the scoring threshold
            if (IsBallBeyondThreshold(other.transform.position)) {
                scoringController.SendMessage("GoalScored", gameObject.tag);
            }
        }
    }

    private bool IsBallBeyondThreshold(Vector3 ballPosition) {
        float distanceFromGoalLine = Vector3.Dot(ballPosition - transform.position, transform.forward);
        return distanceFromGoalLine > scoringThreshold;
    }
}