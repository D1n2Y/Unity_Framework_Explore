using FrameworkDesign.Painting.Presenter;
using FrameworkDesign.Painting.View;
using UnityEngine;
using UnityEngine.UI;

public class ComponentView : MonoBehaviour,
    IComponentView
{
    private static ComponentView s_original;
    private IComponentPresenter _presenter;
    private InputField _inputDesc;

    public static Transform Parent;

    public IComponentPresenter Presenter
    {
        get
        {
            if (_presenter != null)
            {
                return _presenter;
            }

            _presenter = new ComponentPresenter();
            _presenter.View = this;

            return _presenter;
        }
        set => _presenter = value;
    }

    public bool IsTemplate { get; set; } = true;

    private void Awake()
    {
        Parent = transform.parent;
        s_original = s_original ?? this;
        _inputDesc = transform.Find("Input_Desc")?.GetComponent<InputField>();
    }

    private void Start()
    {
        gameObject.SetActive(!IsTemplate);
    }

    private void OnEnable()
    {
        _inputDesc?.onEndEdit.AddListener(Presenter.EndInputDesc);
    }

    private void OnDisable()
    {
        _inputDesc?.onEndEdit.RemoveListener(Presenter.EndInputDesc);
    }

    public static ComponentView Instantiate()
    {
        ComponentView original = GameObject.Instantiate(s_original, Parent);
        original.IsTemplate = false;
        original.gameObject.SetActive(true);
        return original;
    }

    public static void Destroy(ComponentView view)
    {
        GameObject.Destroy(view.gameObject);
    }
}
