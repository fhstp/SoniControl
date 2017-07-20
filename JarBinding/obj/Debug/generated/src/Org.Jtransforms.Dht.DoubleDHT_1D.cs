using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Org.Jtransforms.Dht {

	// Metadata.xml XPath class reference: path="/api/package[@name='org.jtransforms.dht']/class[@name='DoubleDHT_1D']"
	[global::Android.Runtime.Register ("org/jtransforms/dht/DoubleDHT_1D", DoNotGenerateAcw=true)]
	public partial class DoubleDHT_1D : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("org/jtransforms/dht/DoubleDHT_1D", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (DoubleDHT_1D); }
		}

		protected DoubleDHT_1D (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor_J;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='org.jtransforms.dht']/class[@name='DoubleDHT_1D']/constructor[@name='DoubleDHT_1D' and count(parameter)=1 and parameter[1][@type='long']]"
		[Register (".ctor", "(J)V", "")]
		public unsafe DoubleDHT_1D (long p0)
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				if (((object) this).GetType () != typeof (DoubleDHT_1D)) {
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

		static Delegate cb_forward_arrayD;
#pragma warning disable 0169
		static Delegate GetForward_arrayDHandler ()
		{
			if (cb_forward_arrayD == null)
				cb_forward_arrayD = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Forward_arrayD);
			return cb_forward_arrayD;
		}

		static void n_Forward_arrayD (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Org.Jtransforms.Dht.DoubleDHT_1D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Dht.DoubleDHT_1D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			double[] p0 = (double[]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (double));
			__this.Forward (p0);
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
		}
#pragma warning restore 0169

		static IntPtr id_forward_arrayD;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.dht']/class[@name='DoubleDHT_1D']/method[@name='forward' and count(parameter)=1 and parameter[1][@type='double[]']]"
		[Register ("forward", "([D)V", "GetForward_arrayDHandler")]
		public virtual unsafe void Forward (double[] p0)
		{
			if (id_forward_arrayD == IntPtr.Zero)
				id_forward_arrayD = JNIEnv.GetMethodID (class_ref, "forward", "([D)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_forward_arrayD, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "forward", "([D)V"), __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static Delegate cb_forward_arrayDI;
#pragma warning disable 0169
		static Delegate GetForward_arrayDIHandler ()
		{
			if (cb_forward_arrayDI == null)
				cb_forward_arrayDI = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, int>) n_Forward_arrayDI);
			return cb_forward_arrayDI;
		}

		static void n_Forward_arrayDI (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, int p1)
		{
			global::Org.Jtransforms.Dht.DoubleDHT_1D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Dht.DoubleDHT_1D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			double[] p0 = (double[]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (double));
			__this.Forward (p0, p1);
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
		}
#pragma warning restore 0169

		static IntPtr id_forward_arrayDI;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.dht']/class[@name='DoubleDHT_1D']/method[@name='forward' and count(parameter)=2 and parameter[1][@type='double[]'] and parameter[2][@type='int']]"
		[Register ("forward", "([DI)V", "GetForward_arrayDIHandler")]
		public virtual unsafe void Forward (double[] p0, int p1)
		{
			if (id_forward_arrayDI == IntPtr.Zero)
				id_forward_arrayDI = JNIEnv.GetMethodID (class_ref, "forward", "([DI)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_forward_arrayDI, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "forward", "([DI)V"), __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static Delegate cb_forward_Lpl_edu_icm_jlargearrays_DoubleLargeArray_;
#pragma warning disable 0169
		static Delegate GetForward_Lpl_edu_icm_jlargearrays_DoubleLargeArray_Handler ()
		{
			if (cb_forward_Lpl_edu_icm_jlargearrays_DoubleLargeArray_ == null)
				cb_forward_Lpl_edu_icm_jlargearrays_DoubleLargeArray_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Forward_Lpl_edu_icm_jlargearrays_DoubleLargeArray_);
			return cb_forward_Lpl_edu_icm_jlargearrays_DoubleLargeArray_;
		}

		static void n_Forward_Lpl_edu_icm_jlargearrays_DoubleLargeArray_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Org.Jtransforms.Dht.DoubleDHT_1D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Dht.DoubleDHT_1D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p0 = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Forward (p0);
		}
#pragma warning restore 0169

		static IntPtr id_forward_Lpl_edu_icm_jlargearrays_DoubleLargeArray_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.dht']/class[@name='DoubleDHT_1D']/method[@name='forward' and count(parameter)=1 and parameter[1][@type='pl.edu.icm.jlargearrays.DoubleLargeArray']]"
		[Register ("forward", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;)V", "GetForward_Lpl_edu_icm_jlargearrays_DoubleLargeArray_Handler")]
		public virtual unsafe void Forward (global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p0)
		{
			if (id_forward_Lpl_edu_icm_jlargearrays_DoubleLargeArray_ == IntPtr.Zero)
				id_forward_Lpl_edu_icm_jlargearrays_DoubleLargeArray_ = JNIEnv.GetMethodID (class_ref, "forward", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_forward_Lpl_edu_icm_jlargearrays_DoubleLargeArray_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "forward", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;)V"), __args);
			} finally {
			}
		}

		static Delegate cb_forward_Lpl_edu_icm_jlargearrays_DoubleLargeArray_J;
#pragma warning disable 0169
		static Delegate GetForward_Lpl_edu_icm_jlargearrays_DoubleLargeArray_JHandler ()
		{
			if (cb_forward_Lpl_edu_icm_jlargearrays_DoubleLargeArray_J == null)
				cb_forward_Lpl_edu_icm_jlargearrays_DoubleLargeArray_J = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, long>) n_Forward_Lpl_edu_icm_jlargearrays_DoubleLargeArray_J);
			return cb_forward_Lpl_edu_icm_jlargearrays_DoubleLargeArray_J;
		}

		static void n_Forward_Lpl_edu_icm_jlargearrays_DoubleLargeArray_J (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, long p1)
		{
			global::Org.Jtransforms.Dht.DoubleDHT_1D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Dht.DoubleDHT_1D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p0 = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Forward (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_forward_Lpl_edu_icm_jlargearrays_DoubleLargeArray_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.dht']/class[@name='DoubleDHT_1D']/method[@name='forward' and count(parameter)=2 and parameter[1][@type='pl.edu.icm.jlargearrays.DoubleLargeArray'] and parameter[2][@type='long']]"
		[Register ("forward", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;J)V", "GetForward_Lpl_edu_icm_jlargearrays_DoubleLargeArray_JHandler")]
		public virtual unsafe void Forward (global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p0, long p1)
		{
			if (id_forward_Lpl_edu_icm_jlargearrays_DoubleLargeArray_J == IntPtr.Zero)
				id_forward_Lpl_edu_icm_jlargearrays_DoubleLargeArray_J = JNIEnv.GetMethodID (class_ref, "forward", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;J)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_forward_Lpl_edu_icm_jlargearrays_DoubleLargeArray_J, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "forward", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;J)V"), __args);
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
			global::Org.Jtransforms.Dht.DoubleDHT_1D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Dht.DoubleDHT_1D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			double[] p0 = (double[]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (double));
			__this.Inverse (p0, p1);
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
		}
#pragma warning restore 0169

		static IntPtr id_inverse_arrayDZ;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.dht']/class[@name='DoubleDHT_1D']/method[@name='inverse' and count(parameter)=2 and parameter[1][@type='double[]'] and parameter[2][@type='boolean']]"
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

		static Delegate cb_inverse_arrayDIZ;
#pragma warning disable 0169
		static Delegate GetInverse_arrayDIZHandler ()
		{
			if (cb_inverse_arrayDIZ == null)
				cb_inverse_arrayDIZ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, int, bool>) n_Inverse_arrayDIZ);
			return cb_inverse_arrayDIZ;
		}

		static void n_Inverse_arrayDIZ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, int p1, bool p2)
		{
			global::Org.Jtransforms.Dht.DoubleDHT_1D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Dht.DoubleDHT_1D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			double[] p0 = (double[]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (double));
			__this.Inverse (p0, p1, p2);
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
		}
#pragma warning restore 0169

		static IntPtr id_inverse_arrayDIZ;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.dht']/class[@name='DoubleDHT_1D']/method[@name='inverse' and count(parameter)=3 and parameter[1][@type='double[]'] and parameter[2][@type='int'] and parameter[3][@type='boolean']]"
		[Register ("inverse", "([DIZ)V", "GetInverse_arrayDIZHandler")]
		public virtual unsafe void Inverse (double[] p0, int p1, bool p2)
		{
			if (id_inverse_arrayDIZ == IntPtr.Zero)
				id_inverse_arrayDIZ = JNIEnv.GetMethodID (class_ref, "inverse", "([DIZ)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_inverse_arrayDIZ, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "inverse", "([DIZ)V"), __args);
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
			global::Org.Jtransforms.Dht.DoubleDHT_1D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Dht.DoubleDHT_1D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p0 = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Inverse (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_inverse_Lpl_edu_icm_jlargearrays_DoubleLargeArray_Z;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.dht']/class[@name='DoubleDHT_1D']/method[@name='inverse' and count(parameter)=2 and parameter[1][@type='pl.edu.icm.jlargearrays.DoubleLargeArray'] and parameter[2][@type='boolean']]"
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

		static Delegate cb_inverse_Lpl_edu_icm_jlargearrays_DoubleLargeArray_JZ;
#pragma warning disable 0169
		static Delegate GetInverse_Lpl_edu_icm_jlargearrays_DoubleLargeArray_JZHandler ()
		{
			if (cb_inverse_Lpl_edu_icm_jlargearrays_DoubleLargeArray_JZ == null)
				cb_inverse_Lpl_edu_icm_jlargearrays_DoubleLargeArray_JZ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, long, bool>) n_Inverse_Lpl_edu_icm_jlargearrays_DoubleLargeArray_JZ);
			return cb_inverse_Lpl_edu_icm_jlargearrays_DoubleLargeArray_JZ;
		}

		static void n_Inverse_Lpl_edu_icm_jlargearrays_DoubleLargeArray_JZ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, long p1, bool p2)
		{
			global::Org.Jtransforms.Dht.DoubleDHT_1D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Dht.DoubleDHT_1D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p0 = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Inverse (p0, p1, p2);
		}
#pragma warning restore 0169

		static IntPtr id_inverse_Lpl_edu_icm_jlargearrays_DoubleLargeArray_JZ;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.dht']/class[@name='DoubleDHT_1D']/method[@name='inverse' and count(parameter)=3 and parameter[1][@type='pl.edu.icm.jlargearrays.DoubleLargeArray'] and parameter[2][@type='long'] and parameter[3][@type='boolean']]"
		[Register ("inverse", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;JZ)V", "GetInverse_Lpl_edu_icm_jlargearrays_DoubleLargeArray_JZHandler")]
		public virtual unsafe void Inverse (global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p0, long p1, bool p2)
		{
			if (id_inverse_Lpl_edu_icm_jlargearrays_DoubleLargeArray_JZ == IntPtr.Zero)
				id_inverse_Lpl_edu_icm_jlargearrays_DoubleLargeArray_JZ = JNIEnv.GetMethodID (class_ref, "inverse", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;JZ)V");
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_inverse_Lpl_edu_icm_jlargearrays_DoubleLargeArray_JZ, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "inverse", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;JZ)V"), __args);
			} finally {
			}
		}

	}
}
