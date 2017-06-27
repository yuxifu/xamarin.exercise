using System;
using Android.App;
using Android.Runtime;
using Android.Content;
using Android.Views;
using Android.Widget;
using Android.Support.V4.View;
using Java.Lang;


namespace TreePager
{
	class TreePagerAdapter : PagerAdapter
	{
		Context context;
		TreeCatalog treeCatalog;

		public TreePagerAdapter(Context context, TreeCatalog treeCatalog)
		{
			this.context = context;
			this.treeCatalog = treeCatalog;
		}

		public override int Count
		{
			get { return treeCatalog.NumTrees; }
		}

		public override bool IsViewFromObject(View view, Java.Lang.Object @object)
		{
			return view == @object;
		}

		public override Java.Lang.Object InstantiateItem(ViewGroup container, int position)
		{
			var imageView = new ImageView(context);
			imageView.SetImageResource(treeCatalog[position].imageId);
			var viewPager = container.JavaCast<ViewPager>();
			viewPager.AddView(imageView);
			return imageView;
		}

		public override void DestroyItem(ViewGroup container, int position, Java.Lang.Object @object)
		{
			var viewPager = container.JavaCast<ViewPager>();
			viewPager.RemoveView(@object as View);
		}

		public override Java.Lang.ICharSequence GetPageTitleFormatted(int position)
		{
			return new Java.Lang.String(treeCatalog[position].caption);
		}


	}
}