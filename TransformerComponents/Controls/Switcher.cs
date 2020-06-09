using Atata;

namespace TransformerComponents.Controls
{
    [FindByClass("switch-container__switch", Visibility = Visibility.Any)]
    public class Switcher<_> : Control<_>
        where _ : PageObject<_>
    {
        [FindByClass("switch-container__toggle")]
        public Control<_> Toggler { get; set; }

        public bool IsTransformerMode => Toggler.Css["left"].Value == "35px";

        public bool TransformerMode()
        {
            var value = Toggler.Css["left"].Value;
            return value == "35px;";
        }
    }
}
