using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Org.Jtransforms.Fft {

	// Metadata.xml XPath class reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='DoubleFFT_1D']"
	[global::Android.Runtime.Register ("org/jtransforms/fft/DoubleFFT_1D", DoNotGenerateAcw=true)]
	public sealed partial class DoubleFFT_1D : global::Java.Lang.Object {

		// Metadata.xml XPath class reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='DoubleFFT_1D.Plans']"
		[global::Android.Runtime.Register ("org/jtransforms/fft/DoubleFFT_1D$Plans", DoNotGenerateAcw=true)]
		public sealed partial class Plans : global::Java.Lang.Enum {


			static IntPtr BLUESTEIN_jfieldId;

			// Metadata.xml XPath field reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='DoubleFFT_1D.Plans']/field[@name='BLUESTEIN']"
			[Register ("BLUESTEIN")]
			public static global::Org.Jtransforms.Fft.DoubleFFT_1D.Plans Bluestein {
				get {
					if (BLUESTEIN_jfieldId == IntPtr.Zero)
						BLUESTEIN_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "BLUESTEIN", "Lorg/jtransforms/fft/DoubleFFT_1D$Plans;");
					IntPtr __ret = JNIEnv.GetStaticObjectField (class_ref, BLUESTEIN_jfieldId);
					return global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.DoubleFFT_1D.Plans> (__ret, JniHandleOwnership.TransferLocalRef);
				}
			}

			static IntPtr MIXED_RADIX_jfieldId;

			// Metadata.xml XPath field reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='DoubleFFT_1D.Plans']/field[@name='MIXED_RADIX']"
			[Register ("MIXED_RADIX")]
			public static global::Org.Jtransforms.Fft.DoubleFFT_1D.Plans MixedRadix {
				get {
					if (MIXED_RADIX_jfieldId == IntPtr.Zero)
						MIXED_RADIX_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "MIXED_RADIX", "Lorg/jtransforms/fft/DoubleFFT_1D$Plans;");
					IntPtr __ret = JNIEnv.GetStaticObjectField (class_ref, MIXED_RADIX_jfieldId);
					return global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.DoubleFFT_1D.Plans> (__ret, JniHandleOwnership.TransferLocalRef);
				}
			}

			static IntPtr SPLIT_RADIX_jfieldId;

			// Metadata.xml XPath field reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='DoubleFFT_1D.Plans']/field[@name='SPLIT_RADIX']"
			[Register ("SPLIT_RADIX")]
			public static global::Org.Jtransforms.Fft.DoubleFFT_1D.Plans SplitRadix {
				get {
					if (SPLIT_RADIX_jfieldId == IntPtr.Zero)
						SPLIT_RADIX_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "SPLIT_RADIX", "Lorg/jtransforms/fft/DoubleFFT_1D$Plans;");
					IntPtr __ret = JNIEnv.GetStaticObjectField (class_ref, SPLIT_RADIX_jfieldId);
					return global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.DoubleFFT_1D.Plans> (__ret, JniHandleOwnership.TransferLocalRef);
				}
			}
			internal static IntPtr java_class_handle;
			internal static IntPtr class_ref {
				get {
					return JNIEnv.FindClass ("org/jtransforms/fft/DoubleFFT_1D$Plans", ref java_class_handle);
				}
			}

			protected override IntPtr ThresholdClass {
				get { return class_ref; }
			}

			protected override global::System.Type ThresholdType {
				get { return typeof (Plans); }
			}

			internal Plans (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		}

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("org/jtransforms/fft/DoubleFFT_1D", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (DoubleFFT_1D); }
		}

		internal DoubleFFT_1D (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor_J;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='DoubleFFT_1D']/constructor[@name='DoubleFFT_1D' and count(parameter)=1 and parameter[1][@type='long']]"
		[Register (".ctor", "(J)V", "")]
		public unsafe DoubleFFT_1D (long p0)
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				if (((object) this).GetType () != typeof (DoubleFFT_1D)) {
					SetHandle (
							global::Android.Runtime.JNIEnv.StartCreateInstance (((object) this).GetType (), "(J)V", __args),
							JniHandleOwnership.TransferLocalRef);
					global::Android.Runtime.JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, "(J)V", __args);
					return;
				}

				if (id_ctor_J == IntPtr.Zero)
					id_ctor_J = JNIEnv.GetMethodID (class_ref, "<init>", "(J)V");
				SetHandle (
						global::Android.Runtime.JNIEnv.StartCreateInstance (class_ref, id_ctor_J, __args),
						JniHandleOwnership.TransferLocalRef);
				JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, class_ref, id_ctor_J, __args);
			} finally {
			}
		}

		static IntPtr id_complexForward_arrayD;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='DoubleFFT_1D']/method[@name='complexForward' and count(parameter)=1 and parameter[1][@type='double[]']]"
		[Register ("complexForward", "([D)V", "")]
		public unsafe void ComplexForward (double[] p0)
		{
			if (id_complexForward_arrayD == IntPtr.Zero)
				id_complexForward_arrayD = JNIEnv.GetMethodID (class_ref, "complexForward", "([D)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_complexForward_arrayD, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static IntPtr id_complexForward_arrayDI;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='DoubleFFT_1D']/method[@name='complexForward' and count(parameter)=2 and parameter[1][@type='double[]'] and parameter[2][@type='int']]"
		[Register ("complexForward", "([DI)V", "")]
		public unsafe void ComplexForward (double[] p0, int p1)
		{
			if (id_complexForward_arrayDI == IntPtr.Zero)
				id_complexForward_arrayDI = JNIEnv.GetMethodID (class_ref, "complexForward", "([DI)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_complexForward_arrayDI, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static IntPtr id_complexForward_Lpl_edu_icm_jlargearrays_DoubleLargeArray_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='DoubleFFT_1D']/method[@name='complexForward' and count(parameter)=1 and parameter[1][@type='pl.edu.icm.jlargearrays.DoubleLargeArray']]"
		[Register ("complexForward", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;)V", "")]
		public unsafe void ComplexForward (global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p0)
		{
			if (id_complexForward_Lpl_edu_icm_jlargearrays_DoubleLargeArray_ == IntPtr.Zero)
				id_complexForward_Lpl_edu_icm_jlargearrays_DoubleLargeArray_ = JNIEnv.GetMethodID (class_ref, "complexForward", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_complexForward_Lpl_edu_icm_jlargearrays_DoubleLargeArray_, __args);
			} finally {
			}
		}

		static IntPtr id_complexForward_Lpl_edu_icm_jlargearrays_DoubleLargeArray_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='DoubleFFT_1D']/method[@name='complexForward' and count(parameter)=2 and parameter[1][@type='pl.edu.icm.jlargearrays.DoubleLargeArray'] and parameter[2][@type='long']]"
		[Register ("complexForward", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;J)V", "")]
		public unsafe void ComplexForward (global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p0, long p1)
		{
			if (id_complexForward_Lpl_edu_icm_jlargearrays_DoubleLargeArray_J == IntPtr.Zero)
				id_complexForward_Lpl_edu_icm_jlargearrays_DoubleLargeArray_J = JNIEnv.GetMethodID (class_ref, "complexForward", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;J)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_complexForward_Lpl_edu_icm_jlargearrays_DoubleLargeArray_J, __args);
			} finally {
			}
		}

		static IntPtr id_complexInverse_arrayDZ;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='DoubleFFT_1D']/method[@name='complexInverse' and count(parameter)=2 and parameter[1][@type='double[]'] and parameter[2][@type='boolean']]"
		[Register ("complexInverse", "([DZ)V", "")]
		public unsafe void ComplexInverse (double[] p0, bool p1)
		{
			if (id_complexInverse_arrayDZ == IntPtr.Zero)
				id_complexInverse_arrayDZ = JNIEnv.GetMethodID (class_ref, "complexInverse", "([DZ)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_complexInverse_arrayDZ, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static IntPtr id_complexInverse_arrayDIZ;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='DoubleFFT_1D']/method[@name='complexInverse' and count(parameter)=3 and parameter[1][@type='double[]'] and parameter[2][@type='int'] and parameter[3][@type='boolean']]"
		[Register ("complexInverse", "([DIZ)V", "")]
		public unsafe void ComplexInverse (double[] p0, int p1, bool p2)
		{
			if (id_complexInverse_arrayDIZ == IntPtr.Zero)
				id_complexInverse_arrayDIZ = JNIEnv.GetMethodID (class_ref, "complexInverse", "([DIZ)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_complexInverse_arrayDIZ, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static IntPtr id_complexInverse_Lpl_edu_icm_jlargearrays_DoubleLargeArray_Z;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='DoubleFFT_1D']/method[@name='complexInverse' and count(parameter)=2 and parameter[1][@type='pl.edu.icm.jlargearrays.DoubleLargeArray'] and parameter[2][@type='boolean']]"
		[Register ("complexInverse", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;Z)V", "")]
		public unsafe void ComplexInverse (global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p0, bool p1)
		{
			if (id_complexInverse_Lpl_edu_icm_jlargearrays_DoubleLargeArray_Z == IntPtr.Zero)
				id_complexInverse_Lpl_edu_icm_jlargearrays_DoubleLargeArray_Z = JNIEnv.GetMethodID (class_ref, "complexInverse", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;Z)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_complexInverse_Lpl_edu_icm_jlargearrays_DoubleLargeArray_Z, __args);
			} finally {
			}
		}

		static IntPtr id_complexInverse_Lpl_edu_icm_jlargearrays_DoubleLargeArray_JZ;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='DoubleFFT_1D']/method[@name='complexInverse' and count(parameter)=3 and parameter[1][@type='pl.edu.icm.jlargearrays.DoubleLargeArray'] and parameter[2][@type='long'] and parameter[3][@type='boolean']]"
		[Register ("complexInverse", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;JZ)V", "")]
		public unsafe void ComplexInverse (global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p0, long p1, bool p2)
		{
			if (id_complexInverse_Lpl_edu_icm_jlargearrays_DoubleLargeArray_JZ == IntPtr.Zero)
				id_complexInverse_Lpl_edu_icm_jlargearrays_DoubleLargeArray_JZ = JNIEnv.GetMethodID (class_ref, "complexInverse", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;JZ)V");
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_complexInverse_Lpl_edu_icm_jlargearrays_DoubleLargeArray_JZ, __args);
			} finally {
			}
		}

		static IntPtr id_realForward_arrayD;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='DoubleFFT_1D']/method[@name='realForward' and count(parameter)=1 and parameter[1][@type='double[]']]"
		[Register ("realForward", "([D)V", "")]
		public unsafe void RealForward (double[] p0)
		{
			if (id_realForward_arrayD == IntPtr.Zero)
				id_realForward_arrayD = JNIEnv.GetMethodID (class_ref, "realForward", "([D)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_realForward_arrayD, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static IntPtr id_realForward_arrayDI;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='DoubleFFT_1D']/method[@name='realForward' and count(parameter)=2 and parameter[1][@type='double[]'] and parameter[2][@type='int']]"
		[Register ("realForward", "([DI)V", "")]
		public unsafe void RealForward (double[] p0, int p1)
		{
			if (id_realForward_arrayDI == IntPtr.Zero)
				id_realForward_arrayDI = JNIEnv.GetMethodID (class_ref, "realForward", "([DI)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_realForward_arrayDI, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static IntPtr id_realForward_Lpl_edu_icm_jlargearrays_DoubleLargeArray_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='DoubleFFT_1D']/method[@name='realForward' and count(parameter)=1 and parameter[1][@type='pl.edu.icm.jlargearrays.DoubleLargeArray']]"
		[Register ("realForward", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;)V", "")]
		public unsafe void RealForward (global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p0)
		{
			if (id_realForward_Lpl_edu_icm_jlargearrays_DoubleLargeArray_ == IntPtr.Zero)
				id_realForward_Lpl_edu_icm_jlargearrays_DoubleLargeArray_ = JNIEnv.GetMethodID (class_ref, "realForward", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_realForward_Lpl_edu_icm_jlargearrays_DoubleLargeArray_, __args);
			} finally {
			}
		}

		static IntPtr id_realForward_Lpl_edu_icm_jlargearrays_DoubleLargeArray_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='DoubleFFT_1D']/method[@name='realForward' and count(parameter)=2 and parameter[1][@type='pl.edu.icm.jlargearrays.DoubleLargeArray'] and parameter[2][@type='long']]"
		[Register ("realForward", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;J)V", "")]
		public unsafe void RealForward (global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p0, long p1)
		{
			if (id_realForward_Lpl_edu_icm_jlargearrays_DoubleLargeArray_J == IntPtr.Zero)
				id_realForward_Lpl_edu_icm_jlargearrays_DoubleLargeArray_J = JNIEnv.GetMethodID (class_ref, "realForward", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;J)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_realForward_Lpl_edu_icm_jlargearrays_DoubleLargeArray_J, __args);
			} finally {
			}
		}

		static IntPtr id_realForwardFull_arrayD;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='DoubleFFT_1D']/method[@name='realForwardFull' and count(parameter)=1 and parameter[1][@type='double[]']]"
		[Register ("realForwardFull", "([D)V", "")]
		public unsafe void RealForwardFull (double[] p0)
		{
			if (id_realForwardFull_arrayD == IntPtr.Zero)
				id_realForwardFull_arrayD = JNIEnv.GetMethodID (class_ref, "realForwardFull", "([D)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_realForwardFull_arrayD, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static IntPtr id_realForwardFull_arrayDI;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='DoubleFFT_1D']/method[@name='realForwardFull' and count(parameter)=2 and parameter[1][@type='double[]'] and parameter[2][@type='int']]"
		[Register ("realForwardFull", "([DI)V", "")]
		public unsafe void RealForwardFull (double[] p0, int p1)
		{
			if (id_realForwardFull_arrayDI == IntPtr.Zero)
				id_realForwardFull_arrayDI = JNIEnv.GetMethodID (class_ref, "realForwardFull", "([DI)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_realForwardFull_arrayDI, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static IntPtr id_realForwardFull_Lpl_edu_icm_jlargearrays_DoubleLargeArray_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='DoubleFFT_1D']/method[@name='realForwardFull' and count(parameter)=1 and parameter[1][@type='pl.edu.icm.jlargearrays.DoubleLargeArray']]"
		[Register ("realForwardFull", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;)V", "")]
		public unsafe void RealForwardFull (global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p0)
		{
			if (id_realForwardFull_Lpl_edu_icm_jlargearrays_DoubleLargeArray_ == IntPtr.Zero)
				id_realForwardFull_Lpl_edu_icm_jlargearrays_DoubleLargeArray_ = JNIEnv.GetMethodID (class_ref, "realForwardFull", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_realForwardFull_Lpl_edu_icm_jlargearrays_DoubleLargeArray_, __args);
			} finally {
			}
		}

		static IntPtr id_realForwardFull_Lpl_edu_icm_jlargearrays_DoubleLargeArray_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='DoubleFFT_1D']/method[@name='realForwardFull' and count(parameter)=2 and parameter[1][@type='pl.edu.icm.jlargearrays.DoubleLargeArray'] and parameter[2][@type='long']]"
		[Register ("realForwardFull", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;J)V", "")]
		public unsafe void RealForwardFull (global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p0, long p1)
		{
			if (id_realForwardFull_Lpl_edu_icm_jlargearrays_DoubleLargeArray_J == IntPtr.Zero)
				id_realForwardFull_Lpl_edu_icm_jlargearrays_DoubleLargeArray_J = JNIEnv.GetMethodID (class_ref, "realForwardFull", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;J)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_realForwardFull_Lpl_edu_icm_jlargearrays_DoubleLargeArray_J, __args);
			} finally {
			}
		}

		static IntPtr id_realInverse2_arrayDIZ;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='DoubleFFT_1D']/method[@name='realInverse2' and count(parameter)=3 and parameter[1][@type='double[]'] and parameter[2][@type='int'] and parameter[3][@type='boolean']]"
		[Register ("realInverse2", "([DIZ)V", "")]
		protected unsafe void RealInverse2 (double[] p0, int p1, bool p2)
		{
			if (id_realInverse2_arrayDIZ == IntPtr.Zero)
				id_realInverse2_arrayDIZ = JNIEnv.GetMethodID (class_ref, "realInverse2", "([DIZ)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_realInverse2_arrayDIZ, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static IntPtr id_realInverse2_Lpl_edu_icm_jlargearrays_DoubleLargeArray_JZ;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='DoubleFFT_1D']/method[@name='realInverse2' and count(parameter)=3 and parameter[1][@type='pl.edu.icm.jlargearrays.DoubleLargeArray'] and parameter[2][@type='long'] and parameter[3][@type='boolean']]"
		[Register ("realInverse2", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;JZ)V", "")]
		protected unsafe void RealInverse2 (global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p0, long p1, bool p2)
		{
			if (id_realInverse2_Lpl_edu_icm_jlargearrays_DoubleLargeArray_JZ == IntPtr.Zero)
				id_realInverse2_Lpl_edu_icm_jlargearrays_DoubleLargeArray_JZ = JNIEnv.GetMethodID (class_ref, "realInverse2", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;JZ)V");
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_realInverse2_Lpl_edu_icm_jlargearrays_DoubleLargeArray_JZ, __args);
			} finally {
			}
		}

		static IntPtr id_realInverse_arrayDZ;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='DoubleFFT_1D']/method[@name='realInverse' and count(parameter)=2 and parameter[1][@type='double[]'] and parameter[2][@type='boolean']]"
		[Register ("realInverse", "([DZ)V", "")]
		public unsafe void RealInverse (double[] p0, bool p1)
		{
			if (id_realInverse_arrayDZ == IntPtr.Zero)
				id_realInverse_arrayDZ = JNIEnv.GetMethodID (class_ref, "realInverse", "([DZ)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_realInverse_arrayDZ, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static IntPtr id_realInverse_arrayDIZ;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='DoubleFFT_1D']/method[@name='realInverse' and count(parameter)=3 and parameter[1][@type='double[]'] and parameter[2][@type='int'] and parameter[3][@type='boolean']]"
		[Register ("realInverse", "([DIZ)V", "")]
		public unsafe void RealInverse (double[] p0, int p1, bool p2)
		{
			if (id_realInverse_arrayDIZ == IntPtr.Zero)
				id_realInverse_arrayDIZ = JNIEnv.GetMethodID (class_ref, "realInverse", "([DIZ)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_realInverse_arrayDIZ, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static IntPtr id_realInverse_Lpl_edu_icm_jlargearrays_DoubleLargeArray_Z;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='DoubleFFT_1D']/method[@name='realInverse' and count(parameter)=2 and parameter[1][@type='pl.edu.icm.jlargearrays.DoubleLargeArray'] and parameter[2][@type='boolean']]"
		[Register ("realInverse", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;Z)V", "")]
		public unsafe void RealInverse (global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p0, bool p1)
		{
			if (id_realInverse_Lpl_edu_icm_jlargearrays_DoubleLargeArray_Z == IntPtr.Zero)
				id_realInverse_Lpl_edu_icm_jlargearrays_DoubleLargeArray_Z = JNIEnv.GetMethodID (class_ref, "realInverse", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;Z)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_realInverse_Lpl_edu_icm_jlargearrays_DoubleLargeArray_Z, __args);
			} finally {
			}
		}

		static IntPtr id_realInverse_Lpl_edu_icm_jlargearrays_DoubleLargeArray_JZ;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='DoubleFFT_1D']/method[@name='realInverse' and count(parameter)=3 and parameter[1][@type='pl.edu.icm.jlargearrays.DoubleLargeArray'] and parameter[2][@type='long'] and parameter[3][@type='boolean']]"
		[Register ("realInverse", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;JZ)V", "")]
		public unsafe void RealInverse (global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p0, long p1, bool p2)
		{
			if (id_realInverse_Lpl_edu_icm_jlargearrays_DoubleLargeArray_JZ == IntPtr.Zero)
				id_realInverse_Lpl_edu_icm_jlargearrays_DoubleLargeArray_JZ = JNIEnv.GetMethodID (class_ref, "realInverse", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;JZ)V");
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_realInverse_Lpl_edu_icm_jlargearrays_DoubleLargeArray_JZ, __args);
			} finally {
			}
		}

		static IntPtr id_realInverseFull_arrayDZ;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='DoubleFFT_1D']/method[@name='realInverseFull' and count(parameter)=2 and parameter[1][@type='double[]'] and parameter[2][@type='boolean']]"
		[Register ("realInverseFull", "([DZ)V", "")]
		public unsafe void RealInverseFull (double[] p0, bool p1)
		{
			if (id_realInverseFull_arrayDZ == IntPtr.Zero)
				id_realInverseFull_arrayDZ = JNIEnv.GetMethodID (class_ref, "realInverseFull", "([DZ)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_realInverseFull_arrayDZ, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static IntPtr id_realInverseFull_arrayDIZ;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='DoubleFFT_1D']/method[@name='realInverseFull' and count(parameter)=3 and parameter[1][@type='double[]'] and parameter[2][@type='int'] and parameter[3][@type='boolean']]"
		[Register ("realInverseFull", "([DIZ)V", "")]
		public unsafe void RealInverseFull (double[] p0, int p1, bool p2)
		{
			if (id_realInverseFull_arrayDIZ == IntPtr.Zero)
				id_realInverseFull_arrayDIZ = JNIEnv.GetMethodID (class_ref, "realInverseFull", "([DIZ)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_realInverseFull_arrayDIZ, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static IntPtr id_realInverseFull_Lpl_edu_icm_jlargearrays_DoubleLargeArray_Z;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='DoubleFFT_1D']/method[@name='realInverseFull' and count(parameter)=2 and parameter[1][@type='pl.edu.icm.jlargearrays.DoubleLargeArray'] and parameter[2][@type='boolean']]"
		[Register ("realInverseFull", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;Z)V", "")]
		public unsafe void RealInverseFull (global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p0, bool p1)
		{
			if (id_realInverseFull_Lpl_edu_icm_jlargearrays_DoubleLargeArray_Z == IntPtr.Zero)
				id_realInverseFull_Lpl_edu_icm_jlargearrays_DoubleLargeArray_Z = JNIEnv.GetMethodID (class_ref, "realInverseFull", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;Z)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_realInverseFull_Lpl_edu_icm_jlargearrays_DoubleLargeArray_Z, __args);
			} finally {
			}
		}

		static IntPtr id_realInverseFull_Lpl_edu_icm_jlargearrays_DoubleLargeArray_JZ;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='DoubleFFT_1D']/method[@name='realInverseFull' and count(parameter)=3 and parameter[1][@type='pl.edu.icm.jlargearrays.DoubleLargeArray'] and parameter[2][@type='long'] and parameter[3][@type='boolean']]"
		[Register ("realInverseFull", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;JZ)V", "")]
		public unsafe void RealInverseFull (global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p0, long p1, bool p2)
		{
			if (id_realInverseFull_Lpl_edu_icm_jlargearrays_DoubleLargeArray_JZ == IntPtr.Zero)
				id_realInverseFull_Lpl_edu_icm_jlargearrays_DoubleLargeArray_JZ = JNIEnv.GetMethodID (class_ref, "realInverseFull", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;JZ)V");
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_realInverseFull_Lpl_edu_icm_jlargearrays_DoubleLargeArray_JZ, __args);
			} finally {
			}
		}

	}
}
