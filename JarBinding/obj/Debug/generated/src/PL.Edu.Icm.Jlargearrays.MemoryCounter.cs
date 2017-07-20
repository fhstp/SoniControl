using System;
using System.Collections.Generic;
using Android.Runtime;

namespace PL.Edu.Icm.Jlargearrays {

	// Metadata.xml XPath class reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='MemoryCounter']"
	[global::Android.Runtime.Register ("pl/edu/icm/jlargearrays/MemoryCounter", DoNotGenerateAcw=true)]
	public partial class MemoryCounter : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("pl/edu/icm/jlargearrays/MemoryCounter", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (MemoryCounter); }
		}

		protected MemoryCounter (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_getCounter;
		public static unsafe long Counter {
			// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='MemoryCounter']/method[@name='getCounter' and count(parameter)=0]"
			[Register ("getCounter", "()J", "GetGetCounterHandler")]
			get {
				if (id_getCounter == IntPtr.Zero)
					id_getCounter = JNIEnv.GetStaticMethodID (class_ref, "getCounter", "()J");
				try {
					return JNIEnv.CallStaticLongMethod  (class_ref, id_getCounter);
				} finally {
				}
			}
		}

		static IntPtr id_decreaseCounter_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='MemoryCounter']/method[@name='decreaseCounter' and count(parameter)=1 and parameter[1][@type='long']]"
		[Register ("decreaseCounter", "(J)V", "")]
		public static unsafe void DecreaseCounter (long p0)
		{
			if (id_decreaseCounter_J == IntPtr.Zero)
				id_decreaseCounter_J = JNIEnv.GetStaticMethodID (class_ref, "decreaseCounter", "(J)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_decreaseCounter_J, __args);
			} finally {
			}
		}

		static IntPtr id_increaseCounter_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='MemoryCounter']/method[@name='increaseCounter' and count(parameter)=1 and parameter[1][@type='long']]"
		[Register ("increaseCounter", "(J)V", "")]
		public static unsafe void IncreaseCounter (long p0)
		{
			if (id_increaseCounter_J == IntPtr.Zero)
				id_increaseCounter_J = JNIEnv.GetStaticMethodID (class_ref, "increaseCounter", "(J)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_increaseCounter_J, __args);
			} finally {
			}
		}

	}
}
