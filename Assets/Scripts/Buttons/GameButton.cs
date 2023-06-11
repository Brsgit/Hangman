using UnityEngine;
using UnityEngine.UI;

namespace Buttons
{

    [RequireComponent(typeof(Button), typeof(ButtonView))]
    public class GameButton : MonoBehaviour, IObservable<GameButton>
    {
        private Button _button;

        private ButtonView _buttonView;

        private ButtonModel _buttonModel;

        private IObserver<GameButton> _observer;

        protected virtual void Awake()
        {
            _button = GetComponent<Button>();
        }

        protected virtual void OnEnable()
        {
            _button.onClick.AddListener(ProcessCLick);
        }

        protected virtual void OnDisable()
        {
            _button.onClick.RemoveListener(ProcessCLick);
        }

        public virtual void Init(ButtonModel model)
        {
            _buttonView = GetComponent<ButtonView>();
            this._buttonModel = model;
            _buttonView.Init(_buttonModel.Text);
        }

        public ButtonType GetButtonType()
        {
            return _buttonModel.Type;
        }

        public string GetButtonText()
        {
            return _buttonModel.Text;
        }

        protected virtual void Notify()
        {
            _observer.Notify(this);
        }

        protected virtual void ProcessCLick()
        {
            Notify();
            if(_buttonModel.Type == ButtonType.Letter) _button.interactable = false;
        }

        public void Subscribe(IObserver<GameButton> observer)
        {
            _observer = observer;
        }

        public void Unsubscribe(IObserver<GameButton> observer)
        {
            _observer = null;
        }

        public virtual void ReEnable()
        {
            _button.interactable = true;
        }

    }
}
