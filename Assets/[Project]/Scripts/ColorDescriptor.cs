using System.Collections.Generic;
using UnityEngine;

public class ColorDescriptor : MonoBehaviour
{
    [SerializeField] private ScriptableColor _scriptableColor;
    [SerializeField] private List<SpriteRenderer> _rendererList;
    public ScriptableColor ScriptableColor { get => _scriptableColor; }

    void Start()
    {
        SetRendererColor();
    }

    private void SetRendererColor()
    {
        if (_scriptableColor && _rendererList.Count > 0)
        {
            foreach (var item in _rendererList)
            {
                item.color = _scriptableColor.color;
            }
        }
    }

    public void SetColor(ScriptableColor value)
    {
        _scriptableColor = value;
        SetRendererColor();
    }

    public bool IsSameColor(ScriptableColor color)
    {
        return color == _scriptableColor;
    }
}
