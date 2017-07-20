using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Org.Jtransforms.Fft {

	// Metadata.xml XPath class reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='FloatFFT_1D']"
	[global::Android.Runtime.Register ("org/jtransforms/fft/FloatFFT_1D", DoNotGenerateAcw=true)]
	public sealed partial class FloatFFT_1D : global::Java.Lang.Object {

		// Metadata.xml XPath class reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='FloatFFT_1D.Plans']"
		[global::Android.Runtime.Register ("org/jtransforms/fft/FloatFFT_1D$Plans", DoNotGenerateAcw=true)]
		public sealed partial class Plans : global::Java.Lang.Enum {


			static IntPtr BLUESTEIN_jfieldId;

			// Metadata.xml XPath field reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='FloatFFT_1D.Plans']/field[@name='BLUESTEIN']"
			[Register ("BLUESTEIN")]
			public static global::Org.Jtransforms.Fft.FloatFFT_1D.Plans Bluestein {
				get {
					if (BLUESTEIN_jfieldId == IntPtr.Zero)
						BLUESTEIN_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "BLUESTEIN", "Lorg/jtransforms/fft/FloatFFT_1D$Plans;");
					IntPtr __ret = JNIEnv.GetStaticObjectField (class_ref, BLUESTEIN_jfieldId);
					return global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.FloatFFT_1D.Plans> (__ret, JniHandleOwnership.TransferLocalRef);
				}
			}

			static IntPtr MIXED_RADIX_jfieldId;

			// Metadata.xml XPath field reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='FloatFFT_1D.Plans']/field[@name='MIXED_RADIX']"
			[Register ("MIXED_RADIX")]
			public static global::Org.Jtransforms.Fft.FloatFFT_1D.Plans MixedRadix {
				get {
					if (MIXED_RADIX_jfieldId == IntPtr.Zero)
						MIXED_RADIX_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "MIXED_RADIX", "Lorg/jtransforms/fft/FloatFFT_1D$Plans;");
					IntPtr __ret = JNIEnv.GetStaticObjectField (class_ref, MIXED_RADIX_jfieldId);
					return global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.FloatFFT_1D.Plans> (__ret, JniHandleOwnership.TransferLocalRef);
				}
			}

			static IntPtr SPLIT_RADIX_jfieldId;

			// Metadata.xml XPath field reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='FloatFFT_1D.Plans']/field[@name='SPLIT_RADIX']"
			[Register ("SPLIT_RADIX")]
			public static global::Org.Jtransforms.Fft.FloatFFT_1D.Plans SplitRadix {
				get {
					if (SPLIT_RADIX_jfieldId == IntPtr.Zero)
						SPLIT_RADIX_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "SPLIT_RADIX", "Lorg/jtransforms/fft/FloatFFT_1D$Plans;");
					IntPtr __ret = JNIEnv.GetStaticObjectField (class_ref, SPLIT_RADIX_jfieldId);
					return global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.FloatFFT_1D.Plans> (__ret, JniHandleOwnership.TransferLocalRef);
				}
			}
			internal static IntPtr java_class_handle;
			internal static IntPtr class_ref {
				get {
					return JNIEnv.FindClass ("org/jtransforms/fft/FloatFFT_1D$Plans", ref java_class_handle);
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
				return JNIEnv.FindClass ("org/jtransforms/fft/FloatFFT_1D", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (FloatFFT_1D); }
		}

		internal FloatFFT_1D (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor_J;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='FloatFFT_1D']/constructor[@name='FloatFFT_1D' and count(parameter)=1 and parameter[1][@type='long']]"
		[Register (".ctor", "(J)V", "")]
		public unsafe FloatFFT_1D (long p0)
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				if (((object) this).GetType () != typeof (FloatFFT_1D)) {
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

		static IntPtr id_complexForward_arrayF;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='FloatFFT_1D']/method[@name='complexForward' and count(parameter)=1 and parameter[1][@type='float[]']]"
		[Register ("complexForward", "([F)V", "")]
		public unsafe void ComplexForward (float[] p0)
		{
			if (id_complexForward_arrayF == IntPtr.Zero)
				id_complexForward_arrayF = JNIEnv.GetMethodID (class_ref, "complexForward", "([F)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_complexForward_arrayF, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static IntPtr id_complexForward_arrayFI;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='FloatFFT_1D']/method[@name='complexForward' and count(parameter)=2 and parameter[1][@type='float[]'] and parameter[2][@type='int']]"
		[Register ("complexForward", "([FI)V", "")]
		public unsafe void ComplexForward (float[] p0, int p1)
		{
			if (id_complexForward_arrayFI == IntPtr.Zero)
				id_complexForward_arrayFI = JNIEnv.GetMethodID (class_ref, "complexForward", "([FI)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_complexForward_arrayFI, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static IntPtr id_complexForward_Lpl_edu_icm_jlargearrays_FloatLargeArray_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='FloatFFT_1D']/method[@name='complexForward' and count(parameter)=1 and parameter[1][@type='pl.edu.icm.jlargearrays.FloatLargeArray']]"
		[Register ("complexForward", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;)V", "")]
		public unsafe void ComplexForward (global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p0)
		{
			if (id_complexForward_Lpl_edu_icm_jlargearrays_FloatLargeArray_ == IntPtr.Zero)
				id_complexForward_Lpl_edu_icm_jlargearrays_FloatLargeArray_ = JNIEnv.GetMethodID (class_ref, "complexForward", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_complexForward_Lpl_edu_icm_jlargearrays_FloatLargeArray_, __args);
			} finally {
			}
		}

		static IntPtr id_complexForward_Lpl_edu_icm_jlargearrays_FloatLargeArray_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='FloatFFT_1D']/method[@name='complexForward' and count(parameter)=2 and parameter[1][@type='pl.edu.icm.jlargearrays.FloatLargeArray'] and parameter[2][@type='long']]"
		[Register ("complexForward", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;J)V", "")]
		public unsafe void ComplexForward (global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p0, long p1)
		{
			if (id_complexForward_Lpl_edu_icm_jlargearrays_FloatLargeArray_J == IntPtr.Zero)
				id_complexForward_Lpl_edu_icm_jlargearrays_FloatLargeArray_J = JNIEnv.GetMethodID (class_ref, "complexForward", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;J)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_complexForward_Lpl_edu_icm_jlargearrays_FloatLargeArray_J, __args);
			} finally {
			}
		}

		static IntPtr id_complexInverse_arrayFZ;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='FloatFFT_1D']/method[@name='complexInverse' and count(parameter)=2 and parameter[1][@type='float[]'] and parameter[2][@type='boolean']]"
		[Register ("complexInverse", "([FZ)V", "")]
		public unsafe void ComplexInverse (float[] p0, bool p1)
		{
			if (id_complexInverse_arrayFZ == IntPtr.Zero)
				id_complexInverse_arrayFZ = JNIEnv.GetMethodID (class_ref, "complexInverse", "([FZ)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_complexInverse_arrayFZ, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static IntPtr id_complexInverse_arrayFIZ;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='FloatFFT_1D']/method[@name='complexInverse' and count(parameter)=3 and parameter[1][@type='float[]'] and parameter[2][@type='int'] and parameter[3][@type='boolean']]"
		[Register ("complexInverse", "([FIZ)V", "")]
		public unsafe void ComplexInverse (float[] p0, int p1, bool p2)
		{
			if (id_complexInverse_arrayFIZ == IntPtr.Zero)
				id_complexInverse_arrayFIZ = JNIEnv.GetMethodID (class_ref, "complexInverse", "([FIZ)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_complexInverse_arrayFIZ, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static IntPtr id_complexInverse_Lpl_edu_icm_jlargearrays_FloatLargeArray_Z;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='FloatFFT_1D']/method[@name='complexInverse' and count(parameter)=2 and parameter[1][@type='pl.edu.icm.jlargearrays.FloatLargeArray'] and parameter[2][@type='boolean']]"
		[Register ("complexInverse", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;Z)V", "")]
		public unsafe void ComplexInverse (global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p0, bool p1)
		{
			if (id_complexInverse_Lpl_edu_icm_jlargearrays_FloatLargeArray_Z == IntPtr.Zero)
				id_complexInverse_Lpl_edu_icm_jlargearrays_FloatLargeArray_Z = JNIEnv.GetMethodID (class_ref, "complexInverse", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;Z)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_complexInverse_Lpl_edu_icm_jlargearrays_FloatLargeArray_Z, __args);
			} finally {
			}
		}

		static IntPtr id_complexInverse_Lpl_edu_icm_jlargearrays_FloatLargeArray_JZ;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='FloatFFT_1D']/method[@name='complexInverse' and count(parameter)=3 and parameter[1][@type='pl.edu.icm.jlargearrays.FloatLargeArray'] and parameter[2][@type='long'] and parameter[3][@type='boolean']]"
		[Register ("complexInverse", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;JZ)V", "")]
		public unsafe void ComplexInverse (global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p0, long p1, bool p2)
		{
			if (id_complexInverse_Lpl_edu_icm_jlargearrays_FloatLargeArray_JZ == IntPtr.Zero)
				id_complexInverse_Lpl_edu_icm_jlargearrays_FloatLargeArray_JZ = JNIEnv.GetMethodID (class_ref, "complexInverse", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;JZ)V");
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_complexInverse_Lpl_edu_icm_jlargearrays_FloatLargeArray_JZ, __args);
			} finally {
			}
		}

		static IntPtr id_realForward_arrayF;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='FloatFFT_1D']/method[@name='realForward' and count(parameter)=1 and parameter[1][@type='float[]']]"
		[Register ("realForward", "([F)V", "")]
		public unsafe void RealForward (float[] p0)
		{
			if (id_realForward_arrayF == IntPtr.Zero)
				id_realForward_arrayF = JNIEnv.GetMethodID (class_ref, "realForward", "([F)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_realForward_arrayF, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static IntPtr id_realForward_arrayFI;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='FloatFFT_1D']/method[@name='realForward' and count(parameter)=2 and parameter[1][@type='float[]'] and parameter[2][@type='int']]"
		[Register ("realForward", "([FI)V", "")]
		public unsafe void RealForward (float[] p0, int p1)
		{
			if (id_realForward_arrayFI == IntPtr.Zero)
				id_realForward_arrayFI = JNIEnv.GetMethodID (class_ref, "realForward", "([FI)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_realForward_arrayFI, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static IntPtr id_realForward_Lpl_edu_icm_jlargearrays_FloatLargeArray_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='FloatFFT_1D']/method[@name='realForward' and count(parameter)=1 and parameter[1][@type='pl.edu.icm.jlargearrays.FloatLargeArray']]"
		[Register ("realForward", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;)V", "")]
		public unsafe void RealForward (global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p0)
		{
			if (id_realForward_Lpl_edu_icm_jlargearrays_FloatLargeArray_ == IntPtr.Zero)
				id_realForward_Lpl_edu_icm_jlargearrays_FloatLargeArray_ = JNIEnv.GetMethodID (class_ref, "realForward", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_realForward_Lpl_edu_icm_jlargearrays_FloatLargeArray_, __args);
			} finally {
			}
		}

		static IntPtr id_realForward_Lpl_edu_icm_jlargearrays_FloatLargeArray_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='FloatFFT_1D']/method[@name='realForward' and count(parameter)=2 and parameter[1][@type='pl.edu.icm.jlargearrays.FloatLargeArray'] and parameter[2][@type='long']]"
		[Register ("realForward", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;J)V", "")]
		public unsafe void RealForward (global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p0, long p1)
		{
			if (id_realForward_Lpl_edu_icm_jlargearrays_FloatLargeArray_J == IntPtr.Zero)
				id_realForward_Lpl_edu_icm_jlargearrays_FloatLargeArray_J = JNIEnv.GetMethodID (class_ref, "realForward", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;J)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_realForward_Lpl_edu_icm_jlargearrays_FloatLargeArray_J, __args);
			} finally {
			}
		}

		static IntPtr id_realForwardFull_arrayF;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='FloatFFT_1D']/method[@name='realForwardFull' and count(parameter)=1 and parameter[1][@type='float[]']]"
		[Register ("realForwardFull", "([F)V", "")]
		public unsafe void RealForwardFull (float[] p0)
		{
			if (id_realForwardFull_arrayF == IntPtr.Zero)
				id_realForwardFull_arrayF = JNIEnv.GetMethodID (class_ref, "realForwardFull", "([F)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_realForwardFull_arrayF, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static IntPtr id_realForwardFull_arrayFI;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='FloatFFT_1D']/method[@name='realForwardFull' and count(parameter)=2 and parameter[1][@type='float[]'] and parameter[2][@type='int']]"
		[Register ("realForwardFull", "([FI)V", "")]
		public unsafe void RealForwardFull (float[] p0, int p1)
		{
			if (id_realForwardFull_arrayFI == IntPtr.Zero)
				id_realForwardFull_arrayFI = JNIEnv.GetMethodID (class_ref, "realForwardFull", "([FI)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_realForwardFull_arrayFI, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static IntPtr id_realForwardFull_Lpl_edu_icm_jlargearrays_FloatLargeArray_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='FloatFFT_1D']/method[@name='realForwardFull' and count(parameter)=1 and parameter[1][@type='pl.edu.icm.jlargearrays.FloatLargeArray']]"
		[Register ("realForwardFull", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;)V", "")]
		public unsafe void RealForwardFull (global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p0)
		{
			if (id_realForwardFull_Lpl_edu_icm_jlargearrays_FloatLargeArray_ == IntPtr.Zero)
				id_realForwardFull_Lpl_edu_icm_jlargearrays_FloatLargeArray_ = JNIEnv.GetMethodID (class_ref, "realForwardFull", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_realForwardFull_Lpl_edu_icm_jlargearrays_FloatLargeArray_, __args);
			} finally {
			}
		}

		static IntPtr id_realForwardFull_Lpl_edu_icm_jlargearrays_FloatLargeArray_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='FloatFFT_1D']/method[@name='realForwardFull' and count(parameter)=2 and parameter[1][@type='pl.edu.icm.jlargearrays.FloatLargeArray'] and parameter[2][@type='long']]"
		[Register ("realForwardFull", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;J)V", "")]
		public unsafe void RealForwardFull (global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p0, long p1)
		{
			if (id_realForwardFull_Lpl_edu_icm_jlargearrays_FloatLargeArray_J == IntPtr.Zero)
				id_realForwardFull_Lpl_edu_icm_jlargearrays_FloatLargeArray_J = JNIEnv.GetMethodID (class_ref, "realForwardFull", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;J)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_realForwardFull_Lpl_edu_icm_jlargearrays_FloatLargeArray_J, __args);
			} finally {
			}
		}

		static IntPtr id_realInverse2_arrayFIZ;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='FloatFFT_1D']/method[@name='realInverse2' and count(parameter)=3 and parameter[1][@type='float[]'] and parameter[2][@type='int'] and parameter[3][@type='boolean']]"
		[Register ("realInverse2", "([FIZ)V", "")]
		protected unsafe void RealInverse2 (float[] p0, int p1, bool p2)
		{
			if (id_realInverse2_arrayFIZ == IntPtr.Zero)
				id_realInverse2_arrayFIZ = JNIEnv.GetMethodID (class_ref, "realInverse2", "([FIZ)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_realInverse2_arrayFIZ, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static IntPtr id_realInverse2_Lpl_edu_icm_jlargearrays_FloatLargeArray_JZ;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='FloatFFT_1D']/method[@name='realInverse2' and count(parameter)=3 and parameter[1][@type='pl.edu.icm.jlargearrays.FloatLargeArray'] and parameter[2][@type='long'] and parameter[3][@type='boolean']]"
		[Register ("realInverse2", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;JZ)V", "")]
		protected unsafe void RealInverse2 (global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p0, long p1, bool p2)
		{
			if (id_realInverse2_Lpl_edu_icm_jlargearrays_FloatLargeArray_JZ == IntPtr.Zero)
				id_realInverse2_Lpl_edu_icm_jlargearrays_FloatLargeArray_JZ = JNIEnv.GetMethodID (class_ref, "realInverse2", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;JZ)V");
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_realInverse2_Lpl_edu_icm_jlargearrays_FloatLargeArray_JZ, __args);
			} finally {
			}
		}

		static IntPtr id_realInverse_arrayFZ;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='FloatFFT_1D']/method[@name='realInverse' and count(parameter)=2 and parameter[1][@type='float[]'] and parameter[2][@type='boolean']]"
		[Register ("realInverse", "([FZ)V", "")]
		public unsafe void RealInverse (float[] p0, bool p1)
		{
			if (id_realInverse_arrayFZ == IntPtr.Zero)
				id_realInverse_arrayFZ = JNIEnv.GetMethodID (class_ref, "realInverse", "([FZ)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_realInverse_arrayFZ, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static IntPtr id_realInverse_arrayFIZ;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='FloatFFT_1D']/method[@name='realInverse' and count(parameter)=3 and parameter[1][@type='float[]'] and parameter[2][@type='int'] and parameter[3][@type='boolean']]"
		[Register ("realInverse", "([FIZ)V", "")]
		public unsafe void RealInverse (float[] p0, int p1, bool p2)
		{
			if (id_realInverse_arrayFIZ == IntPtr.Zero)
				id_realInverse_arrayFIZ = JNIEnv.GetMethodID (class_ref, "realInverse", "([FIZ)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_realInverse_arrayFIZ, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static IntPtr id_realInverse_Lpl_edu_icm_jlargearrays_FloatLargeArray_Z;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='FloatFFT_1D']/method[@name='realInverse' and count(parameter)=2 and parameter[1][@type='pl.edu.icm.jlargearrays.FloatLargeArray'] and parameter[2][@type='boolean']]"
		[Register ("realInverse", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;Z)V", "")]
		public unsafe void RealInverse (global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p0, bool p1)
		{
			if (id_realInverse_Lpl_edu_icm_jlargearrays_FloatLargeArray_Z == IntPtr.Zero)
				id_realInverse_Lpl_edu_icm_jlargearrays_FloatLargeArray_Z = JNIEnv.GetMethodID (class_ref, "realInverse", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;Z)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_realInverse_Lpl_edu_icm_jlargearrays_FloatLargeArray_Z, __args);
			} finally {
			}
		}

		static IntPtr id_realInverse_Lpl_edu_icm_jlargearrays_FloatLargeArray_JZ;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='FloatFFT_1D']/method[@name='realInverse' and count(parameter)=3 and parameter[1][@type='pl.edu.icm.jlargearrays.FloatLargeArray'] and parameter[2][@type='long'] and parameter[3][@type='boolean']]"
		[Register ("realInverse", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;JZ)V", "")]
		public unsafe void RealInverse (global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p0, long p1, bool p2)
		{
			if (id_realInverse_Lpl_edu_icm_jlargearrays_FloatLargeArray_JZ == IntPtr.Zero)
				id_realInverse_Lpl_edu_icm_jlargearrays_FloatLargeArray_JZ = JNIEnv.GetMethodID (class_ref, "realInverse", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;JZ)V");
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_realInverse_Lpl_edu_icm_jlargearrays_FloatLargeArray_JZ, __args);
			} finally {
			}
		}

		static IntPtr id_realInverseFull_arrayFZ;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='FloatFFT_1D']/method[@name='realInverseFull' and count(parameter)=2 and parameter[1][@type='float[]'] and parameter[2][@type='boolean']]"
		[Register ("realInverseFull", "([FZ)V", "")]
		public unsafe void RealInverseFull (float[] p0, bool p1)
		{
			if (id_realInverseFull_arrayFZ == IntPtr.Zero)
				id_realInverseFull_arrayFZ = JNIEnv.GetMethodID (class_ref, "realInverseFull", "([FZ)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_realInverseFull_arrayFZ, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static IntPtr id_realInverseFull_arrayFIZ;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='FloatFFT_1D']/method[@name='realInverseFull' and count(parameter)=3 and parameter[1][@type='float[]'] and parameter[2][@type='int'] and parameter[3][@type='boolean']]"
		[Register ("realInverseFull", "([FIZ)V", "")]
		public unsafe void RealInverseFull (float[] p0, int p1, bool p2)
		{
			if (id_realInverseFull_arrayFIZ == IntPtr.Zero)
				id_realInverseFull_arrayFIZ = JNIEnv.GetMethodID (class_ref, "realInverseFull", "([FIZ)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_realInverseFull_arrayFIZ, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static IntPtr id_realInverseFull_Lpl_edu_icm_jlargearrays_FloatLargeArray_Z;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='FloatFFT_1D']/method[@name='realInverseFull' and count(parameter)=2 and parameter[1][@type='pl.edu.icm.jlargearrays.FloatLargeArray'] and parameter[2][@type='boolean']]"
		[Register ("realInverseFull", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;Z)V", "")]
		public unsafe void RealInverseFull (global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p0, bool p1)
		{
			if (id_realInverseFull_Lpl_edu_icm_jlargearrays_FloatLargeArray_Z == IntPtr.Zero)
				id_realInverseFull_Lpl_edu_icm_jlargearrays_FloatLargeArray_Z = JNIEnv.GetMethodID (class_ref, "realInverseFull", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;Z)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_realInverseFull_Lpl_edu_icm_jlargearrays_FloatLargeArray_Z, __args);
			} finally {
			}
		}

		static IntPtr id_realInverseFull_Lpl_edu_icm_jlargearrays_FloatLargeArray_JZ;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='FloatFFT_1D']/method[@name='realInverseFull' and count(parameter)=3 and parameter[1][@type='pl.edu.icm.jlargearrays.FloatLargeArray'] and parameter[2][@type='long'] and parameter[3][@type='boolean']]"
		[Register ("realInverseFull", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;JZ)V", "")]
		public unsafe void RealInverseFull (global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p0, long p1, bool p2)
		{
			if (id_realInverseFull_Lpl_edu_icm_jlargearrays_FloatLargeArray_JZ == IntPtr.Zero)
				id_realInverseFull_Lpl_edu_icm_jlargearrays_FloatLargeArray_JZ = JNIEnv.GetMethodID (class_ref, "realInverseFull", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;JZ)V");
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_realInverseFull_Lpl_edu_icm_jlargearrays_FloatLargeArray_JZ, __args);
			} finally {
			}
		}

	}
}
