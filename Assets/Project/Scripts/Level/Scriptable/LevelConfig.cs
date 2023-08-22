using UnityEngine;

[CreateAssetMenu(menuName = "Level/LevelConfig", fileName = "LevelConfig")]
public class LevelConfig : ScriptableObject
{
    public LevelDifficulty difficulty;
    public Wall wallPrefab;
    public int multiplySpeedByScore;
    public float speed;
    public float wallDistance;
    public float wallOffset;
    public float holeSize;
}
