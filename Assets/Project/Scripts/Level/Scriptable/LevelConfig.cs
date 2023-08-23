using UnityEngine;

[CreateAssetMenu(menuName = "Level/LevelConfig", fileName = "LevelConfig")]
public class LevelConfig : ScriptableObject
{
    public LevelDifficulty difficulty;
    public Wall wallPrefab;
    public int scoreCountForMultiplySpeed;
    public float speedMultiply;
    public float startSpeed;
    public float wallDistance;
    public float holeOffset;
    public float holeSize;
}
