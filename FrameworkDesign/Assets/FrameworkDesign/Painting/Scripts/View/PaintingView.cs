using FrameworkDesign.Painting.Presenter;
using FrameworkDesign.Painting.View;
using UnityEngine;
using UnityEngine.UI;

public class PaintingView : MonoBehaviour, IPaintingView
{
    private IPaintingPresenter _presenter;
    private Button _btnAddEntity;
    private Button _btnSubEntity;
    private Transform _entityRoot;
    private Transform _entity;
    private Button _btnAddComponent;
    private Button _btnSubComponent;

    public IPaintingPresenter Presenter
    {
        get
        {
            if (_presenter != null)
            {
                return _presenter;
            }

            _presenter = new PaintingPresenter();
            _presenter.View = this;

            return _presenter;
        }
        set => _presenter = value;
    }

    private void Awake()
    {
        _btnAddEntity = transform.Find("Btn_AddEntity")?.GetComponent<Button>();
        _btnSubEntity = transform.Find("Btn_SubEntity")?.GetComponent<Button>();
        _entityRoot = transform.Find("Entities");
        _entity = transform.Find("Entities/Components");
        _btnAddComponent = transform.Find("Btn_AddComponent")?.GetComponent<Button>();
        _btnSubComponent = transform.Find("Btn_SubComponent")?.GetComponent<Button>();
    }

    private void Start()
    {
        _entity?.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _btnAddEntity?.onClick.AddListener(Presenter.ClickAddEntity);
        _btnSubEntity?.onClick.AddListener(Presenter.ClickSubEntity);
        _btnAddComponent?.onClick.AddListener(Presenter.ClickAddComponent);
        _btnSubComponent?.onClick.AddListener(Presenter.ClickSubComponent);
    }

    private void OnDisable()
    {
        _btnAddEntity?.onClick.RemoveListener(Presenter.ClickAddEntity);
        _btnSubEntity?.onClick.RemoveListener(Presenter.ClickSubEntity);
        _btnAddComponent?.onClick.RemoveListener(Presenter.ClickAddComponent);
        _btnSubComponent?.onClick.RemoveListener(Presenter.ClickSubComponent);
    }

    public void AddEntity()
    {
        Transform entity = Instantiate(_entity, _entityRoot);
        entity.gameObject.SetActive(true);
        foreach (Transform child in entity)
        {
            child.gameObject.SetActive(true);
        }
    }

    public void SubEntity()
    {
        Transform entity = _entityRoot.GetChild(_entityRoot.childCount - 1);
        if (entity.gameObject.activeSelf)
        {
            DestroyImmediate(entity.gameObject);
        }

        if (_entityRoot.GetChild(_entityRoot.childCount - 1).gameObject.activeSelf)
        {
            ComponentView.Parent = _entityRoot.GetChild(_entityRoot.childCount - 1);
        }
    }
}
