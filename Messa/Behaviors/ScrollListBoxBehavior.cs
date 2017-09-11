using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace Messa.Behaviors
{
    public class ScrollListBoxBehavior : Behavior<ListBox>
    {
        protected override void OnAttached()
        {
            AssociatedObject.Loaded += OnLoaded;
            AssociatedObject.Unloaded += OnUnLoaded;
        }

        protected override void OnDetaching()
        {
            AssociatedObject.Loaded -= OnLoaded;
            AssociatedObject.Unloaded -= OnUnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            if (!(AssociatedObject.ItemsSource is INotifyCollectionChanged incc)) return;

            incc.CollectionChanged += OnCollectionChanged;
        }

        private void OnUnLoaded(object sender, RoutedEventArgs e)
        {
            if (!(AssociatedObject.ItemsSource is INotifyCollectionChanged incc)) return;

            incc.CollectionChanged -= OnCollectionChanged;
        }

        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action != NotifyCollectionChangedAction.Add) return;
            var count = AssociatedObject.Items.Count;
            if (count == 0)
                return;

            var item = AssociatedObject.Items[count - 1];

            AssociatedObject.ScrollIntoView(e.NewItems[0]);
        }
    }
}
