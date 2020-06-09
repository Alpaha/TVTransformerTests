using Atata;

namespace TransformerComponents.Controls.Rate
{
    [FindByClass("rate__body tabs__body show")]
    public class RateBody<_> : Control<_>
        where _ : PageObject<_>
    {
        public RateTransformerCheck<_> TransformerCheck { get; set; }
    }

    [FindByClass("transformer-check rate__item")]
    public class RateTransformerCheck<_> : Control<_>
        where _ : PageObject<_>
    {
        [FindByClass("progress-bar__title")]
        public Text<_> Title { get; set; }

        public RateTransformerProgressBar<_> ProgressBar { get; set; }

        [FindByClass("progress-bar__channels")]
        public Text<_> ChannelsCount { get; set; }
    }
}
