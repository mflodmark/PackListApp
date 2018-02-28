using PackListApp.Models;

namespace PackListApp.ViewModels
{
    public class ListItemViewModel: BaseViewModel
    {
        //public string Item { get; set; }

        public ListItemViewModel() { }

        public ListItemViewModel(ListItem listItem)
        {
            // When initializing this object, I'm using the private field directly
            // because I don't want this to raise a notification. 

            // You may think we have violated the DRY principle (Don't Repeat 
            // Yourself) because we've defined these properties in 2 places. 
            // While that is partially true, we've done this for good reasons. 
            // When you use the same class both as the domain and presentation model
            // that class becomes bloated with too many responsibilities. This is
            // not an issue for a small app (like this ContactBook app). But as
            // the complexity of your application increases, throwing all these
            // properties and methods into the same class will end up with a big 
            // mess. So, it's better to have two separate models, one for presentation
            // one for domain. This improves separation of concerns in your application
            // but on the downside it comes with a cost: you have to repeat some of
            // the properteis and map them together. While these few lines of 
            // property assignment are not a major issue, if this still bothers
            // you, you can use a convention-based mapping library like AutoMapper.


            Item = listItem.Item;
        }

        private string _item;

        public string Item
        {
            get => _item;
            set => SetValue(ref _item, value);
        }

 
    }
}