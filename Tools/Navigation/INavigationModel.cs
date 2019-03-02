namespace LAB02.Tools.Navigation
{
    internal enum ViewType
    {
        EnterInfo,
        ShowInfo
    }

    interface INavigationModel
    {
        void Navigate(ViewType viewType);
    }
}