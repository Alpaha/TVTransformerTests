using Atata;

namespace TransformerComponents.Controls.Transformer
{
    [ControlDefinition("*")]
    public class BaseTab<_> : Control<_>
        where _ : PageObject<_>
    {
        public ChannelCard<_> ChannelCard { get; set; }
    }
}
