using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Org.Jtransforms.Fft {

	// Metadata.xml XPath class reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='FloatFFT_2D']"
	[global::Android.Runtime.Register ("org/jtransforms/fft/FloatFFT_2D", DoNotGenerateAcw=true)]
	public partial class FloatFFT_2D : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("org/jtransforms/fft/FloatFFT_2D", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (FloatFFT_2D); }
		}

		protected FloatFFT_2D (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor_JJ;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='FloatFFT_2D']/constructor[@name='FloatFFT_2D' and count(parameter)=2 and parameter[1][@type='long'] and parameter[2][@type='long']]"
		[Register (".ctor", "(JJ)V", "")]
		public unsafe FloatFFT_2D (long p0, long p1)
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				if (((object) this).GetType () != typeof (FloatFFT_2D)) {
					SetHandle (
							global::Android.Runtime.JNIEnv.StartCreateInstance (((object) this).GetType (), "(JJ)V", __args),
							JniHandleOwnership.TransferLocalRef);
					global::Android.Runtime.JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, "(JJ)V", __args);
					return;
				}

				if (id_ctor_JJ == IntPtr.Zero)
					id_ctor_JJ = JNIEnv.GetMethodID (class_ref, "<init>", "(JJ)V");
				SetHandle (
						global::Android.Runtime.JNIEnv.StartCreateInstance (class_ref, id_ctor_JJ, __args),
						JniHandleOwnership.TransferLocalRef);
				JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, class_ref, id_ctor_JJ, __args);
			} finally {
			}
		}

		static Delegate cb_complexForward_arrayF;
#pragma warning disable 0169
		static Delegate GetComplexForward_arrayFHandler ()
		{
			if (cb_complexForward_arrayF == null)
				cb_complexForward_arrayF = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_ComplexForward_arrayF);
			return cb_complexForward_arrayF;
		}

		static void n_ComplexForward_arrayF (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Org.Jtransforms.Fft.FloatFFT_2D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.FloatFFT_2D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			float[] p0 = (float[]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (float));
			__this.ComplexForward (p0);
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
		}
#pragma warning restore 0169

		static IntPtr id_complexForward_arrayF;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='FloatFFT_2D']/method[@name='complexForward' and count(parameter)=1 and parameter[1][@type='float[]']]"
		[Register ("complexForward", "([F)V", "GetComplexForward_arrayFHandler")]
		public virtual unsafe void ComplexForward (float[] p0)
		{
			if (id_complexForward_arrayF == IntPtr.Zero)
				id_complexForward_arrayF = JNIEnv.GetMethodID (class_ref, "complexForward", "([F)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_complexForward_arrayF, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "complexForward", "([F)V"), __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static Delegate cb_complexForward_arrayarrayF;
#pragma warning disable 0169
		static Delegate GetComplexForward_arrayarrayFHandler ()
		{
			if (cb_complexForward_arrayarrayF == null)
				cb_complexForward_arrayarrayF = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_ComplexForward_arrayarrayF);
			return cb_complexForward_arrayarrayF;
		}

		static void n_ComplexForward_arrayarrayF (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Org.Jtransforms.Fft.FloatFFT_2D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.FloatFFT_2D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			float[][] p0 = (float[][]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (float[]));
			__this.ComplexForward (p0);
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
		}
#pragma warning restore 0169

		static IntPtr id_complexForward_arrayarrayF;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='FloatFFT_2D']/method[@name='complexForward' and count(parameter)=1 and parameter[1][@type='float[][]']]"
		[Register ("complexForward", "([[F)V", "GetComplexForward_arrayarrayFHandler")]
		public virtual unsafe void ComplexForward (float[][] p0)
		{
			if (id_complexForward_arrayarrayF == IntPtr.Zero)
				id_complexForward_arrayarrayF = JNIEnv.GetMethodID (class_ref, "complexForward", "([[F)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_complexForward_arrayarrayF, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "complexForward", "([[F)V"), __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static Delegate cb_complexForward_Lpl_edu_icm_jlargearrays_FloatLargeArray_;
#pragma warning disable 0169
		static Delegate GetComplexForward_Lpl_edu_icm_jlargearrays_FloatLargeArray_Handler ()
		{
			if (cb_complexForward_Lpl_edu_icm_jlargearrays_FloatLargeArray_ == null)
				cb_complexForward_Lpl_edu_icm_jlargearrays_FloatLargeArray_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_ComplexForward_Lpl_edu_icm_jlargearrays_FloatLargeArray_);
			return cb_complexForward_Lpl_edu_icm_jlargearrays_FloatLargeArray_;
		}

		static void n_ComplexForward_Lpl_edu_icm_jlargearrays_FloatLargeArray_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Org.Jtransforms.Fft.FloatFFT_2D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.FloatFFT_2D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p0 = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.FloatLargeArray> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.ComplexForward (p0);
		}
#pragma warning restore 0169

		static IntPtr id_complexForward_Lpl_edu_icm_jlargearrays_FloatLargeArray_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='FloatFFT_2D']/method[@name='complexForward' and count(parameter)=1 and parameter[1][@type='pl.edu.icm.jlargearrays.FloatLargeArray']]"
		[Register ("complexForward", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;)V", "GetComplexForward_Lpl_edu_icm_jlargearrays_FloatLargeArray_Handler")]
		public virtual unsafe void ComplexForward (global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p0)
		{
			if (id_complexForward_Lpl_edu_icm_jlargearrays_FloatLargeArray_ == IntPtr.Zero)
				id_complexForward_Lpl_edu_icm_jlargearrays_FloatLargeArray_ = JNIEnv.GetMethodID (class_ref, "complexForward", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_complexForward_Lpl_edu_icm_jlargearrays_FloatLargeArray_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "complexForward", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;)V"), __args);
			} finally {
			}
		}

		static Delegate cb_complexInverse_arrayFZ;
#pragma warning disable 0169
		static Delegate GetComplexInverse_arrayFZHandler ()
		{
			if (cb_complexInverse_arrayFZ == null)
				cb_complexInverse_arrayFZ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, bool>) n_ComplexInverse_arrayFZ);
			return cb_complexInverse_arrayFZ;
		}

		static void n_ComplexInverse_arrayFZ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, bool p1)
		{
			global::Org.Jtransforms.Fft.FloatFFT_2D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.FloatFFT_2D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			float[] p0 = (float[]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (float));
			__this.ComplexInverse (p0, p1);
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
		}
#pragma warning restore 0169

		static IntPtr id_complexInverse_arrayFZ;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='FloatFFT_2D']/method[@name='complexInverse' and count(parameter)=2 and parameter[1][@type='float[]'] and parameter[2][@type='boolean']]"
		[Register ("complexInverse", "([FZ)V", "GetComplexInverse_arrayFZHandler")]
		public virtual unsafe void ComplexInverse (float[] p0, bool p1)
		{
			if (id_complexInverse_arrayFZ == IntPtr.Zero)
				id_complexInverse_arrayFZ = JNIEnv.GetMethodID (class_ref, "complexInverse", "([FZ)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_complexInverse_arrayFZ, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "complexInverse", "([FZ)V"), __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static Delegate cb_complexInverse_arrayarrayFZ;
#pragma warning disable 0169
		static Delegate GetComplexInverse_arrayarrayFZHandler ()
		{
			if (cb_complexInverse_arrayarrayFZ == null)
				cb_complexInverse_arrayarrayFZ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, bool>) n_ComplexInverse_arrayarrayFZ);
			return cb_complexInverse_arrayarrayFZ;
		}

		static void n_ComplexInverse_arrayarrayFZ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, bool p1)
		{
			global::Org.Jtransforms.Fft.FloatFFT_2D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.FloatFFT_2D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			float[][] p0 = (float[][]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (float[]));
			__this.ComplexInverse (p0, p1);
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
		}
#pragma warning restore 0169

		static IntPtr id_complexInverse_arrayarrayFZ;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='FloatFFT_2D']/method[@name='complexInverse' and count(parameter)=2 and parameter[1][@type='float[][]'] and parameter[2][@type='boolean']]"
		[Register ("complexInverse", "([[FZ)V", "GetComplexInverse_arrayarrayFZHandler")]
		public virtual unsafe void ComplexInverse (float[][] p0, bool p1)
		{
			if (id_complexInverse_arrayarrayFZ == IntPtr.Zero)
				id_complexInverse_arrayarrayFZ = JNIEnv.GetMethodID (class_ref, "complexInverse", "([[FZ)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_complexInverse_arrayarrayFZ, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "complexInverse", "([[FZ)V"), __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static Delegate cb_complexInverse_Lpl_edu_icm_jlargearrays_FloatLargeArray_Z;
#pragma warning disable 0169
		static Delegate GetComplexInverse_Lpl_edu_icm_jlargearrays_FloatLargeArray_ZHandler ()
		{
			if (cb_complexInverse_Lpl_edu_icm_jlargearrays_FloatLargeArray_Z == null)
				cb_complexInverse_Lpl_edu_icm_jlargearrays_FloatLargeArray_Z = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, bool>) n_ComplexInverse_Lpl_edu_icm_jlargearrays_FloatLargeArray_Z);
			return cb_complexInverse_Lpl_edu_icm_jlargearrays_FloatLargeArray_Z;
		}

		static void n_ComplexInverse_Lpl_edu_icm_jlargearrays_FloatLargeArray_Z (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, bool p1)
		{
			global::Org.Jtransforms.Fft.FloatFFT_2D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.FloatFFT_2D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p0 = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.FloatLargeArray> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.ComplexInverse (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_complexInverse_Lpl_edu_icm_jlargearrays_FloatLargeArray_Z;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='FloatFFT_2D']/method[@name='complexInverse' and count(parameter)=2 and parameter[1][@type='pl.edu.icm.jlargearrays.FloatLargeArray'] and parameter[2][@type='boolean']]"
		[Register ("complexInverse", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;Z)V", "GetComplexInverse_Lpl_edu_icm_jlargearrays_FloatLargeArray_ZHandler")]
		public virtual unsafe void ComplexInverse (global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p0, bool p1)
		{
			if (id_complexInverse_Lpl_edu_icm_jlargearrays_FloatLargeArray_Z == IntPtr.Zero)
				id_complexInverse_Lpl_edu_icm_jlargearrays_FloatLargeArray_Z = JNIEnv.GetMethodID (class_ref, "complexInverse", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;Z)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_complexInverse_Lpl_edu_icm_jlargearrays_FloatLargeArray_Z, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "complexInverse", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;Z)V"), __args);
			} finally {
			}
		}

		static Delegate cb_realForward_arrayF;
#pragma warning disable 0169
		static Delegate GetRealForward_arrayFHandler ()
		{
			if (cb_realForward_arrayF == null)
				cb_realForward_arrayF = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_RealForward_arrayF);
			return cb_realForward_arrayF;
		}

		static void n_RealForward_arrayF (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Org.Jtransforms.Fft.FloatFFT_2D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.FloatFFT_2D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			float[] p0 = (float[]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (float));
			__this.RealForward (p0);
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
		}
#pragma warning restore 0169

		static IntPtr id_realForward_arrayF;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='FloatFFT_2D']/method[@name='realForward' and count(parameter)=1 and parameter[1][@type='float[]']]"
		[Register ("realForward", "([F)V", "GetRealForward_arrayFHandler")]
		public virtual unsafe void RealForward (float[] p0)
		{
			if (id_realForward_arrayF == IntPtr.Zero)
				id_realForward_arrayF = JNIEnv.GetMethodID (class_ref, "realForward", "([F)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_realForward_arrayF, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "realForward", "([F)V"), __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static Delegate cb_realForward_arrayarrayF;
#pragma warning disable 0169
		static Delegate GetRealForward_arrayarrayFHandler ()
		{
			if (cb_realForward_arrayarrayF == null)
				cb_realForward_arrayarrayF = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_RealForward_arrayarrayF);
			return cb_realForward_arrayarrayF;
		}

		static void n_RealForward_arrayarrayF (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Org.Jtransforms.Fft.FloatFFT_2D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.FloatFFT_2D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			float[][] p0 = (float[][]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (float[]));
			__this.RealForward (p0);
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
		}
#pragma warning restore 0169

		static IntPtr id_realForward_arrayarrayF;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='FloatFFT_2D']/method[@name='realForward' and count(parameter)=1 and parameter[1][@type='float[][]']]"
		[Register ("realForward", "([[F)V", "GetRealForward_arrayarrayFHandler")]
		public virtual unsafe void RealForward (float[][] p0)
		{
			if (id_realForward_arrayarrayF == IntPtr.Zero)
				id_realForward_arrayarrayF = JNIEnv.GetMethodID (class_ref, "realForward", "([[F)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_realForward_arrayarrayF, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "realForward", "([[F)V"), __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static Delegate cb_realForward_Lpl_edu_icm_jlargearrays_FloatLargeArray_;
#pragma warning disable 0169
		static Delegate GetRealForward_Lpl_edu_icm_jlargearrays_FloatLargeArray_Handler ()
		{
			if (cb_realForward_Lpl_edu_icm_jlargearrays_FloatLargeArray_ == null)
				cb_realForward_Lpl_edu_icm_jlargearrays_FloatLargeArray_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_RealForward_Lpl_edu_icm_jlargearrays_FloatLargeArray_);
			return cb_realForward_Lpl_edu_icm_jlargearrays_FloatLargeArray_;
		}

		static void n_RealForward_Lpl_edu_icm_jlargearrays_FloatLargeArray_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Org.Jtransforms.Fft.FloatFFT_2D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.FloatFFT_2D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p0 = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.FloatLargeArray> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.RealForward (p0);
		}
#pragma warning restore 0169

		static IntPtr id_realForward_Lpl_edu_icm_jlargearrays_FloatLargeArray_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='FloatFFT_2D']/method[@name='realForward' and count(parameter)=1 and parameter[1][@type='pl.edu.icm.jlargearrays.FloatLargeArray']]"
		[Register ("realForward", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;)V", "GetRealForward_Lpl_edu_icm_jlargearrays_FloatLargeArray_Handler")]
		public virtual unsafe void RealForward (global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p0)
		{
			if (id_realForward_Lpl_edu_icm_jlargearrays_FloatLargeArray_ == IntPtr.Zero)
				id_realForward_Lpl_edu_icm_jlargearrays_FloatLargeArray_ = JNIEnv.GetMethodID (class_ref, "realForward", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_realForward_Lpl_edu_icm_jlargearrays_FloatLargeArray_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "realForward", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;)V"), __args);
			} finally {
			}
		}

		static Delegate cb_realForwardFull_arrayF;
#pragma warning disable 0169
		static Delegate GetRealForwardFull_arrayFHandler ()
		{
			if (cb_realForwardFull_arrayF == null)
				cb_realForwardFull_arrayF = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_RealForwardFull_arrayF);
			return cb_realForwardFull_arrayF;
		}

		static void n_RealForwardFull_arrayF (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Org.Jtransforms.Fft.FloatFFT_2D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.FloatFFT_2D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			float[] p0 = (float[]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (float));
			__this.RealForwardFull (p0);
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
		}
#pragma warning restore 0169

		static IntPtr id_realForwardFull_arrayF;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='FloatFFT_2D']/method[@name='realForwardFull' and count(parameter)=1 and parameter[1][@type='float[]']]"
		[Register ("realForwardFull", "([F)V", "GetRealForwardFull_arrayFHandler")]
		public virtual unsafe void RealForwardFull (float[] p0)
		{
			if (id_realForwardFull_arrayF == IntPtr.Zero)
				id_realForwardFull_arrayF = JNIEnv.GetMethodID (class_ref, "realForwardFull", "([F)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_realForwardFull_arrayF, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "realForwardFull", "([F)V"), __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static Delegate cb_realForwardFull_arrayarrayF;
#pragma warning disable 0169
		static Delegate GetRealForwardFull_arrayarrayFHandler ()
		{
			if (cb_realForwardFull_arrayarrayF == null)
				cb_realForwardFull_arrayarrayF = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_RealForwardFull_arrayarrayF);
			return cb_realForwardFull_arrayarrayF;
		}

		static void n_RealForwardFull_arrayarrayF (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Org.Jtransforms.Fft.FloatFFT_2D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.FloatFFT_2D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			float[][] p0 = (float[][]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (float[]));
			__this.RealForwardFull (p0);
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
		}
#pragma warning restore 0169

		static IntPtr id_realForwardFull_arrayarrayF;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='FloatFFT_2D']/method[@name='realForwardFull' and count(parameter)=1 and parameter[1][@type='float[][]']]"
		[Register ("realForwardFull", "([[F)V", "GetRealForwardFull_arrayarrayFHandler")]
		public virtual unsafe void RealForwardFull (float[][] p0)
		{
			if (id_realForwardFull_arrayarrayF == IntPtr.Zero)
				id_realForwardFull_arrayarrayF = JNIEnv.GetMethodID (class_ref, "realForwardFull", "([[F)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_realForwardFull_arrayarrayF, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "realForwardFull", "([[F)V"), __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static Delegate cb_realForwardFull_Lpl_edu_icm_jlargearrays_FloatLargeArray_;
#pragma warning disable 0169
		static Delegate GetRealForwardFull_Lpl_edu_icm_jlargearrays_FloatLargeArray_Handler ()
		{
			if (cb_realForwardFull_Lpl_edu_icm_jlargearrays_FloatLargeArray_ == null)
				cb_realForwardFull_Lpl_edu_icm_jlargearrays_FloatLargeArray_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_RealForwardFull_Lpl_edu_icm_jlargearrays_FloatLargeArray_);
			return cb_realForwardFull_Lpl_edu_icm_jlargearrays_FloatLargeArray_;
		}

		static void n_RealForwardFull_Lpl_edu_icm_jlargearrays_FloatLargeArray_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Org.Jtransforms.Fft.FloatFFT_2D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.FloatFFT_2D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p0 = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.FloatLargeArray> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.RealForwardFull (p0);
		}
#pragma warning restore 0169

		static IntPtr id_realForwardFull_Lpl_edu_icm_jlargearrays_FloatLargeArray_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='FloatFFT_2D']/method[@name='realForwardFull' and count(parameter)=1 and parameter[1][@type='pl.edu.icm.jlargearrays.FloatLargeArray']]"
		[Register ("realForwardFull", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;)V", "GetRealForwardFull_Lpl_edu_icm_jlargearrays_FloatLargeArray_Handler")]
		public virtual unsafe void RealForwardFull (global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p0)
		{
			if (id_realForwardFull_Lpl_edu_icm_jlargearrays_FloatLargeArray_ == IntPtr.Zero)
				id_realForwardFull_Lpl_edu_icm_jlargearrays_FloatLargeArray_ = JNIEnv.GetMethodID (class_ref, "realForwardFull", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_realForwardFull_Lpl_edu_icm_jlargearrays_FloatLargeArray_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "realForwardFull", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;)V"), __args);
			} finally {
			}
		}

		static Delegate cb_realInverse_arrayFZ;
#pragma warning disable 0169
		static Delegate GetRealInverse_arrayFZHandler ()
		{
			if (cb_realInverse_arrayFZ == null)
				cb_realInverse_arrayFZ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, bool>) n_RealInverse_arrayFZ);
			return cb_realInverse_arrayFZ;
		}

		static void n_RealInverse_arrayFZ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, bool p1)
		{
			global::Org.Jtransforms.Fft.FloatFFT_2D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.FloatFFT_2D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			float[] p0 = (float[]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (float));
			__this.RealInverse (p0, p1);
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
		}
#pragma warning restore 0169

		static IntPtr id_realInverse_arrayFZ;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='FloatFFT_2D']/method[@name='realInverse' and count(parameter)=2 and parameter[1][@type='float[]'] and parameter[2][@type='boolean']]"
		[Register ("realInverse", "([FZ)V", "GetRealInverse_arrayFZHandler")]
		public virtual unsafe void RealInverse (float[] p0, bool p1)
		{
			if (id_realInverse_arrayFZ == IntPtr.Zero)
				id_realInverse_arrayFZ = JNIEnv.GetMethodID (class_ref, "realInverse", "([FZ)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_realInverse_arrayFZ, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "realInverse", "([FZ)V"), __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static Delegate cb_realInverse_arrayarrayFZ;
#pragma warning disable 0169
		static Delegate GetRealInverse_arrayarrayFZHandler ()
		{
			if (cb_realInverse_arrayarrayFZ == null)
				cb_realInverse_arrayarrayFZ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, bool>) n_RealInverse_arrayarrayFZ);
			return cb_realInverse_arrayarrayFZ;
		}

		static void n_RealInverse_arrayarrayFZ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, bool p1)
		{
			global::Org.Jtransforms.Fft.FloatFFT_2D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.FloatFFT_2D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			float[][] p0 = (float[][]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (float[]));
			__this.RealInverse (p0, p1);
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
		}
#pragma warning restore 0169

		static IntPtr id_realInverse_arrayarrayFZ;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='FloatFFT_2D']/method[@name='realInverse' and count(parameter)=2 and parameter[1][@type='float[][]'] and parameter[2][@type='boolean']]"
		[Register ("realInverse", "([[FZ)V", "GetRealInverse_arrayarrayFZHandler")]
		public virtual unsafe void RealInverse (float[][] p0, bool p1)
		{
			if (id_realInverse_arrayarrayFZ == IntPtr.Zero)
				id_realInverse_arrayarrayFZ = JNIEnv.GetMethodID (class_ref, "realInverse", "([[FZ)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_realInverse_arrayarrayFZ, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "realInverse", "([[FZ)V"), __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static Delegate cb_realInverse_Lpl_edu_icm_jlargearrays_FloatLargeArray_Z;
#pragma warning disable 0169
		static Delegate GetRealInverse_Lpl_edu_icm_jlargearrays_FloatLargeArray_ZHandler ()
		{
			if (cb_realInverse_Lpl_edu_icm_jlargearrays_FloatLargeArray_Z == null)
				cb_realInverse_Lpl_edu_icm_jlargearrays_FloatLargeArray_Z = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, bool>) n_RealInverse_Lpl_edu_icm_jlargearrays_FloatLargeArray_Z);
			return cb_realInverse_Lpl_edu_icm_jlargearrays_FloatLargeArray_Z;
		}

		static void n_RealInverse_Lpl_edu_icm_jlargearrays_FloatLargeArray_Z (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, bool p1)
		{
			global::Org.Jtransforms.Fft.FloatFFT_2D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.FloatFFT_2D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p0 = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.FloatLargeArray> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.RealInverse (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_realInverse_Lpl_edu_icm_jlargearrays_FloatLargeArray_Z;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='FloatFFT_2D']/method[@name='realInverse' and count(parameter)=2 and parameter[1][@type='pl.edu.icm.jlargearrays.FloatLargeArray'] and parameter[2][@type='boolean']]"
		[Register ("realInverse", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;Z)V", "GetRealInverse_Lpl_edu_icm_jlargearrays_FloatLargeArray_ZHandler")]
		public virtual unsafe void RealInverse (global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p0, bool p1)
		{
			if (id_realInverse_Lpl_edu_icm_jlargearrays_FloatLargeArray_Z == IntPtr.Zero)
				id_realInverse_Lpl_edu_icm_jlargearrays_FloatLargeArray_Z = JNIEnv.GetMethodID (class_ref, "realInverse", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;Z)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_realInverse_Lpl_edu_icm_jlargearrays_FloatLargeArray_Z, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "realInverse", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;Z)V"), __args);
			} finally {
			}
		}

		static Delegate cb_realInverseFull_arrayFZ;
#pragma warning disable 0169
		static Delegate GetRealInverseFull_arrayFZHandler ()
		{
			if (cb_realInverseFull_arrayFZ == null)
				cb_realInverseFull_arrayFZ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, bool>) n_RealInverseFull_arrayFZ);
			return cb_realInverseFull_arrayFZ;
		}

		static void n_RealInverseFull_arrayFZ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, bool p1)
		{
			global::Org.Jtransforms.Fft.FloatFFT_2D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.FloatFFT_2D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			float[] p0 = (float[]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (float));
			__this.RealInverseFull (p0, p1);
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
		}
#pragma warning restore 0169

		static IntPtr id_realInverseFull_arrayFZ;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='FloatFFT_2D']/method[@name='realInverseFull' and count(parameter)=2 and parameter[1][@type='float[]'] and parameter[2][@type='boolean']]"
		[Register ("realInverseFull", "([FZ)V", "GetRealInverseFull_arrayFZHandler")]
		public virtual unsafe void RealInverseFull (float[] p0, bool p1)
		{
			if (id_realInverseFull_arrayFZ == IntPtr.Zero)
				id_realInverseFull_arrayFZ = JNIEnv.GetMethodID (class_ref, "realInverseFull", "([FZ)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_realInverseFull_arrayFZ, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "realInverseFull", "([FZ)V"), __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static Delegate cb_realInverseFull_arrayarrayFZ;
#pragma warning disable 0169
		static Delegate GetRealInverseFull_arrayarrayFZHandler ()
		{
			if (cb_realInverseFull_arrayarrayFZ == null)
				cb_realInverseFull_arrayarrayFZ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, bool>) n_RealInverseFull_arrayarrayFZ);
			return cb_realInverseFull_arrayarrayFZ;
		}

		static void n_RealInverseFull_arrayarrayFZ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, bool p1)
		{
			global::Org.Jtransforms.Fft.FloatFFT_2D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.FloatFFT_2D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			float[][] p0 = (float[][]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (float[]));
			__this.RealInverseFull (p0, p1);
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
		}
#pragma warning restore 0169

		static IntPtr id_realInverseFull_arrayarrayFZ;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='FloatFFT_2D']/method[@name='realInverseFull' and count(parameter)=2 and parameter[1][@type='float[][]'] and parameter[2][@type='boolean']]"
		[Register ("realInverseFull", "([[FZ)V", "GetRealInverseFull_arrayarrayFZHandler")]
		public virtual unsafe void RealInverseFull (float[][] p0, bool p1)
		{
			if (id_realInverseFull_arrayarrayFZ == IntPtr.Zero)
				id_realInverseFull_arrayarrayFZ = JNIEnv.GetMethodID (class_ref, "realInverseFull", "([[FZ)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_realInverseFull_arrayarrayFZ, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "realInverseFull", "([[FZ)V"), __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static Delegate cb_realInverseFull_Lpl_edu_icm_jlargearrays_FloatLargeArray_Z;
#pragma warning disable 0169
		static Delegate GetRealInverseFull_Lpl_edu_icm_jlargearrays_FloatLargeArray_ZHandler ()
		{
			if (cb_realInverseFull_Lpl_edu_icm_jlargearrays_FloatLargeArray_Z == null)
				cb_realInverseFull_Lpl_edu_icm_jlargearrays_FloatLargeArray_Z = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, bool>) n_RealInverseFull_Lpl_edu_icm_jlargearrays_FloatLargeArray_Z);
			return cb_realInverseFull_Lpl_edu_icm_jlargearrays_FloatLargeArray_Z;
		}

		static void n_RealInverseFull_Lpl_edu_icm_jlargearrays_FloatLargeArray_Z (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, bool p1)
		{
			global::Org.Jtransforms.Fft.FloatFFT_2D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.FloatFFT_2D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p0 = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.FloatLargeArray> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.RealInverseFull (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_realInverseFull_Lpl_edu_icm_jlargearrays_FloatLargeArray_Z;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='FloatFFT_2D']/method[@name='realInverseFull' and count(parameter)=2 and parameter[1][@type='pl.edu.icm.jlargearrays.FloatLargeArray'] and parameter[2][@type='boolean']]"
		[Register ("realInverseFull", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;Z)V", "GetRealInverseFull_Lpl_edu_icm_jlargearrays_FloatLargeArray_ZHandler")]
		public virtual unsafe void RealInverseFull (global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p0, bool p1)
		{
			if (id_realInverseFull_Lpl_edu_icm_jlargearrays_FloatLargeArray_Z == IntPtr.Zero)
				id_realInverseFull_Lpl_edu_icm_jlargearrays_FloatLargeArray_Z = JNIEnv.GetMethodID (class_ref, "realInverseFull", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;Z)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_realInverseFull_Lpl_edu_icm_jlargearrays_FloatLargeArray_Z, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "realInverseFull", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;Z)V"), __args);
			} finally {
			}
		}

	}
}
