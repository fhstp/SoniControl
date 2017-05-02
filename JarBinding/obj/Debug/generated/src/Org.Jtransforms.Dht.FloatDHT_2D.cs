using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Org.Jtransforms.Dht {

	// Metadata.xml XPath class reference: path="/api/package[@name='org.jtransforms.dht']/class[@name='FloatDHT_2D']"
	[global::Android.Runtime.Register ("org/jtransforms/dht/FloatDHT_2D", DoNotGenerateAcw=true)]
	public partial class FloatDHT_2D : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("org/jtransforms/dht/FloatDHT_2D", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (FloatDHT_2D); }
		}

		protected FloatDHT_2D (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor_JJ;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='org.jtransforms.dht']/class[@name='FloatDHT_2D']/constructor[@name='FloatDHT_2D' and count(parameter)=2 and parameter[1][@type='long'] and parameter[2][@type='long']]"
		[Register (".ctor", "(JJ)V", "")]
		public unsafe FloatDHT_2D (long p0, long p1)
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				if (((object) this).GetType () != typeof (FloatDHT_2D)) {
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

		static Delegate cb_forward_arrayF;
#pragma warning disable 0169
		static Delegate GetForward_arrayFHandler ()
		{
			if (cb_forward_arrayF == null)
				cb_forward_arrayF = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Forward_arrayF);
			return cb_forward_arrayF;
		}

		static void n_Forward_arrayF (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Org.Jtransforms.Dht.FloatDHT_2D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Dht.FloatDHT_2D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			float[] p0 = (float[]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (float));
			__this.Forward (p0);
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
		}
#pragma warning restore 0169

		static IntPtr id_forward_arrayF;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.dht']/class[@name='FloatDHT_2D']/method[@name='forward' and count(parameter)=1 and parameter[1][@type='float[]']]"
		[Register ("forward", "([F)V", "GetForward_arrayFHandler")]
		public virtual unsafe void Forward (float[] p0)
		{
			if (id_forward_arrayF == IntPtr.Zero)
				id_forward_arrayF = JNIEnv.GetMethodID (class_ref, "forward", "([F)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_forward_arrayF, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "forward", "([F)V"), __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static Delegate cb_forward_arrayarrayF;
#pragma warning disable 0169
		static Delegate GetForward_arrayarrayFHandler ()
		{
			if (cb_forward_arrayarrayF == null)
				cb_forward_arrayarrayF = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Forward_arrayarrayF);
			return cb_forward_arrayarrayF;
		}

		static void n_Forward_arrayarrayF (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Org.Jtransforms.Dht.FloatDHT_2D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Dht.FloatDHT_2D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			float[][] p0 = (float[][]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (float[]));
			__this.Forward (p0);
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
		}
#pragma warning restore 0169

		static IntPtr id_forward_arrayarrayF;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.dht']/class[@name='FloatDHT_2D']/method[@name='forward' and count(parameter)=1 and parameter[1][@type='float[][]']]"
		[Register ("forward", "([[F)V", "GetForward_arrayarrayFHandler")]
		public virtual unsafe void Forward (float[][] p0)
		{
			if (id_forward_arrayarrayF == IntPtr.Zero)
				id_forward_arrayarrayF = JNIEnv.GetMethodID (class_ref, "forward", "([[F)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_forward_arrayarrayF, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "forward", "([[F)V"), __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static Delegate cb_forward_Lpl_edu_icm_jlargearrays_FloatLargeArray_;
#pragma warning disable 0169
		static Delegate GetForward_Lpl_edu_icm_jlargearrays_FloatLargeArray_Handler ()
		{
			if (cb_forward_Lpl_edu_icm_jlargearrays_FloatLargeArray_ == null)
				cb_forward_Lpl_edu_icm_jlargearrays_FloatLargeArray_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Forward_Lpl_edu_icm_jlargearrays_FloatLargeArray_);
			return cb_forward_Lpl_edu_icm_jlargearrays_FloatLargeArray_;
		}

		static void n_Forward_Lpl_edu_icm_jlargearrays_FloatLargeArray_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Org.Jtransforms.Dht.FloatDHT_2D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Dht.FloatDHT_2D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p0 = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.FloatLargeArray> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Forward (p0);
		}
#pragma warning restore 0169

		static IntPtr id_forward_Lpl_edu_icm_jlargearrays_FloatLargeArray_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.dht']/class[@name='FloatDHT_2D']/method[@name='forward' and count(parameter)=1 and parameter[1][@type='pl.edu.icm.jlargearrays.FloatLargeArray']]"
		[Register ("forward", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;)V", "GetForward_Lpl_edu_icm_jlargearrays_FloatLargeArray_Handler")]
		public virtual unsafe void Forward (global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p0)
		{
			if (id_forward_Lpl_edu_icm_jlargearrays_FloatLargeArray_ == IntPtr.Zero)
				id_forward_Lpl_edu_icm_jlargearrays_FloatLargeArray_ = JNIEnv.GetMethodID (class_ref, "forward", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_forward_Lpl_edu_icm_jlargearrays_FloatLargeArray_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "forward", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;)V"), __args);
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
			global::Org.Jtransforms.Dht.FloatDHT_2D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Dht.FloatDHT_2D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			float[] p0 = (float[]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (float));
			__this.Inverse (p0, p1);
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
		}
#pragma warning restore 0169

		static IntPtr id_inverse_arrayFZ;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.dht']/class[@name='FloatDHT_2D']/method[@name='inverse' and count(parameter)=2 and parameter[1][@type='float[]'] and parameter[2][@type='boolean']]"
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

		static Delegate cb_inverse_arrayarrayFZ;
#pragma warning disable 0169
		static Delegate GetInverse_arrayarrayFZHandler ()
		{
			if (cb_inverse_arrayarrayFZ == null)
				cb_inverse_arrayarrayFZ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, bool>) n_Inverse_arrayarrayFZ);
			return cb_inverse_arrayarrayFZ;
		}

		static void n_Inverse_arrayarrayFZ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, bool p1)
		{
			global::Org.Jtransforms.Dht.FloatDHT_2D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Dht.FloatDHT_2D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			float[][] p0 = (float[][]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (float[]));
			__this.Inverse (p0, p1);
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
		}
#pragma warning restore 0169

		static IntPtr id_inverse_arrayarrayFZ;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.dht']/class[@name='FloatDHT_2D']/method[@name='inverse' and count(parameter)=2 and parameter[1][@type='float[][]'] and parameter[2][@type='boolean']]"
		[Register ("inverse", "([[FZ)V", "GetInverse_arrayarrayFZHandler")]
		public virtual unsafe void Inverse (float[][] p0, bool p1)
		{
			if (id_inverse_arrayarrayFZ == IntPtr.Zero)
				id_inverse_arrayarrayFZ = JNIEnv.GetMethodID (class_ref, "inverse", "([[FZ)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_inverse_arrayarrayFZ, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "inverse", "([[FZ)V"), __args);
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
			global::Org.Jtransforms.Dht.FloatDHT_2D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Dht.FloatDHT_2D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p0 = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.FloatLargeArray> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Inverse (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_inverse_Lpl_edu_icm_jlargearrays_FloatLargeArray_Z;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.dht']/class[@name='FloatDHT_2D']/method[@name='inverse' and count(parameter)=2 and parameter[1][@type='pl.edu.icm.jlargearrays.FloatLargeArray'] and parameter[2][@type='boolean']]"
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
