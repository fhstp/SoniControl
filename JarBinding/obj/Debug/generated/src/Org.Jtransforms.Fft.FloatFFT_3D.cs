using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Org.Jtransforms.Fft {

	// Metadata.xml XPath class reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='FloatFFT_3D']"
	[global::Android.Runtime.Register ("org/jtransforms/fft/FloatFFT_3D", DoNotGenerateAcw=true)]
	public partial class FloatFFT_3D : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("org/jtransforms/fft/FloatFFT_3D", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (FloatFFT_3D); }
		}

		protected FloatFFT_3D (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor_JJJ;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='FloatFFT_3D']/constructor[@name='FloatFFT_3D' and count(parameter)=3 and parameter[1][@type='long'] and parameter[2][@type='long'] and parameter[3][@type='long']]"
		[Register (".ctor", "(JJJ)V", "")]
		public unsafe FloatFFT_3D (long p0, long p1, long p2)
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				if (((object) this).GetType () != typeof (FloatFFT_3D)) {
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
			global::Org.Jtransforms.Fft.FloatFFT_3D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.FloatFFT_3D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			float[] p0 = (float[]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (float));
			__this.ComplexForward (p0);
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
		}
#pragma warning restore 0169

		static IntPtr id_complexForward_arrayF;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='FloatFFT_3D']/method[@name='complexForward' and count(parameter)=1 and parameter[1][@type='float[]']]"
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

		static Delegate cb_complexForward_arrayarrayarrayF;
#pragma warning disable 0169
		static Delegate GetComplexForward_arrayarrayarrayFHandler ()
		{
			if (cb_complexForward_arrayarrayarrayF == null)
				cb_complexForward_arrayarrayarrayF = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_ComplexForward_arrayarrayarrayF);
			return cb_complexForward_arrayarrayarrayF;
		}

		static void n_ComplexForward_arrayarrayarrayF (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Org.Jtransforms.Fft.FloatFFT_3D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.FloatFFT_3D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			float[][][] p0 = (float[][][]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (float[][]));
			__this.ComplexForward (p0);
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
		}
#pragma warning restore 0169

		static IntPtr id_complexForward_arrayarrayarrayF;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='FloatFFT_3D']/method[@name='complexForward' and count(parameter)=1 and parameter[1][@type='float[][][]']]"
		[Register ("complexForward", "([[[F)V", "GetComplexForward_arrayarrayarrayFHandler")]
		public virtual unsafe void ComplexForward (float[][][] p0)
		{
			if (id_complexForward_arrayarrayarrayF == IntPtr.Zero)
				id_complexForward_arrayarrayarrayF = JNIEnv.GetMethodID (class_ref, "complexForward", "([[[F)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_complexForward_arrayarrayarrayF, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "complexForward", "([[[F)V"), __args);
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
			global::Org.Jtransforms.Fft.FloatFFT_3D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.FloatFFT_3D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p0 = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.FloatLargeArray> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.ComplexForward (p0);
		}
#pragma warning restore 0169

		static IntPtr id_complexForward_Lpl_edu_icm_jlargearrays_FloatLargeArray_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='FloatFFT_3D']/method[@name='complexForward' and count(parameter)=1 and parameter[1][@type='pl.edu.icm.jlargearrays.FloatLargeArray']]"
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
			global::Org.Jtransforms.Fft.FloatFFT_3D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.FloatFFT_3D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			float[] p0 = (float[]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (float));
			__this.ComplexInverse (p0, p1);
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
		}
#pragma warning restore 0169

		static IntPtr id_complexInverse_arrayFZ;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='FloatFFT_3D']/method[@name='complexInverse' and count(parameter)=2 and parameter[1][@type='float[]'] and parameter[2][@type='boolean']]"
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

		static Delegate cb_complexInverse_arrayarrayarrayFZ;
#pragma warning disable 0169
		static Delegate GetComplexInverse_arrayarrayarrayFZHandler ()
		{
			if (cb_complexInverse_arrayarrayarrayFZ == null)
				cb_complexInverse_arrayarrayarrayFZ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, bool>) n_ComplexInverse_arrayarrayarrayFZ);
			return cb_complexInverse_arrayarrayarrayFZ;
		}

		static void n_ComplexInverse_arrayarrayarrayFZ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, bool p1)
		{
			global::Org.Jtransforms.Fft.FloatFFT_3D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.FloatFFT_3D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			float[][][] p0 = (float[][][]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (float[][]));
			__this.ComplexInverse (p0, p1);
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
		}
#pragma warning restore 0169

		static IntPtr id_complexInverse_arrayarrayarrayFZ;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='FloatFFT_3D']/method[@name='complexInverse' and count(parameter)=2 and parameter[1][@type='float[][][]'] and parameter[2][@type='boolean']]"
		[Register ("complexInverse", "([[[FZ)V", "GetComplexInverse_arrayarrayarrayFZHandler")]
		public virtual unsafe void ComplexInverse (float[][][] p0, bool p1)
		{
			if (id_complexInverse_arrayarrayarrayFZ == IntPtr.Zero)
				id_complexInverse_arrayarrayarrayFZ = JNIEnv.GetMethodID (class_ref, "complexInverse", "([[[FZ)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_complexInverse_arrayarrayarrayFZ, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "complexInverse", "([[[FZ)V"), __args);
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
			global::Org.Jtransforms.Fft.FloatFFT_3D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.FloatFFT_3D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p0 = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.FloatLargeArray> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.ComplexInverse (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_complexInverse_Lpl_edu_icm_jlargearrays_FloatLargeArray_Z;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='FloatFFT_3D']/method[@name='complexInverse' and count(parameter)=2 and parameter[1][@type='pl.edu.icm.jlargearrays.FloatLargeArray'] and parameter[2][@type='boolean']]"
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
			global::Org.Jtransforms.Fft.FloatFFT_3D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.FloatFFT_3D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			float[] p0 = (float[]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (float));
			__this.RealForward (p0);
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
		}
#pragma warning restore 0169

		static IntPtr id_realForward_arrayF;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='FloatFFT_3D']/method[@name='realForward' and count(parameter)=1 and parameter[1][@type='float[]']]"
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

		static Delegate cb_realForward_arrayarrayarrayF;
#pragma warning disable 0169
		static Delegate GetRealForward_arrayarrayarrayFHandler ()
		{
			if (cb_realForward_arrayarrayarrayF == null)
				cb_realForward_arrayarrayarrayF = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_RealForward_arrayarrayarrayF);
			return cb_realForward_arrayarrayarrayF;
		}

		static void n_RealForward_arrayarrayarrayF (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Org.Jtransforms.Fft.FloatFFT_3D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.FloatFFT_3D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			float[][][] p0 = (float[][][]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (float[][]));
			__this.RealForward (p0);
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
		}
#pragma warning restore 0169

		static IntPtr id_realForward_arrayarrayarrayF;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='FloatFFT_3D']/method[@name='realForward' and count(parameter)=1 and parameter[1][@type='float[][][]']]"
		[Register ("realForward", "([[[F)V", "GetRealForward_arrayarrayarrayFHandler")]
		public virtual unsafe void RealForward (float[][][] p0)
		{
			if (id_realForward_arrayarrayarrayF == IntPtr.Zero)
				id_realForward_arrayarrayarrayF = JNIEnv.GetMethodID (class_ref, "realForward", "([[[F)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_realForward_arrayarrayarrayF, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "realForward", "([[[F)V"), __args);
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
			global::Org.Jtransforms.Fft.FloatFFT_3D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.FloatFFT_3D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p0 = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.FloatLargeArray> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.RealForward (p0);
		}
#pragma warning restore 0169

		static IntPtr id_realForward_Lpl_edu_icm_jlargearrays_FloatLargeArray_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='FloatFFT_3D']/method[@name='realForward' and count(parameter)=1 and parameter[1][@type='pl.edu.icm.jlargearrays.FloatLargeArray']]"
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
			global::Org.Jtransforms.Fft.FloatFFT_3D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.FloatFFT_3D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			float[] p0 = (float[]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (float));
			__this.RealForwardFull (p0);
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
		}
#pragma warning restore 0169

		static IntPtr id_realForwardFull_arrayF;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='FloatFFT_3D']/method[@name='realForwardFull' and count(parameter)=1 and parameter[1][@type='float[]']]"
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

		static Delegate cb_realForwardFull_arrayarrayarrayF;
#pragma warning disable 0169
		static Delegate GetRealForwardFull_arrayarrayarrayFHandler ()
		{
			if (cb_realForwardFull_arrayarrayarrayF == null)
				cb_realForwardFull_arrayarrayarrayF = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_RealForwardFull_arrayarrayarrayF);
			return cb_realForwardFull_arrayarrayarrayF;
		}

		static void n_RealForwardFull_arrayarrayarrayF (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Org.Jtransforms.Fft.FloatFFT_3D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.FloatFFT_3D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			float[][][] p0 = (float[][][]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (float[][]));
			__this.RealForwardFull (p0);
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
		}
#pragma warning restore 0169

		static IntPtr id_realForwardFull_arrayarrayarrayF;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='FloatFFT_3D']/method[@name='realForwardFull' and count(parameter)=1 and parameter[1][@type='float[][][]']]"
		[Register ("realForwardFull", "([[[F)V", "GetRealForwardFull_arrayarrayarrayFHandler")]
		public virtual unsafe void RealForwardFull (float[][][] p0)
		{
			if (id_realForwardFull_arrayarrayarrayF == IntPtr.Zero)
				id_realForwardFull_arrayarrayarrayF = JNIEnv.GetMethodID (class_ref, "realForwardFull", "([[[F)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_realForwardFull_arrayarrayarrayF, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "realForwardFull", "([[[F)V"), __args);
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
			global::Org.Jtransforms.Fft.FloatFFT_3D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.FloatFFT_3D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p0 = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.FloatLargeArray> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.RealForwardFull (p0);
		}
#pragma warning restore 0169

		static IntPtr id_realForwardFull_Lpl_edu_icm_jlargearrays_FloatLargeArray_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='FloatFFT_3D']/method[@name='realForwardFull' and count(parameter)=1 and parameter[1][@type='pl.edu.icm.jlargearrays.FloatLargeArray']]"
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
			global::Org.Jtransforms.Fft.FloatFFT_3D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.FloatFFT_3D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			float[] p0 = (float[]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (float));
			__this.RealInverse (p0, p1);
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
		}
#pragma warning restore 0169

		static IntPtr id_realInverse_arrayFZ;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='FloatFFT_3D']/method[@name='realInverse' and count(parameter)=2 and parameter[1][@type='float[]'] and parameter[2][@type='boolean']]"
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

		static Delegate cb_realInverse_arrayarrayarrayFZ;
#pragma warning disable 0169
		static Delegate GetRealInverse_arrayarrayarrayFZHandler ()
		{
			if (cb_realInverse_arrayarrayarrayFZ == null)
				cb_realInverse_arrayarrayarrayFZ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, bool>) n_RealInverse_arrayarrayarrayFZ);
			return cb_realInverse_arrayarrayarrayFZ;
		}

		static void n_RealInverse_arrayarrayarrayFZ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, bool p1)
		{
			global::Org.Jtransforms.Fft.FloatFFT_3D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.FloatFFT_3D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			float[][][] p0 = (float[][][]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (float[][]));
			__this.RealInverse (p0, p1);
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
		}
#pragma warning restore 0169

		static IntPtr id_realInverse_arrayarrayarrayFZ;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='FloatFFT_3D']/method[@name='realInverse' and count(parameter)=2 and parameter[1][@type='float[][][]'] and parameter[2][@type='boolean']]"
		[Register ("realInverse", "([[[FZ)V", "GetRealInverse_arrayarrayarrayFZHandler")]
		public virtual unsafe void RealInverse (float[][][] p0, bool p1)
		{
			if (id_realInverse_arrayarrayarrayFZ == IntPtr.Zero)
				id_realInverse_arrayarrayarrayFZ = JNIEnv.GetMethodID (class_ref, "realInverse", "([[[FZ)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_realInverse_arrayarrayarrayFZ, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "realInverse", "([[[FZ)V"), __args);
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
			global::Org.Jtransforms.Fft.FloatFFT_3D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.FloatFFT_3D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p0 = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.FloatLargeArray> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.RealInverse (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_realInverse_Lpl_edu_icm_jlargearrays_FloatLargeArray_Z;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='FloatFFT_3D']/method[@name='realInverse' and count(parameter)=2 and parameter[1][@type='pl.edu.icm.jlargearrays.FloatLargeArray'] and parameter[2][@type='boolean']]"
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
			global::Org.Jtransforms.Fft.FloatFFT_3D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.FloatFFT_3D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			float[] p0 = (float[]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (float));
			__this.RealInverseFull (p0, p1);
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
		}
#pragma warning restore 0169

		static IntPtr id_realInverseFull_arrayFZ;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='FloatFFT_3D']/method[@name='realInverseFull' and count(parameter)=2 and parameter[1][@type='float[]'] and parameter[2][@type='boolean']]"
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

		static Delegate cb_realInverseFull_arrayarrayarrayFZ;
#pragma warning disable 0169
		static Delegate GetRealInverseFull_arrayarrayarrayFZHandler ()
		{
			if (cb_realInverseFull_arrayarrayarrayFZ == null)
				cb_realInverseFull_arrayarrayarrayFZ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, bool>) n_RealInverseFull_arrayarrayarrayFZ);
			return cb_realInverseFull_arrayarrayarrayFZ;
		}

		static void n_RealInverseFull_arrayarrayarrayFZ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, bool p1)
		{
			global::Org.Jtransforms.Fft.FloatFFT_3D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.FloatFFT_3D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			float[][][] p0 = (float[][][]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (float[][]));
			__this.RealInverseFull (p0, p1);
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
		}
#pragma warning restore 0169

		static IntPtr id_realInverseFull_arrayarrayarrayFZ;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='FloatFFT_3D']/method[@name='realInverseFull' and count(parameter)=2 and parameter[1][@type='float[][][]'] and parameter[2][@type='boolean']]"
		[Register ("realInverseFull", "([[[FZ)V", "GetRealInverseFull_arrayarrayarrayFZHandler")]
		public virtual unsafe void RealInverseFull (float[][][] p0, bool p1)
		{
			if (id_realInverseFull_arrayarrayarrayFZ == IntPtr.Zero)
				id_realInverseFull_arrayarrayarrayFZ = JNIEnv.GetMethodID (class_ref, "realInverseFull", "([[[FZ)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_realInverseFull_arrayarrayarrayFZ, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "realInverseFull", "([[[FZ)V"), __args);
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
			global::Org.Jtransforms.Fft.FloatFFT_3D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.FloatFFT_3D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p0 = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.FloatLargeArray> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.RealInverseFull (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_realInverseFull_Lpl_edu_icm_jlargearrays_FloatLargeArray_Z;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='FloatFFT_3D']/method[@name='realInverseFull' and count(parameter)=2 and parameter[1][@type='pl.edu.icm.jlargearrays.FloatLargeArray'] and parameter[2][@type='boolean']]"
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
