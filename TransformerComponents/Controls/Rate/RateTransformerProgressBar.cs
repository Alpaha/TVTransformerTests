using Atata;
using System.Drawing;

namespace TransformerComponents.Controls.Rate
{
    [FindByClass("progress-bar__progress", Visibility = Visibility.Any)]
    public class RateTransformerProgressBar<_> : Control<_>
        where _ : PageObject<_>
    {
        public RateTransformerProgress<_> Progress { get; set; }
    }

    [FindByClass("progress-bar__progress-value", Visibility = Visibility.Any)]
    public class RateTransformerProgress<_> : Control<_>
        where _ : PageObject<_>
    {
        public string ColorCode => Css["background-color"].Value;
    }
}
