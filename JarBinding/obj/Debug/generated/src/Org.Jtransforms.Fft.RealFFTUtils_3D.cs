using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Org.Jtransforms.Fft {

	// Metadata.xml XPath class reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='RealFFTUtils_3D']"
	[global::Android.Runtime.Register ("org/jtransforms/fft/RealFFTUtils_3D", DoNotGenerateAcw=true)]
	public partial class RealFFTUtils_3D : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("org/jtransforms/fft/RealFFTUtils_3D", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (RealFFTUtils_3D); }
		}

		protected RealFFTUtils_3D (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor_JJJ;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='RealFFTUtils_3D']/constructor[@name='RealFFTUtils_3D' and count(parameter)=3 and parameter[1][@type='long'] and parameter[2][@type='long'] and parameter[3][@type='long']]"
		[Register (".ctor", "(JJJ)V", "")]
		public unsafe RealFFTUtils_3D (long p0, long p1, long p2)
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				if (((object) this).GetType () != typeof (RealFFTUtils_3D)) {
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

		static Delegate cb_getIndex_III;
#pragma warning disable 0169
		static Delegate GetGetIndex_IIIHandler ()
		{
			if (cb_getIndex_III == null)
				cb_getIndex_III = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int, int, int, int>) n_GetIndex_III);
			return cb_getIndex_III;
		}

		static int n_GetIndex_III (IntPtr jnienv, IntPtr native__this, int p0, int p1, int p2)
		{
			global::Org.Jtransforms.Fft.RealFFTUtils_3D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.RealFFTUtils_3D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.GetIndex (p0, p1, p2);
		}
#pragma warning restore 0169

		static IntPtr id_getIndex_III;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='RealFFTUtils_3D']/method[@name='getIndex' and count(parameter)=3 and parameter[1][@type='int'] and parameter[2][@type='int'] and parameter[3][@type='int']]"
		[Register ("getIndex", "(III)I", "GetGetIndex_IIIHandler")]
		public virtual unsafe int GetIndex (int p0, int p1, int p2)
		{
			if (id_getIndex_III == IntPtr.Zero)
				id_getIndex_III = JNIEnv.GetMethodID (class_ref, "getIndex", "(III)I");
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);

				if (((object) this).GetType () == ThresholdType)
					return JNIEnv.CallIntMethod (((global::Java.Lang.Object) this).Handle, id_getIndex_III, __args);
				else
					return JNIEnv.CallNonvirtualIntMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getIndex", "(III)I"), __args);
			} finally {
			}
		}

		static Delegate cb_getIndex_JJJ;
#pragma warning disable 0169
		static Delegate GetGetIndex_JJJHandler ()
		{
			if (cb_getIndex_JJJ == null)
				cb_getIndex_JJJ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, long, long, long, long>) n_GetIndex_JJJ);
			return cb_getIndex_JJJ;
		}

		static long n_GetIndex_JJJ (IntPtr jnienv, IntPtr native__this, long p0, long p1, long p2)
		{
			global::Org.Jtransforms.Fft.RealFFTUtils_3D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.RealFFTUtils_3D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.GetIndex (p0, p1, p2);
		}
#pragma warning restore 0169

		static IntPtr id_getIndex_JJJ;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='RealFFTUtils_3D']/method[@name='getIndex' and count(parameter)=3 and parameter[1][@type='long'] and parameter[2][@type='long'] and parameter[3][@type='long']]"
		[Register ("getIndex", "(JJJ)J", "GetGetIndex_JJJHandler")]
		public virtual unsafe long GetIndex (long p0, long p1, long p2)
		{
			if (id_getIndex_JJJ == IntPtr.Zero)
				id_getIndex_JJJ = JNIEnv.GetMethodID (class_ref, "getIndex", "(JJJ)J");
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);

				if (((object) this).GetType () == ThresholdType)
					return JNIEnv.CallLongMethod (((global::Java.Lang.Object) this).Handle, id_getIndex_JJJ, __args);
				else
					return JNIEnv.CallNonvirtualLongMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getIndex", "(JJJ)J"), __args);
			} finally {
			}
		}

		static Delegate cb_pack_DIIIarrayDI;
#pragma warning disable 0169
		static Delegate GetPack_DIIIarrayDIHandler ()
		{
			if (cb_pack_DIIIarrayDI == null)
				cb_pack_DIIIarrayDI = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, double, int, int, int, IntPtr, int>) n_Pack_DIIIarrayDI);
			return cb_pack_DIIIarrayDI;
		}

		static void n_Pack_DIIIarrayDI (IntPtr jnienv, IntPtr native__this, double p0, int p1, int p2, int p3, IntPtr native_p4, int p5)
		{
			global::Org.Jtransforms.Fft.RealFFTUtils_3D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.RealFFTUtils_3D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			double[] p4 = (double[]) JNIEnv.GetArray (native_p4, JniHandleOwnership.DoNotTransfer, typeof (double));
			__this.Pack (p0, p1, p2, p3, p4, p5);
			if (p4 != null)
				JNIEnv.CopyArray (p4, native_p4);
		}
#pragma warning restore 0169

		static IntPtr id_pack_DIIIarrayDI;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='RealFFTUtils_3D']/method[@name='pack' and count(parameter)=6 and parameter[1][@type='double'] and parameter[2][@type='int'] and parameter[3][@type='int'] and parameter[4][@type='int'] and parameter[5][@type='double[]'] and parameter[6][@type='int']]"
		[Register ("pack", "(DIII[DI)V", "GetPack_DIIIarrayDIHandler")]
		public virtual unsafe void Pack (double p0, int p1, int p2, int p3, double[] p4, int p5)
		{
			if (id_pack_DIIIarrayDI == IntPtr.Zero)
				id_pack_DIIIarrayDI = JNIEnv.GetMethodID (class_ref, "pack", "(DIII[DI)V");
			IntPtr native_p4 = JNIEnv.NewArray (p4);
			try {
				JValue* __args = stackalloc JValue [6];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (native_p4);
				__args [5] = new JValue (p5);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_pack_DIIIarrayDI, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "pack", "(DIII[DI)V"), __args);
			} finally {
				if (p4 != null) {
					JNIEnv.CopyArray (native_p4, p4);
					JNIEnv.DeleteLocalRef (native_p4);
				}
			}
		}

		static Delegate cb_pack_DIIIarrayarrayarrayD;
#pragma warning disable 0169
		static Delegate GetPack_DIIIarrayarrayarrayDHandler ()
		{
			if (cb_pack_DIIIarrayarrayarrayD == null)
				cb_pack_DIIIarrayarrayarrayD = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, double, int, int, int, IntPtr>) n_Pack_DIIIarrayarrayarrayD);
			return cb_pack_DIIIarrayarrayarrayD;
		}

		static void n_Pack_DIIIarrayarrayarrayD (IntPtr jnienv, IntPtr native__this, double p0, int p1, int p2, int p3, IntPtr native_p4)
		{
			global::Org.Jtransforms.Fft.RealFFTUtils_3D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.RealFFTUtils_3D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			double[][][] p4 = (double[][][]) JNIEnv.GetArray (native_p4, JniHandleOwnership.DoNotTransfer, typeof (double[][]));
			__this.Pack (p0, p1, p2, p3, p4);
			if (p4 != null)
				JNIEnv.CopyArray (p4, native_p4);
		}
#pragma warning restore 0169

		static IntPtr id_pack_DIIIarrayarrayarrayD;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='RealFFTUtils_3D']/method[@name='pack' and count(parameter)=5 and parameter[1][@type='double'] and parameter[2][@type='int'] and parameter[3][@type='int'] and parameter[4][@type='int'] and parameter[5][@type='double[][][]']]"
		[Register ("pack", "(DIII[[[D)V", "GetPack_DIIIarrayarrayarrayDHandler")]
		public virtual unsafe void Pack (double p0, int p1, int p2, int p3, double[][][] p4)
		{
			if (id_pack_DIIIarrayarrayarrayD == IntPtr.Zero)
				id_pack_DIIIarrayarrayarrayD = JNIEnv.GetMethodID (class_ref, "pack", "(DIII[[[D)V");
			IntPtr native_p4 = JNIEnv.NewArray (p4);
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (native_p4);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_pack_DIIIarrayarrayarrayD, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "pack", "(DIII[[[D)V"), __args);
			} finally {
				if (p4 != null) {
					JNIEnv.CopyArray (native_p4, p4);
					JNIEnv.DeleteLocalRef (native_p4);
				}
			}
		}

		static Delegate cb_pack_DJJJLpl_edu_icm_jlargearrays_DoubleLargeArray_J;
#pragma warning disable 0169
		static Delegate GetPack_DJJJLpl_edu_icm_jlargearrays_DoubleLargeArray_JHandler ()
		{
			if (cb_pack_DJJJLpl_edu_icm_jlargearrays_DoubleLargeArray_J == null)
				cb_pack_DJJJLpl_edu_icm_jlargearrays_DoubleLargeArray_J = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, double, long, long, long, IntPtr, long>) n_Pack_DJJJLpl_edu_icm_jlargearrays_DoubleLargeArray_J);
			return cb_pack_DJJJLpl_edu_icm_jlargearrays_DoubleLargeArray_J;
		}

		static void n_Pack_DJJJLpl_edu_icm_jlargearrays_DoubleLargeArray_J (IntPtr jnienv, IntPtr native__this, double p0, long p1, long p2, long p3, IntPtr native_p4, long p5)
		{
			global::Org.Jtransforms.Fft.RealFFTUtils_3D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.RealFFTUtils_3D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p4 = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray> (native_p4, JniHandleOwnership.DoNotTransfer);
			__this.Pack (p0, p1, p2, p3, p4, p5);
		}
#pragma warning restore 0169

		static IntPtr id_pack_DJJJLpl_edu_icm_jlargearrays_DoubleLargeArray_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='RealFFTUtils_3D']/method[@name='pack' and count(parameter)=6 and parameter[1][@type='double'] and parameter[2][@type='long'] and parameter[3][@type='long'] and parameter[4][@type='long'] and parameter[5][@type='pl.edu.icm.jlargearrays.DoubleLargeArray'] and parameter[6][@type='long']]"
		[Register ("pack", "(DJJJLpl/edu/icm/jlargearrays/DoubleLargeArray;J)V", "GetPack_DJJJLpl_edu_icm_jlargearrays_DoubleLargeArray_JHandler")]
		public virtual unsafe void Pack (double p0, long p1, long p2, long p3, global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p4, long p5)
		{
			if (id_pack_DJJJLpl_edu_icm_jlargearrays_DoubleLargeArray_J == IntPtr.Zero)
				id_pack_DJJJLpl_edu_icm_jlargearrays_DoubleLargeArray_J = JNIEnv.GetMethodID (class_ref, "pack", "(DJJJLpl/edu/icm/jlargearrays/DoubleLargeArray;J)V");
			try {
				JValue* __args = stackalloc JValue [6];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (p4);
				__args [5] = new JValue (p5);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_pack_DJJJLpl_edu_icm_jlargearrays_DoubleLargeArray_J, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "pack", "(DJJJLpl/edu/icm/jlargearrays/DoubleLargeArray;J)V"), __args);
			} finally {
			}
		}

		static Delegate cb_pack_FIIIarrayFI;
#pragma warning disable 0169
		static Delegate GetPack_FIIIarrayFIHandler ()
		{
			if (cb_pack_FIIIarrayFI == null)
				cb_pack_FIIIarrayFI = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, float, int, int, int, IntPtr, int>) n_Pack_FIIIarrayFI);
			return cb_pack_FIIIarrayFI;
		}

		static void n_Pack_FIIIarrayFI (IntPtr jnienv, IntPtr native__this, float p0, int p1, int p2, int p3, IntPtr native_p4, int p5)
		{
			global::Org.Jtransforms.Fft.RealFFTUtils_3D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.RealFFTUtils_3D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			float[] p4 = (float[]) JNIEnv.GetArray (native_p4, JniHandleOwnership.DoNotTransfer, typeof (float));
			__this.Pack (p0, p1, p2, p3, p4, p5);
			if (p4 != null)
				JNIEnv.CopyArray (p4, native_p4);
		}
#pragma warning restore 0169

		static IntPtr id_pack_FIIIarrayFI;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='RealFFTUtils_3D']/method[@name='pack' and count(parameter)=6 and parameter[1][@type='float'] and parameter[2][@type='int'] and parameter[3][@type='int'] and parameter[4][@type='int'] and parameter[5][@type='float[]'] and parameter[6][@type='int']]"
		[Register ("pack", "(FIII[FI)V", "GetPack_FIIIarrayFIHandler")]
		public virtual unsafe void Pack (float p0, int p1, int p2, int p3, float[] p4, int p5)
		{
			if (id_pack_FIIIarrayFI == IntPtr.Zero)
				id_pack_FIIIarrayFI = JNIEnv.GetMethodID (class_ref, "pack", "(FIII[FI)V");
			IntPtr native_p4 = JNIEnv.NewArray (p4);
			try {
				JValue* __args = stackalloc JValue [6];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (native_p4);
				__args [5] = new JValue (p5);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_pack_FIIIarrayFI, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "pack", "(FIII[FI)V"), __args);
			} finally {
				if (p4 != null) {
					JNIEnv.CopyArray (native_p4, p4);
					JNIEnv.DeleteLocalRef (native_p4);
				}
			}
		}

		static Delegate cb_pack_FIIIarrayarrayarrayF;
#pragma warning disable 0169
		static Delegate GetPack_FIIIarrayarrayarrayFHandler ()
		{
			if (cb_pack_FIIIarrayarrayarrayF == null)
				cb_pack_FIIIarrayarrayarrayF = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, float, int, int, int, IntPtr>) n_Pack_FIIIarrayarrayarrayF);
			return cb_pack_FIIIarrayarrayarrayF;
		}

		static void n_Pack_FIIIarrayarrayarrayF (IntPtr jnienv, IntPtr native__this, float p0, int p1, int p2, int p3, IntPtr native_p4)
		{
			global::Org.Jtransforms.Fft.RealFFTUtils_3D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.RealFFTUtils_3D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			float[][][] p4 = (float[][][]) JNIEnv.GetArray (native_p4, JniHandleOwnership.DoNotTransfer, typeof (float[][]));
			__this.Pack (p0, p1, p2, p3, p4);
			if (p4 != null)
				JNIEnv.CopyArray (p4, native_p4);
		}
#pragma warning restore 0169

		static IntPtr id_pack_FIIIarrayarrayarrayF;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='RealFFTUtils_3D']/method[@name='pack' and count(parameter)=5 and parameter[1][@type='float'] and parameter[2][@type='int'] and parameter[3][@type='int'] and parameter[4][@type='int'] and parameter[5][@type='float[][][]']]"
		[Register ("pack", "(FIII[[[F)V", "GetPack_FIIIarrayarrayarrayFHandler")]
		public virtual unsafe void Pack (float p0, int p1, int p2, int p3, float[][][] p4)
		{
			if (id_pack_FIIIarrayarrayarrayF == IntPtr.Zero)
				id_pack_FIIIarrayarrayarrayF = JNIEnv.GetMethodID (class_ref, "pack", "(FIII[[[F)V");
			IntPtr native_p4 = JNIEnv.NewArray (p4);
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (native_p4);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_pack_FIIIarrayarrayarrayF, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "pack", "(FIII[[[F)V"), __args);
			} finally {
				if (p4 != null) {
					JNIEnv.CopyArray (native_p4, p4);
					JNIEnv.DeleteLocalRef (native_p4);
				}
			}
		}

		static Delegate cb_pack_FJJJLpl_edu_icm_jlargearrays_FloatLargeArray_J;
#pragma warning disable 0169
		static Delegate GetPack_FJJJLpl_edu_icm_jlargearrays_FloatLargeArray_JHandler ()
		{
			if (cb_pack_FJJJLpl_edu_icm_jlargearrays_FloatLargeArray_J == null)
				cb_pack_FJJJLpl_edu_icm_jlargearrays_FloatLargeArray_J = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, float, long, long, long, IntPtr, long>) n_Pack_FJJJLpl_edu_icm_jlargearrays_FloatLargeArray_J);
			return cb_pack_FJJJLpl_edu_icm_jlargearrays_FloatLargeArray_J;
		}

		static void n_Pack_FJJJLpl_edu_icm_jlargearrays_FloatLargeArray_J (IntPtr jnienv, IntPtr native__this, float p0, long p1, long p2, long p3, IntPtr native_p4, long p5)
		{
			global::Org.Jtransforms.Fft.RealFFTUtils_3D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.RealFFTUtils_3D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p4 = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.FloatLargeArray> (native_p4, JniHandleOwnership.DoNotTransfer);
			__this.Pack (p0, p1, p2, p3, p4, p5);
		}
#pragma warning restore 0169

		static IntPtr id_pack_FJJJLpl_edu_icm_jlargearrays_FloatLargeArray_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='RealFFTUtils_3D']/method[@name='pack' and count(parameter)=6 and parameter[1][@type='float'] and parameter[2][@type='long'] and parameter[3][@type='long'] and parameter[4][@type='long'] and parameter[5][@type='pl.edu.icm.jlargearrays.FloatLargeArray'] and parameter[6][@type='long']]"
		[Register ("pack", "(FJJJLpl/edu/icm/jlargearrays/FloatLargeArray;J)V", "GetPack_FJJJLpl_edu_icm_jlargearrays_FloatLargeArray_JHandler")]
		public virtual unsafe void Pack (float p0, long p1, long p2, long p3, global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p4, long p5)
		{
			if (id_pack_FJJJLpl_edu_icm_jlargearrays_FloatLargeArray_J == IntPtr.Zero)
				id_pack_FJJJLpl_edu_icm_jlargearrays_FloatLargeArray_J = JNIEnv.GetMethodID (class_ref, "pack", "(FJJJLpl/edu/icm/jlargearrays/FloatLargeArray;J)V");
			try {
				JValue* __args = stackalloc JValue [6];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (p4);
				__args [5] = new JValue (p5);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_pack_FJJJLpl_edu_icm_jlargearrays_FloatLargeArray_J, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "pack", "(FJJJLpl/edu/icm/jlargearrays/FloatLargeArray;J)V"), __args);
			} finally {
			}
		}

		static Delegate cb_unpack_IIIarrayDI;
#pragma warning disable 0169
		static Delegate GetUnpack_IIIarrayDIHandler ()
		{
			if (cb_unpack_IIIarrayDI == null)
				cb_unpack_IIIarrayDI = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int, int, int, IntPtr, int, double>) n_Unpack_IIIarrayDI);
			return cb_unpack_IIIarrayDI;
		}

		static double n_Unpack_IIIarrayDI (IntPtr jnienv, IntPtr native__this, int p0, int p1, int p2, IntPtr native_p3, int p4)
		{
			global::Org.Jtransforms.Fft.RealFFTUtils_3D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.RealFFTUtils_3D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			double[] p3 = (double[]) JNIEnv.GetArray (native_p3, JniHandleOwnership.DoNotTransfer, typeof (double));
			double __ret = __this.Unpack (p0, p1, p2, p3, p4);
			if (p3 != null)
				JNIEnv.CopyArray (p3, native_p3);
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_unpack_IIIarrayDI;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='RealFFTUtils_3D']/method[@name='unpack' and count(parameter)=5 and parameter[1][@type='int'] and parameter[2][@type='int'] and parameter[3][@type='int'] and parameter[4][@type='double[]'] and parameter[5][@type='int']]"
		[Register ("unpack", "(III[DI)D", "GetUnpack_IIIarrayDIHandler")]
		public virtual unsafe double Unpack (int p0, int p1, int p2, double[] p3, int p4)
		{
			if (id_unpack_IIIarrayDI == IntPtr.Zero)
				id_unpack_IIIarrayDI = JNIEnv.GetMethodID (class_ref, "unpack", "(III[DI)D");
			IntPtr native_p3 = JNIEnv.NewArray (p3);
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (native_p3);
				__args [4] = new JValue (p4);

				double __ret;
				if (((object) this).GetType () == ThresholdType)
					__ret = JNIEnv.CallDoubleMethod (((global::Java.Lang.Object) this).Handle, id_unpack_IIIarrayDI, __args);
				else
					__ret = JNIEnv.CallNonvirtualDoubleMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "unpack", "(III[DI)D"), __args);
				return __ret;
			} finally {
				if (p3 != null) {
					JNIEnv.CopyArray (native_p3, p3);
					JNIEnv.DeleteLocalRef (native_p3);
				}
			}
		}

		static Delegate cb_unpack_IIIarrayarrayarrayD;
#pragma warning disable 0169
		static Delegate GetUnpack_IIIarrayarrayarrayDHandler ()
		{
			if (cb_unpack_IIIarrayarrayarrayD == null)
				cb_unpack_IIIarrayarrayarrayD = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int, int, int, IntPtr, double>) n_Unpack_IIIarrayarrayarrayD);
			return cb_unpack_IIIarrayarrayarrayD;
		}

		static double n_Unpack_IIIarrayarrayarrayD (IntPtr jnienv, IntPtr native__this, int p0, int p1, int p2, IntPtr native_p3)
		{
			global::Org.Jtransforms.Fft.RealFFTUtils_3D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.RealFFTUtils_3D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			double[][][] p3 = (double[][][]) JNIEnv.GetArray (native_p3, JniHandleOwnership.DoNotTransfer, typeof (double[][]));
			double __ret = __this.Unpack (p0, p1, p2, p3);
			if (p3 != null)
				JNIEnv.CopyArray (p3, native_p3);
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_unpack_IIIarrayarrayarrayD;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='RealFFTUtils_3D']/method[@name='unpack' and count(parameter)=4 and parameter[1][@type='int'] and parameter[2][@type='int'] and parameter[3][@type='int'] and parameter[4][@type='double[][][]']]"
		[Register ("unpack", "(III[[[D)D", "GetUnpack_IIIarrayarrayarrayDHandler")]
		public virtual unsafe double Unpack (int p0, int p1, int p2, double[][][] p3)
		{
			if (id_unpack_IIIarrayarrayarrayD == IntPtr.Zero)
				id_unpack_IIIarrayarrayarrayD = JNIEnv.GetMethodID (class_ref, "unpack", "(III[[[D)D");
			IntPtr native_p3 = JNIEnv.NewArray (p3);
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (native_p3);

				double __ret;
				if (((object) this).GetType () == ThresholdType)
					__ret = JNIEnv.CallDoubleMethod (((global::Java.Lang.Object) this).Handle, id_unpack_IIIarrayarrayarrayD, __args);
				else
					__ret = JNIEnv.CallNonvirtualDoubleMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "unpack", "(III[[[D)D"), __args);
				return __ret;
			} finally {
				if (p3 != null) {
					JNIEnv.CopyArray (native_p3, p3);
					JNIEnv.DeleteLocalRef (native_p3);
				}
			}
		}

		static Delegate cb_unpack_IIIarrayFI;
#pragma warning disable 0169
		static Delegate GetUnpack_IIIarrayFIHandler ()
		{
			if (cb_unpack_IIIarrayFI == null)
				cb_unpack_IIIarrayFI = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int, int, int, IntPtr, int, float>) n_Unpack_IIIarrayFI);
			return cb_unpack_IIIarrayFI;
		}

		static float n_Unpack_IIIarrayFI (IntPtr jnienv, IntPtr native__this, int p0, int p1, int p2, IntPtr native_p3, int p4)
		{
			global::Org.Jtransforms.Fft.RealFFTUtils_3D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.RealFFTUtils_3D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			float[] p3 = (float[]) JNIEnv.GetArray (native_p3, JniHandleOwnership.DoNotTransfer, typeof (float));
			float __ret = __this.Unpack (p0, p1, p2, p3, p4);
			if (p3 != null)
				JNIEnv.CopyArray (p3, native_p3);
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_unpack_IIIarrayFI;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='RealFFTUtils_3D']/method[@name='unpack' and count(parameter)=5 and parameter[1][@type='int'] and parameter[2][@type='int'] and parameter[3][@type='int'] and parameter[4][@type='float[]'] and parameter[5][@type='int']]"
		[Register ("unpack", "(III[FI)F", "GetUnpack_IIIarrayFIHandler")]
		public virtual unsafe float Unpack (int p0, int p1, int p2, float[] p3, int p4)
		{
			if (id_unpack_IIIarrayFI == IntPtr.Zero)
				id_unpack_IIIarrayFI = JNIEnv.GetMethodID (class_ref, "unpack", "(III[FI)F");
			IntPtr native_p3 = JNIEnv.NewArray (p3);
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (native_p3);
				__args [4] = new JValue (p4);

				float __ret;
				if (((object) this).GetType () == ThresholdType)
					__ret = JNIEnv.CallFloatMethod (((global::Java.Lang.Object) this).Handle, id_unpack_IIIarrayFI, __args);
				else
					__ret = JNIEnv.CallNonvirtualFloatMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "unpack", "(III[FI)F"), __args);
				return __ret;
			} finally {
				if (p3 != null) {
					JNIEnv.CopyArray (native_p3, p3);
					JNIEnv.DeleteLocalRef (native_p3);
				}
			}
		}

		static Delegate cb_unpack_IIIarrayarrayarrayF;
#pragma warning disable 0169
		static Delegate GetUnpack_IIIarrayarrayarrayFHandler ()
		{
			if (cb_unpack_IIIarrayarrayarrayF == null)
				cb_unpack_IIIarrayarrayarrayF = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int, int, int, IntPtr, float>) n_Unpack_IIIarrayarrayarrayF);
			return cb_unpack_IIIarrayarrayarrayF;
		}

		static float n_Unpack_IIIarrayarrayarrayF (IntPtr jnienv, IntPtr native__this, int p0, int p1, int p2, IntPtr native_p3)
		{
			global::Org.Jtransforms.Fft.RealFFTUtils_3D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.RealFFTUtils_3D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			float[][][] p3 = (float[][][]) JNIEnv.GetArray (native_p3, JniHandleOwnership.DoNotTransfer, typeof (float[][]));
			float __ret = __this.Unpack (p0, p1, p2, p3);
			if (p3 != null)
				JNIEnv.CopyArray (p3, native_p3);
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_unpack_IIIarrayarrayarrayF;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='RealFFTUtils_3D']/method[@name='unpack' and count(parameter)=4 and parameter[1][@type='int'] and parameter[2][@type='int'] and parameter[3][@type='int'] and parameter[4][@type='float[][][]']]"
		[Register ("unpack", "(III[[[F)F", "GetUnpack_IIIarrayarrayarrayFHandler")]
		public virtual unsafe float Unpack (int p0, int p1, int p2, float[][][] p3)
		{
			if (id_unpack_IIIarrayarrayarrayF == IntPtr.Zero)
				id_unpack_IIIarrayarrayarrayF = JNIEnv.GetMethodID (class_ref, "unpack", "(III[[[F)F");
			IntPtr native_p3 = JNIEnv.NewArray (p3);
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (native_p3);

				float __ret;
				if (((object) this).GetType () == ThresholdType)
					__ret = JNIEnv.CallFloatMethod (((global::Java.Lang.Object) this).Handle, id_unpack_IIIarrayarrayarrayF, __args);
				else
					__ret = JNIEnv.CallNonvirtualFloatMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "unpack", "(III[[[F)F"), __args);
				return __ret;
			} finally {
				if (p3 != null) {
					JNIEnv.CopyArray (native_p3, p3);
					JNIEnv.DeleteLocalRef (native_p3);
				}
			}
		}

		static Delegate cb_unpack_JJJLpl_edu_icm_jlargearrays_DoubleLargeArray_J;
#pragma warning disable 0169
		static Delegate GetUnpack_JJJLpl_edu_icm_jlargearrays_DoubleLargeArray_JHandler ()
		{
			if (cb_unpack_JJJLpl_edu_icm_jlargearrays_DoubleLargeArray_J == null)
				cb_unpack_JJJLpl_edu_icm_jlargearrays_DoubleLargeArray_J = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, long, long, long, IntPtr, long, double>) n_Unpack_JJJLpl_edu_icm_jlargearrays_DoubleLargeArray_J);
			return cb_unpack_JJJLpl_edu_icm_jlargearrays_DoubleLargeArray_J;
		}

		static double n_Unpack_JJJLpl_edu_icm_jlargearrays_DoubleLargeArray_J (IntPtr jnienv, IntPtr native__this, long p0, long p1, long p2, IntPtr native_p3, long p4)
		{
			global::Org.Jtransforms.Fft.RealFFTUtils_3D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.RealFFTUtils_3D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p3 = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray> (native_p3, JniHandleOwnership.DoNotTransfer);
			double __ret = __this.Unpack (p0, p1, p2, p3, p4);
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_unpack_JJJLpl_edu_icm_jlargearrays_DoubleLargeArray_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='RealFFTUtils_3D']/method[@name='unpack' and count(parameter)=5 and parameter[1][@type='long'] and parameter[2][@type='long'] and parameter[3][@type='long'] and parameter[4][@type='pl.edu.icm.jlargearrays.DoubleLargeArray'] and parameter[5][@type='long']]"
		[Register ("unpack", "(JJJLpl/edu/icm/jlargearrays/DoubleLargeArray;J)D", "GetUnpack_JJJLpl_edu_icm_jlargearrays_DoubleLargeArray_JHandler")]
		public virtual unsafe double Unpack (long p0, long p1, long p2, global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p3, long p4)
		{
			if (id_unpack_JJJLpl_edu_icm_jlargearrays_DoubleLargeArray_J == IntPtr.Zero)
				id_unpack_JJJLpl_edu_icm_jlargearrays_DoubleLargeArray_J = JNIEnv.GetMethodID (class_ref, "unpack", "(JJJLpl/edu/icm/jlargearrays/DoubleLargeArray;J)D");
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (p4);

				double __ret;
				if (((object) this).GetType () == ThresholdType)
					__ret = JNIEnv.CallDoubleMethod (((global::Java.Lang.Object) this).Handle, id_unpack_JJJLpl_edu_icm_jlargearrays_DoubleLargeArray_J, __args);
				else
					__ret = JNIEnv.CallNonvirtualDoubleMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "unpack", "(JJJLpl/edu/icm/jlargearrays/DoubleLargeArray;J)D"), __args);
				return __ret;
			} finally {
			}
		}

		static Delegate cb_unpack_JJJLpl_edu_icm_jlargearrays_FloatLargeArray_J;
#pragma warning disable 0169
		static Delegate GetUnpack_JJJLpl_edu_icm_jlargearrays_FloatLargeArray_JHandler ()
		{
			if (cb_unpack_JJJLpl_edu_icm_jlargearrays_FloatLargeArray_J == null)
				cb_unpack_JJJLpl_edu_icm_jlargearrays_FloatLargeArray_J = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, long, long, long, IntPtr, long, float>) n_Unpack_JJJLpl_edu_icm_jlargearrays_FloatLargeArray_J);
			return cb_unpack_JJJLpl_edu_icm_jlargearrays_FloatLargeArray_J;
		}

		static float n_Unpack_JJJLpl_edu_icm_jlargearrays_FloatLargeArray_J (IntPtr jnienv, IntPtr native__this, long p0, long p1, long p2, IntPtr native_p3, long p4)
		{
			global::Org.Jtransforms.Fft.RealFFTUtils_3D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.RealFFTUtils_3D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p3 = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.FloatLargeArray> (native_p3, JniHandleOwnership.DoNotTransfer);
			float __ret = __this.Unpack (p0, p1, p2, p3, p4);
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_unpack_JJJLpl_edu_icm_jlargearrays_FloatLargeArray_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='RealFFTUtils_3D']/method[@name='unpack' and count(parameter)=5 and parameter[1][@type='long'] and parameter[2][@type='long'] and parameter[3][@type='long'] and parameter[4][@type='pl.edu.icm.jlargearrays.FloatLargeArray'] and parameter[5][@type='long']]"
		[Register ("unpack", "(JJJLpl/edu/icm/jlargearrays/FloatLargeArray;J)F", "GetUnpack_JJJLpl_edu_icm_jlargearrays_FloatLargeArray_JHandler")]
		public virtual unsafe float Unpack (long p0, long p1, long p2, global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p3, long p4)
		{
			if (id_unpack_JJJLpl_edu_icm_jlargearrays_FloatLargeArray_J == IntPtr.Zero)
				id_unpack_JJJLpl_edu_icm_jlargearrays_FloatLargeArray_J = JNIEnv.GetMethodID (class_ref, "unpack", "(JJJLpl/edu/icm/jlargearrays/FloatLargeArray;J)F");
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (p4);

				float __ret;
				if (((object) this).GetType () == ThresholdType)
					__ret = JNIEnv.CallFloatMethod (((global::Java.Lang.Object) this).Handle, id_unpack_JJJLpl_edu_icm_jlargearrays_FloatLargeArray_J, __args);
				else
					__ret = JNIEnv.CallNonvirtualFloatMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "unpack", "(JJJLpl/edu/icm/jlargearrays/FloatLargeArray;J)F"), __args);
				return __ret;
			} finally {
			}
		}

	}
}
