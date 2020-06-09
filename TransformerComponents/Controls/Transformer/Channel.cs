using Atata;

namespace TransformerComponents.Controls.Transformer
{
    [FindByClass("channel", As = FindAs.Sibling)]
    public class Channel<_> : Control<_>
        where _ : PageObject<_>
    {
        [FindByClass("channels-grid__cell-icon")]
        public Image<_> Image { get; set; }

        public string Name => Image.Attributes["Title"].Value;
    }
}
