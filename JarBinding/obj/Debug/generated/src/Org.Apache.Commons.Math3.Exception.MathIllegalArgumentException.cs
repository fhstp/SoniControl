using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Org.Apache.Commons.Math3.Exception {

	// Metadata.xml XPath class reference: path="/api/package[@name='org.apache.commons.math3.exception']/class[@name='MathIllegalArgumentException']"
	[global::Android.Runtime.Register ("org/apache/commons/math3/exception/MathIllegalArgumentException", DoNotGenerateAcw=true)]
	public partial class MathIllegalArgumentException : global::Java.Lang.IllegalArgumentException, global::Org.Apache.Commons.Math3.Exception.Util.IExceptionContextProvider {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("org/apache/commons/math3/exception/MathIllegalArgumentException", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (MathIllegalArgumentException); }
		}

		protected MathIllegalArgumentException (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor_Lorg_apache_commons_math3_exception_util_Localizable_arrayLjava_lang_Object_;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='org.apache.commons.math3.exception']/class[@name='MathIllegalArgumentException']/constructor[@name='MathIllegalArgumentException' and count(parameter)=2 and parameter[1][@type='org.apache.commons.math3.exception.util.Localizable'] and parameter[2][@type='java.lang.Object...']]"
		[Register (".ctor", "(Lorg/apache/commons/math3/exception/util/Localizable;[Ljava/lang/Object;)V", "")]
		public unsafe MathIllegalArgumentException (global::Org.Apache.Commons.Math3.Exception.Util.ILocalizable p0, params global:: Java.Lang.Object[] p1)
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Throwable) this).Handle != IntPtr.Zero)
				return;

			IntPtr native_p1 = JNIEnv.NewArray (p1);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				if (((object) this).GetType () != typeof (MathIllegalArgumentException)) {
					SetHandle (
							global::Android.Runtime.JNIEnv.StartCreateInstance (((object) this).GetType (), "(Lorg/apache/commons/math3/exception/util/Localizable;[Ljava/lang/Object;)V", __args),
							JniHandleOwnership.TransferLocalRef);
					global::Android.Runtime.JNIEnv.FinishCreateInstance (((global::Java.Lang.Throwable) this).Handle, "(Lorg/apache/commons/math3/exception/util/Localizable;[Ljava/lang/Object;)V", __args);
					return;
				}

				if (id_ctor_Lorg_apache_commons_math3_exception_util_Localizable_arrayLjava_lang_Object_ == IntPtr.Zero)
					id_ctor_Lorg_apache_commons_math3_exception_util_Localizable_arrayLjava_lang_Object_ = JNIEnv.GetMethodID (class_ref, "<init>", "(Lorg/apache/commons/math3/exception/util/Localizable;[Ljava/lang/Object;)V");
				SetHandle (
						global::Android.Runtime.JNIEnv.StartCreateInstance (class_ref, id_ctor_Lorg_apache_commons_math3_exception_util_Localizable_arrayLjava_lang_Object_, __args),
						JniHandleOwnership.TransferLocalRef);
				JNIEnv.FinishCreateInstance (((global::Java.Lang.Throwable) this).Handle, class_ref, id_ctor_Lorg_apache_commons_math3_exception_util_Localizable_arrayLjava_lang_Object_, __args);
			} finally {
				if (p1 != null) {
					JNIEnv.CopyArray (native_p1, p1);
					JNIEnv.DeleteLocalRef (native_p1);
				}
			}
		}

		static Delegate cb_getContext;
#pragma warning disable 0169
		static Delegate GetGetContextHandler ()
		{
			if (cb_getContext == null)
				cb_getContext = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetContext);
			return cb_getContext;
		}

		static IntPtr n_GetContext (IntPtr jnienv, IntPtr native__this)
		{
			global::Org.Apache.Commons.Math3.Exception.MathIllegalArgumentException __this = global::Java.Lang.Object.GetObject<global::Org.Apache.Commons.Math3.Exception.MathIllegalArgumentException> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.Context);
		}
#pragma warning restore 0169

		static IntPtr id_getContext;
		public virtual unsafe global::Org.Apache.Commons.Math3.Exception.Util.ExceptionContext Context {
			// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.exception']/class[@name='MathIllegalArgumentException']/method[@name='getContext' and count(parameter)=0]"
			[Register ("getContext", "()Lorg/apache/commons/math3/exception/util/ExceptionContext;", "GetGetContextHandler")]
			get {
				if (id_getContext == IntPtr.Zero)
					id_getContext = JNIEnv.GetMethodID (class_ref, "getContext", "()Lorg/apache/commons/math3/exception/util/ExceptionContext;");
				try {

					if (((object) this).GetType () == ThresholdType)
						return global::Java.Lang.Object.GetObject<global::Org.Apache.Commons.Math3.Exception.Util.ExceptionContext> (JNIEnv.CallObjectMethod (((global::Java.Lang.Throwable) this).Handle, id_getContext), JniHandleOwnership.TransferLocalRef);
					else
						return global::Java.Lang.Object.GetObject<global::Org.Apache.Commons.Math3.Exception.Util.ExceptionContext> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Throwable) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getContext", "()Lorg/apache/commons/math3/exception/util/ExceptionContext;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

	}
}
