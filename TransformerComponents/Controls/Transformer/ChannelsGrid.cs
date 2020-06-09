using Atata;

namespace TransformerComponents.Controls.Transformer
{
    [FindByClass("channels-grid")]
    public class ChannelsGrid<_> : Control<_>
        where _ : PageObject<_>
    {
        public ControlList<Channel<_>, _> ChannelsList { get; set; }
    }
}
