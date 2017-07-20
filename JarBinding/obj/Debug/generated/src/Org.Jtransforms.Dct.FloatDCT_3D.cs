using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Org.Jtransforms.Dct {

	// Metadata.xml XPath class reference: path="/api/package[@name='org.jtransforms.dct']/class[@name='FloatDCT_3D']"
	[global::Android.Runtime.Register ("org/jtransforms/dct/FloatDCT_3D", DoNotGenerateAcw=true)]
	public partial class FloatDCT_3D : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("org/jtransforms/dct/FloatDCT_3D", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (FloatDCT_3D); }
		}

		protected FloatDCT_3D (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor_JJJ;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='org.jtransforms.dct']/class[@name='FloatDCT_3D']/constructor[@name='FloatDCT_3D' and count(parameter)=3 and parameter[1][@type='long'] and parameter[2][@type='long'] and parameter[3][@type='long']]"
		[Register (".ctor", "(JJJ)V", "")]
		public unsafe FloatDCT_3D (long p0, long p1, long p2)
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				if (((object) this).GetType () != typeof (FloatDCT_3D)) {
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

		static Delegate cb_forward_arrayFZ;
#pragma warning disable 0169
		static Delegate GetForward_arrayFZHandler ()
		{
			if (cb_forward_arrayFZ == null)
				cb_forward_arrayFZ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, bool>) n_Forward_arrayFZ);
			return cb_forward_arrayFZ;
		}

		static void n_Forward_arrayFZ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, bool p1)
		{
			global::Org.Jtransforms.Dct.FloatDCT_3D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Dct.FloatDCT_3D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			float[] p0 = (float[]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (float));
			__this.Forward (p0, p1);
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
		}
#pragma warning restore 0169

		static IntPtr id_forward_arrayFZ;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.dct']/class[@name='FloatDCT_3D']/method[@name='forward' and count(parameter)=2 and parameter[1][@type='float[]'] and parameter[2][@type='boolean']]"
		[Register ("forward", "([FZ)V", "GetForward_arrayFZHandler")]
		public virtual unsafe void Forward (float[] p0, bool p1)
		{
			if (id_forward_arrayFZ == IntPtr.Zero)
				id_forward_arrayFZ = JNIEnv.GetMethodID (class_ref, "forward", "([FZ)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_forward_arrayFZ, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "forward", "([FZ)V"), __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static Delegate cb_forward_arrayarrayarrayFZ;
#pragma warning disable 0169
		static Delegate GetForward_arrayarrayarrayFZHandler ()
		{
			if (cb_forward_arrayarrayarrayFZ == null)
				cb_forward_arrayarrayarrayFZ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, bool>) n_Forward_arrayarrayarrayFZ);
			return cb_forward_arrayarrayarrayFZ;
		}

		static void n_Forward_arrayarrayarrayFZ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, bool p1)
		{
			global::Org.Jtransforms.Dct.FloatDCT_3D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Dct.FloatDCT_3D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			float[][][] p0 = (float[][][]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (float[][]));
			__this.Forward (p0, p1);
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
		}
#pragma warning restore 0169

		static IntPtr id_forward_arrayarrayarrayFZ;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.dct']/class[@name='FloatDCT_3D']/method[@name='forward' and count(parameter)=2 and parameter[1][@type='float[][][]'] and parameter[2][@type='boolean']]"
		[Register ("forward", "([[[FZ)V", "GetForward_arrayarrayarrayFZHandler")]
		public virtual unsafe void Forward (float[][][] p0, bool p1)
		{
			if (id_forward_arrayarrayarrayFZ == IntPtr.Zero)
				id_forward_arrayarrayarrayFZ = JNIEnv.GetMethodID (class_ref, "forward", "([[[FZ)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_forward_arrayarrayarrayFZ, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "forward", "([[[FZ)V"), __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static Delegate cb_forward_Lpl_edu_icm_jlargearrays_FloatLargeArray_Z;
#pragma warning disable 0169
		static Delegate GetForward_Lpl_edu_icm_jlargearrays_FloatLargeArray_ZHandler ()
		{
			if (cb_forward_Lpl_edu_icm_jlargearrays_FloatLargeArray_Z == null)
				cb_forward_Lpl_edu_icm_jlargearrays_FloatLargeArray_Z = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, bool>) n_Forward_Lpl_edu_icm_jlargearrays_FloatLargeArray_Z);
			return cb_forward_Lpl_edu_icm_jlargearrays_FloatLargeArray_Z;
		}

		static void n_Forward_Lpl_edu_icm_jlargearrays_FloatLargeArray_Z (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, bool p1)
		{
			global::Org.Jtransforms.Dct.FloatDCT_3D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Dct.FloatDCT_3D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p0 = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.FloatLargeArray> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Forward (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_forward_Lpl_edu_icm_jlargearrays_FloatLargeArray_Z;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.dct']/class[@name='FloatDCT_3D']/method[@name='forward' and count(parameter)=2 and parameter[1][@type='pl.edu.icm.jlargearrays.FloatLargeArray'] and parameter[2][@type='boolean']]"
		[Register ("forward", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;Z)V", "GetForward_Lpl_edu_icm_jlargearrays_FloatLargeArray_ZHandler")]
		public virtual unsafe void Forward (global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p0, bool p1)
		{
			if (id_forward_Lpl_edu_icm_jlargearrays_FloatLargeArray_Z == IntPtr.Zero)
				id_forward_Lpl_edu_icm_jlargearrays_FloatLargeArray_Z = JNIEnv.GetMethodID (class_ref, "forward", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;Z)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_forward_Lpl_edu_icm_jlargearrays_FloatLargeArray_Z, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "forward", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;Z)V"), __args);
			} finally {
			}
		}

		static Delegate cb_inverse_arrayFZ;
#pragma warning disable 0169
		static Delegate GetInverse_arrayFZHandler ()
		{
			if (cb_inverse_arrayFZ == null)
				cb_inverse_arrayFZ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, bool>) n_Inverse_arrayFZ);
			return cb_inverse_arrayFZ;
		}

		static void n_Inverse_arrayFZ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, bool p1)
		{
			global::Org.Jtransforms.Dct.FloatDCT_3D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Dct.FloatDCT_3D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			float[] p0 = (float[]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (float));
			__this.Inverse (p0, p1);
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
		}
#pragma warning restore 0169

		static IntPtr id_inverse_arrayFZ;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.dct']/class[@name='FloatDCT_3D']/method[@name='inverse' and count(parameter)=2 and parameter[1][@type='float[]'] and parameter[2][@type='boolean']]"
		[Register ("inverse", "([FZ)V", "GetInverse_arrayFZHandler")]
		public virtual unsafe void Inverse (float[] p0, bool p1)
		{
			if (id_inverse_arrayFZ == IntPtr.Zero)
				id_inverse_arrayFZ = JNIEnv.GetMethodID (class_ref, "inverse", "([FZ)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_inverse_arrayFZ, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "inverse", "([FZ)V"), __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static Delegate cb_inverse_arrayarrayarrayFZ;
#pragma warning disable 0169
		static Delegate GetInverse_arrayarrayarrayFZHandler ()
		{
			if (cb_inverse_arrayarrayarrayFZ == null)
				cb_inverse_arrayarrayarrayFZ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, bool>) n_Inverse_arrayarrayarrayFZ);
			return cb_inverse_arrayarrayarrayFZ;
		}

		static void n_Inverse_arrayarrayarrayFZ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, bool p1)
		{
			global::Org.Jtransforms.Dct.FloatDCT_3D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Dct.FloatDCT_3D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			float[][][] p0 = (float[][][]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (float[][]));
			__this.Inverse (p0, p1);
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
		}
#pragma warning restore 0169

		static IntPtr id_inverse_arrayarrayarrayFZ;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.dct']/class[@name='FloatDCT_3D']/method[@name='inverse' and count(parameter)=2 and parameter[1][@type='float[][][]'] and parameter[2][@type='boolean']]"
		[Register ("inverse", "([[[FZ)V", "GetInverse_arrayarrayarrayFZHandler")]
		public virtual unsafe void Inverse (float[][][] p0, bool p1)
		{
			if (id_inverse_arrayarrayarrayFZ == IntPtr.Zero)
				id_inverse_arrayarrayarrayFZ = JNIEnv.GetMethodID (class_ref, "inverse", "([[[FZ)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_inverse_arrayarrayarrayFZ, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "inverse", "([[[FZ)V"), __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static Delegate cb_inverse_Lpl_edu_icm_jlargearrays_FloatLargeArray_Z;
#pragma warning disable 0169
		static Delegate GetInverse_Lpl_edu_icm_jlargearrays_FloatLargeArray_ZHandler ()
		{
			if (cb_inverse_Lpl_edu_icm_jlargearrays_FloatLargeArray_Z == null)
				cb_inverse_Lpl_edu_icm_jlargearrays_FloatLargeArray_Z = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, bool>) n_Inverse_Lpl_edu_icm_jlargearrays_FloatLargeArray_Z);
			return cb_inverse_Lpl_edu_icm_jlargearrays_FloatLargeArray_Z;
		}

		static void n_Inverse_Lpl_edu_icm_jlargearrays_FloatLargeArray_Z (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, bool p1)
		{
			global::Org.Jtransforms.Dct.FloatDCT_3D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Dct.FloatDCT_3D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p0 = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.FloatLargeArray> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Inverse (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_inverse_Lpl_edu_icm_jlargearrays_FloatLargeArray_Z;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.dct']/class[@name='FloatDCT_3D']/method[@name='inverse' and count(parameter)=2 and parameter[1][@type='pl.edu.icm.jlargearrays.FloatLargeArray'] and parameter[2][@type='boolean']]"
		[Register ("inverse", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;Z)V", "GetInverse_Lpl_edu_icm_jlargearrays_FloatLargeArray_ZHandler")]
		public virtual unsafe void Inverse (global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p0, bool p1)
		{
			if (id_inverse_Lpl_edu_icm_jlargearrays_FloatLargeArray_Z == IntPtr.Zero)
				id_inverse_Lpl_edu_icm_jlargearrays_FloatLargeArray_Z = JNIEnv.GetMethodID (class_ref, "inverse", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;Z)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_inverse_Lpl_edu_icm_jlargearrays_FloatLargeArray_Z, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "inverse", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;Z)V"), __args);
			} finally {
			}
		}

	}
}
