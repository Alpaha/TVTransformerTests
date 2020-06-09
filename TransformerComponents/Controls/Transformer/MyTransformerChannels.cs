using Atata;

namespace TransformerComponents.Controls.Transformer
{
    [FindByClass("channels-grid my-transformer__channels")]
    public class MyTransformerChannels<_> : Control<_>
        where _ : PageObject<_>
    {
        public ControlList<Channel<_>, _> Channels { get; set; }
    }
}
