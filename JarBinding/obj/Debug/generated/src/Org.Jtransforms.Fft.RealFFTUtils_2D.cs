using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Org.Jtransforms.Fft {

	// Metadata.xml XPath class reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='RealFFTUtils_2D']"
	[global::Android.Runtime.Register ("org/jtransforms/fft/RealFFTUtils_2D", DoNotGenerateAcw=true)]
	public partial class RealFFTUtils_2D : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("org/jtransforms/fft/RealFFTUtils_2D", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (RealFFTUtils_2D); }
		}

		protected RealFFTUtils_2D (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor_JJ;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='RealFFTUtils_2D']/constructor[@name='RealFFTUtils_2D' and count(parameter)=2 and parameter[1][@type='long'] and parameter[2][@type='long']]"
		[Register (".ctor", "(JJ)V", "")]
		public unsafe RealFFTUtils_2D (long p0, long p1)
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				if (((object) this).GetType () != typeof (RealFFTUtils_2D)) {
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

		static Delegate cb_getIndex_II;
#pragma warning disable 0169
		static Delegate GetGetIndex_IIHandler ()
		{
			if (cb_getIndex_II == null)
				cb_getIndex_II = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int, int, int>) n_GetIndex_II);
			return cb_getIndex_II;
		}

		static int n_GetIndex_II (IntPtr jnienv, IntPtr native__this, int p0, int p1)
		{
			global::Org.Jtransforms.Fft.RealFFTUtils_2D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.RealFFTUtils_2D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.GetIndex (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_getIndex_II;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='RealFFTUtils_2D']/method[@name='getIndex' and count(parameter)=2 and parameter[1][@type='int'] and parameter[2][@type='int']]"
		[Register ("getIndex", "(II)I", "GetGetIndex_IIHandler")]
		public virtual unsafe int GetIndex (int p0, int p1)
		{
			if (id_getIndex_II == IntPtr.Zero)
				id_getIndex_II = JNIEnv.GetMethodID (class_ref, "getIndex", "(II)I");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);

				if (((object) this).GetType () == ThresholdType)
					return JNIEnv.CallIntMethod (((global::Java.Lang.Object) this).Handle, id_getIndex_II, __args);
				else
					return JNIEnv.CallNonvirtualIntMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getIndex", "(II)I"), __args);
			} finally {
			}
		}

		static Delegate cb_getIndex_JJ;
#pragma warning disable 0169
		static Delegate GetGetIndex_JJHandler ()
		{
			if (cb_getIndex_JJ == null)
				cb_getIndex_JJ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, long, long, long>) n_GetIndex_JJ);
			return cb_getIndex_JJ;
		}

		static long n_GetIndex_JJ (IntPtr jnienv, IntPtr native__this, long p0, long p1)
		{
			global::Org.Jtransforms.Fft.RealFFTUtils_2D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.RealFFTUtils_2D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.GetIndex (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_getIndex_JJ;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='RealFFTUtils_2D']/method[@name='getIndex' and count(parameter)=2 and parameter[1][@type='long'] and parameter[2][@type='long']]"
		[Register ("getIndex", "(JJ)J", "GetGetIndex_JJHandler")]
		public virtual unsafe long GetIndex (long p0, long p1)
		{
			if (id_getIndex_JJ == IntPtr.Zero)
				id_getIndex_JJ = JNIEnv.GetMethodID (class_ref, "getIndex", "(JJ)J");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);

				if (((object) this).GetType () == ThresholdType)
					return JNIEnv.CallLongMethod (((global::Java.Lang.Object) this).Handle, id_getIndex_JJ, __args);
				else
					return JNIEnv.CallNonvirtualLongMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getIndex", "(JJ)J"), __args);
			} finally {
			}
		}

		static Delegate cb_pack_DIIarrayDI;
#pragma warning disable 0169
		static Delegate GetPack_DIIarrayDIHandler ()
		{
			if (cb_pack_DIIarrayDI == null)
				cb_pack_DIIarrayDI = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, double, int, int, IntPtr, int>) n_Pack_DIIarrayDI);
			return cb_pack_DIIarrayDI;
		}

		static void n_Pack_DIIarrayDI (IntPtr jnienv, IntPtr native__this, double p0, int p1, int p2, IntPtr native_p3, int p4)
		{
			global::Org.Jtransforms.Fft.RealFFTUtils_2D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.RealFFTUtils_2D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			double[] p3 = (double[]) JNIEnv.GetArray (native_p3, JniHandleOwnership.DoNotTransfer, typeof (double));
			__this.Pack (p0, p1, p2, p3, p4);
			if (p3 != null)
				JNIEnv.CopyArray (p3, native_p3);
		}
#pragma warning restore 0169

		static IntPtr id_pack_DIIarrayDI;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='RealFFTUtils_2D']/method[@name='pack' and count(parameter)=5 and parameter[1][@type='double'] and parameter[2][@type='int'] and parameter[3][@type='int'] and parameter[4][@type='double[]'] and parameter[5][@type='int']]"
		[Register ("pack", "(DII[DI)V", "GetPack_DIIarrayDIHandler")]
		public virtual unsafe void Pack (double p0, int p1, int p2, double[] p3, int p4)
		{
			if (id_pack_DIIarrayDI == IntPtr.Zero)
				id_pack_DIIarrayDI = JNIEnv.GetMethodID (class_ref, "pack", "(DII[DI)V");
			IntPtr native_p3 = JNIEnv.NewArray (p3);
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (native_p3);
				__args [4] = new JValue (p4);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_pack_DIIarrayDI, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "pack", "(DII[DI)V"), __args);
			} finally {
				if (p3 != null) {
					JNIEnv.CopyArray (native_p3, p3);
					JNIEnv.DeleteLocalRef (native_p3);
				}
			}
		}

		static Delegate cb_pack_DIIarrayarrayD;
#pragma warning disable 0169
		static Delegate GetPack_DIIarrayarrayDHandler ()
		{
			if (cb_pack_DIIarrayarrayD == null)
				cb_pack_DIIarrayarrayD = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, double, int, int, IntPtr>) n_Pack_DIIarrayarrayD);
			return cb_pack_DIIarrayarrayD;
		}

		static void n_Pack_DIIarrayarrayD (IntPtr jnienv, IntPtr native__this, double p0, int p1, int p2, IntPtr native_p3)
		{
			global::Org.Jtransforms.Fft.RealFFTUtils_2D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.RealFFTUtils_2D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			double[][] p3 = (double[][]) JNIEnv.GetArray (native_p3, JniHandleOwnership.DoNotTransfer, typeof (double[]));
			__this.Pack (p0, p1, p2, p3);
			if (p3 != null)
				JNIEnv.CopyArray (p3, native_p3);
		}
#pragma warning restore 0169

		static IntPtr id_pack_DIIarrayarrayD;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='RealFFTUtils_2D']/method[@name='pack' and count(parameter)=4 and parameter[1][@type='double'] and parameter[2][@type='int'] and parameter[3][@type='int'] and parameter[4][@type='double[][]']]"
		[Register ("pack", "(DII[[D)V", "GetPack_DIIarrayarrayDHandler")]
		public virtual unsafe void Pack (double p0, int p1, int p2, double[][] p3)
		{
			if (id_pack_DIIarrayarrayD == IntPtr.Zero)
				id_pack_DIIarrayarrayD = JNIEnv.GetMethodID (class_ref, "pack", "(DII[[D)V");
			IntPtr native_p3 = JNIEnv.NewArray (p3);
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (native_p3);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_pack_DIIarrayarrayD, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "pack", "(DII[[D)V"), __args);
			} finally {
				if (p3 != null) {
					JNIEnv.CopyArray (native_p3, p3);
					JNIEnv.DeleteLocalRef (native_p3);
				}
			}
		}

		static Delegate cb_pack_DJJLpl_edu_icm_jlargearrays_DoubleLargeArray_J;
#pragma warning disable 0169
		static Delegate GetPack_DJJLpl_edu_icm_jlargearrays_DoubleLargeArray_JHandler ()
		{
			if (cb_pack_DJJLpl_edu_icm_jlargearrays_DoubleLargeArray_J == null)
				cb_pack_DJJLpl_edu_icm_jlargearrays_DoubleLargeArray_J = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, double, long, long, IntPtr, long>) n_Pack_DJJLpl_edu_icm_jlargearrays_DoubleLargeArray_J);
			return cb_pack_DJJLpl_edu_icm_jlargearrays_DoubleLargeArray_J;
		}

		static void n_Pack_DJJLpl_edu_icm_jlargearrays_DoubleLargeArray_J (IntPtr jnienv, IntPtr native__this, double p0, long p1, long p2, IntPtr native_p3, long p4)
		{
			global::Org.Jtransforms.Fft.RealFFTUtils_2D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.RealFFTUtils_2D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p3 = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray> (native_p3, JniHandleOwnership.DoNotTransfer);
			__this.Pack (p0, p1, p2, p3, p4);
		}
#pragma warning restore 0169

		static IntPtr id_pack_DJJLpl_edu_icm_jlargearrays_DoubleLargeArray_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='RealFFTUtils_2D']/method[@name='pack' and count(parameter)=5 and parameter[1][@type='double'] and parameter[2][@type='long'] and parameter[3][@type='long'] and parameter[4][@type='pl.edu.icm.jlargearrays.DoubleLargeArray'] and parameter[5][@type='long']]"
		[Register ("pack", "(DJJLpl/edu/icm/jlargearrays/DoubleLargeArray;J)V", "GetPack_DJJLpl_edu_icm_jlargearrays_DoubleLargeArray_JHandler")]
		public virtual unsafe void Pack (double p0, long p1, long p2, global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p3, long p4)
		{
			if (id_pack_DJJLpl_edu_icm_jlargearrays_DoubleLargeArray_J == IntPtr.Zero)
				id_pack_DJJLpl_edu_icm_jlargearrays_DoubleLargeArray_J = JNIEnv.GetMethodID (class_ref, "pack", "(DJJLpl/edu/icm/jlargearrays/DoubleLargeArray;J)V");
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (p4);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_pack_DJJLpl_edu_icm_jlargearrays_DoubleLargeArray_J, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "pack", "(DJJLpl/edu/icm/jlargearrays/DoubleLargeArray;J)V"), __args);
			} finally {
			}
		}

		static Delegate cb_pack_FIIarrayFI;
#pragma warning disable 0169
		static Delegate GetPack_FIIarrayFIHandler ()
		{
			if (cb_pack_FIIarrayFI == null)
				cb_pack_FIIarrayFI = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, float, int, int, IntPtr, int>) n_Pack_FIIarrayFI);
			return cb_pack_FIIarrayFI;
		}

		static void n_Pack_FIIarrayFI (IntPtr jnienv, IntPtr native__this, float p0, int p1, int p2, IntPtr native_p3, int p4)
		{
			global::Org.Jtransforms.Fft.RealFFTUtils_2D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.RealFFTUtils_2D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			float[] p3 = (float[]) JNIEnv.GetArray (native_p3, JniHandleOwnership.DoNotTransfer, typeof (float));
			__this.Pack (p0, p1, p2, p3, p4);
			if (p3 != null)
				JNIEnv.CopyArray (p3, native_p3);
		}
#pragma warning restore 0169

		static IntPtr id_pack_FIIarrayFI;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='RealFFTUtils_2D']/method[@name='pack' and count(parameter)=5 and parameter[1][@type='float'] and parameter[2][@type='int'] and parameter[3][@type='int'] and parameter[4][@type='float[]'] and parameter[5][@type='int']]"
		[Register ("pack", "(FII[FI)V", "GetPack_FIIarrayFIHandler")]
		public virtual unsafe void Pack (float p0, int p1, int p2, float[] p3, int p4)
		{
			if (id_pack_FIIarrayFI == IntPtr.Zero)
				id_pack_FIIarrayFI = JNIEnv.GetMethodID (class_ref, "pack", "(FII[FI)V");
			IntPtr native_p3 = JNIEnv.NewArray (p3);
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (native_p3);
				__args [4] = new JValue (p4);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_pack_FIIarrayFI, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "pack", "(FII[FI)V"), __args);
			} finally {
				if (p3 != null) {
					JNIEnv.CopyArray (native_p3, p3);
					JNIEnv.DeleteLocalRef (native_p3);
				}
			}
		}

		static Delegate cb_pack_FIIarrayarrayF;
#pragma warning disable 0169
		static Delegate GetPack_FIIarrayarrayFHandler ()
		{
			if (cb_pack_FIIarrayarrayF == null)
				cb_pack_FIIarrayarrayF = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, float, int, int, IntPtr>) n_Pack_FIIarrayarrayF);
			return cb_pack_FIIarrayarrayF;
		}

		static void n_Pack_FIIarrayarrayF (IntPtr jnienv, IntPtr native__this, float p0, int p1, int p2, IntPtr native_p3)
		{
			global::Org.Jtransforms.Fft.RealFFTUtils_2D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.RealFFTUtils_2D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			float[][] p3 = (float[][]) JNIEnv.GetArray (native_p3, JniHandleOwnership.DoNotTransfer, typeof (float[]));
			__this.Pack (p0, p1, p2, p3);
			if (p3 != null)
				JNIEnv.CopyArray (p3, native_p3);
		}
#pragma warning restore 0169

		static IntPtr id_pack_FIIarrayarrayF;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='RealFFTUtils_2D']/method[@name='pack' and count(parameter)=4 and parameter[1][@type='float'] and parameter[2][@type='int'] and parameter[3][@type='int'] and parameter[4][@type='float[][]']]"
		[Register ("pack", "(FII[[F)V", "GetPack_FIIarrayarrayFHandler")]
		public virtual unsafe void Pack (float p0, int p1, int p2, float[][] p3)
		{
			if (id_pack_FIIarrayarrayF == IntPtr.Zero)
				id_pack_FIIarrayarrayF = JNIEnv.GetMethodID (class_ref, "pack", "(FII[[F)V");
			IntPtr native_p3 = JNIEnv.NewArray (p3);
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (native_p3);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_pack_FIIarrayarrayF, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "pack", "(FII[[F)V"), __args);
			} finally {
				if (p3 != null) {
					JNIEnv.CopyArray (native_p3, p3);
					JNIEnv.DeleteLocalRef (native_p3);
				}
			}
		}

		static Delegate cb_pack_FJJLpl_edu_icm_jlargearrays_FloatLargeArray_J;
#pragma warning disable 0169
		static Delegate GetPack_FJJLpl_edu_icm_jlargearrays_FloatLargeArray_JHandler ()
		{
			if (cb_pack_FJJLpl_edu_icm_jlargearrays_FloatLargeArray_J == null)
				cb_pack_FJJLpl_edu_icm_jlargearrays_FloatLargeArray_J = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, float, long, long, IntPtr, long>) n_Pack_FJJLpl_edu_icm_jlargearrays_FloatLargeArray_J);
			return cb_pack_FJJLpl_edu_icm_jlargearrays_FloatLargeArray_J;
		}

		static void n_Pack_FJJLpl_edu_icm_jlargearrays_FloatLargeArray_J (IntPtr jnienv, IntPtr native__this, float p0, long p1, long p2, IntPtr native_p3, long p4)
		{
			global::Org.Jtransforms.Fft.RealFFTUtils_2D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.RealFFTUtils_2D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p3 = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.FloatLargeArray> (native_p3, JniHandleOwnership.DoNotTransfer);
			__this.Pack (p0, p1, p2, p3, p4);
		}
#pragma warning restore 0169

		static IntPtr id_pack_FJJLpl_edu_icm_jlargearrays_FloatLargeArray_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='RealFFTUtils_2D']/method[@name='pack' and count(parameter)=5 and parameter[1][@type='float'] and parameter[2][@type='long'] and parameter[3][@type='long'] and parameter[4][@type='pl.edu.icm.jlargearrays.FloatLargeArray'] and parameter[5][@type='long']]"
		[Register ("pack", "(FJJLpl/edu/icm/jlargearrays/FloatLargeArray;J)V", "GetPack_FJJLpl_edu_icm_jlargearrays_FloatLargeArray_JHandler")]
		public virtual unsafe void Pack (float p0, long p1, long p2, global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p3, long p4)
		{
			if (id_pack_FJJLpl_edu_icm_jlargearrays_FloatLargeArray_J == IntPtr.Zero)
				id_pack_FJJLpl_edu_icm_jlargearrays_FloatLargeArray_J = JNIEnv.GetMethodID (class_ref, "pack", "(FJJLpl/edu/icm/jlargearrays/FloatLargeArray;J)V");
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (p4);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_pack_FJJLpl_edu_icm_jlargearrays_FloatLargeArray_J, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "pack", "(FJJLpl/edu/icm/jlargearrays/FloatLargeArray;J)V"), __args);
			} finally {
			}
		}

		static Delegate cb_unpack_IIarrayDI;
#pragma warning disable 0169
		static Delegate GetUnpack_IIarrayDIHandler ()
		{
			if (cb_unpack_IIarrayDI == null)
				cb_unpack_IIarrayDI = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int, int, IntPtr, int, double>) n_Unpack_IIarrayDI);
			return cb_unpack_IIarrayDI;
		}

		static double n_Unpack_IIarrayDI (IntPtr jnienv, IntPtr native__this, int p0, int p1, IntPtr native_p2, int p3)
		{
			global::Org.Jtransforms.Fft.RealFFTUtils_2D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.RealFFTUtils_2D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			double[] p2 = (double[]) JNIEnv.GetArray (native_p2, JniHandleOwnership.DoNotTransfer, typeof (double));
			double __ret = __this.Unpack (p0, p1, p2, p3);
			if (p2 != null)
				JNIEnv.CopyArray (p2, native_p2);
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_unpack_IIarrayDI;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='RealFFTUtils_2D']/method[@name='unpack' and count(parameter)=4 and parameter[1][@type='int'] and parameter[2][@type='int'] and parameter[3][@type='double[]'] and parameter[4][@type='int']]"
		[Register ("unpack", "(II[DI)D", "GetUnpack_IIarrayDIHandler")]
		public virtual unsafe double Unpack (int p0, int p1, double[] p2, int p3)
		{
			if (id_unpack_IIarrayDI == IntPtr.Zero)
				id_unpack_IIarrayDI = JNIEnv.GetMethodID (class_ref, "unpack", "(II[DI)D");
			IntPtr native_p2 = JNIEnv.NewArray (p2);
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (native_p2);
				__args [3] = new JValue (p3);

				double __ret;
				if (((object) this).GetType () == ThresholdType)
					__ret = JNIEnv.CallDoubleMethod (((global::Java.Lang.Object) this).Handle, id_unpack_IIarrayDI, __args);
				else
					__ret = JNIEnv.CallNonvirtualDoubleMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "unpack", "(II[DI)D"), __args);
				return __ret;
			} finally {
				if (p2 != null) {
					JNIEnv.CopyArray (native_p2, p2);
					JNIEnv.DeleteLocalRef (native_p2);
				}
			}
		}

		static Delegate cb_unpack_IIarrayarrayD;
#pragma warning disable 0169
		static Delegate GetUnpack_IIarrayarrayDHandler ()
		{
			if (cb_unpack_IIarrayarrayD == null)
				cb_unpack_IIarrayarrayD = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int, int, IntPtr, double>) n_Unpack_IIarrayarrayD);
			return cb_unpack_IIarrayarrayD;
		}

		static double n_Unpack_IIarrayarrayD (IntPtr jnienv, IntPtr native__this, int p0, int p1, IntPtr native_p2)
		{
			global::Org.Jtransforms.Fft.RealFFTUtils_2D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.RealFFTUtils_2D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			double[][] p2 = (double[][]) JNIEnv.GetArray (native_p2, JniHandleOwnership.DoNotTransfer, typeof (double[]));
			double __ret = __this.Unpack (p0, p1, p2);
			if (p2 != null)
				JNIEnv.CopyArray (p2, native_p2);
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_unpack_IIarrayarrayD;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='RealFFTUtils_2D']/method[@name='unpack' and count(parameter)=3 and parameter[1][@type='int'] and parameter[2][@type='int'] and parameter[3][@type='double[][]']]"
		[Register ("unpack", "(II[[D)D", "GetUnpack_IIarrayarrayDHandler")]
		public virtual unsafe double Unpack (int p0, int p1, double[][] p2)
		{
			if (id_unpack_IIarrayarrayD == IntPtr.Zero)
				id_unpack_IIarrayarrayD = JNIEnv.GetMethodID (class_ref, "unpack", "(II[[D)D");
			IntPtr native_p2 = JNIEnv.NewArray (p2);
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (native_p2);

				double __ret;
				if (((object) this).GetType () == ThresholdType)
					__ret = JNIEnv.CallDoubleMethod (((global::Java.Lang.Object) this).Handle, id_unpack_IIarrayarrayD, __args);
				else
					__ret = JNIEnv.CallNonvirtualDoubleMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "unpack", "(II[[D)D"), __args);
				return __ret;
			} finally {
				if (p2 != null) {
					JNIEnv.CopyArray (native_p2, p2);
					JNIEnv.DeleteLocalRef (native_p2);
				}
			}
		}

		static Delegate cb_unpack_IIarrayFI;
#pragma warning disable 0169
		static Delegate GetUnpack_IIarrayFIHandler ()
		{
			if (cb_unpack_IIarrayFI == null)
				cb_unpack_IIarrayFI = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int, int, IntPtr, int, float>) n_Unpack_IIarrayFI);
			return cb_unpack_IIarrayFI;
		}

		static float n_Unpack_IIarrayFI (IntPtr jnienv, IntPtr native__this, int p0, int p1, IntPtr native_p2, int p3)
		{
			global::Org.Jtransforms.Fft.RealFFTUtils_2D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.RealFFTUtils_2D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			float[] p2 = (float[]) JNIEnv.GetArray (native_p2, JniHandleOwnership.DoNotTransfer, typeof (float));
			float __ret = __this.Unpack (p0, p1, p2, p3);
			if (p2 != null)
				JNIEnv.CopyArray (p2, native_p2);
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_unpack_IIarrayFI;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='RealFFTUtils_2D']/method[@name='unpack' and count(parameter)=4 and parameter[1][@type='int'] and parameter[2][@type='int'] and parameter[3][@type='float[]'] and parameter[4][@type='int']]"
		[Register ("unpack", "(II[FI)F", "GetUnpack_IIarrayFIHandler")]
		public virtual unsafe float Unpack (int p0, int p1, float[] p2, int p3)
		{
			if (id_unpack_IIarrayFI == IntPtr.Zero)
				id_unpack_IIarrayFI = JNIEnv.GetMethodID (class_ref, "unpack", "(II[FI)F");
			IntPtr native_p2 = JNIEnv.NewArray (p2);
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (native_p2);
				__args [3] = new JValue (p3);

				float __ret;
				if (((object) this).GetType () == ThresholdType)
					__ret = JNIEnv.CallFloatMethod (((global::Java.Lang.Object) this).Handle, id_unpack_IIarrayFI, __args);
				else
					__ret = JNIEnv.CallNonvirtualFloatMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "unpack", "(II[FI)F"), __args);
				return __ret;
			} finally {
				if (p2 != null) {
					JNIEnv.CopyArray (native_p2, p2);
					JNIEnv.DeleteLocalRef (native_p2);
				}
			}
		}

		static Delegate cb_unpack_IIarrayarrayF;
#pragma warning disable 0169
		static Delegate GetUnpack_IIarrayarrayFHandler ()
		{
			if (cb_unpack_IIarrayarrayF == null)
				cb_unpack_IIarrayarrayF = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int, int, IntPtr, float>) n_Unpack_IIarrayarrayF);
			return cb_unpack_IIarrayarrayF;
		}

		static float n_Unpack_IIarrayarrayF (IntPtr jnienv, IntPtr native__this, int p0, int p1, IntPtr native_p2)
		{
			global::Org.Jtransforms.Fft.RealFFTUtils_2D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.RealFFTUtils_2D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			float[][] p2 = (float[][]) JNIEnv.GetArray (native_p2, JniHandleOwnership.DoNotTransfer, typeof (float[]));
			float __ret = __this.Unpack (p0, p1, p2);
			if (p2 != null)
				JNIEnv.CopyArray (p2, native_p2);
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_unpack_IIarrayarrayF;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='RealFFTUtils_2D']/method[@name='unpack' and count(parameter)=3 and parameter[1][@type='int'] and parameter[2][@type='int'] and parameter[3][@type='float[][]']]"
		[Register ("unpack", "(II[[F)F", "GetUnpack_IIarrayarrayFHandler")]
		public virtual unsafe float Unpack (int p0, int p1, float[][] p2)
		{
			if (id_unpack_IIarrayarrayF == IntPtr.Zero)
				id_unpack_IIarrayarrayF = JNIEnv.GetMethodID (class_ref, "unpack", "(II[[F)F");
			IntPtr native_p2 = JNIEnv.NewArray (p2);
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (native_p2);

				float __ret;
				if (((object) this).GetType () == ThresholdType)
					__ret = JNIEnv.CallFloatMethod (((global::Java.Lang.Object) this).Handle, id_unpack_IIarrayarrayF, __args);
				else
					__ret = JNIEnv.CallNonvirtualFloatMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "unpack", "(II[[F)F"), __args);
				return __ret;
			} finally {
				if (p2 != null) {
					JNIEnv.CopyArray (native_p2, p2);
					JNIEnv.DeleteLocalRef (native_p2);
				}
			}
		}

		static Delegate cb_unpack_JJLpl_edu_icm_jlargearrays_DoubleLargeArray_J;
#pragma warning disable 0169
		static Delegate GetUnpack_JJLpl_edu_icm_jlargearrays_DoubleLargeArray_JHandler ()
		{
			if (cb_unpack_JJLpl_edu_icm_jlargearrays_DoubleLargeArray_J == null)
				cb_unpack_JJLpl_edu_icm_jlargearrays_DoubleLargeArray_J = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, long, long, IntPtr, long, double>) n_Unpack_JJLpl_edu_icm_jlargearrays_DoubleLargeArray_J);
			return cb_unpack_JJLpl_edu_icm_jlargearrays_DoubleLargeArray_J;
		}

		static double n_Unpack_JJLpl_edu_icm_jlargearrays_DoubleLargeArray_J (IntPtr jnienv, IntPtr native__this, long p0, long p1, IntPtr native_p2, long p3)
		{
			global::Org.Jtransforms.Fft.RealFFTUtils_2D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.RealFFTUtils_2D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p2 = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray> (native_p2, JniHandleOwnership.DoNotTransfer);
			double __ret = __this.Unpack (p0, p1, p2, p3);
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_unpack_JJLpl_edu_icm_jlargearrays_DoubleLargeArray_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='RealFFTUtils_2D']/method[@name='unpack' and count(parameter)=4 and parameter[1][@type='long'] and parameter[2][@type='long'] and parameter[3][@type='pl.edu.icm.jlargearrays.DoubleLargeArray'] and parameter[4][@type='long']]"
		[Register ("unpack", "(JJLpl/edu/icm/jlargearrays/DoubleLargeArray;J)D", "GetUnpack_JJLpl_edu_icm_jlargearrays_DoubleLargeArray_JHandler")]
		public virtual unsafe double Unpack (long p0, long p1, global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p2, long p3)
		{
			if (id_unpack_JJLpl_edu_icm_jlargearrays_DoubleLargeArray_J == IntPtr.Zero)
				id_unpack_JJLpl_edu_icm_jlargearrays_DoubleLargeArray_J = JNIEnv.GetMethodID (class_ref, "unpack", "(JJLpl/edu/icm/jlargearrays/DoubleLargeArray;J)D");
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);

				double __ret;
				if (((object) this).GetType () == ThresholdType)
					__ret = JNIEnv.CallDoubleMethod (((global::Java.Lang.Object) this).Handle, id_unpack_JJLpl_edu_icm_jlargearrays_DoubleLargeArray_J, __args);
				else
					__ret = JNIEnv.CallNonvirtualDoubleMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "unpack", "(JJLpl/edu/icm/jlargearrays/DoubleLargeArray;J)D"), __args);
				return __ret;
			} finally {
			}
		}

		static Delegate cb_unpack_JJLpl_edu_icm_jlargearrays_FloatLargeArray_J;
#pragma warning disable 0169
		static Delegate GetUnpack_JJLpl_edu_icm_jlargearrays_FloatLargeArray_JHandler ()
		{
			if (cb_unpack_JJLpl_edu_icm_jlargearrays_FloatLargeArray_J == null)
				cb_unpack_JJLpl_edu_icm_jlargearrays_FloatLargeArray_J = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, long, long, IntPtr, long, float>) n_Unpack_JJLpl_edu_icm_jlargearrays_FloatLargeArray_J);
			return cb_unpack_JJLpl_edu_icm_jlargearrays_FloatLargeArray_J;
		}

		static float n_Unpack_JJLpl_edu_icm_jlargearrays_FloatLargeArray_J (IntPtr jnienv, IntPtr native__this, long p0, long p1, IntPtr native_p2, long p3)
		{
			global::Org.Jtransforms.Fft.RealFFTUtils_2D __this = global::Java.Lang.Object.GetObject<global::Org.Jtransforms.Fft.RealFFTUtils_2D> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p2 = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.FloatLargeArray> (native_p2, JniHandleOwnership.DoNotTransfer);
			float __ret = __this.Unpack (p0, p1, p2, p3);
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_unpack_JJLpl_edu_icm_jlargearrays_FloatLargeArray_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.fft']/class[@name='RealFFTUtils_2D']/method[@name='unpack' and count(parameter)=4 and parameter[1][@type='long'] and parameter[2][@type='long'] and parameter[3][@type='pl.edu.icm.jlargearrays.FloatLargeArray'] and parameter[4][@type='long']]"
		[Register ("unpack", "(JJLpl/edu/icm/jlargearrays/FloatLargeArray;J)F", "GetUnpack_JJLpl_edu_icm_jlargearrays_FloatLargeArray_JHandler")]
		public virtual unsafe float Unpack (long p0, long p1, global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p2, long p3)
		{
			if (id_unpack_JJLpl_edu_icm_jlargearrays_FloatLargeArray_J == IntPtr.Zero)
				id_unpack_JJLpl_edu_icm_jlargearrays_FloatLargeArray_J = JNIEnv.GetMethodID (class_ref, "unpack", "(JJLpl/edu/icm/jlargearrays/FloatLargeArray;J)F");
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);

				float __ret;
				if (((object) this).GetType () == ThresholdType)
					__ret = JNIEnv.CallFloatMethod (((global::Java.Lang.Object) this).Handle, id_unpack_JJLpl_edu_icm_jlargearrays_FloatLargeArray_J, __args);
				else
					__ret = JNIEnv.CallNonvirtualFloatMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "unpack", "(JJLpl/edu/icm/jlargearrays/FloatLargeArray;J)F"), __args);
				return __ret;
			} finally {
			}
		}

	}
}
