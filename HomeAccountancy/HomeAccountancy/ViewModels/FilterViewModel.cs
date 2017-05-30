using HomeAccountancy.Models;

namespace HomeAccountancy.ViewModels
{
    class FilterViewModel
    {
        public Filter CurrentFilter { get; set; }

        public FilterViewModel()
        {
            CurrentFilter = Filter.GetInstance();
        }
    }
}
