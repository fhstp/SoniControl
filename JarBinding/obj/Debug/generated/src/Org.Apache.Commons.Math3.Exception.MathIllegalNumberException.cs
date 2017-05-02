using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Org.Apache.Commons.Math3.Exception {

	// Metadata.xml XPath class reference: path="/api/package[@name='org.apache.commons.math3.exception']/class[@name='MathIllegalNumberException']"
	[global::Android.Runtime.Register ("org/apache/commons/math3/exception/MathIllegalNumberException", DoNotGenerateAcw=true)]
	public partial class MathIllegalNumberException : global::Org.Apache.Commons.Math3.Exception.MathIllegalArgumentException {


		static IntPtr INTEGER_ZERO_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='org.apache.commons.math3.exception']/class[@name='MathIllegalNumberException']/field[@name='INTEGER_ZERO']"
		[Register ("INTEGER_ZERO")]
		protected static global::Java.Lang.Integer IntegerZero {
			get {
				if (INTEGER_ZERO_jfieldId == IntPtr.Zero)
					INTEGER_ZERO_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "INTEGER_ZERO", "Ljava/lang/Integer;");
				IntPtr __ret = JNIEnv.GetStaticObjectField (class_ref, INTEGER_ZERO_jfieldId);
				return global::Java.Lang.Object.GetObject<global::Java.Lang.Integer> (__ret, JniHandleOwnership.TransferLocalRef);
			}
		}
		internal static new IntPtr java_class_handle;
		internal static new IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("org/apache/commons/math3/exception/MathIllegalNumberException", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (MathIllegalNumberException); }
		}

		protected MathIllegalNumberException (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor_Lorg_apache_commons_math3_exception_util_Localizable_Ljava_lang_Number_arrayLjava_lang_Object_;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='org.apache.commons.math3.exception']/class[@name='MathIllegalNumberException']/constructor[@name='MathIllegalNumberException' and count(parameter)=3 and parameter[1][@type='org.apache.commons.math3.exception.util.Localizable'] and parameter[2][@type='java.lang.Number'] and parameter[3][@type='java.lang.Object...']]"
		[Register (".ctor", "(Lorg/apache/commons/math3/exception/util/Localizable;Ljava/lang/Number;[Ljava/lang/Object;)V", "")]
		protected unsafe MathIllegalNumberException (global::Org.Apache.Commons.Math3.Exception.Util.ILocalizable p0, global::Java.Lang.Number p1, params global:: Java.Lang.Object[] p2)
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Throwable) this).Handle != IntPtr.Zero)
				return;

			IntPtr native_p2 = JNIEnv.NewArray (p2);
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (native_p2);
				if (((object) this).GetType () != typeof (MathIllegalNumberException)) {
					SetHandle (
							global::Android.Runtime.JNIEnv.StartCreateInstance (((object) this).GetType (), "(Lorg/apache/commons/math3/exception/util/Localizable;Ljava/lang/Number;[Ljava/lang/Object;)V", __args),
							JniHandleOwnership.TransferLocalRef);
					global::Android.Runtime.JNIEnv.FinishCreateInstance (((global::Java.Lang.Throwable) this).Handle, "(Lorg/apache/commons/math3/exception/util/Localizable;Ljava/lang/Number;[Ljava/lang/Object;)V", __args);
					return;
				}

				if (id_ctor_Lorg_apache_commons_math3_exception_util_Localizable_Ljava_lang_Number_arrayLjava_lang_Object_ == IntPtr.Zero)
					id_ctor_Lorg_apache_commons_math3_exception_util_Localizable_Ljava_lang_Number_arrayLjava_lang_Object_ = JNIEnv.GetMethodID (class_ref, "<init>", "(Lorg/apache/commons/math3/exception/util/Localizable;Ljava/lang/Number;[Ljava/lang/Object;)V");
				SetHandle (
						global::Android.Runtime.JNIEnv.StartCreateInstance (class_ref, id_ctor_Lorg_apache_commons_math3_exception_util_Localizable_Ljava_lang_Number_arrayLjava_lang_Object_, __args),
						JniHandleOwnership.TransferLocalRef);
				JNIEnv.FinishCreateInstance (((global::Java.Lang.Throwable) this).Handle, class_ref, id_ctor_Lorg_apache_commons_math3_exception_util_Localizable_Ljava_lang_Number_arrayLjava_lang_Object_, __args);
			} finally {
				if (p2 != null) {
					JNIEnv.CopyArray (native_p2, p2);
					JNIEnv.DeleteLocalRef (native_p2);
				}
			}
		}

		static Delegate cb_getArgument;
#pragma warning disable 0169
		static Delegate GetGetArgumentHandler ()
		{
			if (cb_getArgument == null)
				cb_getArgument = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetArgument);
			return cb_getArgument;
		}

		static IntPtr n_GetArgument (IntPtr jnienv, IntPtr native__this)
		{
			global::Org.Apache.Commons.Math3.Exception.MathIllegalNumberException __this = global::Java.Lang.Object.GetObject<global::Org.Apache.Commons.Math3.Exception.MathIllegalNumberException> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.Argument);
		}
#pragma warning restore 0169

		static IntPtr id_getArgument;
		public virtual unsafe global::Java.Lang.Number Argument {
			// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.exception']/class[@name='MathIllegalNumberException']/method[@name='getArgument' and count(parameter)=0]"
			[Register ("getArgument", "()Ljava/lang/Number;", "GetGetArgumentHandler")]
			get {
				if (id_getArgument == IntPtr.Zero)
					id_getArgument = JNIEnv.GetMethodID (class_ref, "getArgument", "()Ljava/lang/Number;");
				try {

					if (((object) this).GetType () == ThresholdType)
						return global::Java.Lang.Object.GetObject<global::Java.Lang.Number> (JNIEnv.CallObjectMethod (((global::Java.Lang.Throwable) this).Handle, id_getArgument), JniHandleOwnership.TransferLocalRef);
					else
						return global::Java.Lang.Object.GetObject<global::Java.Lang.Number> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Throwable) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getArgument", "()Ljava/lang/Number;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

	}
}
