using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V4.View;
using Android.Support.V4.App;

namespace FlashCardPager
{
    [Activity(Label = "FlashCardPager", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : FragmentActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
            ViewPager viewPager = FindViewById<ViewPager>(Resource.Id.pager);
            FlashCardDeck flashCards = new FlashCardDeck();

            FlashCardDeckAdapter adapter =
                new FlashCardDeckAdapter(SupportFragmentManager, flashCards);
            viewPager.Adapter = adapter;
        }
    }
}

