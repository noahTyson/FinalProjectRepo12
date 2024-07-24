using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    // Drag & drop the gameObject with the Text component in the inspector
    [SerializeField]
    private Text Text;
    private int score;
    void Start()
    {
        Reset();
    }
    public void AddPoints( int pointsToAdd )
    {
        score += pointsToAdd;
        Text.text = score.ToString();
    }
    public void Reset()
    {
        score = 0;
    }
}