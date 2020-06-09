using Atata;

namespace TransformerComponents.Controls.Transformer
{
    [FindById("transformer")]
    public class Transformer<_> : Control<_>
        where _ : PageObject<_>
    {
        public NavigationMenu<_> NavigationMenu { get; set; }
        public Switcher<_> Switcher { get; set; }
        public MyTransformerTab<_> MyTransformerTab { get; set; }
        public AllChannelsTab<_> AllChannelsTab { get; set; }


    }
}
