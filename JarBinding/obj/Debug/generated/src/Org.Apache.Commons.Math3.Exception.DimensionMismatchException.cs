using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Org.Apache.Commons.Math3.Exception {

	// Metadata.xml XPath class reference: path="/api/package[@name='org.apache.commons.math3.exception']/class[@name='DimensionMismatchException']"
	[global::Android.Runtime.Register ("org/apache/commons/math3/exception/DimensionMismatchException", DoNotGenerateAcw=true)]
	public partial class DimensionMismatchException : global::Org.Apache.Commons.Math3.Exception.MathIllegalNumberException {

		internal static new IntPtr java_class_handle;
		internal static new IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("org/apache/commons/math3/exception/DimensionMismatchException", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (DimensionMismatchException); }
		}

		protected DimensionMismatchException (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor_Lorg_apache_commons_math3_exception_util_Localizable_II;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='org.apache.commons.math3.exception']/class[@name='DimensionMismatchException']/constructor[@name='DimensionMismatchException' and count(parameter)=3 and parameter[1][@type='org.apache.commons.math3.exception.util.Localizable'] and parameter[2][@type='int'] and parameter[3][@type='int']]"
		[Register (".ctor", "(Lorg/apache/commons/math3/exception/util/Localizable;II)V", "")]
		public unsafe DimensionMismatchException (global::Org.Apache.Commons.Math3.Exception.Util.ILocalizable p0, int p1, int p2)
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Throwable) this).Handle != IntPtr.Zero)
				return;

			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				if (((object) this).GetType () != typeof (DimensionMismatchException)) {
					SetHandle (
							global::Android.Runtime.JNIEnv.StartCreateInstance (((object) this).GetType (), "(Lorg/apache/commons/math3/exception/util/Localizable;II)V", __args),
							JniHandleOwnership.TransferLocalRef);
					global::Android.Runtime.JNIEnv.FinishCreateInstance (((global::Java.Lang.Throwable) this).Handle, "(Lorg/apache/commons/math3/exception/util/Localizable;II)V", __args);
					return;
				}

				if (id_ctor_Lorg_apache_commons_math3_exception_util_Localizable_II == IntPtr.Zero)
					id_ctor_Lorg_apache_commons_math3_exception_util_Localizable_II = JNIEnv.GetMethodID (class_ref, "<init>", "(Lorg/apache/commons/math3/exception/util/Localizable;II)V");
				SetHandle (
						global::Android.Runtime.JNIEnv.StartCreateInstance (class_ref, id_ctor_Lorg_apache_commons_math3_exception_util_Localizable_II, __args),
						JniHandleOwnership.TransferLocalRef);
				JNIEnv.FinishCreateInstance (((global::Java.Lang.Throwable) this).Handle, class_ref, id_ctor_Lorg_apache_commons_math3_exception_util_Localizable_II, __args);
			} finally {
			}
		}

		static IntPtr id_ctor_II;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='org.apache.commons.math3.exception']/class[@name='DimensionMismatchException']/constructor[@name='DimensionMismatchException' and count(parameter)=2 and parameter[1][@type='int'] and parameter[2][@type='int']]"
		[Register (".ctor", "(II)V", "")]
		public unsafe DimensionMismatchException (int p0, int p1)
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Throwable) this).Handle != IntPtr.Zero)
				return;

			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				if (((object) this).GetType () != typeof (DimensionMismatchException)) {
					SetHandle (
							global::Android.Runtime.JNIEnv.StartCreateInstance (((object) this).GetType (), "(II)V", __args),
							JniHandleOwnership.TransferLocalRef);
					global::Android.Runtime.JNIEnv.FinishCreateInstance (((global::Java.Lang.Throwable) this).Handle, "(II)V", __args);
					return;
				}

				if (id_ctor_II == IntPtr.Zero)
					id_ctor_II = JNIEnv.GetMethodID (class_ref, "<init>", "(II)V");
				SetHandle (
						global::Android.Runtime.JNIEnv.StartCreateInstance (class_ref, id_ctor_II, __args),
						JniHandleOwnership.TransferLocalRef);
				JNIEnv.FinishCreateInstance (((global::Java.Lang.Throwable) this).Handle, class_ref, id_ctor_II, __args);
			} finally {
			}
		}

		static Delegate cb_getDimension;
#pragma warning disable 0169
		static Delegate GetGetDimensionHandler ()
		{
			if (cb_getDimension == null)
				cb_getDimension = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int>) n_GetDimension);
			return cb_getDimension;
		}

		static int n_GetDimension (IntPtr jnienv, IntPtr native__this)
		{
			global::Org.Apache.Commons.Math3.Exception.DimensionMismatchException __this = global::Java.Lang.Object.GetObject<global::Org.Apache.Commons.Math3.Exception.DimensionMismatchException> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.Dimension;
		}
#pragma warning restore 0169

		static IntPtr id_getDimension;
		public virtual unsafe int Dimension {
			// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.exception']/class[@name='DimensionMismatchException']/method[@name='getDimension' and count(parameter)=0]"
			[Register ("getDimension", "()I", "GetGetDimensionHandler")]
			get {
				if (id_getDimension == IntPtr.Zero)
					id_getDimension = JNIEnv.GetMethodID (class_ref, "getDimension", "()I");
				try {

					if (((object) this).GetType () == ThresholdType)
						return JNIEnv.CallIntMethod (((global::Java.Lang.Throwable) this).Handle, id_getDimension);
					else
						return JNIEnv.CallNonvirtualIntMethod (((global::Java.Lang.Throwable) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getDimension", "()I"));
				} finally {
				}
			}
		}

	}
}
