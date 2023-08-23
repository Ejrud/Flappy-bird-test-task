using System;

[Serializable]
public class PlayerModel
{
    public event Action OnScoreChanged;
    
    public PlayerModel(LevelDifficulty levelDifficulty, ScoresModel scoresModel ,float soundValue)
    {
        this.levelDifficulty = levelDifficulty;
        this.scoresModel = scoresModel;
        this.soundValue = soundValue;
    }

    public LevelDifficulty levelDifficulty;
    public ScoresModel scoresModel;
    public float soundValue;

    // Вообще в модели нежелательно хранить какую либо логику.
    public void TryUpdateScore(int value, LevelDifficulty difficulty)
    {
        switch (difficulty)
        {
            case LevelDifficulty.Easy:
                scoresModel.easyScore = (value > scoresModel.easyScore) ? value : scoresModel.easyScore;
                break;
            
            case LevelDifficulty.Medium:
                scoresModel.mediumScore = (value > scoresModel.mediumScore) ? value : scoresModel.mediumScore;
                break;
            
            case LevelDifficulty.Hard:
                scoresModel.hardScore = (value > scoresModel.hardScore) ? value : scoresModel.hardScore;
                break;
            
            default:
                throw new NotImplementedException();
        }
        
        OnScoreChanged?.Invoke();
    }

    public void UpdateSoundValue(float value)
    {
        soundValue = value;
    }

    public void ChangeDifficulty(LevelDifficulty value)
    {
        levelDifficulty = value;
    }
}