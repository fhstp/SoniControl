using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Org.Jtransforms.Fft {

	// Metadata.xml XPath class reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='BenchmarkDoubleFFT']"
	[global::Android.Runtime.Register ("org/jtransforms/fft/BenchmarkDoubleFFT", DoNotGenerateAcw=true)]
	public partial class BenchmarkDoubleFFT : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("org/jtransforms/fft/BenchmarkDoubleFFT", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (BenchmarkDoubleFFT); }
		}

		protected BenchmarkDoubleFFT (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_benchmarkComplexForward_1D;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='BenchmarkDoubleFFT']/method[@name='benchmarkComplexForward_1D' and count(parameter)=0]"
		[Register ("benchmarkComplexForward_1D", "()V", "")]
		public static unsafe void BenchmarkComplexForward_1D ()
		{
			if (id_benchmarkComplexForward_1D == IntPtr.Zero)
				id_benchmarkComplexForward_1D = JNIEnv.GetStaticMethodID (class_ref, "benchmarkComplexForward_1D", "()V");
			try {
				JNIEnv.CallStaticVoidMethod  (class_ref, id_benchmarkComplexForward_1D);
			} finally {
			}
		}

		static IntPtr id_benchmarkComplexForward_2D_input_1D;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='BenchmarkDoubleFFT']/method[@name='benchmarkComplexForward_2D_input_1D' and count(parameter)=0]"
		[Register ("benchmarkComplexForward_2D_input_1D", "()V", "")]
		public static unsafe void BenchmarkComplexForward_2D_input_1D ()
		{
			if (id_benchmarkComplexForward_2D_input_1D == IntPtr.Zero)
				id_benchmarkComplexForward_2D_input_1D = JNIEnv.GetStaticMethodID (class_ref, "benchmarkComplexForward_2D_input_1D", "()V");
			try {
				JNIEnv.CallStaticVoidMethod  (class_ref, id_benchmarkComplexForward_2D_input_1D);
			} finally {
			}
		}

		static IntPtr id_benchmarkComplexForward_2D_input_2D;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='BenchmarkDoubleFFT']/method[@name='benchmarkComplexForward_2D_input_2D' and count(parameter)=0]"
		[Register ("benchmarkComplexForward_2D_input_2D", "()V", "")]
		public static unsafe void BenchmarkComplexForward_2D_input_2D ()
		{
			if (id_benchmarkComplexForward_2D_input_2D == IntPtr.Zero)
				id_benchmarkComplexForward_2D_input_2D = JNIEnv.GetStaticMethodID (class_ref, "benchmarkComplexForward_2D_input_2D", "()V");
			try {
				JNIEnv.CallStaticVoidMethod  (class_ref, id_benchmarkComplexForward_2D_input_2D);
			} finally {
			}
		}

		static IntPtr id_benchmarkComplexForward_3D_input_1D;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='BenchmarkDoubleFFT']/method[@name='benchmarkComplexForward_3D_input_1D' and count(parameter)=0]"
		[Register ("benchmarkComplexForward_3D_input_1D", "()V", "")]
		public static unsafe void BenchmarkComplexForward_3D_input_1D ()
		{
			if (id_benchmarkComplexForward_3D_input_1D == IntPtr.Zero)
				id_benchmarkComplexForward_3D_input_1D = JNIEnv.GetStaticMethodID (class_ref, "benchmarkComplexForward_3D_input_1D", "()V");
			try {
				JNIEnv.CallStaticVoidMethod  (class_ref, id_benchmarkComplexForward_3D_input_1D);
			} finally {
			}
		}

		static IntPtr id_benchmarkComplexForward_3D_input_3D;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='BenchmarkDoubleFFT']/method[@name='benchmarkComplexForward_3D_input_3D' and count(parameter)=0]"
		[Register ("benchmarkComplexForward_3D_input_3D", "()V", "")]
		public static unsafe void BenchmarkComplexForward_3D_input_3D ()
		{
			if (id_benchmarkComplexForward_3D_input_3D == IntPtr.Zero)
				id_benchmarkComplexForward_3D_input_3D = JNIEnv.GetStaticMethodID (class_ref, "benchmarkComplexForward_3D_input_3D", "()V");
			try {
				JNIEnv.CallStaticVoidMethod  (class_ref, id_benchmarkComplexForward_3D_input_3D);
			} finally {
			}
		}

		static IntPtr id_benchmarkRealForward_1D;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='BenchmarkDoubleFFT']/method[@name='benchmarkRealForward_1D' and count(parameter)=0]"
		[Register ("benchmarkRealForward_1D", "()V", "")]
		public static unsafe void BenchmarkRealForward_1D ()
		{
			if (id_benchmarkRealForward_1D == IntPtr.Zero)
				id_benchmarkRealForward_1D = JNIEnv.GetStaticMethodID (class_ref, "benchmarkRealForward_1D", "()V");
			try {
				JNIEnv.CallStaticVoidMethod  (class_ref, id_benchmarkRealForward_1D);
			} finally {
			}
		}

		static IntPtr id_benchmarkRealForward_2D_input_1D;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='BenchmarkDoubleFFT']/method[@name='benchmarkRealForward_2D_input_1D' and count(parameter)=0]"
		[Register ("benchmarkRealForward_2D_input_1D", "()V", "")]
		public static unsafe void BenchmarkRealForward_2D_input_1D ()
		{
			if (id_benchmarkRealForward_2D_input_1D == IntPtr.Zero)
				id_benchmarkRealForward_2D_input_1D = JNIEnv.GetStaticMethodID (class_ref, "benchmarkRealForward_2D_input_1D", "()V");
			try {
				JNIEnv.CallStaticVoidMethod  (class_ref, id_benchmarkRealForward_2D_input_1D);
			} finally {
			}
		}

		static IntPtr id_benchmarkRealForward_2D_input_2D;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='BenchmarkDoubleFFT']/method[@name='benchmarkRealForward_2D_input_2D' and count(parameter)=0]"
		[Register ("benchmarkRealForward_2D_input_2D", "()V", "")]
		public static unsafe void BenchmarkRealForward_2D_input_2D ()
		{
			if (id_benchmarkRealForward_2D_input_2D == IntPtr.Zero)
				id_benchmarkRealForward_2D_input_2D = JNIEnv.GetStaticMethodID (class_ref, "benchmarkRealForward_2D_input_2D", "()V");
			try {
				JNIEnv.CallStaticVoidMethod  (class_ref, id_benchmarkRealForward_2D_input_2D);
			} finally {
			}
		}

		static IntPtr id_benchmarkRealForward_3D_input_1D;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='BenchmarkDoubleFFT']/method[@name='benchmarkRealForward_3D_input_1D' and count(parameter)=0]"
		[Register ("benchmarkRealForward_3D_input_1D", "()V", "")]
		public static unsafe void BenchmarkRealForward_3D_input_1D ()
		{
			if (id_benchmarkRealForward_3D_input_1D == IntPtr.Zero)
				id_benchmarkRealForward_3D_input_1D = JNIEnv.GetStaticMethodID (class_ref, "benchmarkRealForward_3D_input_1D", "()V");
			try {
				JNIEnv.CallStaticVoidMethod  (class_ref, id_benchmarkRealForward_3D_input_1D);
			} finally {
			}
		}

		static IntPtr id_benchmarkRealForward_3D_input_3D;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='BenchmarkDoubleFFT']/method[@name='benchmarkRealForward_3D_input_3D' and count(parameter)=0]"
		[Register ("benchmarkRealForward_3D_input_3D", "()V", "")]
		public static unsafe void BenchmarkRealForward_3D_input_3D ()
		{
			if (id_benchmarkRealForward_3D_input_3D == IntPtr.Zero)
				id_benchmarkRealForward_3D_input_3D = JNIEnv.GetStaticMethodID (class_ref, "benchmarkRealForward_3D_input_3D", "()V");
			try {
				JNIEnv.CallStaticVoidMethod  (class_ref, id_benchmarkRealForward_3D_input_3D);
			} finally {
			}
		}

		static IntPtr id_main_arrayLjava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='BenchmarkDoubleFFT']/method[@name='main' and count(parameter)=1 and parameter[1][@type='java.lang.String[]']]"
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
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='BenchmarkDoubleFFT']/method[@name='parseArguments' and count(parameter)=1 and parameter[1][@type='java.lang.String[]']]"
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
