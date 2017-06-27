using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V4.View;

namespace TreePager
{
    [Activity(Label = "TreePager", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle savedInstanceState)
        {
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.Main);
			ViewPager viewPager = FindViewById<ViewPager>(Resource.Id.viewpager);
			TreeCatalog treeCatalog = new TreeCatalog();

            viewPager.Adapter = new TreePagerAdapter(this, treeCatalog);
        }
    }
}

