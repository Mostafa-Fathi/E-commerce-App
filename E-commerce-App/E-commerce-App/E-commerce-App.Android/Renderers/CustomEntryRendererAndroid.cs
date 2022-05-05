using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using E_commerce_App.Controls;
using E_commerce_App.Droid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRendererAndroid))]
namespace E_commerce_App.Droid
{
    [Obsolete]
    public class CustomEntryRendererAndroid : EntryRenderer
    {
        //this class to  remove undelineon Entry and customize cursor  on Entry
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if(Control != null)
            {
                if (Build.VERSION.SdkInt >= BuildVersionCodes.Q)
                {
                    Control.SetTextCursorDrawable(0); //This API Intrduced in android 10
                }
                else
                {
                   IntPtr IntPtrtextViewClass = JNIEnv.FindClass(typeof(TextView));
                IntPtr mCursorDrawableResProperty = JNIEnv.GetFieldID(IntPtrtextViewClass, "mCursorDrawableRes", "I");

                    JNIEnv.SetField(Control.Handle, mCursorDrawableResProperty, Resource.Drawable.cursor);
                }

                //cursor is the xml file name which we defined 

                //remove underline on Entry
                Control.SetBackgroundColor(Android.Graphics.Color.Transparent);
                //Control.Background = null;
            }
        }
    }
}