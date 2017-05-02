using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Org.Jtransforms.Utils {

	// Metadata.xml XPath class reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']"
	[global::Android.Runtime.Register ("org/jtransforms/utils/CommonUtils", DoNotGenerateAcw=true)]
	public partial class CommonUtils : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("org/jtransforms/utils/CommonUtils", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (CommonUtils); }
		}

		protected CommonUtils (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/constructor[@name='CommonUtils' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe CommonUtils ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (((object) this).GetType () != typeof (CommonUtils)) {
					SetHandle (
							global::Android.Runtime.JNIEnv.StartCreateInstance (((object) this).GetType (), "()V"),
							JniHandleOwnership.TransferLocalRef);
					global::Android.Runtime.JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, "()V");
					return;
				}

				if (id_ctor == IntPtr.Zero)
					id_ctor = JNIEnv.GetMethodID (class_ref, "<init>", "()V");
				SetHandle (
						global::Android.Runtime.JNIEnv.StartCreateInstance (class_ref, id_ctor),
						JniHandleOwnership.TransferLocalRef);
				JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, class_ref, id_ctor);
			} finally {
			}
		}

		static IntPtr id_getThreadsBeginN_1D_FFT_2Threads;
		static IntPtr id_setThreadsBeginN_1D_FFT_2Threads_J;
		public static unsafe long ThreadsBeginN_1D_FFT_2Threads {
			// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='getThreadsBeginN_1D_FFT_2Threads' and count(parameter)=0]"
			[Register ("getThreadsBeginN_1D_FFT_2Threads", "()J", "GetGetThreadsBeginN_1D_FFT_2ThreadsHandler")]
			get {
				if (id_getThreadsBeginN_1D_FFT_2Threads == IntPtr.Zero)
					id_getThreadsBeginN_1D_FFT_2Threads = JNIEnv.GetStaticMethodID (class_ref, "getThreadsBeginN_1D_FFT_2Threads", "()J");
				try {
					return JNIEnv.CallStaticLongMethod  (class_ref, id_getThreadsBeginN_1D_FFT_2Threads);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='setThreadsBeginN_1D_FFT_2Threads' and count(parameter)=1 and parameter[1][@type='long']]"
			[Register ("setThreadsBeginN_1D_FFT_2Threads", "(J)V", "GetSetThreadsBeginN_1D_FFT_2Threads_JHandler")]
			set {
				if (id_setThreadsBeginN_1D_FFT_2Threads_J == IntPtr.Zero)
					id_setThreadsBeginN_1D_FFT_2Threads_J = JNIEnv.GetStaticMethodID (class_ref, "setThreadsBeginN_1D_FFT_2Threads", "(J)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);
					JNIEnv.CallStaticVoidMethod  (class_ref, id_setThreadsBeginN_1D_FFT_2Threads_J, __args);
				} finally {
				}
			}
		}

		static IntPtr id_getThreadsBeginN_1D_FFT_4Threads;
		static IntPtr id_setThreadsBeginN_1D_FFT_4Threads_J;
		public static unsafe long ThreadsBeginN_1D_FFT_4Threads {
			// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='getThreadsBeginN_1D_FFT_4Threads' and count(parameter)=0]"
			[Register ("getThreadsBeginN_1D_FFT_4Threads", "()J", "GetGetThreadsBeginN_1D_FFT_4ThreadsHandler")]
			get {
				if (id_getThreadsBeginN_1D_FFT_4Threads == IntPtr.Zero)
					id_getThreadsBeginN_1D_FFT_4Threads = JNIEnv.GetStaticMethodID (class_ref, "getThreadsBeginN_1D_FFT_4Threads", "()J");
				try {
					return JNIEnv.CallStaticLongMethod  (class_ref, id_getThreadsBeginN_1D_FFT_4Threads);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='setThreadsBeginN_1D_FFT_4Threads' and count(parameter)=1 and parameter[1][@type='long']]"
			[Register ("setThreadsBeginN_1D_FFT_4Threads", "(J)V", "GetSetThreadsBeginN_1D_FFT_4Threads_JHandler")]
			set {
				if (id_setThreadsBeginN_1D_FFT_4Threads_J == IntPtr.Zero)
					id_setThreadsBeginN_1D_FFT_4Threads_J = JNIEnv.GetStaticMethodID (class_ref, "setThreadsBeginN_1D_FFT_4Threads", "(J)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);
					JNIEnv.CallStaticVoidMethod  (class_ref, id_setThreadsBeginN_1D_FFT_4Threads_J, __args);
				} finally {
				}
			}
		}

		static IntPtr id_getThreadsBeginN_2D;
		static IntPtr id_setThreadsBeginN_2D_J;
		public static unsafe long ThreadsBeginN_2D {
			// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='getThreadsBeginN_2D' and count(parameter)=0]"
			[Register ("getThreadsBeginN_2D", "()J", "GetGetThreadsBeginN_2DHandler")]
			get {
				if (id_getThreadsBeginN_2D == IntPtr.Zero)
					id_getThreadsBeginN_2D = JNIEnv.GetStaticMethodID (class_ref, "getThreadsBeginN_2D", "()J");
				try {
					return JNIEnv.CallStaticLongMethod  (class_ref, id_getThreadsBeginN_2D);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='setThreadsBeginN_2D' and count(parameter)=1 and parameter[1][@type='long']]"
			[Register ("setThreadsBeginN_2D", "(J)V", "GetSetThreadsBeginN_2D_JHandler")]
			set {
				if (id_setThreadsBeginN_2D_J == IntPtr.Zero)
					id_setThreadsBeginN_2D_J = JNIEnv.GetStaticMethodID (class_ref, "setThreadsBeginN_2D", "(J)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);
					JNIEnv.CallStaticVoidMethod  (class_ref, id_setThreadsBeginN_2D_J, __args);
				} finally {
				}
			}
		}

		static IntPtr id_getThreadsBeginN_3D;
		static IntPtr id_setThreadsBeginN_3D_J;
		public static unsafe long ThreadsBeginN_3D {
			// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='getThreadsBeginN_3D' and count(parameter)=0]"
			[Register ("getThreadsBeginN_3D", "()J", "GetGetThreadsBeginN_3DHandler")]
			get {
				if (id_getThreadsBeginN_3D == IntPtr.Zero)
					id_getThreadsBeginN_3D = JNIEnv.GetStaticMethodID (class_ref, "getThreadsBeginN_3D", "()J");
				try {
					return JNIEnv.CallStaticLongMethod  (class_ref, id_getThreadsBeginN_3D);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='setThreadsBeginN_3D' and count(parameter)=1 and parameter[1][@type='long']]"
			[Register ("setThreadsBeginN_3D", "(J)V", "GetSetThreadsBeginN_3D_JHandler")]
			set {
				if (id_setThreadsBeginN_3D_J == IntPtr.Zero)
					id_setThreadsBeginN_3D_J = JNIEnv.GetStaticMethodID (class_ref, "setThreadsBeginN_3D", "(J)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);
					JNIEnv.CallStaticVoidMethod  (class_ref, id_setThreadsBeginN_3D_J, __args);
				} finally {
				}
			}
		}

		static IntPtr id_isUseLargeArrays;
		static IntPtr id_setUseLargeArrays_Z;
		public static unsafe bool UseLargeArrays {
			// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='isUseLargeArrays' and count(parameter)=0]"
			[Register ("isUseLargeArrays", "()Z", "GetIsUseLargeArraysHandler")]
			get {
				if (id_isUseLargeArrays == IntPtr.Zero)
					id_isUseLargeArrays = JNIEnv.GetStaticMethodID (class_ref, "isUseLargeArrays", "()Z");
				try {
					return JNIEnv.CallStaticBooleanMethod  (class_ref, id_isUseLargeArrays);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='setUseLargeArrays' and count(parameter)=1 and parameter[1][@type='boolean']]"
			[Register ("setUseLargeArrays", "(Z)V", "GetSetUseLargeArrays_ZHandler")]
			set {
				if (id_setUseLargeArrays_Z == IntPtr.Zero)
					id_setUseLargeArrays_Z = JNIEnv.GetStaticMethodID (class_ref, "setUseLargeArrays", "(Z)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);
					JNIEnv.CallStaticVoidMethod  (class_ref, id_setUseLargeArrays_Z, __args);
				} finally {
				}
			}
		}

		static IntPtr id_bitrv208_arrayDI;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='bitrv208' and count(parameter)=2 and parameter[1][@type='double[]'] and parameter[2][@type='int']]"
		[Register ("bitrv208", "([DI)V", "")]
		public static unsafe void Bitrv208 (double[] p0, int p1)
		{
			if (id_bitrv208_arrayDI == IntPtr.Zero)
				id_bitrv208_arrayDI = JNIEnv.GetStaticMethodID (class_ref, "bitrv208", "([DI)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_bitrv208_arrayDI, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static IntPtr id_bitrv208_arrayFI;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='bitrv208' and count(parameter)=2 and parameter[1][@type='float[]'] and parameter[2][@type='int']]"
		[Register ("bitrv208", "([FI)V", "")]
		public static unsafe void Bitrv208 (float[] p0, int p1)
		{
			if (id_bitrv208_arrayFI == IntPtr.Zero)
				id_bitrv208_arrayFI = JNIEnv.GetStaticMethodID (class_ref, "bitrv208", "([FI)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_bitrv208_arrayFI, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static IntPtr id_bitrv208_Lpl_edu_icm_jlargearrays_DoubleLargeArray_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='bitrv208' and count(parameter)=2 and parameter[1][@type='pl.edu.icm.jlargearrays.DoubleLargeArray'] and parameter[2][@type='long']]"
		[Register ("bitrv208", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;J)V", "")]
		public static unsafe void Bitrv208 (global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p0, long p1)
		{
			if (id_bitrv208_Lpl_edu_icm_jlargearrays_DoubleLargeArray_J == IntPtr.Zero)
				id_bitrv208_Lpl_edu_icm_jlargearrays_DoubleLargeArray_J = JNIEnv.GetStaticMethodID (class_ref, "bitrv208", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;J)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_bitrv208_Lpl_edu_icm_jlargearrays_DoubleLargeArray_J, __args);
			} finally {
			}
		}

		static IntPtr id_bitrv208_Lpl_edu_icm_jlargearrays_FloatLargeArray_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='bitrv208' and count(parameter)=2 and parameter[1][@type='pl.edu.icm.jlargearrays.FloatLargeArray'] and parameter[2][@type='long']]"
		[Register ("bitrv208", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;J)V", "")]
		public static unsafe void Bitrv208 (global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p0, long p1)
		{
			if (id_bitrv208_Lpl_edu_icm_jlargearrays_FloatLargeArray_J == IntPtr.Zero)
				id_bitrv208_Lpl_edu_icm_jlargearrays_FloatLargeArray_J = JNIEnv.GetStaticMethodID (class_ref, "bitrv208", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;J)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_bitrv208_Lpl_edu_icm_jlargearrays_FloatLargeArray_J, __args);
			} finally {
			}
		}

		static IntPtr id_bitrv208neg_arrayDI;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='bitrv208neg' and count(parameter)=2 and parameter[1][@type='double[]'] and parameter[2][@type='int']]"
		[Register ("bitrv208neg", "([DI)V", "")]
		public static unsafe void Bitrv208neg (double[] p0, int p1)
		{
			if (id_bitrv208neg_arrayDI == IntPtr.Zero)
				id_bitrv208neg_arrayDI = JNIEnv.GetStaticMethodID (class_ref, "bitrv208neg", "([DI)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_bitrv208neg_arrayDI, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static IntPtr id_bitrv208neg_arrayFI;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='bitrv208neg' and count(parameter)=2 and parameter[1][@type='float[]'] and parameter[2][@type='int']]"
		[Register ("bitrv208neg", "([FI)V", "")]
		public static unsafe void Bitrv208neg (float[] p0, int p1)
		{
			if (id_bitrv208neg_arrayFI == IntPtr.Zero)
				id_bitrv208neg_arrayFI = JNIEnv.GetStaticMethodID (class_ref, "bitrv208neg", "([FI)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_bitrv208neg_arrayFI, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static IntPtr id_bitrv208neg_Lpl_edu_icm_jlargearrays_DoubleLargeArray_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='bitrv208neg' and count(parameter)=2 and parameter[1][@type='pl.edu.icm.jlargearrays.DoubleLargeArray'] and parameter[2][@type='long']]"
		[Register ("bitrv208neg", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;J)V", "")]
		public static unsafe void Bitrv208neg (global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p0, long p1)
		{
			if (id_bitrv208neg_Lpl_edu_icm_jlargearrays_DoubleLargeArray_J == IntPtr.Zero)
				id_bitrv208neg_Lpl_edu_icm_jlargearrays_DoubleLargeArray_J = JNIEnv.GetStaticMethodID (class_ref, "bitrv208neg", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;J)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_bitrv208neg_Lpl_edu_icm_jlargearrays_DoubleLargeArray_J, __args);
			} finally {
			}
		}

		static IntPtr id_bitrv208neg_Lpl_edu_icm_jlargearrays_FloatLargeArray_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='bitrv208neg' and count(parameter)=2 and parameter[1][@type='pl.edu.icm.jlargearrays.FloatLargeArray'] and parameter[2][@type='long']]"
		[Register ("bitrv208neg", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;J)V", "")]
		public static unsafe void Bitrv208neg (global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p0, long p1)
		{
			if (id_bitrv208neg_Lpl_edu_icm_jlargearrays_FloatLargeArray_J == IntPtr.Zero)
				id_bitrv208neg_Lpl_edu_icm_jlargearrays_FloatLargeArray_J = JNIEnv.GetStaticMethodID (class_ref, "bitrv208neg", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;J)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_bitrv208neg_Lpl_edu_icm_jlargearrays_FloatLargeArray_J, __args);
			} finally {
			}
		}

		static IntPtr id_bitrv216_arrayDI;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='bitrv216' and count(parameter)=2 and parameter[1][@type='double[]'] and parameter[2][@type='int']]"
		[Register ("bitrv216", "([DI)V", "")]
		public static unsafe void Bitrv216 (double[] p0, int p1)
		{
			if (id_bitrv216_arrayDI == IntPtr.Zero)
				id_bitrv216_arrayDI = JNIEnv.GetStaticMethodID (class_ref, "bitrv216", "([DI)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_bitrv216_arrayDI, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static IntPtr id_bitrv216_arrayFI;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='bitrv216' and count(parameter)=2 and parameter[1][@type='float[]'] and parameter[2][@type='int']]"
		[Register ("bitrv216", "([FI)V", "")]
		public static unsafe void Bitrv216 (float[] p0, int p1)
		{
			if (id_bitrv216_arrayFI == IntPtr.Zero)
				id_bitrv216_arrayFI = JNIEnv.GetStaticMethodID (class_ref, "bitrv216", "([FI)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_bitrv216_arrayFI, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static IntPtr id_bitrv216_Lpl_edu_icm_jlargearrays_DoubleLargeArray_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='bitrv216' and count(parameter)=2 and parameter[1][@type='pl.edu.icm.jlargearrays.DoubleLargeArray'] and parameter[2][@type='long']]"
		[Register ("bitrv216", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;J)V", "")]
		public static unsafe void Bitrv216 (global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p0, long p1)
		{
			if (id_bitrv216_Lpl_edu_icm_jlargearrays_DoubleLargeArray_J == IntPtr.Zero)
				id_bitrv216_Lpl_edu_icm_jlargearrays_DoubleLargeArray_J = JNIEnv.GetStaticMethodID (class_ref, "bitrv216", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;J)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_bitrv216_Lpl_edu_icm_jlargearrays_DoubleLargeArray_J, __args);
			} finally {
			}
		}

		static IntPtr id_bitrv216_Lpl_edu_icm_jlargearrays_FloatLargeArray_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='bitrv216' and count(parameter)=2 and parameter[1][@type='pl.edu.icm.jlargearrays.FloatLargeArray'] and parameter[2][@type='long']]"
		[Register ("bitrv216", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;J)V", "")]
		public static unsafe void Bitrv216 (global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p0, long p1)
		{
			if (id_bitrv216_Lpl_edu_icm_jlargearrays_FloatLargeArray_J == IntPtr.Zero)
				id_bitrv216_Lpl_edu_icm_jlargearrays_FloatLargeArray_J = JNIEnv.GetStaticMethodID (class_ref, "bitrv216", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;J)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_bitrv216_Lpl_edu_icm_jlargearrays_FloatLargeArray_J, __args);
			} finally {
			}
		}

		static IntPtr id_bitrv216neg_arrayDI;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='bitrv216neg' and count(parameter)=2 and parameter[1][@type='double[]'] and parameter[2][@type='int']]"
		[Register ("bitrv216neg", "([DI)V", "")]
		public static unsafe void Bitrv216neg (double[] p0, int p1)
		{
			if (id_bitrv216neg_arrayDI == IntPtr.Zero)
				id_bitrv216neg_arrayDI = JNIEnv.GetStaticMethodID (class_ref, "bitrv216neg", "([DI)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_bitrv216neg_arrayDI, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static IntPtr id_bitrv216neg_arrayFI;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='bitrv216neg' and count(parameter)=2 and parameter[1][@type='float[]'] and parameter[2][@type='int']]"
		[Register ("bitrv216neg", "([FI)V", "")]
		public static unsafe void Bitrv216neg (float[] p0, int p1)
		{
			if (id_bitrv216neg_arrayFI == IntPtr.Zero)
				id_bitrv216neg_arrayFI = JNIEnv.GetStaticMethodID (class_ref, "bitrv216neg", "([FI)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_bitrv216neg_arrayFI, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static IntPtr id_bitrv216neg_Lpl_edu_icm_jlargearrays_DoubleLargeArray_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='bitrv216neg' and count(parameter)=2 and parameter[1][@type='pl.edu.icm.jlargearrays.DoubleLargeArray'] and parameter[2][@type='long']]"
		[Register ("bitrv216neg", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;J)V", "")]
		public static unsafe void Bitrv216neg (global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p0, long p1)
		{
			if (id_bitrv216neg_Lpl_edu_icm_jlargearrays_DoubleLargeArray_J == IntPtr.Zero)
				id_bitrv216neg_Lpl_edu_icm_jlargearrays_DoubleLargeArray_J = JNIEnv.GetStaticMethodID (class_ref, "bitrv216neg", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;J)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_bitrv216neg_Lpl_edu_icm_jlargearrays_DoubleLargeArray_J, __args);
			} finally {
			}
		}

		static IntPtr id_bitrv216neg_Lpl_edu_icm_jlargearrays_FloatLargeArray_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='bitrv216neg' and count(parameter)=2 and parameter[1][@type='pl.edu.icm.jlargearrays.FloatLargeArray'] and parameter[2][@type='long']]"
		[Register ("bitrv216neg", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;J)V", "")]
		public static unsafe void Bitrv216neg (global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p0, long p1)
		{
			if (id_bitrv216neg_Lpl_edu_icm_jlargearrays_FloatLargeArray_J == IntPtr.Zero)
				id_bitrv216neg_Lpl_edu_icm_jlargearrays_FloatLargeArray_J = JNIEnv.GetStaticMethodID (class_ref, "bitrv216neg", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;J)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_bitrv216neg_Lpl_edu_icm_jlargearrays_FloatLargeArray_J, __args);
			} finally {
			}
		}

		static IntPtr id_bitrv2_IarrayIarrayDI;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='bitrv2' and count(parameter)=4 and parameter[1][@type='int'] and parameter[2][@type='int[]'] and parameter[3][@type='double[]'] and parameter[4][@type='int']]"
		[Register ("bitrv2", "(I[I[DI)V", "")]
		public static unsafe void Bitrv2 (int p0, int[] p1, double[] p2, int p3)
		{
			if (id_bitrv2_IarrayIarrayDI == IntPtr.Zero)
				id_bitrv2_IarrayIarrayDI = JNIEnv.GetStaticMethodID (class_ref, "bitrv2", "(I[I[DI)V");
			IntPtr native_p1 = JNIEnv.NewArray (p1);
			IntPtr native_p2 = JNIEnv.NewArray (p2);
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (native_p2);
				__args [3] = new JValue (p3);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_bitrv2_IarrayIarrayDI, __args);
			} finally {
				if (p1 != null) {
					JNIEnv.CopyArray (native_p1, p1);
					JNIEnv.DeleteLocalRef (native_p1);
				}
				if (p2 != null) {
					JNIEnv.CopyArray (native_p2, p2);
					JNIEnv.DeleteLocalRef (native_p2);
				}
			}
		}

		static IntPtr id_bitrv2_IarrayIarrayFI;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='bitrv2' and count(parameter)=4 and parameter[1][@type='int'] and parameter[2][@type='int[]'] and parameter[3][@type='float[]'] and parameter[4][@type='int']]"
		[Register ("bitrv2", "(I[I[FI)V", "")]
		public static unsafe void Bitrv2 (int p0, int[] p1, float[] p2, int p3)
		{
			if (id_bitrv2_IarrayIarrayFI == IntPtr.Zero)
				id_bitrv2_IarrayIarrayFI = JNIEnv.GetStaticMethodID (class_ref, "bitrv2", "(I[I[FI)V");
			IntPtr native_p1 = JNIEnv.NewArray (p1);
			IntPtr native_p2 = JNIEnv.NewArray (p2);
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (native_p2);
				__args [3] = new JValue (p3);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_bitrv2_IarrayIarrayFI, __args);
			} finally {
				if (p1 != null) {
					JNIEnv.CopyArray (native_p1, p1);
					JNIEnv.DeleteLocalRef (native_p1);
				}
				if (p2 != null) {
					JNIEnv.CopyArray (native_p2, p2);
					JNIEnv.DeleteLocalRef (native_p2);
				}
			}
		}

		static IntPtr id_bitrv2conj_IarrayIarrayDI;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='bitrv2conj' and count(parameter)=4 and parameter[1][@type='int'] and parameter[2][@type='int[]'] and parameter[3][@type='double[]'] and parameter[4][@type='int']]"
		[Register ("bitrv2conj", "(I[I[DI)V", "")]
		public static unsafe void Bitrv2conj (int p0, int[] p1, double[] p2, int p3)
		{
			if (id_bitrv2conj_IarrayIarrayDI == IntPtr.Zero)
				id_bitrv2conj_IarrayIarrayDI = JNIEnv.GetStaticMethodID (class_ref, "bitrv2conj", "(I[I[DI)V");
			IntPtr native_p1 = JNIEnv.NewArray (p1);
			IntPtr native_p2 = JNIEnv.NewArray (p2);
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (native_p2);
				__args [3] = new JValue (p3);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_bitrv2conj_IarrayIarrayDI, __args);
			} finally {
				if (p1 != null) {
					JNIEnv.CopyArray (native_p1, p1);
					JNIEnv.DeleteLocalRef (native_p1);
				}
				if (p2 != null) {
					JNIEnv.CopyArray (native_p2, p2);
					JNIEnv.DeleteLocalRef (native_p2);
				}
			}
		}

		static IntPtr id_bitrv2conj_IarrayIarrayFI;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='bitrv2conj' and count(parameter)=4 and parameter[1][@type='int'] and parameter[2][@type='int[]'] and parameter[3][@type='float[]'] and parameter[4][@type='int']]"
		[Register ("bitrv2conj", "(I[I[FI)V", "")]
		public static unsafe void Bitrv2conj (int p0, int[] p1, float[] p2, int p3)
		{
			if (id_bitrv2conj_IarrayIarrayFI == IntPtr.Zero)
				id_bitrv2conj_IarrayIarrayFI = JNIEnv.GetStaticMethodID (class_ref, "bitrv2conj", "(I[I[FI)V");
			IntPtr native_p1 = JNIEnv.NewArray (p1);
			IntPtr native_p2 = JNIEnv.NewArray (p2);
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (native_p2);
				__args [3] = new JValue (p3);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_bitrv2conj_IarrayIarrayFI, __args);
			} finally {
				if (p1 != null) {
					JNIEnv.CopyArray (native_p1, p1);
					JNIEnv.DeleteLocalRef (native_p1);
				}
				if (p2 != null) {
					JNIEnv.CopyArray (native_p2, p2);
					JNIEnv.DeleteLocalRef (native_p2);
				}
			}
		}

		static IntPtr id_bitrv2conj_JLpl_edu_icm_jlargearrays_LongLargeArray_Lpl_edu_icm_jlargearrays_DoubleLargeArray_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='bitrv2conj' and count(parameter)=4 and parameter[1][@type='long'] and parameter[2][@type='pl.edu.icm.jlargearrays.LongLargeArray'] and parameter[3][@type='pl.edu.icm.jlargearrays.DoubleLargeArray'] and parameter[4][@type='long']]"
		[Register ("bitrv2conj", "(JLpl/edu/icm/jlargearrays/LongLargeArray;Lpl/edu/icm/jlargearrays/DoubleLargeArray;J)V", "")]
		public static unsafe void Bitrv2conj (long p0, global::PL.Edu.Icm.Jlargearrays.LongLargeArray p1, global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p2, long p3)
		{
			if (id_bitrv2conj_JLpl_edu_icm_jlargearrays_LongLargeArray_Lpl_edu_icm_jlargearrays_DoubleLargeArray_J == IntPtr.Zero)
				id_bitrv2conj_JLpl_edu_icm_jlargearrays_LongLargeArray_Lpl_edu_icm_jlargearrays_DoubleLargeArray_J = JNIEnv.GetStaticMethodID (class_ref, "bitrv2conj", "(JLpl/edu/icm/jlargearrays/LongLargeArray;Lpl/edu/icm/jlargearrays/DoubleLargeArray;J)V");
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_bitrv2conj_JLpl_edu_icm_jlargearrays_LongLargeArray_Lpl_edu_icm_jlargearrays_DoubleLargeArray_J, __args);
			} finally {
			}
		}

		static IntPtr id_bitrv2conj_JLpl_edu_icm_jlargearrays_LongLargeArray_Lpl_edu_icm_jlargearrays_FloatLargeArray_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='bitrv2conj' and count(parameter)=4 and parameter[1][@type='long'] and parameter[2][@type='pl.edu.icm.jlargearrays.LongLargeArray'] and parameter[3][@type='pl.edu.icm.jlargearrays.FloatLargeArray'] and parameter[4][@type='long']]"
		[Register ("bitrv2conj", "(JLpl/edu/icm/jlargearrays/LongLargeArray;Lpl/edu/icm/jlargearrays/FloatLargeArray;J)V", "")]
		public static unsafe void Bitrv2conj (long p0, global::PL.Edu.Icm.Jlargearrays.LongLargeArray p1, global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p2, long p3)
		{
			if (id_bitrv2conj_JLpl_edu_icm_jlargearrays_LongLargeArray_Lpl_edu_icm_jlargearrays_FloatLargeArray_J == IntPtr.Zero)
				id_bitrv2conj_JLpl_edu_icm_jlargearrays_LongLargeArray_Lpl_edu_icm_jlargearrays_FloatLargeArray_J = JNIEnv.GetStaticMethodID (class_ref, "bitrv2conj", "(JLpl/edu/icm/jlargearrays/LongLargeArray;Lpl/edu/icm/jlargearrays/FloatLargeArray;J)V");
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_bitrv2conj_JLpl_edu_icm_jlargearrays_LongLargeArray_Lpl_edu_icm_jlargearrays_FloatLargeArray_J, __args);
			} finally {
			}
		}

		static IntPtr id_bitrv2l_JLpl_edu_icm_jlargearrays_LongLargeArray_Lpl_edu_icm_jlargearrays_DoubleLargeArray_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='bitrv2l' and count(parameter)=4 and parameter[1][@type='long'] and parameter[2][@type='pl.edu.icm.jlargearrays.LongLargeArray'] and parameter[3][@type='pl.edu.icm.jlargearrays.DoubleLargeArray'] and parameter[4][@type='long']]"
		[Register ("bitrv2l", "(JLpl/edu/icm/jlargearrays/LongLargeArray;Lpl/edu/icm/jlargearrays/DoubleLargeArray;J)V", "")]
		public static unsafe void Bitrv2l (long p0, global::PL.Edu.Icm.Jlargearrays.LongLargeArray p1, global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p2, long p3)
		{
			if (id_bitrv2l_JLpl_edu_icm_jlargearrays_LongLargeArray_Lpl_edu_icm_jlargearrays_DoubleLargeArray_J == IntPtr.Zero)
				id_bitrv2l_JLpl_edu_icm_jlargearrays_LongLargeArray_Lpl_edu_icm_jlargearrays_DoubleLargeArray_J = JNIEnv.GetStaticMethodID (class_ref, "bitrv2l", "(JLpl/edu/icm/jlargearrays/LongLargeArray;Lpl/edu/icm/jlargearrays/DoubleLargeArray;J)V");
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_bitrv2l_JLpl_edu_icm_jlargearrays_LongLargeArray_Lpl_edu_icm_jlargearrays_DoubleLargeArray_J, __args);
			} finally {
			}
		}

		static IntPtr id_bitrv2l_JLpl_edu_icm_jlargearrays_LongLargeArray_Lpl_edu_icm_jlargearrays_FloatLargeArray_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='bitrv2l' and count(parameter)=4 and parameter[1][@type='long'] and parameter[2][@type='pl.edu.icm.jlargearrays.LongLargeArray'] and parameter[3][@type='pl.edu.icm.jlargearrays.FloatLargeArray'] and parameter[4][@type='long']]"
		[Register ("bitrv2l", "(JLpl/edu/icm/jlargearrays/LongLargeArray;Lpl/edu/icm/jlargearrays/FloatLargeArray;J)V", "")]
		public static unsafe void Bitrv2l (long p0, global::PL.Edu.Icm.Jlargearrays.LongLargeArray p1, global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p2, long p3)
		{
			if (id_bitrv2l_JLpl_edu_icm_jlargearrays_LongLargeArray_Lpl_edu_icm_jlargearrays_FloatLargeArray_J == IntPtr.Zero)
				id_bitrv2l_JLpl_edu_icm_jlargearrays_LongLargeArray_Lpl_edu_icm_jlargearrays_FloatLargeArray_J = JNIEnv.GetStaticMethodID (class_ref, "bitrv2l", "(JLpl/edu/icm/jlargearrays/LongLargeArray;Lpl/edu/icm/jlargearrays/FloatLargeArray;J)V");
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_bitrv2l_JLpl_edu_icm_jlargearrays_LongLargeArray_Lpl_edu_icm_jlargearrays_FloatLargeArray_J, __args);
			} finally {
			}
		}

		static IntPtr id_cftb040_arrayDI;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cftb040' and count(parameter)=2 and parameter[1][@type='double[]'] and parameter[2][@type='int']]"
		[Register ("cftb040", "([DI)V", "")]
		public static unsafe void Cftb040 (double[] p0, int p1)
		{
			if (id_cftb040_arrayDI == IntPtr.Zero)
				id_cftb040_arrayDI = JNIEnv.GetStaticMethodID (class_ref, "cftb040", "([DI)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_cftb040_arrayDI, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static IntPtr id_cftb040_arrayFI;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cftb040' and count(parameter)=2 and parameter[1][@type='float[]'] and parameter[2][@type='int']]"
		[Register ("cftb040", "([FI)V", "")]
		public static unsafe void Cftb040 (float[] p0, int p1)
		{
			if (id_cftb040_arrayFI == IntPtr.Zero)
				id_cftb040_arrayFI = JNIEnv.GetStaticMethodID (class_ref, "cftb040", "([FI)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_cftb040_arrayFI, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static IntPtr id_cftb040_Lpl_edu_icm_jlargearrays_DoubleLargeArray_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cftb040' and count(parameter)=2 and parameter[1][@type='pl.edu.icm.jlargearrays.DoubleLargeArray'] and parameter[2][@type='long']]"
		[Register ("cftb040", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;J)V", "")]
		public static unsafe void Cftb040 (global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p0, long p1)
		{
			if (id_cftb040_Lpl_edu_icm_jlargearrays_DoubleLargeArray_J == IntPtr.Zero)
				id_cftb040_Lpl_edu_icm_jlargearrays_DoubleLargeArray_J = JNIEnv.GetStaticMethodID (class_ref, "cftb040", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;J)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_cftb040_Lpl_edu_icm_jlargearrays_DoubleLargeArray_J, __args);
			} finally {
			}
		}

		static IntPtr id_cftb040_Lpl_edu_icm_jlargearrays_FloatLargeArray_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cftb040' and count(parameter)=2 and parameter[1][@type='pl.edu.icm.jlargearrays.FloatLargeArray'] and parameter[2][@type='long']]"
		[Register ("cftb040", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;J)V", "")]
		public static unsafe void Cftb040 (global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p0, long p1)
		{
			if (id_cftb040_Lpl_edu_icm_jlargearrays_FloatLargeArray_J == IntPtr.Zero)
				id_cftb040_Lpl_edu_icm_jlargearrays_FloatLargeArray_J = JNIEnv.GetStaticMethodID (class_ref, "cftb040", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;J)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_cftb040_Lpl_edu_icm_jlargearrays_FloatLargeArray_J, __args);
			} finally {
			}
		}

		static IntPtr id_cftb1st_IarrayDIarrayDI;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cftb1st' and count(parameter)=5 and parameter[1][@type='int'] and parameter[2][@type='double[]'] and parameter[3][@type='int'] and parameter[4][@type='double[]'] and parameter[5][@type='int']]"
		[Register ("cftb1st", "(I[DI[DI)V", "")]
		public static unsafe void Cftb1st (int p0, double[] p1, int p2, double[] p3, int p4)
		{
			if (id_cftb1st_IarrayDIarrayDI == IntPtr.Zero)
				id_cftb1st_IarrayDIarrayDI = JNIEnv.GetStaticMethodID (class_ref, "cftb1st", "(I[DI[DI)V");
			IntPtr native_p1 = JNIEnv.NewArray (p1);
			IntPtr native_p3 = JNIEnv.NewArray (p3);
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (native_p3);
				__args [4] = new JValue (p4);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_cftb1st_IarrayDIarrayDI, __args);
			} finally {
				if (p1 != null) {
					JNIEnv.CopyArray (native_p1, p1);
					JNIEnv.DeleteLocalRef (native_p1);
				}
				if (p3 != null) {
					JNIEnv.CopyArray (native_p3, p3);
					JNIEnv.DeleteLocalRef (native_p3);
				}
			}
		}

		static IntPtr id_cftb1st_IarrayFIarrayFI;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cftb1st' and count(parameter)=5 and parameter[1][@type='int'] and parameter[2][@type='float[]'] and parameter[3][@type='int'] and parameter[4][@type='float[]'] and parameter[5][@type='int']]"
		[Register ("cftb1st", "(I[FI[FI)V", "")]
		public static unsafe void Cftb1st (int p0, float[] p1, int p2, float[] p3, int p4)
		{
			if (id_cftb1st_IarrayFIarrayFI == IntPtr.Zero)
				id_cftb1st_IarrayFIarrayFI = JNIEnv.GetStaticMethodID (class_ref, "cftb1st", "(I[FI[FI)V");
			IntPtr native_p1 = JNIEnv.NewArray (p1);
			IntPtr native_p3 = JNIEnv.NewArray (p3);
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (native_p3);
				__args [4] = new JValue (p4);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_cftb1st_IarrayFIarrayFI, __args);
			} finally {
				if (p1 != null) {
					JNIEnv.CopyArray (native_p1, p1);
					JNIEnv.DeleteLocalRef (native_p1);
				}
				if (p3 != null) {
					JNIEnv.CopyArray (native_p3, p3);
					JNIEnv.DeleteLocalRef (native_p3);
				}
			}
		}

		static IntPtr id_cftb1st_JLpl_edu_icm_jlargearrays_DoubleLargeArray_JLpl_edu_icm_jlargearrays_DoubleLargeArray_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cftb1st' and count(parameter)=5 and parameter[1][@type='long'] and parameter[2][@type='pl.edu.icm.jlargearrays.DoubleLargeArray'] and parameter[3][@type='long'] and parameter[4][@type='pl.edu.icm.jlargearrays.DoubleLargeArray'] and parameter[5][@type='long']]"
		[Register ("cftb1st", "(JLpl/edu/icm/jlargearrays/DoubleLargeArray;JLpl/edu/icm/jlargearrays/DoubleLargeArray;J)V", "")]
		public static unsafe void Cftb1st (long p0, global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p1, long p2, global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p3, long p4)
		{
			if (id_cftb1st_JLpl_edu_icm_jlargearrays_DoubleLargeArray_JLpl_edu_icm_jlargearrays_DoubleLargeArray_J == IntPtr.Zero)
				id_cftb1st_JLpl_edu_icm_jlargearrays_DoubleLargeArray_JLpl_edu_icm_jlargearrays_DoubleLargeArray_J = JNIEnv.GetStaticMethodID (class_ref, "cftb1st", "(JLpl/edu/icm/jlargearrays/DoubleLargeArray;JLpl/edu/icm/jlargearrays/DoubleLargeArray;J)V");
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (p4);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_cftb1st_JLpl_edu_icm_jlargearrays_DoubleLargeArray_JLpl_edu_icm_jlargearrays_DoubleLargeArray_J, __args);
			} finally {
			}
		}

		static IntPtr id_cftb1st_JLpl_edu_icm_jlargearrays_FloatLargeArray_JLpl_edu_icm_jlargearrays_FloatLargeArray_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cftb1st' and count(parameter)=5 and parameter[1][@type='long'] and parameter[2][@type='pl.edu.icm.jlargearrays.FloatLargeArray'] and parameter[3][@type='long'] and parameter[4][@type='pl.edu.icm.jlargearrays.FloatLargeArray'] and parameter[5][@type='long']]"
		[Register ("cftb1st", "(JLpl/edu/icm/jlargearrays/FloatLargeArray;JLpl/edu/icm/jlargearrays/FloatLargeArray;J)V", "")]
		public static unsafe void Cftb1st (long p0, global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p1, long p2, global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p3, long p4)
		{
			if (id_cftb1st_JLpl_edu_icm_jlargearrays_FloatLargeArray_JLpl_edu_icm_jlargearrays_FloatLargeArray_J == IntPtr.Zero)
				id_cftb1st_JLpl_edu_icm_jlargearrays_FloatLargeArray_JLpl_edu_icm_jlargearrays_FloatLargeArray_J = JNIEnv.GetStaticMethodID (class_ref, "cftb1st", "(JLpl/edu/icm/jlargearrays/FloatLargeArray;JLpl/edu/icm/jlargearrays/FloatLargeArray;J)V");
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (p4);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_cftb1st_JLpl_edu_icm_jlargearrays_FloatLargeArray_JLpl_edu_icm_jlargearrays_FloatLargeArray_J, __args);
			} finally {
			}
		}

		static IntPtr id_cftbsub_IarrayDIarrayIIarrayD;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cftbsub' and count(parameter)=6 and parameter[1][@type='int'] and parameter[2][@type='double[]'] and parameter[3][@type='int'] and parameter[4][@type='int[]'] and parameter[5][@type='int'] and parameter[6][@type='double[]']]"
		[Register ("cftbsub", "(I[DI[II[D)V", "")]
		public static unsafe void Cftbsub (int p0, double[] p1, int p2, int[] p3, int p4, double[] p5)
		{
			if (id_cftbsub_IarrayDIarrayIIarrayD == IntPtr.Zero)
				id_cftbsub_IarrayDIarrayIIarrayD = JNIEnv.GetStaticMethodID (class_ref, "cftbsub", "(I[DI[II[D)V");
			IntPtr native_p1 = JNIEnv.NewArray (p1);
			IntPtr native_p3 = JNIEnv.NewArray (p3);
			IntPtr native_p5 = JNIEnv.NewArray (p5);
			try {
				JValue* __args = stackalloc JValue [6];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (native_p3);
				__args [4] = new JValue (p4);
				__args [5] = new JValue (native_p5);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_cftbsub_IarrayDIarrayIIarrayD, __args);
			} finally {
				if (p1 != null) {
					JNIEnv.CopyArray (native_p1, p1);
					JNIEnv.DeleteLocalRef (native_p1);
				}
				if (p3 != null) {
					JNIEnv.CopyArray (native_p3, p3);
					JNIEnv.DeleteLocalRef (native_p3);
				}
				if (p5 != null) {
					JNIEnv.CopyArray (native_p5, p5);
					JNIEnv.DeleteLocalRef (native_p5);
				}
			}
		}

		static IntPtr id_cftbsub_IarrayFIarrayIIarrayF;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cftbsub' and count(parameter)=6 and parameter[1][@type='int'] and parameter[2][@type='float[]'] and parameter[3][@type='int'] and parameter[4][@type='int[]'] and parameter[5][@type='int'] and parameter[6][@type='float[]']]"
		[Register ("cftbsub", "(I[FI[II[F)V", "")]
		public static unsafe void Cftbsub (int p0, float[] p1, int p2, int[] p3, int p4, float[] p5)
		{
			if (id_cftbsub_IarrayFIarrayIIarrayF == IntPtr.Zero)
				id_cftbsub_IarrayFIarrayIIarrayF = JNIEnv.GetStaticMethodID (class_ref, "cftbsub", "(I[FI[II[F)V");
			IntPtr native_p1 = JNIEnv.NewArray (p1);
			IntPtr native_p3 = JNIEnv.NewArray (p3);
			IntPtr native_p5 = JNIEnv.NewArray (p5);
			try {
				JValue* __args = stackalloc JValue [6];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (native_p3);
				__args [4] = new JValue (p4);
				__args [5] = new JValue (native_p5);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_cftbsub_IarrayFIarrayIIarrayF, __args);
			} finally {
				if (p1 != null) {
					JNIEnv.CopyArray (native_p1, p1);
					JNIEnv.DeleteLocalRef (native_p1);
				}
				if (p3 != null) {
					JNIEnv.CopyArray (native_p3, p3);
					JNIEnv.DeleteLocalRef (native_p3);
				}
				if (p5 != null) {
					JNIEnv.CopyArray (native_p5, p5);
					JNIEnv.DeleteLocalRef (native_p5);
				}
			}
		}

		static IntPtr id_cftbsub_JLpl_edu_icm_jlargearrays_DoubleLargeArray_JLpl_edu_icm_jlargearrays_LongLargeArray_JLpl_edu_icm_jlargearrays_DoubleLargeArray_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cftbsub' and count(parameter)=6 and parameter[1][@type='long'] and parameter[2][@type='pl.edu.icm.jlargearrays.DoubleLargeArray'] and parameter[3][@type='long'] and parameter[4][@type='pl.edu.icm.jlargearrays.LongLargeArray'] and parameter[5][@type='long'] and parameter[6][@type='pl.edu.icm.jlargearrays.DoubleLargeArray']]"
		[Register ("cftbsub", "(JLpl/edu/icm/jlargearrays/DoubleLargeArray;JLpl/edu/icm/jlargearrays/LongLargeArray;JLpl/edu/icm/jlargearrays/DoubleLargeArray;)V", "")]
		public static unsafe void Cftbsub (long p0, global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p1, long p2, global::PL.Edu.Icm.Jlargearrays.LongLargeArray p3, long p4, global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p5)
		{
			if (id_cftbsub_JLpl_edu_icm_jlargearrays_DoubleLargeArray_JLpl_edu_icm_jlargearrays_LongLargeArray_JLpl_edu_icm_jlargearrays_DoubleLargeArray_ == IntPtr.Zero)
				id_cftbsub_JLpl_edu_icm_jlargearrays_DoubleLargeArray_JLpl_edu_icm_jlargearrays_LongLargeArray_JLpl_edu_icm_jlargearrays_DoubleLargeArray_ = JNIEnv.GetStaticMethodID (class_ref, "cftbsub", "(JLpl/edu/icm/jlargearrays/DoubleLargeArray;JLpl/edu/icm/jlargearrays/LongLargeArray;JLpl/edu/icm/jlargearrays/DoubleLargeArray;)V");
			try {
				JValue* __args = stackalloc JValue [6];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (p4);
				__args [5] = new JValue (p5);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_cftbsub_JLpl_edu_icm_jlargearrays_DoubleLargeArray_JLpl_edu_icm_jlargearrays_LongLargeArray_JLpl_edu_icm_jlargearrays_DoubleLargeArray_, __args);
			} finally {
			}
		}

		static IntPtr id_cftbsub_JLpl_edu_icm_jlargearrays_FloatLargeArray_JLpl_edu_icm_jlargearrays_LongLargeArray_JLpl_edu_icm_jlargearrays_FloatLargeArray_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cftbsub' and count(parameter)=6 and parameter[1][@type='long'] and parameter[2][@type='pl.edu.icm.jlargearrays.FloatLargeArray'] and parameter[3][@type='long'] and parameter[4][@type='pl.edu.icm.jlargearrays.LongLargeArray'] and parameter[5][@type='long'] and parameter[6][@type='pl.edu.icm.jlargearrays.FloatLargeArray']]"
		[Register ("cftbsub", "(JLpl/edu/icm/jlargearrays/FloatLargeArray;JLpl/edu/icm/jlargearrays/LongLargeArray;JLpl/edu/icm/jlargearrays/FloatLargeArray;)V", "")]
		public static unsafe void Cftbsub (long p0, global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p1, long p2, global::PL.Edu.Icm.Jlargearrays.LongLargeArray p3, long p4, global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p5)
		{
			if (id_cftbsub_JLpl_edu_icm_jlargearrays_FloatLargeArray_JLpl_edu_icm_jlargearrays_LongLargeArray_JLpl_edu_icm_jlargearrays_FloatLargeArray_ == IntPtr.Zero)
				id_cftbsub_JLpl_edu_icm_jlargearrays_FloatLargeArray_JLpl_edu_icm_jlargearrays_LongLargeArray_JLpl_edu_icm_jlargearrays_FloatLargeArray_ = JNIEnv.GetStaticMethodID (class_ref, "cftbsub", "(JLpl/edu/icm/jlargearrays/FloatLargeArray;JLpl/edu/icm/jlargearrays/LongLargeArray;JLpl/edu/icm/jlargearrays/FloatLargeArray;)V");
			try {
				JValue* __args = stackalloc JValue [6];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (p4);
				__args [5] = new JValue (p5);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_cftbsub_JLpl_edu_icm_jlargearrays_FloatLargeArray_JLpl_edu_icm_jlargearrays_LongLargeArray_JLpl_edu_icm_jlargearrays_FloatLargeArray_, __args);
			} finally {
			}
		}

		static IntPtr id_cftf040_arrayDI;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cftf040' and count(parameter)=2 and parameter[1][@type='double[]'] and parameter[2][@type='int']]"
		[Register ("cftf040", "([DI)V", "")]
		public static unsafe void Cftf040 (double[] p0, int p1)
		{
			if (id_cftf040_arrayDI == IntPtr.Zero)
				id_cftf040_arrayDI = JNIEnv.GetStaticMethodID (class_ref, "cftf040", "([DI)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_cftf040_arrayDI, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static IntPtr id_cftf040_arrayFI;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cftf040' and count(parameter)=2 and parameter[1][@type='float[]'] and parameter[2][@type='int']]"
		[Register ("cftf040", "([FI)V", "")]
		public static unsafe void Cftf040 (float[] p0, int p1)
		{
			if (id_cftf040_arrayFI == IntPtr.Zero)
				id_cftf040_arrayFI = JNIEnv.GetStaticMethodID (class_ref, "cftf040", "([FI)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_cftf040_arrayFI, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static IntPtr id_cftf040_Lpl_edu_icm_jlargearrays_DoubleLargeArray_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cftf040' and count(parameter)=2 and parameter[1][@type='pl.edu.icm.jlargearrays.DoubleLargeArray'] and parameter[2][@type='long']]"
		[Register ("cftf040", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;J)V", "")]
		public static unsafe void Cftf040 (global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p0, long p1)
		{
			if (id_cftf040_Lpl_edu_icm_jlargearrays_DoubleLargeArray_J == IntPtr.Zero)
				id_cftf040_Lpl_edu_icm_jlargearrays_DoubleLargeArray_J = JNIEnv.GetStaticMethodID (class_ref, "cftf040", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;J)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_cftf040_Lpl_edu_icm_jlargearrays_DoubleLargeArray_J, __args);
			} finally {
			}
		}

		static IntPtr id_cftf040_Lpl_edu_icm_jlargearrays_FloatLargeArray_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cftf040' and count(parameter)=2 and parameter[1][@type='pl.edu.icm.jlargearrays.FloatLargeArray'] and parameter[2][@type='long']]"
		[Register ("cftf040", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;J)V", "")]
		public static unsafe void Cftf040 (global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p0, long p1)
		{
			if (id_cftf040_Lpl_edu_icm_jlargearrays_FloatLargeArray_J == IntPtr.Zero)
				id_cftf040_Lpl_edu_icm_jlargearrays_FloatLargeArray_J = JNIEnv.GetStaticMethodID (class_ref, "cftf040", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;J)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_cftf040_Lpl_edu_icm_jlargearrays_FloatLargeArray_J, __args);
			} finally {
			}
		}

		static IntPtr id_cftf081_arrayDIarrayDI;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cftf081' and count(parameter)=4 and parameter[1][@type='double[]'] and parameter[2][@type='int'] and parameter[3][@type='double[]'] and parameter[4][@type='int']]"
		[Register ("cftf081", "([DI[DI)V", "")]
		public static unsafe void Cftf081 (double[] p0, int p1, double[] p2, int p3)
		{
			if (id_cftf081_arrayDIarrayDI == IntPtr.Zero)
				id_cftf081_arrayDIarrayDI = JNIEnv.GetStaticMethodID (class_ref, "cftf081", "([DI[DI)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			IntPtr native_p2 = JNIEnv.NewArray (p2);
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (native_p2);
				__args [3] = new JValue (p3);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_cftf081_arrayDIarrayDI, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
				if (p2 != null) {
					JNIEnv.CopyArray (native_p2, p2);
					JNIEnv.DeleteLocalRef (native_p2);
				}
			}
		}

		static IntPtr id_cftf081_arrayFIarrayFI;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cftf081' and count(parameter)=4 and parameter[1][@type='float[]'] and parameter[2][@type='int'] and parameter[3][@type='float[]'] and parameter[4][@type='int']]"
		[Register ("cftf081", "([FI[FI)V", "")]
		public static unsafe void Cftf081 (float[] p0, int p1, float[] p2, int p3)
		{
			if (id_cftf081_arrayFIarrayFI == IntPtr.Zero)
				id_cftf081_arrayFIarrayFI = JNIEnv.GetStaticMethodID (class_ref, "cftf081", "([FI[FI)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			IntPtr native_p2 = JNIEnv.NewArray (p2);
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (native_p2);
				__args [3] = new JValue (p3);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_cftf081_arrayFIarrayFI, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
				if (p2 != null) {
					JNIEnv.CopyArray (native_p2, p2);
					JNIEnv.DeleteLocalRef (native_p2);
				}
			}
		}

		static IntPtr id_cftf081_Lpl_edu_icm_jlargearrays_DoubleLargeArray_JLpl_edu_icm_jlargearrays_DoubleLargeArray_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cftf081' and count(parameter)=4 and parameter[1][@type='pl.edu.icm.jlargearrays.DoubleLargeArray'] and parameter[2][@type='long'] and parameter[3][@type='pl.edu.icm.jlargearrays.DoubleLargeArray'] and parameter[4][@type='long']]"
		[Register ("cftf081", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;JLpl/edu/icm/jlargearrays/DoubleLargeArray;J)V", "")]
		public static unsafe void Cftf081 (global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p0, long p1, global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p2, long p3)
		{
			if (id_cftf081_Lpl_edu_icm_jlargearrays_DoubleLargeArray_JLpl_edu_icm_jlargearrays_DoubleLargeArray_J == IntPtr.Zero)
				id_cftf081_Lpl_edu_icm_jlargearrays_DoubleLargeArray_JLpl_edu_icm_jlargearrays_DoubleLargeArray_J = JNIEnv.GetStaticMethodID (class_ref, "cftf081", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;JLpl/edu/icm/jlargearrays/DoubleLargeArray;J)V");
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_cftf081_Lpl_edu_icm_jlargearrays_DoubleLargeArray_JLpl_edu_icm_jlargearrays_DoubleLargeArray_J, __args);
			} finally {
			}
		}

		static IntPtr id_cftf081_Lpl_edu_icm_jlargearrays_FloatLargeArray_JLpl_edu_icm_jlargearrays_FloatLargeArray_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cftf081' and count(parameter)=4 and parameter[1][@type='pl.edu.icm.jlargearrays.FloatLargeArray'] and parameter[2][@type='long'] and parameter[3][@type='pl.edu.icm.jlargearrays.FloatLargeArray'] and parameter[4][@type='long']]"
		[Register ("cftf081", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;JLpl/edu/icm/jlargearrays/FloatLargeArray;J)V", "")]
		public static unsafe void Cftf081 (global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p0, long p1, global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p2, long p3)
		{
			if (id_cftf081_Lpl_edu_icm_jlargearrays_FloatLargeArray_JLpl_edu_icm_jlargearrays_FloatLargeArray_J == IntPtr.Zero)
				id_cftf081_Lpl_edu_icm_jlargearrays_FloatLargeArray_JLpl_edu_icm_jlargearrays_FloatLargeArray_J = JNIEnv.GetStaticMethodID (class_ref, "cftf081", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;JLpl/edu/icm/jlargearrays/FloatLargeArray;J)V");
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_cftf081_Lpl_edu_icm_jlargearrays_FloatLargeArray_JLpl_edu_icm_jlargearrays_FloatLargeArray_J, __args);
			} finally {
			}
		}

		static IntPtr id_cftf082_arrayDIarrayDI;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cftf082' and count(parameter)=4 and parameter[1][@type='double[]'] and parameter[2][@type='int'] and parameter[3][@type='double[]'] and parameter[4][@type='int']]"
		[Register ("cftf082", "([DI[DI)V", "")]
		public static unsafe void Cftf082 (double[] p0, int p1, double[] p2, int p3)
		{
			if (id_cftf082_arrayDIarrayDI == IntPtr.Zero)
				id_cftf082_arrayDIarrayDI = JNIEnv.GetStaticMethodID (class_ref, "cftf082", "([DI[DI)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			IntPtr native_p2 = JNIEnv.NewArray (p2);
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (native_p2);
				__args [3] = new JValue (p3);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_cftf082_arrayDIarrayDI, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
				if (p2 != null) {
					JNIEnv.CopyArray (native_p2, p2);
					JNIEnv.DeleteLocalRef (native_p2);
				}
			}
		}

		static IntPtr id_cftf082_arrayFIarrayFI;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cftf082' and count(parameter)=4 and parameter[1][@type='float[]'] and parameter[2][@type='int'] and parameter[3][@type='float[]'] and parameter[4][@type='int']]"
		[Register ("cftf082", "([FI[FI)V", "")]
		public static unsafe void Cftf082 (float[] p0, int p1, float[] p2, int p3)
		{
			if (id_cftf082_arrayFIarrayFI == IntPtr.Zero)
				id_cftf082_arrayFIarrayFI = JNIEnv.GetStaticMethodID (class_ref, "cftf082", "([FI[FI)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			IntPtr native_p2 = JNIEnv.NewArray (p2);
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (native_p2);
				__args [3] = new JValue (p3);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_cftf082_arrayFIarrayFI, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
				if (p2 != null) {
					JNIEnv.CopyArray (native_p2, p2);
					JNIEnv.DeleteLocalRef (native_p2);
				}
			}
		}

		static IntPtr id_cftf082_Lpl_edu_icm_jlargearrays_DoubleLargeArray_JLpl_edu_icm_jlargearrays_DoubleLargeArray_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cftf082' and count(parameter)=4 and parameter[1][@type='pl.edu.icm.jlargearrays.DoubleLargeArray'] and parameter[2][@type='long'] and parameter[3][@type='pl.edu.icm.jlargearrays.DoubleLargeArray'] and parameter[4][@type='long']]"
		[Register ("cftf082", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;JLpl/edu/icm/jlargearrays/DoubleLargeArray;J)V", "")]
		public static unsafe void Cftf082 (global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p0, long p1, global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p2, long p3)
		{
			if (id_cftf082_Lpl_edu_icm_jlargearrays_DoubleLargeArray_JLpl_edu_icm_jlargearrays_DoubleLargeArray_J == IntPtr.Zero)
				id_cftf082_Lpl_edu_icm_jlargearrays_DoubleLargeArray_JLpl_edu_icm_jlargearrays_DoubleLargeArray_J = JNIEnv.GetStaticMethodID (class_ref, "cftf082", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;JLpl/edu/icm/jlargearrays/DoubleLargeArray;J)V");
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_cftf082_Lpl_edu_icm_jlargearrays_DoubleLargeArray_JLpl_edu_icm_jlargearrays_DoubleLargeArray_J, __args);
			} finally {
			}
		}

		static IntPtr id_cftf082_Lpl_edu_icm_jlargearrays_FloatLargeArray_JLpl_edu_icm_jlargearrays_FloatLargeArray_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cftf082' and count(parameter)=4 and parameter[1][@type='pl.edu.icm.jlargearrays.FloatLargeArray'] and parameter[2][@type='long'] and parameter[3][@type='pl.edu.icm.jlargearrays.FloatLargeArray'] and parameter[4][@type='long']]"
		[Register ("cftf082", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;JLpl/edu/icm/jlargearrays/FloatLargeArray;J)V", "")]
		public static unsafe void Cftf082 (global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p0, long p1, global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p2, long p3)
		{
			if (id_cftf082_Lpl_edu_icm_jlargearrays_FloatLargeArray_JLpl_edu_icm_jlargearrays_FloatLargeArray_J == IntPtr.Zero)
				id_cftf082_Lpl_edu_icm_jlargearrays_FloatLargeArray_JLpl_edu_icm_jlargearrays_FloatLargeArray_J = JNIEnv.GetStaticMethodID (class_ref, "cftf082", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;JLpl/edu/icm/jlargearrays/FloatLargeArray;J)V");
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_cftf082_Lpl_edu_icm_jlargearrays_FloatLargeArray_JLpl_edu_icm_jlargearrays_FloatLargeArray_J, __args);
			} finally {
			}
		}

		static IntPtr id_cftf161_arrayDIarrayDI;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cftf161' and count(parameter)=4 and parameter[1][@type='double[]'] and parameter[2][@type='int'] and parameter[3][@type='double[]'] and parameter[4][@type='int']]"
		[Register ("cftf161", "([DI[DI)V", "")]
		public static unsafe void Cftf161 (double[] p0, int p1, double[] p2, int p3)
		{
			if (id_cftf161_arrayDIarrayDI == IntPtr.Zero)
				id_cftf161_arrayDIarrayDI = JNIEnv.GetStaticMethodID (class_ref, "cftf161", "([DI[DI)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			IntPtr native_p2 = JNIEnv.NewArray (p2);
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (native_p2);
				__args [3] = new JValue (p3);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_cftf161_arrayDIarrayDI, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
				if (p2 != null) {
					JNIEnv.CopyArray (native_p2, p2);
					JNIEnv.DeleteLocalRef (native_p2);
				}
			}
		}

		static IntPtr id_cftf161_arrayFIarrayFI;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cftf161' and count(parameter)=4 and parameter[1][@type='float[]'] and parameter[2][@type='int'] and parameter[3][@type='float[]'] and parameter[4][@type='int']]"
		[Register ("cftf161", "([FI[FI)V", "")]
		public static unsafe void Cftf161 (float[] p0, int p1, float[] p2, int p3)
		{
			if (id_cftf161_arrayFIarrayFI == IntPtr.Zero)
				id_cftf161_arrayFIarrayFI = JNIEnv.GetStaticMethodID (class_ref, "cftf161", "([FI[FI)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			IntPtr native_p2 = JNIEnv.NewArray (p2);
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (native_p2);
				__args [3] = new JValue (p3);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_cftf161_arrayFIarrayFI, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
				if (p2 != null) {
					JNIEnv.CopyArray (native_p2, p2);
					JNIEnv.DeleteLocalRef (native_p2);
				}
			}
		}

		static IntPtr id_cftf161_Lpl_edu_icm_jlargearrays_DoubleLargeArray_JLpl_edu_icm_jlargearrays_DoubleLargeArray_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cftf161' and count(parameter)=4 and parameter[1][@type='pl.edu.icm.jlargearrays.DoubleLargeArray'] and parameter[2][@type='long'] and parameter[3][@type='pl.edu.icm.jlargearrays.DoubleLargeArray'] and parameter[4][@type='long']]"
		[Register ("cftf161", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;JLpl/edu/icm/jlargearrays/DoubleLargeArray;J)V", "")]
		public static unsafe void Cftf161 (global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p0, long p1, global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p2, long p3)
		{
			if (id_cftf161_Lpl_edu_icm_jlargearrays_DoubleLargeArray_JLpl_edu_icm_jlargearrays_DoubleLargeArray_J == IntPtr.Zero)
				id_cftf161_Lpl_edu_icm_jlargearrays_DoubleLargeArray_JLpl_edu_icm_jlargearrays_DoubleLargeArray_J = JNIEnv.GetStaticMethodID (class_ref, "cftf161", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;JLpl/edu/icm/jlargearrays/DoubleLargeArray;J)V");
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_cftf161_Lpl_edu_icm_jlargearrays_DoubleLargeArray_JLpl_edu_icm_jlargearrays_DoubleLargeArray_J, __args);
			} finally {
			}
		}

		static IntPtr id_cftf161_Lpl_edu_icm_jlargearrays_FloatLargeArray_JLpl_edu_icm_jlargearrays_FloatLargeArray_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cftf161' and count(parameter)=4 and parameter[1][@type='pl.edu.icm.jlargearrays.FloatLargeArray'] and parameter[2][@type='long'] and parameter[3][@type='pl.edu.icm.jlargearrays.FloatLargeArray'] and parameter[4][@type='long']]"
		[Register ("cftf161", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;JLpl/edu/icm/jlargearrays/FloatLargeArray;J)V", "")]
		public static unsafe void Cftf161 (global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p0, long p1, global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p2, long p3)
		{
			if (id_cftf161_Lpl_edu_icm_jlargearrays_FloatLargeArray_JLpl_edu_icm_jlargearrays_FloatLargeArray_J == IntPtr.Zero)
				id_cftf161_Lpl_edu_icm_jlargearrays_FloatLargeArray_JLpl_edu_icm_jlargearrays_FloatLargeArray_J = JNIEnv.GetStaticMethodID (class_ref, "cftf161", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;JLpl/edu/icm/jlargearrays/FloatLargeArray;J)V");
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_cftf161_Lpl_edu_icm_jlargearrays_FloatLargeArray_JLpl_edu_icm_jlargearrays_FloatLargeArray_J, __args);
			} finally {
			}
		}

		static IntPtr id_cftf162_arrayDIarrayDI;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cftf162' and count(parameter)=4 and parameter[1][@type='double[]'] and parameter[2][@type='int'] and parameter[3][@type='double[]'] and parameter[4][@type='int']]"
		[Register ("cftf162", "([DI[DI)V", "")]
		public static unsafe void Cftf162 (double[] p0, int p1, double[] p2, int p3)
		{
			if (id_cftf162_arrayDIarrayDI == IntPtr.Zero)
				id_cftf162_arrayDIarrayDI = JNIEnv.GetStaticMethodID (class_ref, "cftf162", "([DI[DI)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			IntPtr native_p2 = JNIEnv.NewArray (p2);
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (native_p2);
				__args [3] = new JValue (p3);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_cftf162_arrayDIarrayDI, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
				if (p2 != null) {
					JNIEnv.CopyArray (native_p2, p2);
					JNIEnv.DeleteLocalRef (native_p2);
				}
			}
		}

		static IntPtr id_cftf162_arrayFIarrayFI;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cftf162' and count(parameter)=4 and parameter[1][@type='float[]'] and parameter[2][@type='int'] and parameter[3][@type='float[]'] and parameter[4][@type='int']]"
		[Register ("cftf162", "([FI[FI)V", "")]
		public static unsafe void Cftf162 (float[] p0, int p1, float[] p2, int p3)
		{
			if (id_cftf162_arrayFIarrayFI == IntPtr.Zero)
				id_cftf162_arrayFIarrayFI = JNIEnv.GetStaticMethodID (class_ref, "cftf162", "([FI[FI)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			IntPtr native_p2 = JNIEnv.NewArray (p2);
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (native_p2);
				__args [3] = new JValue (p3);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_cftf162_arrayFIarrayFI, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
				if (p2 != null) {
					JNIEnv.CopyArray (native_p2, p2);
					JNIEnv.DeleteLocalRef (native_p2);
				}
			}
		}

		static IntPtr id_cftf162_Lpl_edu_icm_jlargearrays_DoubleLargeArray_JLpl_edu_icm_jlargearrays_DoubleLargeArray_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cftf162' and count(parameter)=4 and parameter[1][@type='pl.edu.icm.jlargearrays.DoubleLargeArray'] and parameter[2][@type='long'] and parameter[3][@type='pl.edu.icm.jlargearrays.DoubleLargeArray'] and parameter[4][@type='long']]"
		[Register ("cftf162", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;JLpl/edu/icm/jlargearrays/DoubleLargeArray;J)V", "")]
		public static unsafe void Cftf162 (global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p0, long p1, global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p2, long p3)
		{
			if (id_cftf162_Lpl_edu_icm_jlargearrays_DoubleLargeArray_JLpl_edu_icm_jlargearrays_DoubleLargeArray_J == IntPtr.Zero)
				id_cftf162_Lpl_edu_icm_jlargearrays_DoubleLargeArray_JLpl_edu_icm_jlargearrays_DoubleLargeArray_J = JNIEnv.GetStaticMethodID (class_ref, "cftf162", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;JLpl/edu/icm/jlargearrays/DoubleLargeArray;J)V");
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_cftf162_Lpl_edu_icm_jlargearrays_DoubleLargeArray_JLpl_edu_icm_jlargearrays_DoubleLargeArray_J, __args);
			} finally {
			}
		}

		static IntPtr id_cftf162_Lpl_edu_icm_jlargearrays_FloatLargeArray_JLpl_edu_icm_jlargearrays_FloatLargeArray_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cftf162' and count(parameter)=4 and parameter[1][@type='pl.edu.icm.jlargearrays.FloatLargeArray'] and parameter[2][@type='long'] and parameter[3][@type='pl.edu.icm.jlargearrays.FloatLargeArray'] and parameter[4][@type='long']]"
		[Register ("cftf162", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;JLpl/edu/icm/jlargearrays/FloatLargeArray;J)V", "")]
		public static unsafe void Cftf162 (global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p0, long p1, global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p2, long p3)
		{
			if (id_cftf162_Lpl_edu_icm_jlargearrays_FloatLargeArray_JLpl_edu_icm_jlargearrays_FloatLargeArray_J == IntPtr.Zero)
				id_cftf162_Lpl_edu_icm_jlargearrays_FloatLargeArray_JLpl_edu_icm_jlargearrays_FloatLargeArray_J = JNIEnv.GetStaticMethodID (class_ref, "cftf162", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;JLpl/edu/icm/jlargearrays/FloatLargeArray;J)V");
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_cftf162_Lpl_edu_icm_jlargearrays_FloatLargeArray_JLpl_edu_icm_jlargearrays_FloatLargeArray_J, __args);
			} finally {
			}
		}

		static IntPtr id_cftf1st_IarrayDIarrayDI;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cftf1st' and count(parameter)=5 and parameter[1][@type='int'] and parameter[2][@type='double[]'] and parameter[3][@type='int'] and parameter[4][@type='double[]'] and parameter[5][@type='int']]"
		[Register ("cftf1st", "(I[DI[DI)V", "")]
		public static unsafe void Cftf1st (int p0, double[] p1, int p2, double[] p3, int p4)
		{
			if (id_cftf1st_IarrayDIarrayDI == IntPtr.Zero)
				id_cftf1st_IarrayDIarrayDI = JNIEnv.GetStaticMethodID (class_ref, "cftf1st", "(I[DI[DI)V");
			IntPtr native_p1 = JNIEnv.NewArray (p1);
			IntPtr native_p3 = JNIEnv.NewArray (p3);
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (native_p3);
				__args [4] = new JValue (p4);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_cftf1st_IarrayDIarrayDI, __args);
			} finally {
				if (p1 != null) {
					JNIEnv.CopyArray (native_p1, p1);
					JNIEnv.DeleteLocalRef (native_p1);
				}
				if (p3 != null) {
					JNIEnv.CopyArray (native_p3, p3);
					JNIEnv.DeleteLocalRef (native_p3);
				}
			}
		}

		static IntPtr id_cftf1st_IarrayFIarrayFI;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cftf1st' and count(parameter)=5 and parameter[1][@type='int'] and parameter[2][@type='float[]'] and parameter[3][@type='int'] and parameter[4][@type='float[]'] and parameter[5][@type='int']]"
		[Register ("cftf1st", "(I[FI[FI)V", "")]
		public static unsafe void Cftf1st (int p0, float[] p1, int p2, float[] p3, int p4)
		{
			if (id_cftf1st_IarrayFIarrayFI == IntPtr.Zero)
				id_cftf1st_IarrayFIarrayFI = JNIEnv.GetStaticMethodID (class_ref, "cftf1st", "(I[FI[FI)V");
			IntPtr native_p1 = JNIEnv.NewArray (p1);
			IntPtr native_p3 = JNIEnv.NewArray (p3);
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (native_p3);
				__args [4] = new JValue (p4);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_cftf1st_IarrayFIarrayFI, __args);
			} finally {
				if (p1 != null) {
					JNIEnv.CopyArray (native_p1, p1);
					JNIEnv.DeleteLocalRef (native_p1);
				}
				if (p3 != null) {
					JNIEnv.CopyArray (native_p3, p3);
					JNIEnv.DeleteLocalRef (native_p3);
				}
			}
		}

		static IntPtr id_cftf1st_JLpl_edu_icm_jlargearrays_DoubleLargeArray_JLpl_edu_icm_jlargearrays_DoubleLargeArray_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cftf1st' and count(parameter)=5 and parameter[1][@type='long'] and parameter[2][@type='pl.edu.icm.jlargearrays.DoubleLargeArray'] and parameter[3][@type='long'] and parameter[4][@type='pl.edu.icm.jlargearrays.DoubleLargeArray'] and parameter[5][@type='long']]"
		[Register ("cftf1st", "(JLpl/edu/icm/jlargearrays/DoubleLargeArray;JLpl/edu/icm/jlargearrays/DoubleLargeArray;J)V", "")]
		public static unsafe void Cftf1st (long p0, global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p1, long p2, global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p3, long p4)
		{
			if (id_cftf1st_JLpl_edu_icm_jlargearrays_DoubleLargeArray_JLpl_edu_icm_jlargearrays_DoubleLargeArray_J == IntPtr.Zero)
				id_cftf1st_JLpl_edu_icm_jlargearrays_DoubleLargeArray_JLpl_edu_icm_jlargearrays_DoubleLargeArray_J = JNIEnv.GetStaticMethodID (class_ref, "cftf1st", "(JLpl/edu/icm/jlargearrays/DoubleLargeArray;JLpl/edu/icm/jlargearrays/DoubleLargeArray;J)V");
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (p4);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_cftf1st_JLpl_edu_icm_jlargearrays_DoubleLargeArray_JLpl_edu_icm_jlargearrays_DoubleLargeArray_J, __args);
			} finally {
			}
		}

		static IntPtr id_cftf1st_JLpl_edu_icm_jlargearrays_FloatLargeArray_JLpl_edu_icm_jlargearrays_FloatLargeArray_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cftf1st' and count(parameter)=5 and parameter[1][@type='long'] and parameter[2][@type='pl.edu.icm.jlargearrays.FloatLargeArray'] and parameter[3][@type='long'] and parameter[4][@type='pl.edu.icm.jlargearrays.FloatLargeArray'] and parameter[5][@type='long']]"
		[Register ("cftf1st", "(JLpl/edu/icm/jlargearrays/FloatLargeArray;JLpl/edu/icm/jlargearrays/FloatLargeArray;J)V", "")]
		public static unsafe void Cftf1st (long p0, global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p1, long p2, global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p3, long p4)
		{
			if (id_cftf1st_JLpl_edu_icm_jlargearrays_FloatLargeArray_JLpl_edu_icm_jlargearrays_FloatLargeArray_J == IntPtr.Zero)
				id_cftf1st_JLpl_edu_icm_jlargearrays_FloatLargeArray_JLpl_edu_icm_jlargearrays_FloatLargeArray_J = JNIEnv.GetStaticMethodID (class_ref, "cftf1st", "(JLpl/edu/icm/jlargearrays/FloatLargeArray;JLpl/edu/icm/jlargearrays/FloatLargeArray;J)V");
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (p4);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_cftf1st_JLpl_edu_icm_jlargearrays_FloatLargeArray_JLpl_edu_icm_jlargearrays_FloatLargeArray_J, __args);
			} finally {
			}
		}

		static IntPtr id_cftfsub_IarrayDIarrayIIarrayD;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cftfsub' and count(parameter)=6 and parameter[1][@type='int'] and parameter[2][@type='double[]'] and parameter[3][@type='int'] and parameter[4][@type='int[]'] and parameter[5][@type='int'] and parameter[6][@type='double[]']]"
		[Register ("cftfsub", "(I[DI[II[D)V", "")]
		public static unsafe void Cftfsub (int p0, double[] p1, int p2, int[] p3, int p4, double[] p5)
		{
			if (id_cftfsub_IarrayDIarrayIIarrayD == IntPtr.Zero)
				id_cftfsub_IarrayDIarrayIIarrayD = JNIEnv.GetStaticMethodID (class_ref, "cftfsub", "(I[DI[II[D)V");
			IntPtr native_p1 = JNIEnv.NewArray (p1);
			IntPtr native_p3 = JNIEnv.NewArray (p3);
			IntPtr native_p5 = JNIEnv.NewArray (p5);
			try {
				JValue* __args = stackalloc JValue [6];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (native_p3);
				__args [4] = new JValue (p4);
				__args [5] = new JValue (native_p5);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_cftfsub_IarrayDIarrayIIarrayD, __args);
			} finally {
				if (p1 != null) {
					JNIEnv.CopyArray (native_p1, p1);
					JNIEnv.DeleteLocalRef (native_p1);
				}
				if (p3 != null) {
					JNIEnv.CopyArray (native_p3, p3);
					JNIEnv.DeleteLocalRef (native_p3);
				}
				if (p5 != null) {
					JNIEnv.CopyArray (native_p5, p5);
					JNIEnv.DeleteLocalRef (native_p5);
				}
			}
		}

		static IntPtr id_cftfsub_IarrayFIarrayIIarrayF;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cftfsub' and count(parameter)=6 and parameter[1][@type='int'] and parameter[2][@type='float[]'] and parameter[3][@type='int'] and parameter[4][@type='int[]'] and parameter[5][@type='int'] and parameter[6][@type='float[]']]"
		[Register ("cftfsub", "(I[FI[II[F)V", "")]
		public static unsafe void Cftfsub (int p0, float[] p1, int p2, int[] p3, int p4, float[] p5)
		{
			if (id_cftfsub_IarrayFIarrayIIarrayF == IntPtr.Zero)
				id_cftfsub_IarrayFIarrayIIarrayF = JNIEnv.GetStaticMethodID (class_ref, "cftfsub", "(I[FI[II[F)V");
			IntPtr native_p1 = JNIEnv.NewArray (p1);
			IntPtr native_p3 = JNIEnv.NewArray (p3);
			IntPtr native_p5 = JNIEnv.NewArray (p5);
			try {
				JValue* __args = stackalloc JValue [6];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (native_p3);
				__args [4] = new JValue (p4);
				__args [5] = new JValue (native_p5);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_cftfsub_IarrayFIarrayIIarrayF, __args);
			} finally {
				if (p1 != null) {
					JNIEnv.CopyArray (native_p1, p1);
					JNIEnv.DeleteLocalRef (native_p1);
				}
				if (p3 != null) {
					JNIEnv.CopyArray (native_p3, p3);
					JNIEnv.DeleteLocalRef (native_p3);
				}
				if (p5 != null) {
					JNIEnv.CopyArray (native_p5, p5);
					JNIEnv.DeleteLocalRef (native_p5);
				}
			}
		}

		static IntPtr id_cftfsub_JLpl_edu_icm_jlargearrays_DoubleLargeArray_JLpl_edu_icm_jlargearrays_LongLargeArray_JLpl_edu_icm_jlargearrays_DoubleLargeArray_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cftfsub' and count(parameter)=6 and parameter[1][@type='long'] and parameter[2][@type='pl.edu.icm.jlargearrays.DoubleLargeArray'] and parameter[3][@type='long'] and parameter[4][@type='pl.edu.icm.jlargearrays.LongLargeArray'] and parameter[5][@type='long'] and parameter[6][@type='pl.edu.icm.jlargearrays.DoubleLargeArray']]"
		[Register ("cftfsub", "(JLpl/edu/icm/jlargearrays/DoubleLargeArray;JLpl/edu/icm/jlargearrays/LongLargeArray;JLpl/edu/icm/jlargearrays/DoubleLargeArray;)V", "")]
		public static unsafe void Cftfsub (long p0, global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p1, long p2, global::PL.Edu.Icm.Jlargearrays.LongLargeArray p3, long p4, global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p5)
		{
			if (id_cftfsub_JLpl_edu_icm_jlargearrays_DoubleLargeArray_JLpl_edu_icm_jlargearrays_LongLargeArray_JLpl_edu_icm_jlargearrays_DoubleLargeArray_ == IntPtr.Zero)
				id_cftfsub_JLpl_edu_icm_jlargearrays_DoubleLargeArray_JLpl_edu_icm_jlargearrays_LongLargeArray_JLpl_edu_icm_jlargearrays_DoubleLargeArray_ = JNIEnv.GetStaticMethodID (class_ref, "cftfsub", "(JLpl/edu/icm/jlargearrays/DoubleLargeArray;JLpl/edu/icm/jlargearrays/LongLargeArray;JLpl/edu/icm/jlargearrays/DoubleLargeArray;)V");
			try {
				JValue* __args = stackalloc JValue [6];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (p4);
				__args [5] = new JValue (p5);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_cftfsub_JLpl_edu_icm_jlargearrays_DoubleLargeArray_JLpl_edu_icm_jlargearrays_LongLargeArray_JLpl_edu_icm_jlargearrays_DoubleLargeArray_, __args);
			} finally {
			}
		}

		static IntPtr id_cftfsub_JLpl_edu_icm_jlargearrays_FloatLargeArray_JLpl_edu_icm_jlargearrays_LongLargeArray_JLpl_edu_icm_jlargearrays_FloatLargeArray_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cftfsub' and count(parameter)=6 and parameter[1][@type='long'] and parameter[2][@type='pl.edu.icm.jlargearrays.FloatLargeArray'] and parameter[3][@type='long'] and parameter[4][@type='pl.edu.icm.jlargearrays.LongLargeArray'] and parameter[5][@type='long'] and parameter[6][@type='pl.edu.icm.jlargearrays.FloatLargeArray']]"
		[Register ("cftfsub", "(JLpl/edu/icm/jlargearrays/FloatLargeArray;JLpl/edu/icm/jlargearrays/LongLargeArray;JLpl/edu/icm/jlargearrays/FloatLargeArray;)V", "")]
		public static unsafe void Cftfsub (long p0, global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p1, long p2, global::PL.Edu.Icm.Jlargearrays.LongLargeArray p3, long p4, global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p5)
		{
			if (id_cftfsub_JLpl_edu_icm_jlargearrays_FloatLargeArray_JLpl_edu_icm_jlargearrays_LongLargeArray_JLpl_edu_icm_jlargearrays_FloatLargeArray_ == IntPtr.Zero)
				id_cftfsub_JLpl_edu_icm_jlargearrays_FloatLargeArray_JLpl_edu_icm_jlargearrays_LongLargeArray_JLpl_edu_icm_jlargearrays_FloatLargeArray_ = JNIEnv.GetStaticMethodID (class_ref, "cftfsub", "(JLpl/edu/icm/jlargearrays/FloatLargeArray;JLpl/edu/icm/jlargearrays/LongLargeArray;JLpl/edu/icm/jlargearrays/FloatLargeArray;)V");
			try {
				JValue* __args = stackalloc JValue [6];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (p4);
				__args [5] = new JValue (p5);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_cftfsub_JLpl_edu_icm_jlargearrays_FloatLargeArray_JLpl_edu_icm_jlargearrays_LongLargeArray_JLpl_edu_icm_jlargearrays_FloatLargeArray_, __args);
			} finally {
			}
		}

		static IntPtr id_cftfx41_IarrayDIIarrayD;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cftfx41' and count(parameter)=5 and parameter[1][@type='int'] and parameter[2][@type='double[]'] and parameter[3][@type='int'] and parameter[4][@type='int'] and parameter[5][@type='double[]']]"
		[Register ("cftfx41", "(I[DII[D)V", "")]
		public static unsafe void Cftfx41 (int p0, double[] p1, int p2, int p3, double[] p4)
		{
			if (id_cftfx41_IarrayDIIarrayD == IntPtr.Zero)
				id_cftfx41_IarrayDIIarrayD = JNIEnv.GetStaticMethodID (class_ref, "cftfx41", "(I[DII[D)V");
			IntPtr native_p1 = JNIEnv.NewArray (p1);
			IntPtr native_p4 = JNIEnv.NewArray (p4);
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (native_p4);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_cftfx41_IarrayDIIarrayD, __args);
			} finally {
				if (p1 != null) {
					JNIEnv.CopyArray (native_p1, p1);
					JNIEnv.DeleteLocalRef (native_p1);
				}
				if (p4 != null) {
					JNIEnv.CopyArray (native_p4, p4);
					JNIEnv.DeleteLocalRef (native_p4);
				}
			}
		}

		static IntPtr id_cftfx41_IarrayFIIarrayF;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cftfx41' and count(parameter)=5 and parameter[1][@type='int'] and parameter[2][@type='float[]'] and parameter[3][@type='int'] and parameter[4][@type='int'] and parameter[5][@type='float[]']]"
		[Register ("cftfx41", "(I[FII[F)V", "")]
		public static unsafe void Cftfx41 (int p0, float[] p1, int p2, int p3, float[] p4)
		{
			if (id_cftfx41_IarrayFIIarrayF == IntPtr.Zero)
				id_cftfx41_IarrayFIIarrayF = JNIEnv.GetStaticMethodID (class_ref, "cftfx41", "(I[FII[F)V");
			IntPtr native_p1 = JNIEnv.NewArray (p1);
			IntPtr native_p4 = JNIEnv.NewArray (p4);
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (native_p4);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_cftfx41_IarrayFIIarrayF, __args);
			} finally {
				if (p1 != null) {
					JNIEnv.CopyArray (native_p1, p1);
					JNIEnv.DeleteLocalRef (native_p1);
				}
				if (p4 != null) {
					JNIEnv.CopyArray (native_p4, p4);
					JNIEnv.DeleteLocalRef (native_p4);
				}
			}
		}

		static IntPtr id_cftfx41_JLpl_edu_icm_jlargearrays_DoubleLargeArray_JJLpl_edu_icm_jlargearrays_DoubleLargeArray_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cftfx41' and count(parameter)=5 and parameter[1][@type='long'] and parameter[2][@type='pl.edu.icm.jlargearrays.DoubleLargeArray'] and parameter[3][@type='long'] and parameter[4][@type='long'] and parameter[5][@type='pl.edu.icm.jlargearrays.DoubleLargeArray']]"
		[Register ("cftfx41", "(JLpl/edu/icm/jlargearrays/DoubleLargeArray;JJLpl/edu/icm/jlargearrays/DoubleLargeArray;)V", "")]
		public static unsafe void Cftfx41 (long p0, global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p1, long p2, long p3, global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p4)
		{
			if (id_cftfx41_JLpl_edu_icm_jlargearrays_DoubleLargeArray_JJLpl_edu_icm_jlargearrays_DoubleLargeArray_ == IntPtr.Zero)
				id_cftfx41_JLpl_edu_icm_jlargearrays_DoubleLargeArray_JJLpl_edu_icm_jlargearrays_DoubleLargeArray_ = JNIEnv.GetStaticMethodID (class_ref, "cftfx41", "(JLpl/edu/icm/jlargearrays/DoubleLargeArray;JJLpl/edu/icm/jlargearrays/DoubleLargeArray;)V");
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (p4);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_cftfx41_JLpl_edu_icm_jlargearrays_DoubleLargeArray_JJLpl_edu_icm_jlargearrays_DoubleLargeArray_, __args);
			} finally {
			}
		}

		static IntPtr id_cftfx41_JLpl_edu_icm_jlargearrays_FloatLargeArray_JJLpl_edu_icm_jlargearrays_FloatLargeArray_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cftfx41' and count(parameter)=5 and parameter[1][@type='long'] and parameter[2][@type='pl.edu.icm.jlargearrays.FloatLargeArray'] and parameter[3][@type='long'] and parameter[4][@type='long'] and parameter[5][@type='pl.edu.icm.jlargearrays.FloatLargeArray']]"
		[Register ("cftfx41", "(JLpl/edu/icm/jlargearrays/FloatLargeArray;JJLpl/edu/icm/jlargearrays/FloatLargeArray;)V", "")]
		public static unsafe void Cftfx41 (long p0, global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p1, long p2, long p3, global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p4)
		{
			if (id_cftfx41_JLpl_edu_icm_jlargearrays_FloatLargeArray_JJLpl_edu_icm_jlargearrays_FloatLargeArray_ == IntPtr.Zero)
				id_cftfx41_JLpl_edu_icm_jlargearrays_FloatLargeArray_JJLpl_edu_icm_jlargearrays_FloatLargeArray_ = JNIEnv.GetStaticMethodID (class_ref, "cftfx41", "(JLpl/edu/icm/jlargearrays/FloatLargeArray;JJLpl/edu/icm/jlargearrays/FloatLargeArray;)V");
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (p4);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_cftfx41_JLpl_edu_icm_jlargearrays_FloatLargeArray_JJLpl_edu_icm_jlargearrays_FloatLargeArray_, __args);
			} finally {
			}
		}

		static IntPtr id_cftleaf_IIarrayDIIarrayD;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cftleaf' and count(parameter)=6 and parameter[1][@type='int'] and parameter[2][@type='int'] and parameter[3][@type='double[]'] and parameter[4][@type='int'] and parameter[5][@type='int'] and parameter[6][@type='double[]']]"
		[Register ("cftleaf", "(II[DII[D)V", "")]
		public static unsafe void Cftleaf (int p0, int p1, double[] p2, int p3, int p4, double[] p5)
		{
			if (id_cftleaf_IIarrayDIIarrayD == IntPtr.Zero)
				id_cftleaf_IIarrayDIIarrayD = JNIEnv.GetStaticMethodID (class_ref, "cftleaf", "(II[DII[D)V");
			IntPtr native_p2 = JNIEnv.NewArray (p2);
			IntPtr native_p5 = JNIEnv.NewArray (p5);
			try {
				JValue* __args = stackalloc JValue [6];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (native_p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (p4);
				__args [5] = new JValue (native_p5);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_cftleaf_IIarrayDIIarrayD, __args);
			} finally {
				if (p2 != null) {
					JNIEnv.CopyArray (native_p2, p2);
					JNIEnv.DeleteLocalRef (native_p2);
				}
				if (p5 != null) {
					JNIEnv.CopyArray (native_p5, p5);
					JNIEnv.DeleteLocalRef (native_p5);
				}
			}
		}

		static IntPtr id_cftleaf_IIarrayFIIarrayF;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cftleaf' and count(parameter)=6 and parameter[1][@type='int'] and parameter[2][@type='int'] and parameter[3][@type='float[]'] and parameter[4][@type='int'] and parameter[5][@type='int'] and parameter[6][@type='float[]']]"
		[Register ("cftleaf", "(II[FII[F)V", "")]
		public static unsafe void Cftleaf (int p0, int p1, float[] p2, int p3, int p4, float[] p5)
		{
			if (id_cftleaf_IIarrayFIIarrayF == IntPtr.Zero)
				id_cftleaf_IIarrayFIIarrayF = JNIEnv.GetStaticMethodID (class_ref, "cftleaf", "(II[FII[F)V");
			IntPtr native_p2 = JNIEnv.NewArray (p2);
			IntPtr native_p5 = JNIEnv.NewArray (p5);
			try {
				JValue* __args = stackalloc JValue [6];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (native_p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (p4);
				__args [5] = new JValue (native_p5);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_cftleaf_IIarrayFIIarrayF, __args);
			} finally {
				if (p2 != null) {
					JNIEnv.CopyArray (native_p2, p2);
					JNIEnv.DeleteLocalRef (native_p2);
				}
				if (p5 != null) {
					JNIEnv.CopyArray (native_p5, p5);
					JNIEnv.DeleteLocalRef (native_p5);
				}
			}
		}

		static IntPtr id_cftleaf_JJLpl_edu_icm_jlargearrays_DoubleLargeArray_JJLpl_edu_icm_jlargearrays_DoubleLargeArray_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cftleaf' and count(parameter)=6 and parameter[1][@type='long'] and parameter[2][@type='long'] and parameter[3][@type='pl.edu.icm.jlargearrays.DoubleLargeArray'] and parameter[4][@type='long'] and parameter[5][@type='long'] and parameter[6][@type='pl.edu.icm.jlargearrays.DoubleLargeArray']]"
		[Register ("cftleaf", "(JJLpl/edu/icm/jlargearrays/DoubleLargeArray;JJLpl/edu/icm/jlargearrays/DoubleLargeArray;)V", "")]
		public static unsafe void Cftleaf (long p0, long p1, global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p2, long p3, long p4, global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p5)
		{
			if (id_cftleaf_JJLpl_edu_icm_jlargearrays_DoubleLargeArray_JJLpl_edu_icm_jlargearrays_DoubleLargeArray_ == IntPtr.Zero)
				id_cftleaf_JJLpl_edu_icm_jlargearrays_DoubleLargeArray_JJLpl_edu_icm_jlargearrays_DoubleLargeArray_ = JNIEnv.GetStaticMethodID (class_ref, "cftleaf", "(JJLpl/edu/icm/jlargearrays/DoubleLargeArray;JJLpl/edu/icm/jlargearrays/DoubleLargeArray;)V");
			try {
				JValue* __args = stackalloc JValue [6];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (p4);
				__args [5] = new JValue (p5);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_cftleaf_JJLpl_edu_icm_jlargearrays_DoubleLargeArray_JJLpl_edu_icm_jlargearrays_DoubleLargeArray_, __args);
			} finally {
			}
		}

		static IntPtr id_cftleaf_JJLpl_edu_icm_jlargearrays_FloatLargeArray_JJLpl_edu_icm_jlargearrays_FloatLargeArray_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cftleaf' and count(parameter)=6 and parameter[1][@type='long'] and parameter[2][@type='long'] and parameter[3][@type='pl.edu.icm.jlargearrays.FloatLargeArray'] and parameter[4][@type='long'] and parameter[5][@type='long'] and parameter[6][@type='pl.edu.icm.jlargearrays.FloatLargeArray']]"
		[Register ("cftleaf", "(JJLpl/edu/icm/jlargearrays/FloatLargeArray;JJLpl/edu/icm/jlargearrays/FloatLargeArray;)V", "")]
		public static unsafe void Cftleaf (long p0, long p1, global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p2, long p3, long p4, global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p5)
		{
			if (id_cftleaf_JJLpl_edu_icm_jlargearrays_FloatLargeArray_JJLpl_edu_icm_jlargearrays_FloatLargeArray_ == IntPtr.Zero)
				id_cftleaf_JJLpl_edu_icm_jlargearrays_FloatLargeArray_JJLpl_edu_icm_jlargearrays_FloatLargeArray_ = JNIEnv.GetStaticMethodID (class_ref, "cftleaf", "(JJLpl/edu/icm/jlargearrays/FloatLargeArray;JJLpl/edu/icm/jlargearrays/FloatLargeArray;)V");
			try {
				JValue* __args = stackalloc JValue [6];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (p4);
				__args [5] = new JValue (p5);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_cftleaf_JJLpl_edu_icm_jlargearrays_FloatLargeArray_JJLpl_edu_icm_jlargearrays_FloatLargeArray_, __args);
			} finally {
			}
		}

		static IntPtr id_cftmdl1_IarrayDIarrayDI;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cftmdl1' and count(parameter)=5 and parameter[1][@type='int'] and parameter[2][@type='double[]'] and parameter[3][@type='int'] and parameter[4][@type='double[]'] and parameter[5][@type='int']]"
		[Register ("cftmdl1", "(I[DI[DI)V", "")]
		public static unsafe void Cftmdl1 (int p0, double[] p1, int p2, double[] p3, int p4)
		{
			if (id_cftmdl1_IarrayDIarrayDI == IntPtr.Zero)
				id_cftmdl1_IarrayDIarrayDI = JNIEnv.GetStaticMethodID (class_ref, "cftmdl1", "(I[DI[DI)V");
			IntPtr native_p1 = JNIEnv.NewArray (p1);
			IntPtr native_p3 = JNIEnv.NewArray (p3);
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (native_p3);
				__args [4] = new JValue (p4);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_cftmdl1_IarrayDIarrayDI, __args);
			} finally {
				if (p1 != null) {
					JNIEnv.CopyArray (native_p1, p1);
					JNIEnv.DeleteLocalRef (native_p1);
				}
				if (p3 != null) {
					JNIEnv.CopyArray (native_p3, p3);
					JNIEnv.DeleteLocalRef (native_p3);
				}
			}
		}

		static IntPtr id_cftmdl1_IarrayFIarrayFI;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cftmdl1' and count(parameter)=5 and parameter[1][@type='int'] and parameter[2][@type='float[]'] and parameter[3][@type='int'] and parameter[4][@type='float[]'] and parameter[5][@type='int']]"
		[Register ("cftmdl1", "(I[FI[FI)V", "")]
		public static unsafe void Cftmdl1 (int p0, float[] p1, int p2, float[] p3, int p4)
		{
			if (id_cftmdl1_IarrayFIarrayFI == IntPtr.Zero)
				id_cftmdl1_IarrayFIarrayFI = JNIEnv.GetStaticMethodID (class_ref, "cftmdl1", "(I[FI[FI)V");
			IntPtr native_p1 = JNIEnv.NewArray (p1);
			IntPtr native_p3 = JNIEnv.NewArray (p3);
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (native_p3);
				__args [4] = new JValue (p4);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_cftmdl1_IarrayFIarrayFI, __args);
			} finally {
				if (p1 != null) {
					JNIEnv.CopyArray (native_p1, p1);
					JNIEnv.DeleteLocalRef (native_p1);
				}
				if (p3 != null) {
					JNIEnv.CopyArray (native_p3, p3);
					JNIEnv.DeleteLocalRef (native_p3);
				}
			}
		}

		static IntPtr id_cftmdl1_JLpl_edu_icm_jlargearrays_DoubleLargeArray_JLpl_edu_icm_jlargearrays_DoubleLargeArray_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cftmdl1' and count(parameter)=5 and parameter[1][@type='long'] and parameter[2][@type='pl.edu.icm.jlargearrays.DoubleLargeArray'] and parameter[3][@type='long'] and parameter[4][@type='pl.edu.icm.jlargearrays.DoubleLargeArray'] and parameter[5][@type='long']]"
		[Register ("cftmdl1", "(JLpl/edu/icm/jlargearrays/DoubleLargeArray;JLpl/edu/icm/jlargearrays/DoubleLargeArray;J)V", "")]
		public static unsafe void Cftmdl1 (long p0, global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p1, long p2, global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p3, long p4)
		{
			if (id_cftmdl1_JLpl_edu_icm_jlargearrays_DoubleLargeArray_JLpl_edu_icm_jlargearrays_DoubleLargeArray_J == IntPtr.Zero)
				id_cftmdl1_JLpl_edu_icm_jlargearrays_DoubleLargeArray_JLpl_edu_icm_jlargearrays_DoubleLargeArray_J = JNIEnv.GetStaticMethodID (class_ref, "cftmdl1", "(JLpl/edu/icm/jlargearrays/DoubleLargeArray;JLpl/edu/icm/jlargearrays/DoubleLargeArray;J)V");
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (p4);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_cftmdl1_JLpl_edu_icm_jlargearrays_DoubleLargeArray_JLpl_edu_icm_jlargearrays_DoubleLargeArray_J, __args);
			} finally {
			}
		}

		static IntPtr id_cftmdl1_JLpl_edu_icm_jlargearrays_FloatLargeArray_JLpl_edu_icm_jlargearrays_FloatLargeArray_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cftmdl1' and count(parameter)=5 and parameter[1][@type='long'] and parameter[2][@type='pl.edu.icm.jlargearrays.FloatLargeArray'] and parameter[3][@type='long'] and parameter[4][@type='pl.edu.icm.jlargearrays.FloatLargeArray'] and parameter[5][@type='long']]"
		[Register ("cftmdl1", "(JLpl/edu/icm/jlargearrays/FloatLargeArray;JLpl/edu/icm/jlargearrays/FloatLargeArray;J)V", "")]
		public static unsafe void Cftmdl1 (long p0, global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p1, long p2, global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p3, long p4)
		{
			if (id_cftmdl1_JLpl_edu_icm_jlargearrays_FloatLargeArray_JLpl_edu_icm_jlargearrays_FloatLargeArray_J == IntPtr.Zero)
				id_cftmdl1_JLpl_edu_icm_jlargearrays_FloatLargeArray_JLpl_edu_icm_jlargearrays_FloatLargeArray_J = JNIEnv.GetStaticMethodID (class_ref, "cftmdl1", "(JLpl/edu/icm/jlargearrays/FloatLargeArray;JLpl/edu/icm/jlargearrays/FloatLargeArray;J)V");
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (p4);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_cftmdl1_JLpl_edu_icm_jlargearrays_FloatLargeArray_JLpl_edu_icm_jlargearrays_FloatLargeArray_J, __args);
			} finally {
			}
		}

		static IntPtr id_cftmdl2_IarrayDIarrayDI;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cftmdl2' and count(parameter)=5 and parameter[1][@type='int'] and parameter[2][@type='double[]'] and parameter[3][@type='int'] and parameter[4][@type='double[]'] and parameter[5][@type='int']]"
		[Register ("cftmdl2", "(I[DI[DI)V", "")]
		public static unsafe void Cftmdl2 (int p0, double[] p1, int p2, double[] p3, int p4)
		{
			if (id_cftmdl2_IarrayDIarrayDI == IntPtr.Zero)
				id_cftmdl2_IarrayDIarrayDI = JNIEnv.GetStaticMethodID (class_ref, "cftmdl2", "(I[DI[DI)V");
			IntPtr native_p1 = JNIEnv.NewArray (p1);
			IntPtr native_p3 = JNIEnv.NewArray (p3);
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (native_p3);
				__args [4] = new JValue (p4);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_cftmdl2_IarrayDIarrayDI, __args);
			} finally {
				if (p1 != null) {
					JNIEnv.CopyArray (native_p1, p1);
					JNIEnv.DeleteLocalRef (native_p1);
				}
				if (p3 != null) {
					JNIEnv.CopyArray (native_p3, p3);
					JNIEnv.DeleteLocalRef (native_p3);
				}
			}
		}

		static IntPtr id_cftmdl2_IarrayFIarrayFI;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cftmdl2' and count(parameter)=5 and parameter[1][@type='int'] and parameter[2][@type='float[]'] and parameter[3][@type='int'] and parameter[4][@type='float[]'] and parameter[5][@type='int']]"
		[Register ("cftmdl2", "(I[FI[FI)V", "")]
		public static unsafe void Cftmdl2 (int p0, float[] p1, int p2, float[] p3, int p4)
		{
			if (id_cftmdl2_IarrayFIarrayFI == IntPtr.Zero)
				id_cftmdl2_IarrayFIarrayFI = JNIEnv.GetStaticMethodID (class_ref, "cftmdl2", "(I[FI[FI)V");
			IntPtr native_p1 = JNIEnv.NewArray (p1);
			IntPtr native_p3 = JNIEnv.NewArray (p3);
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (native_p3);
				__args [4] = new JValue (p4);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_cftmdl2_IarrayFIarrayFI, __args);
			} finally {
				if (p1 != null) {
					JNIEnv.CopyArray (native_p1, p1);
					JNIEnv.DeleteLocalRef (native_p1);
				}
				if (p3 != null) {
					JNIEnv.CopyArray (native_p3, p3);
					JNIEnv.DeleteLocalRef (native_p3);
				}
			}
		}

		static IntPtr id_cftmdl2_JLpl_edu_icm_jlargearrays_DoubleLargeArray_JLpl_edu_icm_jlargearrays_DoubleLargeArray_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cftmdl2' and count(parameter)=5 and parameter[1][@type='long'] and parameter[2][@type='pl.edu.icm.jlargearrays.DoubleLargeArray'] and parameter[3][@type='long'] and parameter[4][@type='pl.edu.icm.jlargearrays.DoubleLargeArray'] and parameter[5][@type='long']]"
		[Register ("cftmdl2", "(JLpl/edu/icm/jlargearrays/DoubleLargeArray;JLpl/edu/icm/jlargearrays/DoubleLargeArray;J)V", "")]
		public static unsafe void Cftmdl2 (long p0, global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p1, long p2, global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p3, long p4)
		{
			if (id_cftmdl2_JLpl_edu_icm_jlargearrays_DoubleLargeArray_JLpl_edu_icm_jlargearrays_DoubleLargeArray_J == IntPtr.Zero)
				id_cftmdl2_JLpl_edu_icm_jlargearrays_DoubleLargeArray_JLpl_edu_icm_jlargearrays_DoubleLargeArray_J = JNIEnv.GetStaticMethodID (class_ref, "cftmdl2", "(JLpl/edu/icm/jlargearrays/DoubleLargeArray;JLpl/edu/icm/jlargearrays/DoubleLargeArray;J)V");
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (p4);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_cftmdl2_JLpl_edu_icm_jlargearrays_DoubleLargeArray_JLpl_edu_icm_jlargearrays_DoubleLargeArray_J, __args);
			} finally {
			}
		}

		static IntPtr id_cftmdl2_JLpl_edu_icm_jlargearrays_FloatLargeArray_JLpl_edu_icm_jlargearrays_FloatLargeArray_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cftmdl2' and count(parameter)=5 and parameter[1][@type='long'] and parameter[2][@type='pl.edu.icm.jlargearrays.FloatLargeArray'] and parameter[3][@type='long'] and parameter[4][@type='pl.edu.icm.jlargearrays.FloatLargeArray'] and parameter[5][@type='long']]"
		[Register ("cftmdl2", "(JLpl/edu/icm/jlargearrays/FloatLargeArray;JLpl/edu/icm/jlargearrays/FloatLargeArray;J)V", "")]
		public static unsafe void Cftmdl2 (long p0, global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p1, long p2, global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p3, long p4)
		{
			if (id_cftmdl2_JLpl_edu_icm_jlargearrays_FloatLargeArray_JLpl_edu_icm_jlargearrays_FloatLargeArray_J == IntPtr.Zero)
				id_cftmdl2_JLpl_edu_icm_jlargearrays_FloatLargeArray_JLpl_edu_icm_jlargearrays_FloatLargeArray_J = JNIEnv.GetStaticMethodID (class_ref, "cftmdl2", "(JLpl/edu/icm/jlargearrays/FloatLargeArray;JLpl/edu/icm/jlargearrays/FloatLargeArray;J)V");
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (p4);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_cftmdl2_JLpl_edu_icm_jlargearrays_FloatLargeArray_JLpl_edu_icm_jlargearrays_FloatLargeArray_J, __args);
			} finally {
			}
		}

		static IntPtr id_cftrec4_IarrayDIIarrayD;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cftrec4' and count(parameter)=5 and parameter[1][@type='int'] and parameter[2][@type='double[]'] and parameter[3][@type='int'] and parameter[4][@type='int'] and parameter[5][@type='double[]']]"
		[Register ("cftrec4", "(I[DII[D)V", "")]
		public static unsafe void Cftrec4 (int p0, double[] p1, int p2, int p3, double[] p4)
		{
			if (id_cftrec4_IarrayDIIarrayD == IntPtr.Zero)
				id_cftrec4_IarrayDIIarrayD = JNIEnv.GetStaticMethodID (class_ref, "cftrec4", "(I[DII[D)V");
			IntPtr native_p1 = JNIEnv.NewArray (p1);
			IntPtr native_p4 = JNIEnv.NewArray (p4);
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (native_p4);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_cftrec4_IarrayDIIarrayD, __args);
			} finally {
				if (p1 != null) {
					JNIEnv.CopyArray (native_p1, p1);
					JNIEnv.DeleteLocalRef (native_p1);
				}
				if (p4 != null) {
					JNIEnv.CopyArray (native_p4, p4);
					JNIEnv.DeleteLocalRef (native_p4);
				}
			}
		}

		static IntPtr id_cftrec4_IarrayFIIarrayF;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cftrec4' and count(parameter)=5 and parameter[1][@type='int'] and parameter[2][@type='float[]'] and parameter[3][@type='int'] and parameter[4][@type='int'] and parameter[5][@type='float[]']]"
		[Register ("cftrec4", "(I[FII[F)V", "")]
		public static unsafe void Cftrec4 (int p0, float[] p1, int p2, int p3, float[] p4)
		{
			if (id_cftrec4_IarrayFIIarrayF == IntPtr.Zero)
				id_cftrec4_IarrayFIIarrayF = JNIEnv.GetStaticMethodID (class_ref, "cftrec4", "(I[FII[F)V");
			IntPtr native_p1 = JNIEnv.NewArray (p1);
			IntPtr native_p4 = JNIEnv.NewArray (p4);
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (native_p4);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_cftrec4_IarrayFIIarrayF, __args);
			} finally {
				if (p1 != null) {
					JNIEnv.CopyArray (native_p1, p1);
					JNIEnv.DeleteLocalRef (native_p1);
				}
				if (p4 != null) {
					JNIEnv.CopyArray (native_p4, p4);
					JNIEnv.DeleteLocalRef (native_p4);
				}
			}
		}

		static IntPtr id_cftrec4_JLpl_edu_icm_jlargearrays_DoubleLargeArray_JJLpl_edu_icm_jlargearrays_DoubleLargeArray_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cftrec4' and count(parameter)=5 and parameter[1][@type='long'] and parameter[2][@type='pl.edu.icm.jlargearrays.DoubleLargeArray'] and parameter[3][@type='long'] and parameter[4][@type='long'] and parameter[5][@type='pl.edu.icm.jlargearrays.DoubleLargeArray']]"
		[Register ("cftrec4", "(JLpl/edu/icm/jlargearrays/DoubleLargeArray;JJLpl/edu/icm/jlargearrays/DoubleLargeArray;)V", "")]
		public static unsafe void Cftrec4 (long p0, global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p1, long p2, long p3, global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p4)
		{
			if (id_cftrec4_JLpl_edu_icm_jlargearrays_DoubleLargeArray_JJLpl_edu_icm_jlargearrays_DoubleLargeArray_ == IntPtr.Zero)
				id_cftrec4_JLpl_edu_icm_jlargearrays_DoubleLargeArray_JJLpl_edu_icm_jlargearrays_DoubleLargeArray_ = JNIEnv.GetStaticMethodID (class_ref, "cftrec4", "(JLpl/edu/icm/jlargearrays/DoubleLargeArray;JJLpl/edu/icm/jlargearrays/DoubleLargeArray;)V");
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (p4);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_cftrec4_JLpl_edu_icm_jlargearrays_DoubleLargeArray_JJLpl_edu_icm_jlargearrays_DoubleLargeArray_, __args);
			} finally {
			}
		}

		static IntPtr id_cftrec4_JLpl_edu_icm_jlargearrays_FloatLargeArray_JJLpl_edu_icm_jlargearrays_FloatLargeArray_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cftrec4' and count(parameter)=5 and parameter[1][@type='long'] and parameter[2][@type='pl.edu.icm.jlargearrays.FloatLargeArray'] and parameter[3][@type='long'] and parameter[4][@type='long'] and parameter[5][@type='pl.edu.icm.jlargearrays.FloatLargeArray']]"
		[Register ("cftrec4", "(JLpl/edu/icm/jlargearrays/FloatLargeArray;JJLpl/edu/icm/jlargearrays/FloatLargeArray;)V", "")]
		public static unsafe void Cftrec4 (long p0, global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p1, long p2, long p3, global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p4)
		{
			if (id_cftrec4_JLpl_edu_icm_jlargearrays_FloatLargeArray_JJLpl_edu_icm_jlargearrays_FloatLargeArray_ == IntPtr.Zero)
				id_cftrec4_JLpl_edu_icm_jlargearrays_FloatLargeArray_JJLpl_edu_icm_jlargearrays_FloatLargeArray_ = JNIEnv.GetStaticMethodID (class_ref, "cftrec4", "(JLpl/edu/icm/jlargearrays/FloatLargeArray;JJLpl/edu/icm/jlargearrays/FloatLargeArray;)V");
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (p4);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_cftrec4_JLpl_edu_icm_jlargearrays_FloatLargeArray_JJLpl_edu_icm_jlargearrays_FloatLargeArray_, __args);
			} finally {
			}
		}

		static IntPtr id_cftrec4_th_IarrayDIIarrayD;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cftrec4_th' and count(parameter)=5 and parameter[1][@type='int'] and parameter[2][@type='double[]'] and parameter[3][@type='int'] and parameter[4][@type='int'] and parameter[5][@type='double[]']]"
		[Register ("cftrec4_th", "(I[DII[D)V", "")]
		public static unsafe void Cftrec4_th (int p0, double[] p1, int p2, int p3, double[] p4)
		{
			if (id_cftrec4_th_IarrayDIIarrayD == IntPtr.Zero)
				id_cftrec4_th_IarrayDIIarrayD = JNIEnv.GetStaticMethodID (class_ref, "cftrec4_th", "(I[DII[D)V");
			IntPtr native_p1 = JNIEnv.NewArray (p1);
			IntPtr native_p4 = JNIEnv.NewArray (p4);
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (native_p4);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_cftrec4_th_IarrayDIIarrayD, __args);
			} finally {
				if (p1 != null) {
					JNIEnv.CopyArray (native_p1, p1);
					JNIEnv.DeleteLocalRef (native_p1);
				}
				if (p4 != null) {
					JNIEnv.CopyArray (native_p4, p4);
					JNIEnv.DeleteLocalRef (native_p4);
				}
			}
		}

		static IntPtr id_cftrec4_th_IarrayFIIarrayF;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cftrec4_th' and count(parameter)=5 and parameter[1][@type='int'] and parameter[2][@type='float[]'] and parameter[3][@type='int'] and parameter[4][@type='int'] and parameter[5][@type='float[]']]"
		[Register ("cftrec4_th", "(I[FII[F)V", "")]
		public static unsafe void Cftrec4_th (int p0, float[] p1, int p2, int p3, float[] p4)
		{
			if (id_cftrec4_th_IarrayFIIarrayF == IntPtr.Zero)
				id_cftrec4_th_IarrayFIIarrayF = JNIEnv.GetStaticMethodID (class_ref, "cftrec4_th", "(I[FII[F)V");
			IntPtr native_p1 = JNIEnv.NewArray (p1);
			IntPtr native_p4 = JNIEnv.NewArray (p4);
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (native_p4);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_cftrec4_th_IarrayFIIarrayF, __args);
			} finally {
				if (p1 != null) {
					JNIEnv.CopyArray (native_p1, p1);
					JNIEnv.DeleteLocalRef (native_p1);
				}
				if (p4 != null) {
					JNIEnv.CopyArray (native_p4, p4);
					JNIEnv.DeleteLocalRef (native_p4);
				}
			}
		}

		static IntPtr id_cftrec4_th_JLpl_edu_icm_jlargearrays_DoubleLargeArray_JJLpl_edu_icm_jlargearrays_DoubleLargeArray_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cftrec4_th' and count(parameter)=5 and parameter[1][@type='long'] and parameter[2][@type='pl.edu.icm.jlargearrays.DoubleLargeArray'] and parameter[3][@type='long'] and parameter[4][@type='long'] and parameter[5][@type='pl.edu.icm.jlargearrays.DoubleLargeArray']]"
		[Register ("cftrec4_th", "(JLpl/edu/icm/jlargearrays/DoubleLargeArray;JJLpl/edu/icm/jlargearrays/DoubleLargeArray;)V", "")]
		public static unsafe void Cftrec4_th (long p0, global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p1, long p2, long p3, global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p4)
		{
			if (id_cftrec4_th_JLpl_edu_icm_jlargearrays_DoubleLargeArray_JJLpl_edu_icm_jlargearrays_DoubleLargeArray_ == IntPtr.Zero)
				id_cftrec4_th_JLpl_edu_icm_jlargearrays_DoubleLargeArray_JJLpl_edu_icm_jlargearrays_DoubleLargeArray_ = JNIEnv.GetStaticMethodID (class_ref, "cftrec4_th", "(JLpl/edu/icm/jlargearrays/DoubleLargeArray;JJLpl/edu/icm/jlargearrays/DoubleLargeArray;)V");
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (p4);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_cftrec4_th_JLpl_edu_icm_jlargearrays_DoubleLargeArray_JJLpl_edu_icm_jlargearrays_DoubleLargeArray_, __args);
			} finally {
			}
		}

		static IntPtr id_cftrec4_th_JLpl_edu_icm_jlargearrays_FloatLargeArray_JJLpl_edu_icm_jlargearrays_FloatLargeArray_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cftrec4_th' and count(parameter)=5 and parameter[1][@type='long'] and parameter[2][@type='pl.edu.icm.jlargearrays.FloatLargeArray'] and parameter[3][@type='long'] and parameter[4][@type='long'] and parameter[5][@type='pl.edu.icm.jlargearrays.FloatLargeArray']]"
		[Register ("cftrec4_th", "(JLpl/edu/icm/jlargearrays/FloatLargeArray;JJLpl/edu/icm/jlargearrays/FloatLargeArray;)V", "")]
		public static unsafe void Cftrec4_th (long p0, global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p1, long p2, long p3, global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p4)
		{
			if (id_cftrec4_th_JLpl_edu_icm_jlargearrays_FloatLargeArray_JJLpl_edu_icm_jlargearrays_FloatLargeArray_ == IntPtr.Zero)
				id_cftrec4_th_JLpl_edu_icm_jlargearrays_FloatLargeArray_JJLpl_edu_icm_jlargearrays_FloatLargeArray_ = JNIEnv.GetStaticMethodID (class_ref, "cftrec4_th", "(JLpl/edu/icm/jlargearrays/FloatLargeArray;JJLpl/edu/icm/jlargearrays/FloatLargeArray;)V");
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (p4);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_cftrec4_th_JLpl_edu_icm_jlargearrays_FloatLargeArray_JJLpl_edu_icm_jlargearrays_FloatLargeArray_, __args);
			} finally {
			}
		}

		static IntPtr id_cfttree_IIIarrayDIIarrayD;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cfttree' and count(parameter)=7 and parameter[1][@type='int'] and parameter[2][@type='int'] and parameter[3][@type='int'] and parameter[4][@type='double[]'] and parameter[5][@type='int'] and parameter[6][@type='int'] and parameter[7][@type='double[]']]"
		[Register ("cfttree", "(III[DII[D)I", "")]
		public static unsafe int Cfttree (int p0, int p1, int p2, double[] p3, int p4, int p5, double[] p6)
		{
			if (id_cfttree_IIIarrayDIIarrayD == IntPtr.Zero)
				id_cfttree_IIIarrayDIIarrayD = JNIEnv.GetStaticMethodID (class_ref, "cfttree", "(III[DII[D)I");
			IntPtr native_p3 = JNIEnv.NewArray (p3);
			IntPtr native_p6 = JNIEnv.NewArray (p6);
			try {
				JValue* __args = stackalloc JValue [7];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (native_p3);
				__args [4] = new JValue (p4);
				__args [5] = new JValue (p5);
				__args [6] = new JValue (native_p6);
				int __ret = JNIEnv.CallStaticIntMethod  (class_ref, id_cfttree_IIIarrayDIIarrayD, __args);
				return __ret;
			} finally {
				if (p3 != null) {
					JNIEnv.CopyArray (native_p3, p3);
					JNIEnv.DeleteLocalRef (native_p3);
				}
				if (p6 != null) {
					JNIEnv.CopyArray (native_p6, p6);
					JNIEnv.DeleteLocalRef (native_p6);
				}
			}
		}

		static IntPtr id_cfttree_IIIarrayFIIarrayF;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cfttree' and count(parameter)=7 and parameter[1][@type='int'] and parameter[2][@type='int'] and parameter[3][@type='int'] and parameter[4][@type='float[]'] and parameter[5][@type='int'] and parameter[6][@type='int'] and parameter[7][@type='float[]']]"
		[Register ("cfttree", "(III[FII[F)I", "")]
		public static unsafe int Cfttree (int p0, int p1, int p2, float[] p3, int p4, int p5, float[] p6)
		{
			if (id_cfttree_IIIarrayFIIarrayF == IntPtr.Zero)
				id_cfttree_IIIarrayFIIarrayF = JNIEnv.GetStaticMethodID (class_ref, "cfttree", "(III[FII[F)I");
			IntPtr native_p3 = JNIEnv.NewArray (p3);
			IntPtr native_p6 = JNIEnv.NewArray (p6);
			try {
				JValue* __args = stackalloc JValue [7];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (native_p3);
				__args [4] = new JValue (p4);
				__args [5] = new JValue (p5);
				__args [6] = new JValue (native_p6);
				int __ret = JNIEnv.CallStaticIntMethod  (class_ref, id_cfttree_IIIarrayFIIarrayF, __args);
				return __ret;
			} finally {
				if (p3 != null) {
					JNIEnv.CopyArray (native_p3, p3);
					JNIEnv.DeleteLocalRef (native_p3);
				}
				if (p6 != null) {
					JNIEnv.CopyArray (native_p6, p6);
					JNIEnv.DeleteLocalRef (native_p6);
				}
			}
		}

		static IntPtr id_cfttree_JJJLpl_edu_icm_jlargearrays_DoubleLargeArray_JJLpl_edu_icm_jlargearrays_DoubleLargeArray_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cfttree' and count(parameter)=7 and parameter[1][@type='long'] and parameter[2][@type='long'] and parameter[3][@type='long'] and parameter[4][@type='pl.edu.icm.jlargearrays.DoubleLargeArray'] and parameter[5][@type='long'] and parameter[6][@type='long'] and parameter[7][@type='pl.edu.icm.jlargearrays.DoubleLargeArray']]"
		[Register ("cfttree", "(JJJLpl/edu/icm/jlargearrays/DoubleLargeArray;JJLpl/edu/icm/jlargearrays/DoubleLargeArray;)J", "")]
		public static unsafe long Cfttree (long p0, long p1, long p2, global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p3, long p4, long p5, global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p6)
		{
			if (id_cfttree_JJJLpl_edu_icm_jlargearrays_DoubleLargeArray_JJLpl_edu_icm_jlargearrays_DoubleLargeArray_ == IntPtr.Zero)
				id_cfttree_JJJLpl_edu_icm_jlargearrays_DoubleLargeArray_JJLpl_edu_icm_jlargearrays_DoubleLargeArray_ = JNIEnv.GetStaticMethodID (class_ref, "cfttree", "(JJJLpl/edu/icm/jlargearrays/DoubleLargeArray;JJLpl/edu/icm/jlargearrays/DoubleLargeArray;)J");
			try {
				JValue* __args = stackalloc JValue [7];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (p4);
				__args [5] = new JValue (p5);
				__args [6] = new JValue (p6);
				long __ret = JNIEnv.CallStaticLongMethod  (class_ref, id_cfttree_JJJLpl_edu_icm_jlargearrays_DoubleLargeArray_JJLpl_edu_icm_jlargearrays_DoubleLargeArray_, __args);
				return __ret;
			} finally {
			}
		}

		static IntPtr id_cfttree_JJJLpl_edu_icm_jlargearrays_FloatLargeArray_JJLpl_edu_icm_jlargearrays_FloatLargeArray_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cfttree' and count(parameter)=7 and parameter[1][@type='long'] and parameter[2][@type='long'] and parameter[3][@type='long'] and parameter[4][@type='pl.edu.icm.jlargearrays.FloatLargeArray'] and parameter[5][@type='long'] and parameter[6][@type='long'] and parameter[7][@type='pl.edu.icm.jlargearrays.FloatLargeArray']]"
		[Register ("cfttree", "(JJJLpl/edu/icm/jlargearrays/FloatLargeArray;JJLpl/edu/icm/jlargearrays/FloatLargeArray;)J", "")]
		public static unsafe long Cfttree (long p0, long p1, long p2, global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p3, long p4, long p5, global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p6)
		{
			if (id_cfttree_JJJLpl_edu_icm_jlargearrays_FloatLargeArray_JJLpl_edu_icm_jlargearrays_FloatLargeArray_ == IntPtr.Zero)
				id_cfttree_JJJLpl_edu_icm_jlargearrays_FloatLargeArray_JJLpl_edu_icm_jlargearrays_FloatLargeArray_ = JNIEnv.GetStaticMethodID (class_ref, "cfttree", "(JJJLpl/edu/icm/jlargearrays/FloatLargeArray;JJLpl/edu/icm/jlargearrays/FloatLargeArray;)J");
			try {
				JValue* __args = stackalloc JValue [7];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (p4);
				__args [5] = new JValue (p5);
				__args [6] = new JValue (p6);
				long __ret = JNIEnv.CallStaticLongMethod  (class_ref, id_cfttree_JJJLpl_edu_icm_jlargearrays_FloatLargeArray_JJLpl_edu_icm_jlargearrays_FloatLargeArray_, __args);
				return __ret;
			} finally {
			}
		}

		static IntPtr id_cftx020_arrayDI;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cftx020' and count(parameter)=2 and parameter[1][@type='double[]'] and parameter[2][@type='int']]"
		[Register ("cftx020", "([DI)V", "")]
		public static unsafe void Cftx020 (double[] p0, int p1)
		{
			if (id_cftx020_arrayDI == IntPtr.Zero)
				id_cftx020_arrayDI = JNIEnv.GetStaticMethodID (class_ref, "cftx020", "([DI)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_cftx020_arrayDI, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static IntPtr id_cftx020_arrayFI;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cftx020' and count(parameter)=2 and parameter[1][@type='float[]'] and parameter[2][@type='int']]"
		[Register ("cftx020", "([FI)V", "")]
		public static unsafe void Cftx020 (float[] p0, int p1)
		{
			if (id_cftx020_arrayFI == IntPtr.Zero)
				id_cftx020_arrayFI = JNIEnv.GetStaticMethodID (class_ref, "cftx020", "([FI)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_cftx020_arrayFI, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static IntPtr id_cftx020_Lpl_edu_icm_jlargearrays_DoubleLargeArray_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cftx020' and count(parameter)=2 and parameter[1][@type='pl.edu.icm.jlargearrays.DoubleLargeArray'] and parameter[2][@type='long']]"
		[Register ("cftx020", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;J)V", "")]
		public static unsafe void Cftx020 (global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p0, long p1)
		{
			if (id_cftx020_Lpl_edu_icm_jlargearrays_DoubleLargeArray_J == IntPtr.Zero)
				id_cftx020_Lpl_edu_icm_jlargearrays_DoubleLargeArray_J = JNIEnv.GetStaticMethodID (class_ref, "cftx020", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;J)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_cftx020_Lpl_edu_icm_jlargearrays_DoubleLargeArray_J, __args);
			} finally {
			}
		}

		static IntPtr id_cftx020_Lpl_edu_icm_jlargearrays_FloatLargeArray_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cftx020' and count(parameter)=2 and parameter[1][@type='pl.edu.icm.jlargearrays.FloatLargeArray'] and parameter[2][@type='long']]"
		[Register ("cftx020", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;J)V", "")]
		public static unsafe void Cftx020 (global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p0, long p1)
		{
			if (id_cftx020_Lpl_edu_icm_jlargearrays_FloatLargeArray_J == IntPtr.Zero)
				id_cftx020_Lpl_edu_icm_jlargearrays_FloatLargeArray_J = JNIEnv.GetStaticMethodID (class_ref, "cftx020", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;J)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_cftx020_Lpl_edu_icm_jlargearrays_FloatLargeArray_J, __args);
			} finally {
			}
		}

		static IntPtr id_cftxb020_arrayDI;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cftxb020' and count(parameter)=2 and parameter[1][@type='double[]'] and parameter[2][@type='int']]"
		[Register ("cftxb020", "([DI)V", "")]
		public static unsafe void Cftxb020 (double[] p0, int p1)
		{
			if (id_cftxb020_arrayDI == IntPtr.Zero)
				id_cftxb020_arrayDI = JNIEnv.GetStaticMethodID (class_ref, "cftxb020", "([DI)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_cftxb020_arrayDI, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static IntPtr id_cftxb020_arrayFI;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cftxb020' and count(parameter)=2 and parameter[1][@type='float[]'] and parameter[2][@type='int']]"
		[Register ("cftxb020", "([FI)V", "")]
		public static unsafe void Cftxb020 (float[] p0, int p1)
		{
			if (id_cftxb020_arrayFI == IntPtr.Zero)
				id_cftxb020_arrayFI = JNIEnv.GetStaticMethodID (class_ref, "cftxb020", "([FI)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_cftxb020_arrayFI, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static IntPtr id_cftxb020_Lpl_edu_icm_jlargearrays_DoubleLargeArray_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cftxb020' and count(parameter)=2 and parameter[1][@type='pl.edu.icm.jlargearrays.DoubleLargeArray'] and parameter[2][@type='long']]"
		[Register ("cftxb020", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;J)V", "")]
		public static unsafe void Cftxb020 (global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p0, long p1)
		{
			if (id_cftxb020_Lpl_edu_icm_jlargearrays_DoubleLargeArray_J == IntPtr.Zero)
				id_cftxb020_Lpl_edu_icm_jlargearrays_DoubleLargeArray_J = JNIEnv.GetStaticMethodID (class_ref, "cftxb020", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;J)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_cftxb020_Lpl_edu_icm_jlargearrays_DoubleLargeArray_J, __args);
			} finally {
			}
		}

		static IntPtr id_cftxb020_Lpl_edu_icm_jlargearrays_FloatLargeArray_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cftxb020' and count(parameter)=2 and parameter[1][@type='pl.edu.icm.jlargearrays.FloatLargeArray'] and parameter[2][@type='long']]"
		[Register ("cftxb020", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;J)V", "")]
		public static unsafe void Cftxb020 (global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p0, long p1)
		{
			if (id_cftxb020_Lpl_edu_icm_jlargearrays_FloatLargeArray_J == IntPtr.Zero)
				id_cftxb020_Lpl_edu_icm_jlargearrays_FloatLargeArray_J = JNIEnv.GetStaticMethodID (class_ref, "cftxb020", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;J)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_cftxb020_Lpl_edu_icm_jlargearrays_FloatLargeArray_J, __args);
			} finally {
			}
		}

		static IntPtr id_cftxc020_arrayDI;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cftxc020' and count(parameter)=2 and parameter[1][@type='double[]'] and parameter[2][@type='int']]"
		[Register ("cftxc020", "([DI)V", "")]
		public static unsafe void Cftxc020 (double[] p0, int p1)
		{
			if (id_cftxc020_arrayDI == IntPtr.Zero)
				id_cftxc020_arrayDI = JNIEnv.GetStaticMethodID (class_ref, "cftxc020", "([DI)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_cftxc020_arrayDI, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static IntPtr id_cftxc020_arrayFI;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cftxc020' and count(parameter)=2 and parameter[1][@type='float[]'] and parameter[2][@type='int']]"
		[Register ("cftxc020", "([FI)V", "")]
		public static unsafe void Cftxc020 (float[] p0, int p1)
		{
			if (id_cftxc020_arrayFI == IntPtr.Zero)
				id_cftxc020_arrayFI = JNIEnv.GetStaticMethodID (class_ref, "cftxc020", "([FI)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_cftxc020_arrayFI, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static IntPtr id_cftxc020_Lpl_edu_icm_jlargearrays_DoubleLargeArray_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cftxc020' and count(parameter)=2 and parameter[1][@type='pl.edu.icm.jlargearrays.DoubleLargeArray'] and parameter[2][@type='long']]"
		[Register ("cftxc020", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;J)V", "")]
		public static unsafe void Cftxc020 (global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p0, long p1)
		{
			if (id_cftxc020_Lpl_edu_icm_jlargearrays_DoubleLargeArray_J == IntPtr.Zero)
				id_cftxc020_Lpl_edu_icm_jlargearrays_DoubleLargeArray_J = JNIEnv.GetStaticMethodID (class_ref, "cftxc020", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;J)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_cftxc020_Lpl_edu_icm_jlargearrays_DoubleLargeArray_J, __args);
			} finally {
			}
		}

		static IntPtr id_cftxc020_Lpl_edu_icm_jlargearrays_FloatLargeArray_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='cftxc020' and count(parameter)=2 and parameter[1][@type='pl.edu.icm.jlargearrays.FloatLargeArray'] and parameter[2][@type='long']]"
		[Register ("cftxc020", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;J)V", "")]
		public static unsafe void Cftxc020 (global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p0, long p1)
		{
			if (id_cftxc020_Lpl_edu_icm_jlargearrays_FloatLargeArray_J == IntPtr.Zero)
				id_cftxc020_Lpl_edu_icm_jlargearrays_FloatLargeArray_J = JNIEnv.GetStaticMethodID (class_ref, "cftxc020", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;J)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_cftxc020_Lpl_edu_icm_jlargearrays_FloatLargeArray_J, __args);
			} finally {
			}
		}

		static IntPtr id_dctsub_IarrayDIIarrayDI;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='dctsub' and count(parameter)=6 and parameter[1][@type='int'] and parameter[2][@type='double[]'] and parameter[3][@type='int'] and parameter[4][@type='int'] and parameter[5][@type='double[]'] and parameter[6][@type='int']]"
		[Register ("dctsub", "(I[DII[DI)V", "")]
		public static unsafe void Dctsub (int p0, double[] p1, int p2, int p3, double[] p4, int p5)
		{
			if (id_dctsub_IarrayDIIarrayDI == IntPtr.Zero)
				id_dctsub_IarrayDIIarrayDI = JNIEnv.GetStaticMethodID (class_ref, "dctsub", "(I[DII[DI)V");
			IntPtr native_p1 = JNIEnv.NewArray (p1);
			IntPtr native_p4 = JNIEnv.NewArray (p4);
			try {
				JValue* __args = stackalloc JValue [6];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (native_p4);
				__args [5] = new JValue (p5);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_dctsub_IarrayDIIarrayDI, __args);
			} finally {
				if (p1 != null) {
					JNIEnv.CopyArray (native_p1, p1);
					JNIEnv.DeleteLocalRef (native_p1);
				}
				if (p4 != null) {
					JNIEnv.CopyArray (native_p4, p4);
					JNIEnv.DeleteLocalRef (native_p4);
				}
			}
		}

		static IntPtr id_dctsub_IarrayFIIarrayFI;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='dctsub' and count(parameter)=6 and parameter[1][@type='int'] and parameter[2][@type='float[]'] and parameter[3][@type='int'] and parameter[4][@type='int'] and parameter[5][@type='float[]'] and parameter[6][@type='int']]"
		[Register ("dctsub", "(I[FII[FI)V", "")]
		public static unsafe void Dctsub (int p0, float[] p1, int p2, int p3, float[] p4, int p5)
		{
			if (id_dctsub_IarrayFIIarrayFI == IntPtr.Zero)
				id_dctsub_IarrayFIIarrayFI = JNIEnv.GetStaticMethodID (class_ref, "dctsub", "(I[FII[FI)V");
			IntPtr native_p1 = JNIEnv.NewArray (p1);
			IntPtr native_p4 = JNIEnv.NewArray (p4);
			try {
				JValue* __args = stackalloc JValue [6];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (native_p4);
				__args [5] = new JValue (p5);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_dctsub_IarrayFIIarrayFI, __args);
			} finally {
				if (p1 != null) {
					JNIEnv.CopyArray (native_p1, p1);
					JNIEnv.DeleteLocalRef (native_p1);
				}
				if (p4 != null) {
					JNIEnv.CopyArray (native_p4, p4);
					JNIEnv.DeleteLocalRef (native_p4);
				}
			}
		}

		static IntPtr id_dctsub_JLpl_edu_icm_jlargearrays_DoubleLargeArray_JJLpl_edu_icm_jlargearrays_DoubleLargeArray_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='dctsub' and count(parameter)=6 and parameter[1][@type='long'] and parameter[2][@type='pl.edu.icm.jlargearrays.DoubleLargeArray'] and parameter[3][@type='long'] and parameter[4][@type='long'] and parameter[5][@type='pl.edu.icm.jlargearrays.DoubleLargeArray'] and parameter[6][@type='long']]"
		[Register ("dctsub", "(JLpl/edu/icm/jlargearrays/DoubleLargeArray;JJLpl/edu/icm/jlargearrays/DoubleLargeArray;J)V", "")]
		public static unsafe void Dctsub (long p0, global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p1, long p2, long p3, global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p4, long p5)
		{
			if (id_dctsub_JLpl_edu_icm_jlargearrays_DoubleLargeArray_JJLpl_edu_icm_jlargearrays_DoubleLargeArray_J == IntPtr.Zero)
				id_dctsub_JLpl_edu_icm_jlargearrays_DoubleLargeArray_JJLpl_edu_icm_jlargearrays_DoubleLargeArray_J = JNIEnv.GetStaticMethodID (class_ref, "dctsub", "(JLpl/edu/icm/jlargearrays/DoubleLargeArray;JJLpl/edu/icm/jlargearrays/DoubleLargeArray;J)V");
			try {
				JValue* __args = stackalloc JValue [6];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (p4);
				__args [5] = new JValue (p5);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_dctsub_JLpl_edu_icm_jlargearrays_DoubleLargeArray_JJLpl_edu_icm_jlargearrays_DoubleLargeArray_J, __args);
			} finally {
			}
		}

		static IntPtr id_dctsub_JLpl_edu_icm_jlargearrays_FloatLargeArray_JJLpl_edu_icm_jlargearrays_FloatLargeArray_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='dctsub' and count(parameter)=6 and parameter[1][@type='long'] and parameter[2][@type='pl.edu.icm.jlargearrays.FloatLargeArray'] and parameter[3][@type='long'] and parameter[4][@type='long'] and parameter[5][@type='pl.edu.icm.jlargearrays.FloatLargeArray'] and parameter[6][@type='long']]"
		[Register ("dctsub", "(JLpl/edu/icm/jlargearrays/FloatLargeArray;JJLpl/edu/icm/jlargearrays/FloatLargeArray;J)V", "")]
		public static unsafe void Dctsub (long p0, global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p1, long p2, long p3, global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p4, long p5)
		{
			if (id_dctsub_JLpl_edu_icm_jlargearrays_FloatLargeArray_JJLpl_edu_icm_jlargearrays_FloatLargeArray_J == IntPtr.Zero)
				id_dctsub_JLpl_edu_icm_jlargearrays_FloatLargeArray_JJLpl_edu_icm_jlargearrays_FloatLargeArray_J = JNIEnv.GetStaticMethodID (class_ref, "dctsub", "(JLpl/edu/icm/jlargearrays/FloatLargeArray;JJLpl/edu/icm/jlargearrays/FloatLargeArray;J)V");
			try {
				JValue* __args = stackalloc JValue [6];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (p4);
				__args [5] = new JValue (p5);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_dctsub_JLpl_edu_icm_jlargearrays_FloatLargeArray_JJLpl_edu_icm_jlargearrays_FloatLargeArray_J, __args);
			} finally {
			}
		}

		static IntPtr id_getReminder_JarrayI;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='getReminder' and count(parameter)=2 and parameter[1][@type='long'] and parameter[2][@type='int[]']]"
		[Register ("getReminder", "(J[I)J", "")]
		public static unsafe long GetReminder (long p0, int[] p1)
		{
			if (id_getReminder_JarrayI == IntPtr.Zero)
				id_getReminder_JarrayI = JNIEnv.GetStaticMethodID (class_ref, "getReminder", "(J[I)J");
			IntPtr native_p1 = JNIEnv.NewArray (p1);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				long __ret = JNIEnv.CallStaticLongMethod  (class_ref, id_getReminder_JarrayI, __args);
				return __ret;
			} finally {
				if (p1 != null) {
					JNIEnv.CopyArray (native_p1, p1);
					JNIEnv.DeleteLocalRef (native_p1);
				}
			}
		}

		static IntPtr id_isPowerOf2_I;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='isPowerOf2' and count(parameter)=1 and parameter[1][@type='int']]"
		[Register ("isPowerOf2", "(I)Z", "")]
		public static unsafe bool IsPowerOf2 (int p0)
		{
			if (id_isPowerOf2_I == IntPtr.Zero)
				id_isPowerOf2_I = JNIEnv.GetStaticMethodID (class_ref, "isPowerOf2", "(I)Z");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				return JNIEnv.CallStaticBooleanMethod  (class_ref, id_isPowerOf2_I, __args);
			} finally {
			}
		}

		static IntPtr id_isPowerOf2_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='isPowerOf2' and count(parameter)=1 and parameter[1][@type='long']]"
		[Register ("isPowerOf2", "(J)Z", "")]
		public static unsafe bool IsPowerOf2 (long p0)
		{
			if (id_isPowerOf2_J == IntPtr.Zero)
				id_isPowerOf2_J = JNIEnv.GetStaticMethodID (class_ref, "isPowerOf2", "(J)Z");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				return JNIEnv.CallStaticBooleanMethod  (class_ref, id_isPowerOf2_J, __args);
			} finally {
			}
		}

		static IntPtr id_makect_IarrayDIarrayI;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='makect' and count(parameter)=4 and parameter[1][@type='int'] and parameter[2][@type='double[]'] and parameter[3][@type='int'] and parameter[4][@type='int[]']]"
		[Register ("makect", "(I[DI[I)V", "")]
		public static unsafe void Makect (int p0, double[] p1, int p2, int[] p3)
		{
			if (id_makect_IarrayDIarrayI == IntPtr.Zero)
				id_makect_IarrayDIarrayI = JNIEnv.GetStaticMethodID (class_ref, "makect", "(I[DI[I)V");
			IntPtr native_p1 = JNIEnv.NewArray (p1);
			IntPtr native_p3 = JNIEnv.NewArray (p3);
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (native_p3);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_makect_IarrayDIarrayI, __args);
			} finally {
				if (p1 != null) {
					JNIEnv.CopyArray (native_p1, p1);
					JNIEnv.DeleteLocalRef (native_p1);
				}
				if (p3 != null) {
					JNIEnv.CopyArray (native_p3, p3);
					JNIEnv.DeleteLocalRef (native_p3);
				}
			}
		}

		static IntPtr id_makect_IarrayFIarrayI;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='makect' and count(parameter)=4 and parameter[1][@type='int'] and parameter[2][@type='float[]'] and parameter[3][@type='int'] and parameter[4][@type='int[]']]"
		[Register ("makect", "(I[FI[I)V", "")]
		public static unsafe void Makect (int p0, float[] p1, int p2, int[] p3)
		{
			if (id_makect_IarrayFIarrayI == IntPtr.Zero)
				id_makect_IarrayFIarrayI = JNIEnv.GetStaticMethodID (class_ref, "makect", "(I[FI[I)V");
			IntPtr native_p1 = JNIEnv.NewArray (p1);
			IntPtr native_p3 = JNIEnv.NewArray (p3);
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (native_p3);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_makect_IarrayFIarrayI, __args);
			} finally {
				if (p1 != null) {
					JNIEnv.CopyArray (native_p1, p1);
					JNIEnv.DeleteLocalRef (native_p1);
				}
				if (p3 != null) {
					JNIEnv.CopyArray (native_p3, p3);
					JNIEnv.DeleteLocalRef (native_p3);
				}
			}
		}

		static IntPtr id_makect_JLpl_edu_icm_jlargearrays_DoubleLargeArray_JLpl_edu_icm_jlargearrays_LongLargeArray_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='makect' and count(parameter)=4 and parameter[1][@type='long'] and parameter[2][@type='pl.edu.icm.jlargearrays.DoubleLargeArray'] and parameter[3][@type='long'] and parameter[4][@type='pl.edu.icm.jlargearrays.LongLargeArray']]"
		[Register ("makect", "(JLpl/edu/icm/jlargearrays/DoubleLargeArray;JLpl/edu/icm/jlargearrays/LongLargeArray;)V", "")]
		public static unsafe void Makect (long p0, global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p1, long p2, global::PL.Edu.Icm.Jlargearrays.LongLargeArray p3)
		{
			if (id_makect_JLpl_edu_icm_jlargearrays_DoubleLargeArray_JLpl_edu_icm_jlargearrays_LongLargeArray_ == IntPtr.Zero)
				id_makect_JLpl_edu_icm_jlargearrays_DoubleLargeArray_JLpl_edu_icm_jlargearrays_LongLargeArray_ = JNIEnv.GetStaticMethodID (class_ref, "makect", "(JLpl/edu/icm/jlargearrays/DoubleLargeArray;JLpl/edu/icm/jlargearrays/LongLargeArray;)V");
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_makect_JLpl_edu_icm_jlargearrays_DoubleLargeArray_JLpl_edu_icm_jlargearrays_LongLargeArray_, __args);
			} finally {
			}
		}

		static IntPtr id_makect_JLpl_edu_icm_jlargearrays_FloatLargeArray_JLpl_edu_icm_jlargearrays_LongLargeArray_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='makect' and count(parameter)=4 and parameter[1][@type='long'] and parameter[2][@type='pl.edu.icm.jlargearrays.FloatLargeArray'] and parameter[3][@type='long'] and parameter[4][@type='pl.edu.icm.jlargearrays.LongLargeArray']]"
		[Register ("makect", "(JLpl/edu/icm/jlargearrays/FloatLargeArray;JLpl/edu/icm/jlargearrays/LongLargeArray;)V", "")]
		public static unsafe void Makect (long p0, global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p1, long p2, global::PL.Edu.Icm.Jlargearrays.LongLargeArray p3)
		{
			if (id_makect_JLpl_edu_icm_jlargearrays_FloatLargeArray_JLpl_edu_icm_jlargearrays_LongLargeArray_ == IntPtr.Zero)
				id_makect_JLpl_edu_icm_jlargearrays_FloatLargeArray_JLpl_edu_icm_jlargearrays_LongLargeArray_ = JNIEnv.GetStaticMethodID (class_ref, "makect", "(JLpl/edu/icm/jlargearrays/FloatLargeArray;JLpl/edu/icm/jlargearrays/LongLargeArray;)V");
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_makect_JLpl_edu_icm_jlargearrays_FloatLargeArray_JLpl_edu_icm_jlargearrays_LongLargeArray_, __args);
			} finally {
			}
		}

		static IntPtr id_makeipt_IarrayI;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='makeipt' and count(parameter)=2 and parameter[1][@type='int'] and parameter[2][@type='int[]']]"
		[Register ("makeipt", "(I[I)V", "")]
		public static unsafe void Makeipt (int p0, int[] p1)
		{
			if (id_makeipt_IarrayI == IntPtr.Zero)
				id_makeipt_IarrayI = JNIEnv.GetStaticMethodID (class_ref, "makeipt", "(I[I)V");
			IntPtr native_p1 = JNIEnv.NewArray (p1);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_makeipt_IarrayI, __args);
			} finally {
				if (p1 != null) {
					JNIEnv.CopyArray (native_p1, p1);
					JNIEnv.DeleteLocalRef (native_p1);
				}
			}
		}

		static IntPtr id_makeipt_JLpl_edu_icm_jlargearrays_LongLargeArray_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='makeipt' and count(parameter)=2 and parameter[1][@type='long'] and parameter[2][@type='pl.edu.icm.jlargearrays.LongLargeArray']]"
		[Register ("makeipt", "(JLpl/edu/icm/jlargearrays/LongLargeArray;)V", "")]
		public static unsafe void Makeipt (long p0, global::PL.Edu.Icm.Jlargearrays.LongLargeArray p1)
		{
			if (id_makeipt_JLpl_edu_icm_jlargearrays_LongLargeArray_ == IntPtr.Zero)
				id_makeipt_JLpl_edu_icm_jlargearrays_LongLargeArray_ = JNIEnv.GetStaticMethodID (class_ref, "makeipt", "(JLpl/edu/icm/jlargearrays/LongLargeArray;)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_makeipt_JLpl_edu_icm_jlargearrays_LongLargeArray_, __args);
			} finally {
			}
		}

		static IntPtr id_makewt_IarrayIarrayD;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='makewt' and count(parameter)=3 and parameter[1][@type='int'] and parameter[2][@type='int[]'] and parameter[3][@type='double[]']]"
		[Register ("makewt", "(I[I[D)V", "")]
		public static unsafe void Makewt (int p0, int[] p1, double[] p2)
		{
			if (id_makewt_IarrayIarrayD == IntPtr.Zero)
				id_makewt_IarrayIarrayD = JNIEnv.GetStaticMethodID (class_ref, "makewt", "(I[I[D)V");
			IntPtr native_p1 = JNIEnv.NewArray (p1);
			IntPtr native_p2 = JNIEnv.NewArray (p2);
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (native_p2);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_makewt_IarrayIarrayD, __args);
			} finally {
				if (p1 != null) {
					JNIEnv.CopyArray (native_p1, p1);
					JNIEnv.DeleteLocalRef (native_p1);
				}
				if (p2 != null) {
					JNIEnv.CopyArray (native_p2, p2);
					JNIEnv.DeleteLocalRef (native_p2);
				}
			}
		}

		static IntPtr id_makewt_IarrayIarrayF;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='makewt' and count(parameter)=3 and parameter[1][@type='int'] and parameter[2][@type='int[]'] and parameter[3][@type='float[]']]"
		[Register ("makewt", "(I[I[F)V", "")]
		public static unsafe void Makewt (int p0, int[] p1, float[] p2)
		{
			if (id_makewt_IarrayIarrayF == IntPtr.Zero)
				id_makewt_IarrayIarrayF = JNIEnv.GetStaticMethodID (class_ref, "makewt", "(I[I[F)V");
			IntPtr native_p1 = JNIEnv.NewArray (p1);
			IntPtr native_p2 = JNIEnv.NewArray (p2);
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (native_p2);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_makewt_IarrayIarrayF, __args);
			} finally {
				if (p1 != null) {
					JNIEnv.CopyArray (native_p1, p1);
					JNIEnv.DeleteLocalRef (native_p1);
				}
				if (p2 != null) {
					JNIEnv.CopyArray (native_p2, p2);
					JNIEnv.DeleteLocalRef (native_p2);
				}
			}
		}

		static IntPtr id_makewt_JLpl_edu_icm_jlargearrays_LongLargeArray_Lpl_edu_icm_jlargearrays_DoubleLargeArray_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='makewt' and count(parameter)=3 and parameter[1][@type='long'] and parameter[2][@type='pl.edu.icm.jlargearrays.LongLargeArray'] and parameter[3][@type='pl.edu.icm.jlargearrays.DoubleLargeArray']]"
		[Register ("makewt", "(JLpl/edu/icm/jlargearrays/LongLargeArray;Lpl/edu/icm/jlargearrays/DoubleLargeArray;)V", "")]
		public static unsafe void Makewt (long p0, global::PL.Edu.Icm.Jlargearrays.LongLargeArray p1, global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p2)
		{
			if (id_makewt_JLpl_edu_icm_jlargearrays_LongLargeArray_Lpl_edu_icm_jlargearrays_DoubleLargeArray_ == IntPtr.Zero)
				id_makewt_JLpl_edu_icm_jlargearrays_LongLargeArray_Lpl_edu_icm_jlargearrays_DoubleLargeArray_ = JNIEnv.GetStaticMethodID (class_ref, "makewt", "(JLpl/edu/icm/jlargearrays/LongLargeArray;Lpl/edu/icm/jlargearrays/DoubleLargeArray;)V");
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_makewt_JLpl_edu_icm_jlargearrays_LongLargeArray_Lpl_edu_icm_jlargearrays_DoubleLargeArray_, __args);
			} finally {
			}
		}

		static IntPtr id_makewt_JLpl_edu_icm_jlargearrays_LongLargeArray_Lpl_edu_icm_jlargearrays_FloatLargeArray_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='makewt' and count(parameter)=3 and parameter[1][@type='long'] and parameter[2][@type='pl.edu.icm.jlargearrays.LongLargeArray'] and parameter[3][@type='pl.edu.icm.jlargearrays.FloatLargeArray']]"
		[Register ("makewt", "(JLpl/edu/icm/jlargearrays/LongLargeArray;Lpl/edu/icm/jlargearrays/FloatLargeArray;)V", "")]
		public static unsafe void Makewt (long p0, global::PL.Edu.Icm.Jlargearrays.LongLargeArray p1, global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p2)
		{
			if (id_makewt_JLpl_edu_icm_jlargearrays_LongLargeArray_Lpl_edu_icm_jlargearrays_FloatLargeArray_ == IntPtr.Zero)
				id_makewt_JLpl_edu_icm_jlargearrays_LongLargeArray_Lpl_edu_icm_jlargearrays_FloatLargeArray_ = JNIEnv.GetStaticMethodID (class_ref, "makewt", "(JLpl/edu/icm/jlargearrays/LongLargeArray;Lpl/edu/icm/jlargearrays/FloatLargeArray;)V");
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_makewt_JLpl_edu_icm_jlargearrays_LongLargeArray_Lpl_edu_icm_jlargearrays_FloatLargeArray_, __args);
			} finally {
			}
		}

		static IntPtr id_nextPow2_I;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='nextPow2' and count(parameter)=1 and parameter[1][@type='int']]"
		[Register ("nextPow2", "(I)I", "")]
		public static unsafe int NextPow2 (int p0)
		{
			if (id_nextPow2_I == IntPtr.Zero)
				id_nextPow2_I = JNIEnv.GetStaticMethodID (class_ref, "nextPow2", "(I)I");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				return JNIEnv.CallStaticIntMethod  (class_ref, id_nextPow2_I, __args);
			} finally {
			}
		}

		static IntPtr id_nextPow2_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='nextPow2' and count(parameter)=1 and parameter[1][@type='long']]"
		[Register ("nextPow2", "(J)J", "")]
		public static unsafe long NextPow2 (long p0)
		{
			if (id_nextPow2_J == IntPtr.Zero)
				id_nextPow2_J = JNIEnv.GetStaticMethodID (class_ref, "nextPow2", "(J)J");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				return JNIEnv.CallStaticLongMethod  (class_ref, id_nextPow2_J, __args);
			} finally {
			}
		}

		static IntPtr id_prevPow2_I;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='prevPow2' and count(parameter)=1 and parameter[1][@type='int']]"
		[Register ("prevPow2", "(I)I", "")]
		public static unsafe int PrevPow2 (int p0)
		{
			if (id_prevPow2_I == IntPtr.Zero)
				id_prevPow2_I = JNIEnv.GetStaticMethodID (class_ref, "prevPow2", "(I)I");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				return JNIEnv.CallStaticIntMethod  (class_ref, id_prevPow2_I, __args);
			} finally {
			}
		}

		static IntPtr id_prevPow2_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='prevPow2' and count(parameter)=1 and parameter[1][@type='long']]"
		[Register ("prevPow2", "(J)J", "")]
		public static unsafe long PrevPow2 (long p0)
		{
			if (id_prevPow2_J == IntPtr.Zero)
				id_prevPow2_J = JNIEnv.GetStaticMethodID (class_ref, "prevPow2", "(J)J");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				return JNIEnv.CallStaticLongMethod  (class_ref, id_prevPow2_J, __args);
			} finally {
			}
		}

		static IntPtr id_resetThreadsBeginN;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='resetThreadsBeginN' and count(parameter)=0]"
		[Register ("resetThreadsBeginN", "()V", "")]
		public static unsafe void ResetThreadsBeginN ()
		{
			if (id_resetThreadsBeginN == IntPtr.Zero)
				id_resetThreadsBeginN = JNIEnv.GetStaticMethodID (class_ref, "resetThreadsBeginN", "()V");
			try {
				JNIEnv.CallStaticVoidMethod  (class_ref, id_resetThreadsBeginN);
			} finally {
			}
		}

		static IntPtr id_resetThreadsBeginN_FFT;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='resetThreadsBeginN_FFT' and count(parameter)=0]"
		[Register ("resetThreadsBeginN_FFT", "()V", "")]
		public static unsafe void ResetThreadsBeginN_FFT ()
		{
			if (id_resetThreadsBeginN_FFT == IntPtr.Zero)
				id_resetThreadsBeginN_FFT = JNIEnv.GetStaticMethodID (class_ref, "resetThreadsBeginN_FFT", "()V");
			try {
				JNIEnv.CallStaticVoidMethod  (class_ref, id_resetThreadsBeginN_FFT);
			} finally {
			}
		}

		static IntPtr id_rftbsub_IarrayDIIarrayDI;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='rftbsub' and count(parameter)=6 and parameter[1][@type='int'] and parameter[2][@type='double[]'] and parameter[3][@type='int'] and parameter[4][@type='int'] and parameter[5][@type='double[]'] and parameter[6][@type='int']]"
		[Register ("rftbsub", "(I[DII[DI)V", "")]
		public static unsafe void Rftbsub (int p0, double[] p1, int p2, int p3, double[] p4, int p5)
		{
			if (id_rftbsub_IarrayDIIarrayDI == IntPtr.Zero)
				id_rftbsub_IarrayDIIarrayDI = JNIEnv.GetStaticMethodID (class_ref, "rftbsub", "(I[DII[DI)V");
			IntPtr native_p1 = JNIEnv.NewArray (p1);
			IntPtr native_p4 = JNIEnv.NewArray (p4);
			try {
				JValue* __args = stackalloc JValue [6];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (native_p4);
				__args [5] = new JValue (p5);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_rftbsub_IarrayDIIarrayDI, __args);
			} finally {
				if (p1 != null) {
					JNIEnv.CopyArray (native_p1, p1);
					JNIEnv.DeleteLocalRef (native_p1);
				}
				if (p4 != null) {
					JNIEnv.CopyArray (native_p4, p4);
					JNIEnv.DeleteLocalRef (native_p4);
				}
			}
		}

		static IntPtr id_rftbsub_IarrayFIIarrayFI;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='rftbsub' and count(parameter)=6 and parameter[1][@type='int'] and parameter[2][@type='float[]'] and parameter[3][@type='int'] and parameter[4][@type='int'] and parameter[5][@type='float[]'] and parameter[6][@type='int']]"
		[Register ("rftbsub", "(I[FII[FI)V", "")]
		public static unsafe void Rftbsub (int p0, float[] p1, int p2, int p3, float[] p4, int p5)
		{
			if (id_rftbsub_IarrayFIIarrayFI == IntPtr.Zero)
				id_rftbsub_IarrayFIIarrayFI = JNIEnv.GetStaticMethodID (class_ref, "rftbsub", "(I[FII[FI)V");
			IntPtr native_p1 = JNIEnv.NewArray (p1);
			IntPtr native_p4 = JNIEnv.NewArray (p4);
			try {
				JValue* __args = stackalloc JValue [6];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (native_p4);
				__args [5] = new JValue (p5);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_rftbsub_IarrayFIIarrayFI, __args);
			} finally {
				if (p1 != null) {
					JNIEnv.CopyArray (native_p1, p1);
					JNIEnv.DeleteLocalRef (native_p1);
				}
				if (p4 != null) {
					JNIEnv.CopyArray (native_p4, p4);
					JNIEnv.DeleteLocalRef (native_p4);
				}
			}
		}

		static IntPtr id_rftbsub_JLpl_edu_icm_jlargearrays_DoubleLargeArray_JJLpl_edu_icm_jlargearrays_DoubleLargeArray_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='rftbsub' and count(parameter)=6 and parameter[1][@type='long'] and parameter[2][@type='pl.edu.icm.jlargearrays.DoubleLargeArray'] and parameter[3][@type='long'] and parameter[4][@type='long'] and parameter[5][@type='pl.edu.icm.jlargearrays.DoubleLargeArray'] and parameter[6][@type='long']]"
		[Register ("rftbsub", "(JLpl/edu/icm/jlargearrays/DoubleLargeArray;JJLpl/edu/icm/jlargearrays/DoubleLargeArray;J)V", "")]
		public static unsafe void Rftbsub (long p0, global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p1, long p2, long p3, global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p4, long p5)
		{
			if (id_rftbsub_JLpl_edu_icm_jlargearrays_DoubleLargeArray_JJLpl_edu_icm_jlargearrays_DoubleLargeArray_J == IntPtr.Zero)
				id_rftbsub_JLpl_edu_icm_jlargearrays_DoubleLargeArray_JJLpl_edu_icm_jlargearrays_DoubleLargeArray_J = JNIEnv.GetStaticMethodID (class_ref, "rftbsub", "(JLpl/edu/icm/jlargearrays/DoubleLargeArray;JJLpl/edu/icm/jlargearrays/DoubleLargeArray;J)V");
			try {
				JValue* __args = stackalloc JValue [6];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (p4);
				__args [5] = new JValue (p5);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_rftbsub_JLpl_edu_icm_jlargearrays_DoubleLargeArray_JJLpl_edu_icm_jlargearrays_DoubleLargeArray_J, __args);
			} finally {
			}
		}

		static IntPtr id_rftbsub_JLpl_edu_icm_jlargearrays_FloatLargeArray_JJLpl_edu_icm_jlargearrays_FloatLargeArray_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='rftbsub' and count(parameter)=6 and parameter[1][@type='long'] and parameter[2][@type='pl.edu.icm.jlargearrays.FloatLargeArray'] and parameter[3][@type='long'] and parameter[4][@type='long'] and parameter[5][@type='pl.edu.icm.jlargearrays.FloatLargeArray'] and parameter[6][@type='long']]"
		[Register ("rftbsub", "(JLpl/edu/icm/jlargearrays/FloatLargeArray;JJLpl/edu/icm/jlargearrays/FloatLargeArray;J)V", "")]
		public static unsafe void Rftbsub (long p0, global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p1, long p2, long p3, global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p4, long p5)
		{
			if (id_rftbsub_JLpl_edu_icm_jlargearrays_FloatLargeArray_JJLpl_edu_icm_jlargearrays_FloatLargeArray_J == IntPtr.Zero)
				id_rftbsub_JLpl_edu_icm_jlargearrays_FloatLargeArray_JJLpl_edu_icm_jlargearrays_FloatLargeArray_J = JNIEnv.GetStaticMethodID (class_ref, "rftbsub", "(JLpl/edu/icm/jlargearrays/FloatLargeArray;JJLpl/edu/icm/jlargearrays/FloatLargeArray;J)V");
			try {
				JValue* __args = stackalloc JValue [6];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (p4);
				__args [5] = new JValue (p5);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_rftbsub_JLpl_edu_icm_jlargearrays_FloatLargeArray_JJLpl_edu_icm_jlargearrays_FloatLargeArray_J, __args);
			} finally {
			}
		}

		static IntPtr id_rftfsub_IarrayDIIarrayDI;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='rftfsub' and count(parameter)=6 and parameter[1][@type='int'] and parameter[2][@type='double[]'] and parameter[3][@type='int'] and parameter[4][@type='int'] and parameter[5][@type='double[]'] and parameter[6][@type='int']]"
		[Register ("rftfsub", "(I[DII[DI)V", "")]
		public static unsafe void Rftfsub (int p0, double[] p1, int p2, int p3, double[] p4, int p5)
		{
			if (id_rftfsub_IarrayDIIarrayDI == IntPtr.Zero)
				id_rftfsub_IarrayDIIarrayDI = JNIEnv.GetStaticMethodID (class_ref, "rftfsub", "(I[DII[DI)V");
			IntPtr native_p1 = JNIEnv.NewArray (p1);
			IntPtr native_p4 = JNIEnv.NewArray (p4);
			try {
				JValue* __args = stackalloc JValue [6];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (native_p4);
				__args [5] = new JValue (p5);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_rftfsub_IarrayDIIarrayDI, __args);
			} finally {
				if (p1 != null) {
					JNIEnv.CopyArray (native_p1, p1);
					JNIEnv.DeleteLocalRef (native_p1);
				}
				if (p4 != null) {
					JNIEnv.CopyArray (native_p4, p4);
					JNIEnv.DeleteLocalRef (native_p4);
				}
			}
		}

		static IntPtr id_rftfsub_IarrayFIIarrayFI;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='rftfsub' and count(parameter)=6 and parameter[1][@type='int'] and parameter[2][@type='float[]'] and parameter[3][@type='int'] and parameter[4][@type='int'] and parameter[5][@type='float[]'] and parameter[6][@type='int']]"
		[Register ("rftfsub", "(I[FII[FI)V", "")]
		public static unsafe void Rftfsub (int p0, float[] p1, int p2, int p3, float[] p4, int p5)
		{
			if (id_rftfsub_IarrayFIIarrayFI == IntPtr.Zero)
				id_rftfsub_IarrayFIIarrayFI = JNIEnv.GetStaticMethodID (class_ref, "rftfsub", "(I[FII[FI)V");
			IntPtr native_p1 = JNIEnv.NewArray (p1);
			IntPtr native_p4 = JNIEnv.NewArray (p4);
			try {
				JValue* __args = stackalloc JValue [6];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (native_p4);
				__args [5] = new JValue (p5);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_rftfsub_IarrayFIIarrayFI, __args);
			} finally {
				if (p1 != null) {
					JNIEnv.CopyArray (native_p1, p1);
					JNIEnv.DeleteLocalRef (native_p1);
				}
				if (p4 != null) {
					JNIEnv.CopyArray (native_p4, p4);
					JNIEnv.DeleteLocalRef (native_p4);
				}
			}
		}

		static IntPtr id_rftfsub_JLpl_edu_icm_jlargearrays_DoubleLargeArray_JJLpl_edu_icm_jlargearrays_DoubleLargeArray_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='rftfsub' and count(parameter)=6 and parameter[1][@type='long'] and parameter[2][@type='pl.edu.icm.jlargearrays.DoubleLargeArray'] and parameter[3][@type='long'] and parameter[4][@type='long'] and parameter[5][@type='pl.edu.icm.jlargearrays.DoubleLargeArray'] and parameter[6][@type='long']]"
		[Register ("rftfsub", "(JLpl/edu/icm/jlargearrays/DoubleLargeArray;JJLpl/edu/icm/jlargearrays/DoubleLargeArray;J)V", "")]
		public static unsafe void Rftfsub (long p0, global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p1, long p2, long p3, global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p4, long p5)
		{
			if (id_rftfsub_JLpl_edu_icm_jlargearrays_DoubleLargeArray_JJLpl_edu_icm_jlargearrays_DoubleLargeArray_J == IntPtr.Zero)
				id_rftfsub_JLpl_edu_icm_jlargearrays_DoubleLargeArray_JJLpl_edu_icm_jlargearrays_DoubleLargeArray_J = JNIEnv.GetStaticMethodID (class_ref, "rftfsub", "(JLpl/edu/icm/jlargearrays/DoubleLargeArray;JJLpl/edu/icm/jlargearrays/DoubleLargeArray;J)V");
			try {
				JValue* __args = stackalloc JValue [6];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (p4);
				__args [5] = new JValue (p5);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_rftfsub_JLpl_edu_icm_jlargearrays_DoubleLargeArray_JJLpl_edu_icm_jlargearrays_DoubleLargeArray_J, __args);
			} finally {
			}
		}

		static IntPtr id_rftfsub_JLpl_edu_icm_jlargearrays_FloatLargeArray_JJLpl_edu_icm_jlargearrays_FloatLargeArray_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='rftfsub' and count(parameter)=6 and parameter[1][@type='long'] and parameter[2][@type='pl.edu.icm.jlargearrays.FloatLargeArray'] and parameter[3][@type='long'] and parameter[4][@type='long'] and parameter[5][@type='pl.edu.icm.jlargearrays.FloatLargeArray'] and parameter[6][@type='long']]"
		[Register ("rftfsub", "(JLpl/edu/icm/jlargearrays/FloatLargeArray;JJLpl/edu/icm/jlargearrays/FloatLargeArray;J)V", "")]
		public static unsafe void Rftfsub (long p0, global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p1, long p2, long p3, global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p4, long p5)
		{
			if (id_rftfsub_JLpl_edu_icm_jlargearrays_FloatLargeArray_JJLpl_edu_icm_jlargearrays_FloatLargeArray_J == IntPtr.Zero)
				id_rftfsub_JLpl_edu_icm_jlargearrays_FloatLargeArray_JJLpl_edu_icm_jlargearrays_FloatLargeArray_J = JNIEnv.GetStaticMethodID (class_ref, "rftfsub", "(JLpl/edu/icm/jlargearrays/FloatLargeArray;JJLpl/edu/icm/jlargearrays/FloatLargeArray;J)V");
			try {
				JValue* __args = stackalloc JValue [6];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (p4);
				__args [5] = new JValue (p5);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_rftfsub_JLpl_edu_icm_jlargearrays_FloatLargeArray_JJLpl_edu_icm_jlargearrays_FloatLargeArray_J, __args);
			} finally {
			}
		}

		static IntPtr id_scale_IDarrayDIZ;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='scale' and count(parameter)=5 and parameter[1][@type='int'] and parameter[2][@type='double'] and parameter[3][@type='double[]'] and parameter[4][@type='int'] and parameter[5][@type='boolean']]"
		[Register ("scale", "(ID[DIZ)V", "")]
		public static unsafe void Scale (int p0, double p1, double[] p2, int p3, bool p4)
		{
			if (id_scale_IDarrayDIZ == IntPtr.Zero)
				id_scale_IDarrayDIZ = JNIEnv.GetStaticMethodID (class_ref, "scale", "(ID[DIZ)V");
			IntPtr native_p2 = JNIEnv.NewArray (p2);
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (native_p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (p4);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_scale_IDarrayDIZ, __args);
			} finally {
				if (p2 != null) {
					JNIEnv.CopyArray (native_p2, p2);
					JNIEnv.DeleteLocalRef (native_p2);
				}
			}
		}

		static IntPtr id_scale_IFarrayFIZ;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='scale' and count(parameter)=5 and parameter[1][@type='int'] and parameter[2][@type='float'] and parameter[3][@type='float[]'] and parameter[4][@type='int'] and parameter[5][@type='boolean']]"
		[Register ("scale", "(IF[FIZ)V", "")]
		public static unsafe void Scale (int p0, float p1, float[] p2, int p3, bool p4)
		{
			if (id_scale_IFarrayFIZ == IntPtr.Zero)
				id_scale_IFarrayFIZ = JNIEnv.GetStaticMethodID (class_ref, "scale", "(IF[FIZ)V");
			IntPtr native_p2 = JNIEnv.NewArray (p2);
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (native_p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (p4);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_scale_IFarrayFIZ, __args);
			} finally {
				if (p2 != null) {
					JNIEnv.CopyArray (native_p2, p2);
					JNIEnv.DeleteLocalRef (native_p2);
				}
			}
		}

		static IntPtr id_scale_JDLpl_edu_icm_jlargearrays_DoubleLargeArray_JZ;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='scale' and count(parameter)=5 and parameter[1][@type='long'] and parameter[2][@type='double'] and parameter[3][@type='pl.edu.icm.jlargearrays.DoubleLargeArray'] and parameter[4][@type='long'] and parameter[5][@type='boolean']]"
		[Register ("scale", "(JDLpl/edu/icm/jlargearrays/DoubleLargeArray;JZ)V", "")]
		public static unsafe void Scale (long p0, double p1, global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p2, long p3, bool p4)
		{
			if (id_scale_JDLpl_edu_icm_jlargearrays_DoubleLargeArray_JZ == IntPtr.Zero)
				id_scale_JDLpl_edu_icm_jlargearrays_DoubleLargeArray_JZ = JNIEnv.GetStaticMethodID (class_ref, "scale", "(JDLpl/edu/icm/jlargearrays/DoubleLargeArray;JZ)V");
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (p4);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_scale_JDLpl_edu_icm_jlargearrays_DoubleLargeArray_JZ, __args);
			} finally {
			}
		}

		static IntPtr id_scale_JFLpl_edu_icm_jlargearrays_FloatLargeArray_JZ;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='scale' and count(parameter)=5 and parameter[1][@type='long'] and parameter[2][@type='float'] and parameter[3][@type='pl.edu.icm.jlargearrays.FloatLargeArray'] and parameter[4][@type='long'] and parameter[5][@type='boolean']]"
		[Register ("scale", "(JFLpl/edu/icm/jlargearrays/FloatLargeArray;JZ)V", "")]
		public static unsafe void Scale (long p0, float p1, global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p2, long p3, bool p4)
		{
			if (id_scale_JFLpl_edu_icm_jlargearrays_FloatLargeArray_JZ == IntPtr.Zero)
				id_scale_JFLpl_edu_icm_jlargearrays_FloatLargeArray_JZ = JNIEnv.GetStaticMethodID (class_ref, "scale", "(JFLpl/edu/icm/jlargearrays/FloatLargeArray;JZ)V");
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (p4);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_scale_JFLpl_edu_icm_jlargearrays_FloatLargeArray_JZ, __args);
			} finally {
			}
		}

		static IntPtr id_sleep_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='CommonUtils']/method[@name='sleep' and count(parameter)=1 and parameter[1][@type='long']]"
		[Register ("sleep", "(J)V", "")]
		public static unsafe void Sleep (long p0)
		{
			if (id_sleep_J == IntPtr.Zero)
				id_sleep_J = JNIEnv.GetStaticMethodID (class_ref, "sleep", "(J)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_sleep_J, __args);
			} finally {
			}
		}

	}
}
