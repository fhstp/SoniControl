using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Org.Apache.Commons.Math3.Exception.Util {

	// Metadata.xml XPath class reference: path="/api/package[@name='org.apache.commons.math3.exception.util']/class[@name='ArgUtils']"
	[global::Android.Runtime.Register ("org/apache/commons/math3/exception/util/ArgUtils", DoNotGenerateAcw=true)]
	public partial class ArgUtils : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("org/apache/commons/math3/exception/util/ArgUtils", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (ArgUtils); }
		}

		protected ArgUtils (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_flatten_arrayLjava_lang_Object_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.exception.util']/class[@name='ArgUtils']/method[@name='flatten' and count(parameter)=1 and parameter[1][@type='java.lang.Object[]']]"
		[Register ("flatten", "([Ljava/lang/Object;)[Ljava/lang/Object;", "")]
		public static unsafe global::Java.Lang.Object[] Flatten (global::Java.Lang.Object[] p0)
		{
			if (id_flatten_arrayLjava_lang_Object_ == IntPtr.Zero)
				id_flatten_arrayLjava_lang_Object_ = JNIEnv.GetStaticMethodID (class_ref, "flatten", "([Ljava/lang/Object;)[Ljava/lang/Object;");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				global::Java.Lang.Object[] __ret = (global::Java.Lang.Object[]) JNIEnv.GetArray (JNIEnv.CallStaticObjectMethod  (class_ref, id_flatten_arrayLjava_lang_Object_, __args), JniHandleOwnership.TransferLocalRef, typeof (global::Java.Lang.Object));
				return __ret;
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

	}
}
