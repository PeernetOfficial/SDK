using System.Threading.Tasks;

namespace Peernet.SDK.Models.Presentation
{
    public abstract class GenericViewModelBase<TParameter> : ViewModelBase
        where TParameter : class
    {
        private TParameter parameter;

        public TParameter Parameter
        {
            get => parameter;
            set
            {
                parameter = value;
                OnPropertyChanged(nameof(Parameter));
            }
        }

        public abstract Task Prepare(TParameter parameter);
    }
}