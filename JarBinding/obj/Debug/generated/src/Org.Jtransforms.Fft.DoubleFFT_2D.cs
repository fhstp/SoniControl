using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Org.Jtransforms.Fft {

	// Metadata.xml XPath class reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='DoubleFFT_2D']"
	[global::Android.Runtime.Register ("org/jtransforms/fft/DoubleFFT_2D", DoNotGenerateAcw=true)]
	public partial class DoubleFFT_2D : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("org/jtransforms/fft/DoubleFFT_2D", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (DoubleFFT_2D); }
		}

		protected DoubleFFT_2D (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor_JJ;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='DoubleFFT_2D']/constructor[@name='DoubleFFT_2D' and count(parameter)=2 and parameter[1][@type='long'] and parameter[2][@type='long']]"
		[Register (".ctor", "(JJ)V", "")]
		public unsafe DoubleFFT_2D (long p0, long p1)
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				if (((object) this).GetType () != typeof (DoubleFFT_2D)) {
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

		static Delegate cb_complexForward_arrayD;
#pragma warning disable 0169
		static Delegate GetComplexForward_arrayDHandler ()
		{
			if (cb_complexForward_arrayD == null)
				cb_complexForward_arrayD = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_ComplexForward_arrayD);
			return cb_complexForward_arrayD;
		}

		static void n_ComplexForward_arrayD (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Org.Jtransforms.Fft.DoubleFFT_2D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.DoubleFFT_2D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			double[] p0 = (double[]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (double));
			__this.ComplexForward (p0);
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
		}
#pragma warning restore 0169

		static IntPtr id_complexForward_arrayD;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='DoubleFFT_2D']/method[@name='complexForward' and count(parameter)=1 and parameter[1][@type='double[]']]"
		[Register ("complexForward", "([D)V", "GetComplexForward_arrayDHandler")]
		public virtual unsafe void ComplexForward (double[] p0)
		{
			if (id_complexForward_arrayD == IntPtr.Zero)
				id_complexForward_arrayD = JNIEnv.GetMethodID (class_ref, "complexForward", "([D)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_complexForward_arrayD, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "complexForward", "([D)V"), __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static Delegate cb_complexForward_arrayarrayD;
#pragma warning disable 0169
		static Delegate GetComplexForward_arrayarrayDHandler ()
		{
			if (cb_complexForward_arrayarrayD == null)
				cb_complexForward_arrayarrayD = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_ComplexForward_arrayarrayD);
			return cb_complexForward_arrayarrayD;
		}

		static void n_ComplexForward_arrayarrayD (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Org.Jtransforms.Fft.DoubleFFT_2D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.DoubleFFT_2D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			double[][] p0 = (double[][]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (double[]));
			__this.ComplexForward (p0);
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
		}
#pragma warning restore 0169

		static IntPtr id_complexForward_arrayarrayD;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='DoubleFFT_2D']/method[@name='complexForward' and count(parameter)=1 and parameter[1][@type='double[][]']]"
		[Register ("complexForward", "([[D)V", "GetComplexForward_arrayarrayDHandler")]
		public virtual unsafe void ComplexForward (double[][] p0)
		{
			if (id_complexForward_arrayarrayD == IntPtr.Zero)
				id_complexForward_arrayarrayD = JNIEnv.GetMethodID (class_ref, "complexForward", "([[D)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_complexForward_arrayarrayD, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "complexForward", "([[D)V"), __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static Delegate cb_complexForward_Lpl_edu_icm_jlargearrays_DoubleLargeArray_;
#pragma warning disable 0169
		static Delegate GetComplexForward_Lpl_edu_icm_jlargearrays_DoubleLargeArray_Handler ()
		{
			if (cb_complexForward_Lpl_edu_icm_jlargearrays_DoubleLargeArray_ == null)
				cb_complexForward_Lpl_edu_icm_jlargearrays_DoubleLargeArray_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_ComplexForward_Lpl_edu_icm_jlargearrays_DoubleLargeArray_);
			return cb_complexForward_Lpl_edu_icm_jlargearrays_DoubleLargeArray_;
		}

		static void n_ComplexForward_Lpl_edu_icm_jlargearrays_DoubleLargeArray_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Org.Jtransforms.Fft.DoubleFFT_2D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.DoubleFFT_2D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p0 = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.ComplexForward (p0);
		}
#pragma warning restore 0169

		static IntPtr id_complexForward_Lpl_edu_icm_jlargearrays_DoubleLargeArray_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='DoubleFFT_2D']/method[@name='complexForward' and count(parameter)=1 and parameter[1][@type='pl.edu.icm.jlargearrays.DoubleLargeArray']]"
		[Register ("complexForward", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;)V", "GetComplexForward_Lpl_edu_icm_jlargearrays_DoubleLargeArray_Handler")]
		public virtual unsafe void ComplexForward (global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p0)
		{
			if (id_complexForward_Lpl_edu_icm_jlargearrays_DoubleLargeArray_ == IntPtr.Zero)
				id_complexForward_Lpl_edu_icm_jlargearrays_DoubleLargeArray_ = JNIEnv.GetMethodID (class_ref, "complexForward", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_complexForward_Lpl_edu_icm_jlargearrays_DoubleLargeArray_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "complexForward", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;)V"), __args);
			} finally {
			}
		}

		static Delegate cb_complexInverse_arrayDZ;
#pragma warning disable 0169
		static Delegate GetComplexInverse_arrayDZHandler ()
		{
			if (cb_complexInverse_arrayDZ == null)
				cb_complexInverse_arrayDZ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, bool>) n_ComplexInverse_arrayDZ);
			return cb_complexInverse_arrayDZ;
		}

		static void n_ComplexInverse_arrayDZ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, bool p1)
		{
			global::Org.Jtransforms.Fft.DoubleFFT_2D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.DoubleFFT_2D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			double[] p0 = (double[]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (double));
			__this.ComplexInverse (p0, p1);
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
		}
#pragma warning restore 0169

		static IntPtr id_complexInverse_arrayDZ;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='DoubleFFT_2D']/method[@name='complexInverse' and count(parameter)=2 and parameter[1][@type='double[]'] and parameter[2][@type='boolean']]"
		[Register ("complexInverse", "([DZ)V", "GetComplexInverse_arrayDZHandler")]
		public virtual unsafe void ComplexInverse (double[] p0, bool p1)
		{
			if (id_complexInverse_arrayDZ == IntPtr.Zero)
				id_complexInverse_arrayDZ = JNIEnv.GetMethodID (class_ref, "complexInverse", "([DZ)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_complexInverse_arrayDZ, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "complexInverse", "([DZ)V"), __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static Delegate cb_complexInverse_arrayarrayDZ;
#pragma warning disable 0169
		static Delegate GetComplexInverse_arrayarrayDZHandler ()
		{
			if (cb_complexInverse_arrayarrayDZ == null)
				cb_complexInverse_arrayarrayDZ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, bool>) n_ComplexInverse_arrayarrayDZ);
			return cb_complexInverse_arrayarrayDZ;
		}

		static void n_ComplexInverse_arrayarrayDZ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, bool p1)
		{
			global::Org.Jtransforms.Fft.DoubleFFT_2D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.DoubleFFT_2D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			double[][] p0 = (double[][]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (double[]));
			__this.ComplexInverse (p0, p1);
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
		}
#pragma warning restore 0169

		static IntPtr id_complexInverse_arrayarrayDZ;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='DoubleFFT_2D']/method[@name='complexInverse' and count(parameter)=2 and parameter[1][@type='double[][]'] and parameter[2][@type='boolean']]"
		[Register ("complexInverse", "([[DZ)V", "GetComplexInverse_arrayarrayDZHandler")]
		public virtual unsafe void ComplexInverse (double[][] p0, bool p1)
		{
			if (id_complexInverse_arrayarrayDZ == IntPtr.Zero)
				id_complexInverse_arrayarrayDZ = JNIEnv.GetMethodID (class_ref, "complexInverse", "([[DZ)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_complexInverse_arrayarrayDZ, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "complexInverse", "([[DZ)V"), __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static Delegate cb_complexInverse_Lpl_edu_icm_jlargearrays_DoubleLargeArray_Z;
#pragma warning disable 0169
		static Delegate GetComplexInverse_Lpl_edu_icm_jlargearrays_DoubleLargeArray_ZHandler ()
		{
			if (cb_complexInverse_Lpl_edu_icm_jlargearrays_DoubleLargeArray_Z == null)
				cb_complexInverse_Lpl_edu_icm_jlargearrays_DoubleLargeArray_Z = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, bool>) n_ComplexInverse_Lpl_edu_icm_jlargearrays_DoubleLargeArray_Z);
			return cb_complexInverse_Lpl_edu_icm_jlargearrays_DoubleLargeArray_Z;
		}

		static void n_ComplexInverse_Lpl_edu_icm_jlargearrays_DoubleLargeArray_Z (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, bool p1)
		{
			global::Org.Jtransforms.Fft.DoubleFFT_2D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.DoubleFFT_2D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p0 = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.ComplexInverse (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_complexInverse_Lpl_edu_icm_jlargearrays_DoubleLargeArray_Z;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='DoubleFFT_2D']/method[@name='complexInverse' and count(parameter)=2 and parameter[1][@type='pl.edu.icm.jlargearrays.DoubleLargeArray'] and parameter[2][@type='boolean']]"
		[Register ("complexInverse", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;Z)V", "GetComplexInverse_Lpl_edu_icm_jlargearrays_DoubleLargeArray_ZHandler")]
		public virtual unsafe void ComplexInverse (global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p0, bool p1)
		{
			if (id_complexInverse_Lpl_edu_icm_jlargearrays_DoubleLargeArray_Z == IntPtr.Zero)
				id_complexInverse_Lpl_edu_icm_jlargearrays_DoubleLargeArray_Z = JNIEnv.GetMethodID (class_ref, "complexInverse", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;Z)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_complexInverse_Lpl_edu_icm_jlargearrays_DoubleLargeArray_Z, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "complexInverse", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;Z)V"), __args);
			} finally {
			}
		}

		static Delegate cb_realForward_arrayD;
#pragma warning disable 0169
		static Delegate GetRealForward_arrayDHandler ()
		{
			if (cb_realForward_arrayD == null)
				cb_realForward_arrayD = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_RealForward_arrayD);
			return cb_realForward_arrayD;
		}

		static void n_RealForward_arrayD (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Org.Jtransforms.Fft.DoubleFFT_2D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.DoubleFFT_2D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			double[] p0 = (double[]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (double));
			__this.RealForward (p0);
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
		}
#pragma warning restore 0169

		static IntPtr id_realForward_arrayD;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='DoubleFFT_2D']/method[@name='realForward' and count(parameter)=1 and parameter[1][@type='double[]']]"
		[Register ("realForward", "([D)V", "GetRealForward_arrayDHandler")]
		public virtual unsafe void RealForward (double[] p0)
		{
			if (id_realForward_arrayD == IntPtr.Zero)
				id_realForward_arrayD = JNIEnv.GetMethodID (class_ref, "realForward", "([D)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_realForward_arrayD, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "realForward", "([D)V"), __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static Delegate cb_realForward_arrayarrayD;
#pragma warning disable 0169
		static Delegate GetRealForward_arrayarrayDHandler ()
		{
			if (cb_realForward_arrayarrayD == null)
				cb_realForward_arrayarrayD = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_RealForward_arrayarrayD);
			return cb_realForward_arrayarrayD;
		}

		static void n_RealForward_arrayarrayD (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Org.Jtransforms.Fft.DoubleFFT_2D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.DoubleFFT_2D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			double[][] p0 = (double[][]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (double[]));
			__this.RealForward (p0);
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
		}
#pragma warning restore 0169

		static IntPtr id_realForward_arrayarrayD;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='DoubleFFT_2D']/method[@name='realForward' and count(parameter)=1 and parameter[1][@type='double[][]']]"
		[Register ("realForward", "([[D)V", "GetRealForward_arrayarrayDHandler")]
		public virtual unsafe void RealForward (double[][] p0)
		{
			if (id_realForward_arrayarrayD == IntPtr.Zero)
				id_realForward_arrayarrayD = JNIEnv.GetMethodID (class_ref, "realForward", "([[D)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_realForward_arrayarrayD, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "realForward", "([[D)V"), __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static Delegate cb_realForward_Lpl_edu_icm_jlargearrays_DoubleLargeArray_;
#pragma warning disable 0169
		static Delegate GetRealForward_Lpl_edu_icm_jlargearrays_DoubleLargeArray_Handler ()
		{
			if (cb_realForward_Lpl_edu_icm_jlargearrays_DoubleLargeArray_ == null)
				cb_realForward_Lpl_edu_icm_jlargearrays_DoubleLargeArray_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_RealForward_Lpl_edu_icm_jlargearrays_DoubleLargeArray_);
			return cb_realForward_Lpl_edu_icm_jlargearrays_DoubleLargeArray_;
		}

		static void n_RealForward_Lpl_edu_icm_jlargearrays_DoubleLargeArray_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Org.Jtransforms.Fft.DoubleFFT_2D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.DoubleFFT_2D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p0 = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.RealForward (p0);
		}
#pragma warning restore 0169

		static IntPtr id_realForward_Lpl_edu_icm_jlargearrays_DoubleLargeArray_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='DoubleFFT_2D']/method[@name='realForward' and count(parameter)=1 and parameter[1][@type='pl.edu.icm.jlargearrays.DoubleLargeArray']]"
		[Register ("realForward", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;)V", "GetRealForward_Lpl_edu_icm_jlargearrays_DoubleLargeArray_Handler")]
		public virtual unsafe void RealForward (global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p0)
		{
			if (id_realForward_Lpl_edu_icm_jlargearrays_DoubleLargeArray_ == IntPtr.Zero)
				id_realForward_Lpl_edu_icm_jlargearrays_DoubleLargeArray_ = JNIEnv.GetMethodID (class_ref, "realForward", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_realForward_Lpl_edu_icm_jlargearrays_DoubleLargeArray_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "realForward", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;)V"), __args);
			} finally {
			}
		}

		static Delegate cb_realForwardFull_arrayD;
#pragma warning disable 0169
		static Delegate GetRealForwardFull_arrayDHandler ()
		{
			if (cb_realForwardFull_arrayD == null)
				cb_realForwardFull_arrayD = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_RealForwardFull_arrayD);
			return cb_realForwardFull_arrayD;
		}

		static void n_RealForwardFull_arrayD (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Org.Jtransforms.Fft.DoubleFFT_2D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.DoubleFFT_2D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			double[] p0 = (double[]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (double));
			__this.RealForwardFull (p0);
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
		}
#pragma warning restore 0169

		static IntPtr id_realForwardFull_arrayD;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='DoubleFFT_2D']/method[@name='realForwardFull' and count(parameter)=1 and parameter[1][@type='double[]']]"
		[Register ("realForwardFull", "([D)V", "GetRealForwardFull_arrayDHandler")]
		public virtual unsafe void RealForwardFull (double[] p0)
		{
			if (id_realForwardFull_arrayD == IntPtr.Zero)
				id_realForwardFull_arrayD = JNIEnv.GetMethodID (class_ref, "realForwardFull", "([D)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_realForwardFull_arrayD, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "realForwardFull", "([D)V"), __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static Delegate cb_realForwardFull_arrayarrayD;
#pragma warning disable 0169
		static Delegate GetRealForwardFull_arrayarrayDHandler ()
		{
			if (cb_realForwardFull_arrayarrayD == null)
				cb_realForwardFull_arrayarrayD = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_RealForwardFull_arrayarrayD);
			return cb_realForwardFull_arrayarrayD;
		}

		static void n_RealForwardFull_arrayarrayD (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Org.Jtransforms.Fft.DoubleFFT_2D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.DoubleFFT_2D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			double[][] p0 = (double[][]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (double[]));
			__this.RealForwardFull (p0);
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
		}
#pragma warning restore 0169

		static IntPtr id_realForwardFull_arrayarrayD;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='DoubleFFT_2D']/method[@name='realForwardFull' and count(parameter)=1 and parameter[1][@type='double[][]']]"
		[Register ("realForwardFull", "([[D)V", "GetRealForwardFull_arrayarrayDHandler")]
		public virtual unsafe void RealForwardFull (double[][] p0)
		{
			if (id_realForwardFull_arrayarrayD == IntPtr.Zero)
				id_realForwardFull_arrayarrayD = JNIEnv.GetMethodID (class_ref, "realForwardFull", "([[D)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_realForwardFull_arrayarrayD, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "realForwardFull", "([[D)V"), __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static Delegate cb_realForwardFull_Lpl_edu_icm_jlargearrays_DoubleLargeArray_;
#pragma warning disable 0169
		static Delegate GetRealForwardFull_Lpl_edu_icm_jlargearrays_DoubleLargeArray_Handler ()
		{
			if (cb_realForwardFull_Lpl_edu_icm_jlargearrays_DoubleLargeArray_ == null)
				cb_realForwardFull_Lpl_edu_icm_jlargearrays_DoubleLargeArray_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_RealForwardFull_Lpl_edu_icm_jlargearrays_DoubleLargeArray_);
			return cb_realForwardFull_Lpl_edu_icm_jlargearrays_DoubleLargeArray_;
		}

		static void n_RealForwardFull_Lpl_edu_icm_jlargearrays_DoubleLargeArray_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Org.Jtransforms.Fft.DoubleFFT_2D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.DoubleFFT_2D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p0 = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.RealForwardFull (p0);
		}
#pragma warning restore 0169

		static IntPtr id_realForwardFull_Lpl_edu_icm_jlargearrays_DoubleLargeArray_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='DoubleFFT_2D']/method[@name='realForwardFull' and count(parameter)=1 and parameter[1][@type='pl.edu.icm.jlargearrays.DoubleLargeArray']]"
		[Register ("realForwardFull", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;)V", "GetRealForwardFull_Lpl_edu_icm_jlargearrays_DoubleLargeArray_Handler")]
		public virtual unsafe void RealForwardFull (global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p0)
		{
			if (id_realForwardFull_Lpl_edu_icm_jlargearrays_DoubleLargeArray_ == IntPtr.Zero)
				id_realForwardFull_Lpl_edu_icm_jlargearrays_DoubleLargeArray_ = JNIEnv.GetMethodID (class_ref, "realForwardFull", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_realForwardFull_Lpl_edu_icm_jlargearrays_DoubleLargeArray_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "realForwardFull", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;)V"), __args);
			} finally {
			}
		}

		static Delegate cb_realInverse_arrayDZ;
#pragma warning disable 0169
		static Delegate GetRealInverse_arrayDZHandler ()
		{
			if (cb_realInverse_arrayDZ == null)
				cb_realInverse_arrayDZ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, bool>) n_RealInverse_arrayDZ);
			return cb_realInverse_arrayDZ;
		}

		static void n_RealInverse_arrayDZ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, bool p1)
		{
			global::Org.Jtransforms.Fft.DoubleFFT_2D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.DoubleFFT_2D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			double[] p0 = (double[]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (double));
			__this.RealInverse (p0, p1);
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
		}
#pragma warning restore 0169

		static IntPtr id_realInverse_arrayDZ;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='DoubleFFT_2D']/method[@name='realInverse' and count(parameter)=2 and parameter[1][@type='double[]'] and parameter[2][@type='boolean']]"
		[Register ("realInverse", "([DZ)V", "GetRealInverse_arrayDZHandler")]
		public virtual unsafe void RealInverse (double[] p0, bool p1)
		{
			if (id_realInverse_arrayDZ == IntPtr.Zero)
				id_realInverse_arrayDZ = JNIEnv.GetMethodID (class_ref, "realInverse", "([DZ)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_realInverse_arrayDZ, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "realInverse", "([DZ)V"), __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static Delegate cb_realInverse_arrayarrayDZ;
#pragma warning disable 0169
		static Delegate GetRealInverse_arrayarrayDZHandler ()
		{
			if (cb_realInverse_arrayarrayDZ == null)
				cb_realInverse_arrayarrayDZ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, bool>) n_RealInverse_arrayarrayDZ);
			return cb_realInverse_arrayarrayDZ;
		}

		static void n_RealInverse_arrayarrayDZ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, bool p1)
		{
			global::Org.Jtransforms.Fft.DoubleFFT_2D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.DoubleFFT_2D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			double[][] p0 = (double[][]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (double[]));
			__this.RealInverse (p0, p1);
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
		}
#pragma warning restore 0169

		static IntPtr id_realInverse_arrayarrayDZ;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='DoubleFFT_2D']/method[@name='realInverse' and count(parameter)=2 and parameter[1][@type='double[][]'] and parameter[2][@type='boolean']]"
		[Register ("realInverse", "([[DZ)V", "GetRealInverse_arrayarrayDZHandler")]
		public virtual unsafe void RealInverse (double[][] p0, bool p1)
		{
			if (id_realInverse_arrayarrayDZ == IntPtr.Zero)
				id_realInverse_arrayarrayDZ = JNIEnv.GetMethodID (class_ref, "realInverse", "([[DZ)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_realInverse_arrayarrayDZ, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "realInverse", "([[DZ)V"), __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static Delegate cb_realInverse_Lpl_edu_icm_jlargearrays_DoubleLargeArray_Z;
#pragma warning disable 0169
		static Delegate GetRealInverse_Lpl_edu_icm_jlargearrays_DoubleLargeArray_ZHandler ()
		{
			if (cb_realInverse_Lpl_edu_icm_jlargearrays_DoubleLargeArray_Z == null)
				cb_realInverse_Lpl_edu_icm_jlargearrays_DoubleLargeArray_Z = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, bool>) n_RealInverse_Lpl_edu_icm_jlargearrays_DoubleLargeArray_Z);
			return cb_realInverse_Lpl_edu_icm_jlargearrays_DoubleLargeArray_Z;
		}

		static void n_RealInverse_Lpl_edu_icm_jlargearrays_DoubleLargeArray_Z (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, bool p1)
		{
			global::Org.Jtransforms.Fft.DoubleFFT_2D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.DoubleFFT_2D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p0 = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.RealInverse (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_realInverse_Lpl_edu_icm_jlargearrays_DoubleLargeArray_Z;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='DoubleFFT_2D']/method[@name='realInverse' and count(parameter)=2 and parameter[1][@type='pl.edu.icm.jlargearrays.DoubleLargeArray'] and parameter[2][@type='boolean']]"
		[Register ("realInverse", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;Z)V", "GetRealInverse_Lpl_edu_icm_jlargearrays_DoubleLargeArray_ZHandler")]
		public virtual unsafe void RealInverse (global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p0, bool p1)
		{
			if (id_realInverse_Lpl_edu_icm_jlargearrays_DoubleLargeArray_Z == IntPtr.Zero)
				id_realInverse_Lpl_edu_icm_jlargearrays_DoubleLargeArray_Z = JNIEnv.GetMethodID (class_ref, "realInverse", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;Z)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_realInverse_Lpl_edu_icm_jlargearrays_DoubleLargeArray_Z, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "realInverse", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;Z)V"), __args);
			} finally {
			}
		}

		static Delegate cb_realInverseFull_arrayDZ;
#pragma warning disable 0169
		static Delegate GetRealInverseFull_arrayDZHandler ()
		{
			if (cb_realInverseFull_arrayDZ == null)
				cb_realInverseFull_arrayDZ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, bool>) n_RealInverseFull_arrayDZ);
			return cb_realInverseFull_arrayDZ;
		}

		static void n_RealInverseFull_arrayDZ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, bool p1)
		{
			global::Org.Jtransforms.Fft.DoubleFFT_2D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.DoubleFFT_2D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			double[] p0 = (double[]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (double));
			__this.RealInverseFull (p0, p1);
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
		}
#pragma warning restore 0169

		static IntPtr id_realInverseFull_arrayDZ;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='DoubleFFT_2D']/method[@name='realInverseFull' and count(parameter)=2 and parameter[1][@type='double[]'] and parameter[2][@type='boolean']]"
		[Register ("realInverseFull", "([DZ)V", "GetRealInverseFull_arrayDZHandler")]
		public virtual unsafe void RealInverseFull (double[] p0, bool p1)
		{
			if (id_realInverseFull_arrayDZ == IntPtr.Zero)
				id_realInverseFull_arrayDZ = JNIEnv.GetMethodID (class_ref, "realInverseFull", "([DZ)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_realInverseFull_arrayDZ, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "realInverseFull", "([DZ)V"), __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static Delegate cb_realInverseFull_arrayarrayDZ;
#pragma warning disable 0169
		static Delegate GetRealInverseFull_arrayarrayDZHandler ()
		{
			if (cb_realInverseFull_arrayarrayDZ == null)
				cb_realInverseFull_arrayarrayDZ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, bool>) n_RealInverseFull_arrayarrayDZ);
			return cb_realInverseFull_arrayarrayDZ;
		}

		static void n_RealInverseFull_arrayarrayDZ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, bool p1)
		{
			global::Org.Jtransforms.Fft.DoubleFFT_2D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.DoubleFFT_2D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			double[][] p0 = (double[][]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (double[]));
			__this.RealInverseFull (p0, p1);
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
		}
#pragma warning restore 0169

		static IntPtr id_realInverseFull_arrayarrayDZ;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='DoubleFFT_2D']/method[@name='realInverseFull' and count(parameter)=2 and parameter[1][@type='double[][]'] and parameter[2][@type='boolean']]"
		[Register ("realInverseFull", "([[DZ)V", "GetRealInverseFull_arrayarrayDZHandler")]
		public virtual unsafe void RealInverseFull (double[][] p0, bool p1)
		{
			if (id_realInverseFull_arrayarrayDZ == IntPtr.Zero)
				id_realInverseFull_arrayarrayDZ = JNIEnv.GetMethodID (class_ref, "realInverseFull", "([[DZ)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_realInverseFull_arrayarrayDZ, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "realInverseFull", "([[DZ)V"), __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static Delegate cb_realInverseFull_Lpl_edu_icm_jlargearrays_DoubleLargeArray_Z;
#pragma warning disable 0169
		static Delegate GetRealInverseFull_Lpl_edu_icm_jlargearrays_DoubleLargeArray_ZHandler ()
		{
			if (cb_realInverseFull_Lpl_edu_icm_jlargearrays_DoubleLargeArray_Z == null)
				cb_realInverseFull_Lpl_edu_icm_jlargearrays_DoubleLargeArray_Z = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, bool>) n_RealInverseFull_Lpl_edu_icm_jlargearrays_DoubleLargeArray_Z);
			return cb_realInverseFull_Lpl_edu_icm_jlargearrays_DoubleLargeArray_Z;
		}

		static void n_RealInverseFull_Lpl_edu_icm_jlargearrays_DoubleLargeArray_Z (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, bool p1)
		{
			global::Org.Jtransforms.Fft.DoubleFFT_2D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.DoubleFFT_2D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p0 = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.RealInverseFull (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_realInverseFull_Lpl_edu_icm_jlargearrays_DoubleLargeArray_Z;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='DoubleFFT_2D']/method[@name='realInverseFull' and count(parameter)=2 and parameter[1][@type='pl.edu.icm.jlargearrays.DoubleLargeArray'] and parameter[2][@type='boolean']]"
		[Register ("realInverseFull", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;Z)V", "GetRealInverseFull_Lpl_edu_icm_jlargearrays_DoubleLargeArray_ZHandler")]
		public virtual unsafe void RealInverseFull (global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p0, bool p1)
		{
			if (id_realInverseFull_Lpl_edu_icm_jlargearrays_DoubleLargeArray_Z == IntPtr.Zero)
				id_realInverseFull_Lpl_edu_icm_jlargearrays_DoubleLargeArray_Z = JNIEnv.GetMethodID (class_ref, "realInverseFull", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;Z)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_realInverseFull_Lpl_edu_icm_jlargearrays_DoubleLargeArray_Z, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "realInverseFull", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;Z)V"), __args);
			} finally {
			}
		}

	}
}
