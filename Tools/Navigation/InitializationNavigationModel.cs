using System;
using LAB02.Views;

namespace LAB02.Tools.Navigation
{
    internal class InitializationNavigationModel : BaseNavigationModel
    {
        public InitializationNavigationModel(IContentOwner contentOwner) : base(contentOwner)
        {

        }

        protected override void InitializeView(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.EnterInfo:
                    ViewsDictionary.Add(viewType, new EnterInfoView());
                    break;
                case ViewType.ShowInfo:
                    ViewsDictionary.Add(viewType, new ShowInfoView());
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(viewType), viewType, null);
            }
        }
    }
}