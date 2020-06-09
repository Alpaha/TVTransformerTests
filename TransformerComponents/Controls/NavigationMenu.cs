using System;
using System.Linq;
using Atata;

namespace TransformerComponents.Controls
{
    [FindByClass("navigation-menu", Visibility = Visibility.Any)]
    public class NavigationMenu<_> : Control<_>
        where _ : PageObject<_>
    {
        public ControlList<NavigationTab<_>, _> Tabs { get; set; }

        [FindById("myTransformerCounter")]
        public Text<_> MyTransformerCounter { get; set; }

        public _ ClickTabByName(string name)
        {
            var tab = Tabs.FirstOrDefault(t => t.Name.Value == name);
            if(tab == null)
                throw new Exception($"Не удалось найти вкладку с именем \"{name}\" для нажатия!");
            return tab.Click();
        }
    }

    [FindByClass("navigation-menu__tab", Visibility = Visibility.Any, As = FindAs.Sibling)]
    public class NavigationTab<_> : Control<_>
        where _ : PageObject<_>
    {
        [FindByClass("navigation-menu__tab-name")]
        public Text<_> Name { get; set; }

        public bool IsActive => Attributes["class"].Value.Contains("navigation-menu__tab--active");
    }
}
