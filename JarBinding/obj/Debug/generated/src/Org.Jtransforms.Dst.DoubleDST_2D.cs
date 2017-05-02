using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Org.Jtransforms.Dst {

	// Metadata.xml XPath class reference: path="/api/package[@name='org.jtransforms.dst']/class[@name='DoubleDST_2D']"
	[global::Android.Runtime.Register ("org/jtransforms/dst/DoubleDST_2D", DoNotGenerateAcw=true)]
	public partial class DoubleDST_2D : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("org/jtransforms/dst/DoubleDST_2D", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (DoubleDST_2D); }
		}

		protected DoubleDST_2D (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor_JJ;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='org.jtransforms.dst']/class[@name='DoubleDST_2D']/constructor[@name='DoubleDST_2D' and count(parameter)=2 and parameter[1][@type='long'] and parameter[2][@type='long']]"
		[Register (".ctor", "(JJ)V", "")]
		public unsafe DoubleDST_2D (long p0, long p1)
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				if (((object) this).GetType () != typeof (DoubleDST_2D)) {
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

		static Delegate cb_forward_arrayDZ;
#pragma warning disable 0169
		static Delegate GetForward_arrayDZHandler ()
		{
			if (cb_forward_arrayDZ == null)
				cb_forward_arrayDZ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, bool>) n_Forward_arrayDZ);
			return cb_forward_arrayDZ;
		}

		static void n_Forward_arrayDZ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, bool p1)
		{
			global::Org.Jtransforms.Dst.DoubleDST_2D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Dst.DoubleDST_2D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			double[] p0 = (double[]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (double));
			__this.Forward (p0, p1);
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
		}
#pragma warning restore 0169

		static IntPtr id_forward_arrayDZ;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.dst']/class[@name='DoubleDST_2D']/method[@name='forward' and count(parameter)=2 and parameter[1][@type='double[]'] and parameter[2][@type='boolean']]"
		[Register ("forward", "([DZ)V", "GetForward_arrayDZHandler")]
		public virtual unsafe void Forward (double[] p0, bool p1)
		{
			if (id_forward_arrayDZ == IntPtr.Zero)
				id_forward_arrayDZ = JNIEnv.GetMethodID (class_ref, "forward", "([DZ)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_forward_arrayDZ, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "forward", "([DZ)V"), __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static Delegate cb_forward_arrayarrayDZ;
#pragma warning disable 0169
		static Delegate GetForward_arrayarrayDZHandler ()
		{
			if (cb_forward_arrayarrayDZ == null)
				cb_forward_arrayarrayDZ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, bool>) n_Forward_arrayarrayDZ);
			return cb_forward_arrayarrayDZ;
		}

		static void n_Forward_arrayarrayDZ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, bool p1)
		{
			global::Org.Jtransforms.Dst.DoubleDST_2D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Dst.DoubleDST_2D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			double[][] p0 = (double[][]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (double[]));
			__this.Forward (p0, p1);
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
		}
#pragma warning restore 0169

		static IntPtr id_forward_arrayarrayDZ;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.dst']/class[@name='DoubleDST_2D']/method[@name='forward' and count(parameter)=2 and parameter[1][@type='double[][]'] and parameter[2][@type='boolean']]"
		[Register ("forward", "([[DZ)V", "GetForward_arrayarrayDZHandler")]
		public virtual unsafe void Forward (double[][] p0, bool p1)
		{
			if (id_forward_arrayarrayDZ == IntPtr.Zero)
				id_forward_arrayarrayDZ = JNIEnv.GetMethodID (class_ref, "forward", "([[DZ)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_forward_arrayarrayDZ, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "forward", "([[DZ)V"), __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static Delegate cb_forward_Lpl_edu_icm_jlargearrays_DoubleLargeArray_Z;
#pragma warning disable 0169
		static Delegate GetForward_Lpl_edu_icm_jlargearrays_DoubleLargeArray_ZHandler ()
		{
			if (cb_forward_Lpl_edu_icm_jlargearrays_DoubleLargeArray_Z == null)
				cb_forward_Lpl_edu_icm_jlargearrays_DoubleLargeArray_Z = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, bool>) n_Forward_Lpl_edu_icm_jlargearrays_DoubleLargeArray_Z);
			return cb_forward_Lpl_edu_icm_jlargearrays_DoubleLargeArray_Z;
		}

		static void n_Forward_Lpl_edu_icm_jlargearrays_DoubleLargeArray_Z (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, bool p1)
		{
			global::Org.Jtransforms.Dst.DoubleDST_2D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Dst.DoubleDST_2D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p0 = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Forward (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_forward_Lpl_edu_icm_jlargearrays_DoubleLargeArray_Z;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.dst']/class[@name='DoubleDST_2D']/method[@name='forward' and count(parameter)=2 and parameter[1][@type='pl.edu.icm.jlargearrays.DoubleLargeArray'] and parameter[2][@type='boolean']]"
		[Register ("forward", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;Z)V", "GetForward_Lpl_edu_icm_jlargearrays_DoubleLargeArray_ZHandler")]
		public virtual unsafe void Forward (global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p0, bool p1)
		{
			if (id_forward_Lpl_edu_icm_jlargearrays_DoubleLargeArray_Z == IntPtr.Zero)
				id_forward_Lpl_edu_icm_jlargearrays_DoubleLargeArray_Z = JNIEnv.GetMethodID (class_ref, "forward", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;Z)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_forward_Lpl_edu_icm_jlargearrays_DoubleLargeArray_Z, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "forward", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;Z)V"), __args);
			} finally {
			}
		}

		static Delegate cb_inverse_arrayDZ;
#pragma warning disable 0169
		static Delegate GetInverse_arrayDZHandler ()
		{
			if (cb_inverse_arrayDZ == null)
				cb_inverse_arrayDZ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, bool>) n_Inverse_arrayDZ);
			return cb_inverse_arrayDZ;
		}

		static void n_Inverse_arrayDZ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, bool p1)
		{
			global::Org.Jtransforms.Dst.DoubleDST_2D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Dst.DoubleDST_2D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			double[] p0 = (double[]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (double));
			__this.Inverse (p0, p1);
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
		}
#pragma warning restore 0169

		static IntPtr id_inverse_arrayDZ;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.dst']/class[@name='DoubleDST_2D']/method[@name='inverse' and count(parameter)=2 and parameter[1][@type='double[]'] and parameter[2][@type='boolean']]"
		[Register ("inverse", "([DZ)V", "GetInverse_arrayDZHandler")]
		public virtual unsafe void Inverse (double[] p0, bool p1)
		{
			if (id_inverse_arrayDZ == IntPtr.Zero)
				id_inverse_arrayDZ = JNIEnv.GetMethodID (class_ref, "inverse", "([DZ)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_inverse_arrayDZ, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "inverse", "([DZ)V"), __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static Delegate cb_inverse_arrayarrayDZ;
#pragma warning disable 0169
		static Delegate GetInverse_arrayarrayDZHandler ()
		{
			if (cb_inverse_arrayarrayDZ == null)
				cb_inverse_arrayarrayDZ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, bool>) n_Inverse_arrayarrayDZ);
			return cb_inverse_arrayarrayDZ;
		}

		static void n_Inverse_arrayarrayDZ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, bool p1)
		{
			global::Org.Jtransforms.Dst.DoubleDST_2D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Dst.DoubleDST_2D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			double[][] p0 = (double[][]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (double[]));
			__this.Inverse (p0, p1);
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
		}
#pragma warning restore 0169

		static IntPtr id_inverse_arrayarrayDZ;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.dst']/class[@name='DoubleDST_2D']/method[@name='inverse' and count(parameter)=2 and parameter[1][@type='double[][]'] and parameter[2][@type='boolean']]"
		[Register ("inverse", "([[DZ)V", "GetInverse_arrayarrayDZHandler")]
		public virtual unsafe void Inverse (double[][] p0, bool p1)
		{
			if (id_inverse_arrayarrayDZ == IntPtr.Zero)
				id_inverse_arrayarrayDZ = JNIEnv.GetMethodID (class_ref, "inverse", "([[DZ)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_inverse_arrayarrayDZ, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "inverse", "([[DZ)V"), __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static Delegate cb_inverse_Lpl_edu_icm_jlargearrays_DoubleLargeArray_Z;
#pragma warning disable 0169
		static Delegate GetInverse_Lpl_edu_icm_jlargearrays_DoubleLargeArray_ZHandler ()
		{
			if (cb_inverse_Lpl_edu_icm_jlargearrays_DoubleLargeArray_Z == null)
				cb_inverse_Lpl_edu_icm_jlargearrays_DoubleLargeArray_Z = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, bool>) n_Inverse_Lpl_edu_icm_jlargearrays_DoubleLargeArray_Z);
			return cb_inverse_Lpl_edu_icm_jlargearrays_DoubleLargeArray_Z;
		}

		static void n_Inverse_Lpl_edu_icm_jlargearrays_DoubleLargeArray_Z (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, bool p1)
		{
			global::Org.Jtransforms.Dst.DoubleDST_2D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Dst.DoubleDST_2D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p0 = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Inverse (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_inverse_Lpl_edu_icm_jlargearrays_DoubleLargeArray_Z;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.dst']/class[@name='DoubleDST_2D']/method[@name='inverse' and count(parameter)=2 and parameter[1][@type='pl.edu.icm.jlargearrays.DoubleLargeArray'] and parameter[2][@type='boolean']]"
		[Register ("inverse", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;Z)V", "GetInverse_Lpl_edu_icm_jlargearrays_DoubleLargeArray_ZHandler")]
		public virtual unsafe void Inverse (global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p0, bool p1)
		{
			if (id_inverse_Lpl_edu_icm_jlargearrays_DoubleLargeArray_Z == IntPtr.Zero)
				id_inverse_Lpl_edu_icm_jlargearrays_DoubleLargeArray_Z = JNIEnv.GetMethodID (class_ref, "inverse", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;Z)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_inverse_Lpl_edu_icm_jlargearrays_DoubleLargeArray_Z, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "inverse", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;Z)V"), __args);
			} finally {
			}
		}

	}
}
