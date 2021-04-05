using System.Collections.Generic;
using System.Collections.Specialized;
using System.Windows.Input;
using Xamarin.Forms;

namespace XFBugItemsViewController
{
    public class MyItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class MyAdapter : List<MyItem>, INotifyCollectionChanged
    {
        public event NotifyCollectionChangedEventHandler CollectionChanged;


        public new void Add(MyItem item)
        {
            base.Add(item);
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item));
        }

        public new void Clear()
        {
            base.Clear();
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        private void OnCollectionChanged(NotifyCollectionChangedEventArgs args)
        {
            if (CollectionChanged != null)
            {
                var N = CollectionChanged.GetInvocationList().Length;
                System.Diagnostics.Debug.WriteLine($"Number of items in event invocation list= {N}");
                CollectionChanged.Invoke(this, args);
            }
        }
    }

    public class MainPageViewModel : BaseViewModel
    {
        public MyAdapter MyCollection { get; }
        public ICommand FillCollection { get; set; }
        public ICommand EmptyCollection { get; set; }

        private void DoFillCollection()
        {
            MyCollection.Add(new MyItem { Id = 1, Name = "item1" });
            MyCollection.Add(new MyItem { Id = 2, Name = "item2" });
            MyCollection.Add(new MyItem { Id = 3, Name = "item3" });
        }

        private void DoEmptyCollection()
        {
            MyCollection.Clear();
        }

        public MainPageViewModel()
        {
            FillCollection = new Command(DoFillCollection);
            EmptyCollection = new Command(DoEmptyCollection);
            MyCollection = new MyAdapter();
            DoFillCollection();
        }
    }
}
