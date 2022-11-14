using Parking.PresentationLogic.ViewModels;

namespace Parking.PresentationLogic
{
    public interface INavigationService
    {
        void ShowWindow<TViewModel>(object parametr = null) where TViewModel : BaseViewModel;
    }
}