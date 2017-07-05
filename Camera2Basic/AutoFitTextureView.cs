using System;
using Android.Content;
using Android.Util;
using Android.Views;

namespace Camera2Basic
{
	public class AutoFitTextureView : TextureView
	{
		private int mRatioWidth = 0;
		private int mRatioHeight = 0;

		public AutoFitTextureView(Context context)
			: this (context, null)
		{

		}
		public AutoFitTextureView (Context context, IAttributeSet attrs)
			: this (context, attrs, 0)
		{

		}
		public AutoFitTextureView (Context context, IAttributeSet attrs, int defStyle)
			: base (context, attrs, defStyle)
		{

		}

		public void SetAspectRatio(int width, int height)
		{
			if (width == 0 || height == 0)
				throw new ArgumentException ("Size cannot be negative.");
			mRatioWidth = width;
			mRatioHeight = height;

			//Call this when something has changed which has invalidated the layout of this view. 
			//This will schedule a layout pass of the view tree
			//see https://stackoverflow.com/questions/13856180/usage-of-forcelayout-requestlayout-and-invalidate
			RequestLayout ();
		}

		/*widthMeasureSpec and heightMeasureSpec are compound variables. Meaning while they 
		    are just plain old ints, they actually contain two separate pieces of data.
		    The first part of data stored in these variables is the available space(in pixels) 
		    for the given dimension.
		    int widthPixels = View.MeasureSpec.getSize( widthMeasureSpec ); */
		/*The second piece of data is the measure mode, it is stored in the higher order 
            bits of the int, and is one of these possible values:
            View.MeasureSpec.UNSPECIFIED
		    View.MeasureSpec.AT_MOST
		    View.MeasureSpec.EXACTLY
		    You can extract the value with this convenience method:
		    int widthMode = View.MeasureSpec.getMode(widthMeasureSpec); */
		protected override void OnMeasure (int widthMeasureSpec, int heightMeasureSpec)
		{
			base.OnMeasure (widthMeasureSpec, heightMeasureSpec);
			int width = MeasureSpec.GetSize (widthMeasureSpec);
			int height = MeasureSpec.GetSize (heightMeasureSpec);
            //SetMeasuredDimension(): store the measured width and measured height
			if (0 == mRatioWidth || 0 == mRatioHeight) {
				SetMeasuredDimension (width, height);
			} else {
				if (width < (float)height * mRatioWidth / (float)mRatioHeight) {
					SetMeasuredDimension (width, width * mRatioHeight / mRatioWidth);
				} else {
					SetMeasuredDimension (height * mRatioWidth / mRatioHeight, height);
				}
			}
		}
	}
}

