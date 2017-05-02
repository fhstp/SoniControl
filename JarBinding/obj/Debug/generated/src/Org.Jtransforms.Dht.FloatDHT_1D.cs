using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Org.Jtransforms.Dht {

	// Metadata.xml XPath class reference: path="/api/package[@name='org.jtransforms.dht']/class[@name='FloatDHT_1D']"
	[global::Android.Runtime.Register ("org/jtransforms/dht/FloatDHT_1D", DoNotGenerateAcw=true)]
	public partial class FloatDHT_1D : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("org/jtransforms/dht/FloatDHT_1D", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (FloatDHT_1D); }
		}

		protected FloatDHT_1D (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor_J;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='org.jtransforms.dht']/class[@name='FloatDHT_1D']/constructor[@name='FloatDHT_1D' and count(parameter)=1 and parameter[1][@type='long']]"
		[Register (".ctor", "(J)V", "")]
		public unsafe FloatDHT_1D (long p0)
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				if (((object) this).GetType () != typeof (FloatDHT_1D)) {
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
			global::Org.Jtransforms.Dht.FloatDHT_1D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Dht.FloatDHT_1D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			float[] p0 = (float[]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (float));
			__this.Forward (p0);
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
		}
#pragma warning restore 0169

		static IntPtr id_forward_arrayF;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.dht']/class[@name='FloatDHT_1D']/method[@name='forward' and count(parameter)=1 and parameter[1][@type='float[]']]"
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

		static Delegate cb_forward_arrayFI;
#pragma warning disable 0169
		static Delegate GetForward_arrayFIHandler ()
		{
			if (cb_forward_arrayFI == null)
				cb_forward_arrayFI = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, int>) n_Forward_arrayFI);
			return cb_forward_arrayFI;
		}

		static void n_Forward_arrayFI (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, int p1)
		{
			global::Org.Jtransforms.Dht.FloatDHT_1D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Dht.FloatDHT_1D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			float[] p0 = (float[]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (float));
			__this.Forward (p0, p1);
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
		}
#pragma warning restore 0169

		static IntPtr id_forward_arrayFI;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.dht']/class[@name='FloatDHT_1D']/method[@name='forward' and count(parameter)=2 and parameter[1][@type='float[]'] and parameter[2][@type='int']]"
		[Register ("forward", "([FI)V", "GetForward_arrayFIHandler")]
		public virtual unsafe void Forward (float[] p0, int p1)
		{
			if (id_forward_arrayFI == IntPtr.Zero)
				id_forward_arrayFI = JNIEnv.GetMethodID (class_ref, "forward", "([FI)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_forward_arrayFI, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "forward", "([FI)V"), __args);
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
			global::Org.Jtransforms.Dht.FloatDHT_1D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Dht.FloatDHT_1D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p0 = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.FloatLargeArray> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Forward (p0);
		}
#pragma warning restore 0169

		static IntPtr id_forward_Lpl_edu_icm_jlargearrays_FloatLargeArray_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.dht']/class[@name='FloatDHT_1D']/method[@name='forward' and count(parameter)=1 and parameter[1][@type='pl.edu.icm.jlargearrays.FloatLargeArray']]"
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

		static Delegate cb_forward_Lpl_edu_icm_jlargearrays_FloatLargeArray_J;
#pragma warning disable 0169
		static Delegate GetForward_Lpl_edu_icm_jlargearrays_FloatLargeArray_JHandler ()
		{
			if (cb_forward_Lpl_edu_icm_jlargearrays_FloatLargeArray_J == null)
				cb_forward_Lpl_edu_icm_jlargearrays_FloatLargeArray_J = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, long>) n_Forward_Lpl_edu_icm_jlargearrays_FloatLargeArray_J);
			return cb_forward_Lpl_edu_icm_jlargearrays_FloatLargeArray_J;
		}

		static void n_Forward_Lpl_edu_icm_jlargearrays_FloatLargeArray_J (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, long p1)
		{
			global::Org.Jtransforms.Dht.FloatDHT_1D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Dht.FloatDHT_1D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p0 = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.FloatLargeArray> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Forward (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_forward_Lpl_edu_icm_jlargearrays_FloatLargeArray_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.dht']/class[@name='FloatDHT_1D']/method[@name='forward' and count(parameter)=2 and parameter[1][@type='pl.edu.icm.jlargearrays.FloatLargeArray'] and parameter[2][@type='long']]"
		[Register ("forward", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;J)V", "GetForward_Lpl_edu_icm_jlargearrays_FloatLargeArray_JHandler")]
		public virtual unsafe void Forward (global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p0, long p1)
		{
			if (id_forward_Lpl_edu_icm_jlargearrays_FloatLargeArray_J == IntPtr.Zero)
				id_forward_Lpl_edu_icm_jlargearrays_FloatLargeArray_J = JNIEnv.GetMethodID (class_ref, "forward", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;J)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_forward_Lpl_edu_icm_jlargearrays_FloatLargeArray_J, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "forward", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;J)V"), __args);
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
			global::Org.Jtransforms.Dht.FloatDHT_1D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Dht.FloatDHT_1D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			float[] p0 = (float[]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (float));
			__this.Inverse (p0, p1);
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
		}
#pragma warning restore 0169

		static IntPtr id_inverse_arrayFZ;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.dht']/class[@name='FloatDHT_1D']/method[@name='inverse' and count(parameter)=2 and parameter[1][@type='float[]'] and parameter[2][@type='boolean']]"
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

		static Delegate cb_inverse_arrayFIZ;
#pragma warning disable 0169
		static Delegate GetInverse_arrayFIZHandler ()
		{
			if (cb_inverse_arrayFIZ == null)
				cb_inverse_arrayFIZ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, int, bool>) n_Inverse_arrayFIZ);
			return cb_inverse_arrayFIZ;
		}

		static void n_Inverse_arrayFIZ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, int p1, bool p2)
		{
			global::Org.Jtransforms.Dht.FloatDHT_1D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Dht.FloatDHT_1D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			float[] p0 = (float[]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (float));
			__this.Inverse (p0, p1, p2);
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
		}
#pragma warning restore 0169

		static IntPtr id_inverse_arrayFIZ;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.dht']/class[@name='FloatDHT_1D']/method[@name='inverse' and count(parameter)=3 and parameter[1][@type='float[]'] and parameter[2][@type='int'] and parameter[3][@type='boolean']]"
		[Register ("inverse", "([FIZ)V", "GetInverse_arrayFIZHandler")]
		public virtual unsafe void Inverse (float[] p0, int p1, bool p2)
		{
			if (id_inverse_arrayFIZ == IntPtr.Zero)
				id_inverse_arrayFIZ = JNIEnv.GetMethodID (class_ref, "inverse", "([FIZ)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_inverse_arrayFIZ, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "inverse", "([FIZ)V"), __args);
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
			global::Org.Jtransforms.Dht.FloatDHT_1D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Dht.FloatDHT_1D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p0 = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.FloatLargeArray> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Inverse (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_inverse_Lpl_edu_icm_jlargearrays_FloatLargeArray_Z;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.dht']/class[@name='FloatDHT_1D']/method[@name='inverse' and count(parameter)=2 and parameter[1][@type='pl.edu.icm.jlargearrays.FloatLargeArray'] and parameter[2][@type='boolean']]"
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

		static Delegate cb_inverse_Lpl_edu_icm_jlargearrays_FloatLargeArray_JZ;
#pragma warning disable 0169
		static Delegate GetInverse_Lpl_edu_icm_jlargearrays_FloatLargeArray_JZHandler ()
		{
			if (cb_inverse_Lpl_edu_icm_jlargearrays_FloatLargeArray_JZ == null)
				cb_inverse_Lpl_edu_icm_jlargearrays_FloatLargeArray_JZ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, long, bool>) n_Inverse_Lpl_edu_icm_jlargearrays_FloatLargeArray_JZ);
			return cb_inverse_Lpl_edu_icm_jlargearrays_FloatLargeArray_JZ;
		}

		static void n_Inverse_Lpl_edu_icm_jlargearrays_FloatLargeArray_JZ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, long p1, bool p2)
		{
			global::Org.Jtransforms.Dht.FloatDHT_1D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Dht.FloatDHT_1D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p0 = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.FloatLargeArray> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Inverse (p0, p1, p2);
		}
#pragma warning restore 0169

		static IntPtr id_inverse_Lpl_edu_icm_jlargearrays_FloatLargeArray_JZ;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.dht']/class[@name='FloatDHT_1D']/method[@name='inverse' and count(parameter)=3 and parameter[1][@type='pl.edu.icm.jlargearrays.FloatLargeArray'] and parameter[2][@type='long'] and parameter[3][@type='boolean']]"
		[Register ("inverse", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;JZ)V", "GetInverse_Lpl_edu_icm_jlargearrays_FloatLargeArray_JZHandler")]
		public virtual unsafe void Inverse (global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p0, long p1, bool p2)
		{
			if (id_inverse_Lpl_edu_icm_jlargearrays_FloatLargeArray_JZ == IntPtr.Zero)
				id_inverse_Lpl_edu_icm_jlargearrays_FloatLargeArray_JZ = JNIEnv.GetMethodID (class_ref, "inverse", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;JZ)V");
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_inverse_Lpl_edu_icm_jlargearrays_FloatLargeArray_JZ, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "inverse", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;JZ)V"), __args);
			} finally {
			}
		}

	}
}
