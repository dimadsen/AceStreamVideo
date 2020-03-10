using System;
using AceStream.Dto;

namespace AceStream.SubModules.SquardSubModule
{
    public class SquardInteractor : ISquardInteractor
    {
        private ISquardPresenter _presenter;

        public SquardInteractor(ISquardPresenter presenter)
        {
            _presenter = presenter;

        }
    }
}
