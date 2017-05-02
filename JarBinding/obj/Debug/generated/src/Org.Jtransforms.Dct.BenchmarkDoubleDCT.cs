using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Org.Jtransforms.Dct {

	// Metadata.xml XPath class reference: path="/api/package[@name='org.jtransforms.dct']/class[@name='BenchmarkDoubleDCT']"
	[global::Android.Runtime.Register ("org/jtransforms/dct/BenchmarkDoubleDCT", DoNotGenerateAcw=true)]
	public partial class BenchmarkDoubleDCT : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("org/jtransforms/dct/BenchmarkDoubleDCT", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (BenchmarkDoubleDCT); }
		}

		protected BenchmarkDoubleDCT (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_benchmarkForward_1D;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.dct']/class[@name='BenchmarkDoubleDCT']/method[@name='benchmarkForward_1D' and count(parameter)=0]"
		[Register ("benchmarkForward_1D", "()V", "")]
		public static unsafe void BenchmarkForward_1D ()
		{
			if (id_benchmarkForward_1D == IntPtr.Zero)
				id_benchmarkForward_1D = JNIEnv.GetStaticMethodID (class_ref, "benchmarkForward_1D", "()V");
			try {
				JNIEnv.CallStaticVoidMethod  (class_ref, id_benchmarkForward_1D);
			} finally {
			}
		}

		static IntPtr id_benchmarkForward_2D_input_1D;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.dct']/class[@name='BenchmarkDoubleDCT']/method[@name='benchmarkForward_2D_input_1D' and count(parameter)=0]"
		[Register ("benchmarkForward_2D_input_1D", "()V", "")]
		public static unsafe void BenchmarkForward_2D_input_1D ()
		{
			if (id_benchmarkForward_2D_input_1D == IntPtr.Zero)
				id_benchmarkForward_2D_input_1D = JNIEnv.GetStaticMethodID (class_ref, "benchmarkForward_2D_input_1D", "()V");
			try {
				JNIEnv.CallStaticVoidMethod  (class_ref, id_benchmarkForward_2D_input_1D);
			} finally {
			}
		}

		static IntPtr id_benchmarkForward_2D_input_2D;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.dct']/class[@name='BenchmarkDoubleDCT']/method[@name='benchmarkForward_2D_input_2D' and count(parameter)=0]"
		[Register ("benchmarkForward_2D_input_2D", "()V", "")]
		public static unsafe void BenchmarkForward_2D_input_2D ()
		{
			if (id_benchmarkForward_2D_input_2D == IntPtr.Zero)
				id_benchmarkForward_2D_input_2D = JNIEnv.GetStaticMethodID (class_ref, "benchmarkForward_2D_input_2D", "()V");
			try {
				JNIEnv.CallStaticVoidMethod  (class_ref, id_benchmarkForward_2D_input_2D);
			} finally {
			}
		}

		static IntPtr id_benchmarkForward_3D_input_1D;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.dct']/class[@name='BenchmarkDoubleDCT']/method[@name='benchmarkForward_3D_input_1D' and count(parameter)=0]"
		[Register ("benchmarkForward_3D_input_1D", "()V", "")]
		public static unsafe void BenchmarkForward_3D_input_1D ()
		{
			if (id_benchmarkForward_3D_input_1D == IntPtr.Zero)
				id_benchmarkForward_3D_input_1D = JNIEnv.GetStaticMethodID (class_ref, "benchmarkForward_3D_input_1D", "()V");
			try {
				JNIEnv.CallStaticVoidMethod  (class_ref, id_benchmarkForward_3D_input_1D);
			} finally {
			}
		}

		static IntPtr id_benchmarkForward_3D_input_3D;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.dct']/class[@name='BenchmarkDoubleDCT']/method[@name='benchmarkForward_3D_input_3D' and count(parameter)=0]"
		[Register ("benchmarkForward_3D_input_3D", "()V", "")]
		public static unsafe void BenchmarkForward_3D_input_3D ()
		{
			if (id_benchmarkForward_3D_input_3D == IntPtr.Zero)
				id_benchmarkForward_3D_input_3D = JNIEnv.GetStaticMethodID (class_ref, "benchmarkForward_3D_input_3D", "()V");
			try {
				JNIEnv.CallStaticVoidMethod  (class_ref, id_benchmarkForward_3D_input_3D);
			} finally {
			}
		}

		static IntPtr id_main_arrayLjava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.dct']/class[@name='BenchmarkDoubleDCT']/method[@name='main' and count(parameter)=1 and parameter[1][@type='java.lang.String[]']]"
		[Register ("main", "([Ljava/lang/String;)V", "")]
		public static unsafe void Main (string[] p0)
		{
			if (id_main_arrayLjava_lang_String_ == IntPtr.Zero)
				id_main_arrayLjava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "main", "([Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_main_arrayLjava_lang_String_, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static IntPtr id_parseArguments_arrayLjava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.dct']/class[@name='BenchmarkDoubleDCT']/method[@name='parseArguments' and count(parameter)=1 and parameter[1][@type='java.lang.String[]']]"
		[Register ("parseArguments", "([Ljava/lang/String;)V", "")]
		public static unsafe void ParseArguments (string[] p0)
		{
			if (id_parseArguments_arrayLjava_lang_String_ == IntPtr.Zero)
				id_parseArguments_arrayLjava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "parseArguments", "([Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_parseArguments_arrayLjava_lang_String_, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

	}
}
