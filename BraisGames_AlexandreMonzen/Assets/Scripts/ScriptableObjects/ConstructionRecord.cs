using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Construction Record", menuName = "ScriptableObjects/ConstructionRecord")]
public sealed class ConstructionRecord : ScriptableObject
{
    [SerializeField] private int _woodAmount;
    [SerializeField] private int _stoneAmount;
    [SerializeField] private int _leafAmount;

    [SerializeField] private string _namePreview;
    [SerializeField] private Sprite _imagePreview;
    [SerializeField] private GameObject _prefabConstruction;

    #region Getters & Setters
    public int WoodAmount { get => _woodAmount; }
    public int StoneAmount { get => _stoneAmount; }
    public int LeafAmount { get => _leafAmount; }
    public string NamePreview { get => _namePreview; }
    public Sprite ImagePreview { get => _imagePreview; }
    public GameObject PrefabConstruction { get => _prefabConstruction; }
    #endregion
}
