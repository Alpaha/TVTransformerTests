using Atata;

namespace TransformerComponents.Controls.Rate
{
    [FindById("rate")]
    public class Rate<_> : Control<_>
        where _ : PageObject<_>
    {
        public RateHeader<_> Header { get; set; }
        public RateBody<_> Body { get; set; }
    }
}
