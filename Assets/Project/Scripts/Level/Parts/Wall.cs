using UnityEngine;

public class Wall : MonoBehaviour
{
    public Hole hole => _hole;
    
    public bool IsActive
    {
        get { return _isActive; }
        set
        {
            _isActive = value;
            gameObject.SetActive(_isActive);
        }
    }

    [SerializeField] private Hole _hole;
    
    [Header("Top wall")]
    [SerializeField] private SpriteRenderer _topSpriteRenderer;
    [SerializeField] private BoxCollider2D _topBoxCollider2D;
    
    [Header("Bottom wall")]
    [SerializeField] private SpriteRenderer _bottomSpriteRenderer;
    [SerializeField] private BoxCollider2D _bottomBoxCollider2D;
    
    [Space(10)]
    [SerializeField] private float _wallWidth = 1f;

    private bool _isActive;
    
    public void InitWall(float topHeight, float bottomHeight)
    {
        ResizeWall(_topSpriteRenderer, _topBoxCollider2D, topHeight, -2);
        ResizeWall(_bottomSpriteRenderer, _bottomBoxCollider2D, bottomHeight, 2);
    }

    private void ResizeWall(SpriteRenderer spriteRenderer, BoxCollider2D boxCollider2D, float value, float div)
    {
        spriteRenderer.size = new Vector2(_wallWidth, value);
        boxCollider2D.size = new Vector2(_wallWidth, value);
        boxCollider2D.offset = new Vector2(0, value / div);
    }
    
    [ContextMenu("Set default values")]
    private void SetDefaultValue()
    {
        InitWall(3.5f,3.5f);
    }
}
