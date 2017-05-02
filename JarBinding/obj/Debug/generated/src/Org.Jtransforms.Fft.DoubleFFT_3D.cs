using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Org.Jtransforms.Fft {

	// Metadata.xml XPath class reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='DoubleFFT_3D']"
	[global::Android.Runtime.Register ("org/jtransforms/fft/DoubleFFT_3D", DoNotGenerateAcw=true)]
	public partial class DoubleFFT_3D : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("org/jtransforms/fft/DoubleFFT_3D", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (DoubleFFT_3D); }
		}

		protected DoubleFFT_3D (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor_JJJ;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='DoubleFFT_3D']/constructor[@name='DoubleFFT_3D' and count(parameter)=3 and parameter[1][@type='long'] and parameter[2][@type='long'] and parameter[3][@type='long']]"
		[Register (".ctor", "(JJJ)V", "")]
		public unsafe DoubleFFT_3D (long p0, long p1, long p2)
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				if (((object) this).GetType () != typeof (DoubleFFT_3D)) {
					SetHandle (
							global::Android.Runtime.JNIEnv.StartCreateInstance (((object) this).GetType (), "(JJJ)V", __args),
							JniHandleOwnership.TransferLocalRef);
					global::Android.Runtime.JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, "(JJJ)V", __args);
					return;
				}

				if (id_ctor_JJJ == IntPtr.Zero)
					id_ctor_JJJ = JNIEnv.GetMethodID (class_ref, "<init>", "(JJJ)V");
				SetHandle (
						global::Android.Runtime.JNIEnv.StartCreateInstance (class_ref, id_ctor_JJJ, __args),
						JniHandleOwnership.TransferLocalRef);
				JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, class_ref, id_ctor_JJJ, __args);
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
			global::Org.Jtransforms.Fft.DoubleFFT_3D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.DoubleFFT_3D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			double[] p0 = (double[]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (double));
			__this.ComplexForward (p0);
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
		}
#pragma warning restore 0169

		static IntPtr id_complexForward_arrayD;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='DoubleFFT_3D']/method[@name='complexForward' and count(parameter)=1 and parameter[1][@type='double[]']]"
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

		static Delegate cb_complexForward_arrayarrayarrayD;
#pragma warning disable 0169
		static Delegate GetComplexForward_arrayarrayarrayDHandler ()
		{
			if (cb_complexForward_arrayarrayarrayD == null)
				cb_complexForward_arrayarrayarrayD = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_ComplexForward_arrayarrayarrayD);
			return cb_complexForward_arrayarrayarrayD;
		}

		static void n_ComplexForward_arrayarrayarrayD (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Org.Jtransforms.Fft.DoubleFFT_3D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.DoubleFFT_3D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			double[][][] p0 = (double[][][]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (double[][]));
			__this.ComplexForward (p0);
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
		}
#pragma warning restore 0169

		static IntPtr id_complexForward_arrayarrayarrayD;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='DoubleFFT_3D']/method[@name='complexForward' and count(parameter)=1 and parameter[1][@type='double[][][]']]"
		[Register ("complexForward", "([[[D)V", "GetComplexForward_arrayarrayarrayDHandler")]
		public virtual unsafe void ComplexForward (double[][][] p0)
		{
			if (id_complexForward_arrayarrayarrayD == IntPtr.Zero)
				id_complexForward_arrayarrayarrayD = JNIEnv.GetMethodID (class_ref, "complexForward", "([[[D)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_complexForward_arrayarrayarrayD, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "complexForward", "([[[D)V"), __args);
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
			global::Org.Jtransforms.Fft.DoubleFFT_3D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.DoubleFFT_3D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p0 = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.ComplexForward (p0);
		}
#pragma warning restore 0169

		static IntPtr id_complexForward_Lpl_edu_icm_jlargearrays_DoubleLargeArray_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='DoubleFFT_3D']/method[@name='complexForward' and count(parameter)=1 and parameter[1][@type='pl.edu.icm.jlargearrays.DoubleLargeArray']]"
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
			global::Org.Jtransforms.Fft.DoubleFFT_3D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.DoubleFFT_3D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			double[] p0 = (double[]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (double));
			__this.ComplexInverse (p0, p1);
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
		}
#pragma warning restore 0169

		static IntPtr id_complexInverse_arrayDZ;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='DoubleFFT_3D']/method[@name='complexInverse' and count(parameter)=2 and parameter[1][@type='double[]'] and parameter[2][@type='boolean']]"
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

		static Delegate cb_complexInverse_arrayarrayarrayDZ;
#pragma warning disable 0169
		static Delegate GetComplexInverse_arrayarrayarrayDZHandler ()
		{
			if (cb_complexInverse_arrayarrayarrayDZ == null)
				cb_complexInverse_arrayarrayarrayDZ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, bool>) n_ComplexInverse_arrayarrayarrayDZ);
			return cb_complexInverse_arrayarrayarrayDZ;
		}

		static void n_ComplexInverse_arrayarrayarrayDZ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, bool p1)
		{
			global::Org.Jtransforms.Fft.DoubleFFT_3D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.DoubleFFT_3D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			double[][][] p0 = (double[][][]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (double[][]));
			__this.ComplexInverse (p0, p1);
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
		}
#pragma warning restore 0169

		static IntPtr id_complexInverse_arrayarrayarrayDZ;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='DoubleFFT_3D']/method[@name='complexInverse' and count(parameter)=2 and parameter[1][@type='double[][][]'] and parameter[2][@type='boolean']]"
		[Register ("complexInverse", "([[[DZ)V", "GetComplexInverse_arrayarrayarrayDZHandler")]
		public virtual unsafe void ComplexInverse (double[][][] p0, bool p1)
		{
			if (id_complexInverse_arrayarrayarrayDZ == IntPtr.Zero)
				id_complexInverse_arrayarrayarrayDZ = JNIEnv.GetMethodID (class_ref, "complexInverse", "([[[DZ)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_complexInverse_arrayarrayarrayDZ, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "complexInverse", "([[[DZ)V"), __args);
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
			global::Org.Jtransforms.Fft.DoubleFFT_3D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.DoubleFFT_3D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p0 = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.ComplexInverse (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_complexInverse_Lpl_edu_icm_jlargearrays_DoubleLargeArray_Z;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='DoubleFFT_3D']/method[@name='complexInverse' and count(parameter)=2 and parameter[1][@type='pl.edu.icm.jlargearrays.DoubleLargeArray'] and parameter[2][@type='boolean']]"
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
			global::Org.Jtransforms.Fft.DoubleFFT_3D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.DoubleFFT_3D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			double[] p0 = (double[]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (double));
			__this.RealForward (p0);
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
		}
#pragma warning restore 0169

		static IntPtr id_realForward_arrayD;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='DoubleFFT_3D']/method[@name='realForward' and count(parameter)=1 and parameter[1][@type='double[]']]"
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

		static Delegate cb_realForward_arrayarrayarrayD;
#pragma warning disable 0169
		static Delegate GetRealForward_arrayarrayarrayDHandler ()
		{
			if (cb_realForward_arrayarrayarrayD == null)
				cb_realForward_arrayarrayarrayD = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_RealForward_arrayarrayarrayD);
			return cb_realForward_arrayarrayarrayD;
		}

		static void n_RealForward_arrayarrayarrayD (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Org.Jtransforms.Fft.DoubleFFT_3D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.DoubleFFT_3D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			double[][][] p0 = (double[][][]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (double[][]));
			__this.RealForward (p0);
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
		}
#pragma warning restore 0169

		static IntPtr id_realForward_arrayarrayarrayD;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='DoubleFFT_3D']/method[@name='realForward' and count(parameter)=1 and parameter[1][@type='double[][][]']]"
		[Register ("realForward", "([[[D)V", "GetRealForward_arrayarrayarrayDHandler")]
		public virtual unsafe void RealForward (double[][][] p0)
		{
			if (id_realForward_arrayarrayarrayD == IntPtr.Zero)
				id_realForward_arrayarrayarrayD = JNIEnv.GetMethodID (class_ref, "realForward", "([[[D)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_realForward_arrayarrayarrayD, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "realForward", "([[[D)V"), __args);
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
			global::Org.Jtransforms.Fft.DoubleFFT_3D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.DoubleFFT_3D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p0 = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.RealForward (p0);
		}
#pragma warning restore 0169

		static IntPtr id_realForward_Lpl_edu_icm_jlargearrays_DoubleLargeArray_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='DoubleFFT_3D']/method[@name='realForward' and count(parameter)=1 and parameter[1][@type='pl.edu.icm.jlargearrays.DoubleLargeArray']]"
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
			global::Org.Jtransforms.Fft.DoubleFFT_3D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.DoubleFFT_3D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			double[] p0 = (double[]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (double));
			__this.RealForwardFull (p0);
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
		}
#pragma warning restore 0169

		static IntPtr id_realForwardFull_arrayD;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='DoubleFFT_3D']/method[@name='realForwardFull' and count(parameter)=1 and parameter[1][@type='double[]']]"
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

		static Delegate cb_realForwardFull_arrayarrayarrayD;
#pragma warning disable 0169
		static Delegate GetRealForwardFull_arrayarrayarrayDHandler ()
		{
			if (cb_realForwardFull_arrayarrayarrayD == null)
				cb_realForwardFull_arrayarrayarrayD = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_RealForwardFull_arrayarrayarrayD);
			return cb_realForwardFull_arrayarrayarrayD;
		}

		static void n_RealForwardFull_arrayarrayarrayD (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Org.Jtransforms.Fft.DoubleFFT_3D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.DoubleFFT_3D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			double[][][] p0 = (double[][][]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (double[][]));
			__this.RealForwardFull (p0);
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
		}
#pragma warning restore 0169

		static IntPtr id_realForwardFull_arrayarrayarrayD;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='DoubleFFT_3D']/method[@name='realForwardFull' and count(parameter)=1 and parameter[1][@type='double[][][]']]"
		[Register ("realForwardFull", "([[[D)V", "GetRealForwardFull_arrayarrayarrayDHandler")]
		public virtual unsafe void RealForwardFull (double[][][] p0)
		{
			if (id_realForwardFull_arrayarrayarrayD == IntPtr.Zero)
				id_realForwardFull_arrayarrayarrayD = JNIEnv.GetMethodID (class_ref, "realForwardFull", "([[[D)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_realForwardFull_arrayarrayarrayD, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "realForwardFull", "([[[D)V"), __args);
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
			global::Org.Jtransforms.Fft.DoubleFFT_3D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.DoubleFFT_3D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p0 = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.RealForwardFull (p0);
		}
#pragma warning restore 0169

		static IntPtr id_realForwardFull_Lpl_edu_icm_jlargearrays_DoubleLargeArray_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='DoubleFFT_3D']/method[@name='realForwardFull' and count(parameter)=1 and parameter[1][@type='pl.edu.icm.jlargearrays.DoubleLargeArray']]"
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
			global::Org.Jtransforms.Fft.DoubleFFT_3D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.DoubleFFT_3D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			double[] p0 = (double[]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (double));
			__this.RealInverse (p0, p1);
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
		}
#pragma warning restore 0169

		static IntPtr id_realInverse_arrayDZ;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='DoubleFFT_3D']/method[@name='realInverse' and count(parameter)=2 and parameter[1][@type='double[]'] and parameter[2][@type='boolean']]"
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

		static Delegate cb_realInverse_arrayarrayarrayDZ;
#pragma warning disable 0169
		static Delegate GetRealInverse_arrayarrayarrayDZHandler ()
		{
			if (cb_realInverse_arrayarrayarrayDZ == null)
				cb_realInverse_arrayarrayarrayDZ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, bool>) n_RealInverse_arrayarrayarrayDZ);
			return cb_realInverse_arrayarrayarrayDZ;
		}

		static void n_RealInverse_arrayarrayarrayDZ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, bool p1)
		{
			global::Org.Jtransforms.Fft.DoubleFFT_3D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.DoubleFFT_3D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			double[][][] p0 = (double[][][]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (double[][]));
			__this.RealInverse (p0, p1);
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
		}
#pragma warning restore 0169

		static IntPtr id_realInverse_arrayarrayarrayDZ;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='DoubleFFT_3D']/method[@name='realInverse' and count(parameter)=2 and parameter[1][@type='double[][][]'] and parameter[2][@type='boolean']]"
		[Register ("realInverse", "([[[DZ)V", "GetRealInverse_arrayarrayarrayDZHandler")]
		public virtual unsafe void RealInverse (double[][][] p0, bool p1)
		{
			if (id_realInverse_arrayarrayarrayDZ == IntPtr.Zero)
				id_realInverse_arrayarrayarrayDZ = JNIEnv.GetMethodID (class_ref, "realInverse", "([[[DZ)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_realInverse_arrayarrayarrayDZ, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "realInverse", "([[[DZ)V"), __args);
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
			global::Org.Jtransforms.Fft.DoubleFFT_3D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.DoubleFFT_3D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p0 = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.RealInverse (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_realInverse_Lpl_edu_icm_jlargearrays_DoubleLargeArray_Z;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='DoubleFFT_3D']/method[@name='realInverse' and count(parameter)=2 and parameter[1][@type='pl.edu.icm.jlargearrays.DoubleLargeArray'] and parameter[2][@type='boolean']]"
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
			global::Org.Jtransforms.Fft.DoubleFFT_3D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.DoubleFFT_3D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			double[] p0 = (double[]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (double));
			__this.RealInverseFull (p0, p1);
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
		}
#pragma warning restore 0169

		static IntPtr id_realInverseFull_arrayDZ;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='DoubleFFT_3D']/method[@name='realInverseFull' and count(parameter)=2 and parameter[1][@type='double[]'] and parameter[2][@type='boolean']]"
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

		static Delegate cb_realInverseFull_arrayarrayarrayDZ;
#pragma warning disable 0169
		static Delegate GetRealInverseFull_arrayarrayarrayDZHandler ()
		{
			if (cb_realInverseFull_arrayarrayarrayDZ == null)
				cb_realInverseFull_arrayarrayarrayDZ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, bool>) n_RealInverseFull_arrayarrayarrayDZ);
			return cb_realInverseFull_arrayarrayarrayDZ;
		}

		static void n_RealInverseFull_arrayarrayarrayDZ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, bool p1)
		{
			global::Org.Jtransforms.Fft.DoubleFFT_3D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.DoubleFFT_3D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			double[][][] p0 = (double[][][]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (double[][]));
			__this.RealInverseFull (p0, p1);
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
		}
#pragma warning restore 0169

		static IntPtr id_realInverseFull_arrayarrayarrayDZ;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='DoubleFFT_3D']/method[@name='realInverseFull' and count(parameter)=2 and parameter[1][@type='double[][][]'] and parameter[2][@type='boolean']]"
		[Register ("realInverseFull", "([[[DZ)V", "GetRealInverseFull_arrayarrayarrayDZHandler")]
		public virtual unsafe void RealInverseFull (double[][][] p0, bool p1)
		{
			if (id_realInverseFull_arrayarrayarrayDZ == IntPtr.Zero)
				id_realInverseFull_arrayarrayarrayDZ = JNIEnv.GetMethodID (class_ref, "realInverseFull", "([[[DZ)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_realInverseFull_arrayarrayarrayDZ, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "realInverseFull", "([[[DZ)V"), __args);
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
			global::Org.Jtransforms.Fft.DoubleFFT_3D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.DoubleFFT_3D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p0 = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.RealInverseFull (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_realInverseFull_Lpl_edu_icm_jlargearrays_DoubleLargeArray_Z;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='DoubleFFT_3D']/method[@name='realInverseFull' and count(parameter)=2 and parameter[1][@type='pl.edu.icm.jlargearrays.DoubleLargeArray'] and parameter[2][@type='boolean']]"
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
