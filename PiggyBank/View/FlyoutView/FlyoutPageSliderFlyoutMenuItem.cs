using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiggyBank.View.FlyoutView
{
    public class FlyoutPageSliderFlyoutMenuItem
    {
        public FlyoutPageSliderFlyoutMenuItem()
        {
            TargetType = typeof(FlyoutPageSliderFlyoutMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}