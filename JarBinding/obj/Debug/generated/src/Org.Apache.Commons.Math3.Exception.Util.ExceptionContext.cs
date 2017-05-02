using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Org.Apache.Commons.Math3.Exception.Util {

	// Metadata.xml XPath class reference: path="/api/package[@name='org.apache.commons.math3.exception.util']/class[@name='ExceptionContext']"
	[global::Android.Runtime.Register ("org/apache/commons/math3/exception/util/ExceptionContext", DoNotGenerateAcw=true)]
	public partial class ExceptionContext : global::Java.Lang.Object, global::Java.IO.ISerializable {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("org/apache/commons/math3/exception/util/ExceptionContext", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (ExceptionContext); }
		}

		protected ExceptionContext (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor_Ljava_lang_Throwable_;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='org.apache.commons.math3.exception.util']/class[@name='ExceptionContext']/constructor[@name='ExceptionContext' and count(parameter)=1 and parameter[1][@type='java.lang.Throwable']]"
		[Register (".ctor", "(Ljava/lang/Throwable;)V", "")]
		public unsafe ExceptionContext (global::Java.Lang.Throwable p0)
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				if (((object) this).GetType () != typeof (ExceptionContext)) {
					SetHandle (
							global::Android.Runtime.JNIEnv.StartCreateInstance (((object) this).GetType (), "(Ljava/lang/Throwable;)V", __args),
							JniHandleOwnership.TransferLocalRef);
					global::Android.Runtime.JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, "(Ljava/lang/Throwable;)V", __args);
					return;
				}

				if (id_ctor_Ljava_lang_Throwable_ == IntPtr.Zero)
					id_ctor_Ljava_lang_Throwable_ = JNIEnv.GetMethodID (class_ref, "<init>", "(Ljava/lang/Throwable;)V");
				SetHandle (
						global::Android.Runtime.JNIEnv.StartCreateInstance (class_ref, id_ctor_Ljava_lang_Throwable_, __args),
						JniHandleOwnership.TransferLocalRef);
				JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, class_ref, id_ctor_Ljava_lang_Throwable_, __args);
			} finally {
			}
		}

		static Delegate cb_getKeys;
#pragma warning disable 0169
		static Delegate GetGetKeysHandler ()
		{
			if (cb_getKeys == null)
				cb_getKeys = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetKeys);
			return cb_getKeys;
		}

		static IntPtr n_GetKeys (IntPtr jnienv, IntPtr native__this)
		{
			global::Org.Apache.Commons.Math3.Exception.Util.ExceptionContext __this = global::Java.Lang.Object.GetObject<global::Org.Apache.Commons.Math3.Exception.Util.ExceptionContext> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return global::Android.Runtime.JavaSet<string>.ToLocalJniHandle (__this.Keys);
		}
#pragma warning restore 0169

		static IntPtr id_getKeys;
		public virtual unsafe global::System.Collections.Generic.ICollection<string> Keys {
			// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.exception.util']/class[@name='ExceptionContext']/method[@name='getKeys' and count(parameter)=0]"
			[Register ("getKeys", "()Ljava/util/Set;", "GetGetKeysHandler")]
			get {
				if (id_getKeys == IntPtr.Zero)
					id_getKeys = JNIEnv.GetMethodID (class_ref, "getKeys", "()Ljava/util/Set;");
				try {

					if (((object) this).GetType () == ThresholdType)
						return global::Android.Runtime.JavaSet<string>.FromJniHandle (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getKeys), JniHandleOwnership.TransferLocalRef);
					else
						return global::Android.Runtime.JavaSet<string>.FromJniHandle (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getKeys", "()Ljava/util/Set;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getLocalizedMessage;
#pragma warning disable 0169
		static Delegate GetGetLocalizedMessageHandler ()
		{
			if (cb_getLocalizedMessage == null)
				cb_getLocalizedMessage = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetLocalizedMessage);
			return cb_getLocalizedMessage;
		}

		static IntPtr n_GetLocalizedMessage (IntPtr jnienv, IntPtr native__this)
		{
			global::Org.Apache.Commons.Math3.Exception.Util.ExceptionContext __this = global::Java.Lang.Object.GetObject<global::Org.Apache.Commons.Math3.Exception.Util.ExceptionContext> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.LocalizedMessage);
		}
#pragma warning restore 0169

		static IntPtr id_getLocalizedMessage;
		public virtual unsafe string LocalizedMessage {
			// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.exception.util']/class[@name='ExceptionContext']/method[@name='getLocalizedMessage' and count(parameter)=0]"
			[Register ("getLocalizedMessage", "()Ljava/lang/String;", "GetGetLocalizedMessageHandler")]
			get {
				if (id_getLocalizedMessage == IntPtr.Zero)
					id_getLocalizedMessage = JNIEnv.GetMethodID (class_ref, "getLocalizedMessage", "()Ljava/lang/String;");
				try {

					if (((object) this).GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getLocalizedMessage), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getLocalizedMessage", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getMessage;
#pragma warning disable 0169
		static Delegate GetGetMessageHandler ()
		{
			if (cb_getMessage == null)
				cb_getMessage = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetMessage);
			return cb_getMessage;
		}

		static IntPtr n_GetMessage (IntPtr jnienv, IntPtr native__this)
		{
			global::Org.Apache.Commons.Math3.Exception.Util.ExceptionContext __this = global::Java.Lang.Object.GetObject<global::Org.Apache.Commons.Math3.Exception.Util.ExceptionContext> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Message);
		}
#pragma warning restore 0169

		static IntPtr id_getMessage;
		public virtual unsafe string Message {
			// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.exception.util']/class[@name='ExceptionContext']/method[@name='getMessage' and count(parameter)=0]"
			[Register ("getMessage", "()Ljava/lang/String;", "GetGetMessageHandler")]
			get {
				if (id_getMessage == IntPtr.Zero)
					id_getMessage = JNIEnv.GetMethodID (class_ref, "getMessage", "()Ljava/lang/String;");
				try {

					if (((object) this).GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getMessage), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getMessage", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getThrowable;
#pragma warning disable 0169
		static Delegate GetGetThrowableHandler ()
		{
			if (cb_getThrowable == null)
				cb_getThrowable = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetThrowable);
			return cb_getThrowable;
		}

		static IntPtr n_GetThrowable (IntPtr jnienv, IntPtr native__this)
		{
			global::Org.Apache.Commons.Math3.Exception.Util.ExceptionContext __this = global::Java.Lang.Object.GetObject<global::Org.Apache.Commons.Math3.Exception.Util.ExceptionContext> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.Throwable);
		}
#pragma warning restore 0169

		static IntPtr id_getThrowable;
		public virtual unsafe global::Java.Lang.Throwable Throwable {
			// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.exception.util']/class[@name='ExceptionContext']/method[@name='getThrowable' and count(parameter)=0]"
			[Register ("getThrowable", "()Ljava/lang/Throwable;", "GetGetThrowableHandler")]
			get {
				if (id_getThrowable == IntPtr.Zero)
					id_getThrowable = JNIEnv.GetMethodID (class_ref, "getThrowable", "()Ljava/lang/Throwable;");
				try {

					if (((object) this).GetType () == ThresholdType)
						return global::Java.Lang.Object.GetObject<global::Java.Lang.Throwable> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getThrowable), JniHandleOwnership.TransferLocalRef);
					else
						return global::Java.Lang.Object.GetObject<global::Java.Lang.Throwable> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getThrowable", "()Ljava/lang/Throwable;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_addMessage_Lorg_apache_commons_math3_exception_util_Localizable_arrayLjava_lang_Object_;
#pragma warning disable 0169
		static Delegate GetAddMessage_Lorg_apache_commons_math3_exception_util_Localizable_arrayLjava_lang_Object_Handler ()
		{
			if (cb_addMessage_Lorg_apache_commons_math3_exception_util_Localizable_arrayLjava_lang_Object_ == null)
				cb_addMessage_Lorg_apache_commons_math3_exception_util_Localizable_arrayLjava_lang_Object_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr>) n_AddMessage_Lorg_apache_commons_math3_exception_util_Localizable_arrayLjava_lang_Object_);
			return cb_addMessage_Lorg_apache_commons_math3_exception_util_Localizable_arrayLjava_lang_Object_;
		}

		static void n_AddMessage_Lorg_apache_commons_math3_exception_util_Localizable_arrayLjava_lang_Object_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			global::Org.Apache.Commons.Math3.Exception.Util.ExceptionContext __this = global::Java.Lang.Object.GetObject<global::Org.Apache.Commons.Math3.Exception.Util.ExceptionContext> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Org.Apache.Commons.Math3.Exception.Util.ILocalizable p0 = (global::Org.Apache.Commons.Math3.Exception.Util.ILocalizable)global::Java.Lang.Object.GetObject<global::Org.Apache.Commons.Math3.Exception.Util.ILocalizable> (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Java.Lang.Object[] p1 = (global::Java.Lang.Object[]) JNIEnv.GetArray (native_p1, JniHandleOwnership.DoNotTransfer, typeof (global::Java.Lang.Object));
			__this.AddMessage (p0, p1);
			if (p1 != null)
				JNIEnv.CopyArray (p1, native_p1);
		}
#pragma warning restore 0169

		static IntPtr id_addMessage_Lorg_apache_commons_math3_exception_util_Localizable_arrayLjava_lang_Object_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.exception.util']/class[@name='ExceptionContext']/method[@name='addMessage' and count(parameter)=2 and parameter[1][@type='org.apache.commons.math3.exception.util.Localizable'] and parameter[2][@type='java.lang.Object...']]"
		[Register ("addMessage", "(Lorg/apache/commons/math3/exception/util/Localizable;[Ljava/lang/Object;)V", "GetAddMessage_Lorg_apache_commons_math3_exception_util_Localizable_arrayLjava_lang_Object_Handler")]
		public virtual unsafe void AddMessage (global::Org.Apache.Commons.Math3.Exception.Util.ILocalizable p0, params global:: Java.Lang.Object[] p1)
		{
			if (id_addMessage_Lorg_apache_commons_math3_exception_util_Localizable_arrayLjava_lang_Object_ == IntPtr.Zero)
				id_addMessage_Lorg_apache_commons_math3_exception_util_Localizable_arrayLjava_lang_Object_ = JNIEnv.GetMethodID (class_ref, "addMessage", "(Lorg/apache/commons/math3/exception/util/Localizable;[Ljava/lang/Object;)V");
			IntPtr native_p1 = JNIEnv.NewArray (p1);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_addMessage_Lorg_apache_commons_math3_exception_util_Localizable_arrayLjava_lang_Object_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "addMessage", "(Lorg/apache/commons/math3/exception/util/Localizable;[Ljava/lang/Object;)V"), __args);
			} finally {
				if (p1 != null) {
					JNIEnv.CopyArray (native_p1, p1);
					JNIEnv.DeleteLocalRef (native_p1);
				}
			}
		}

		static Delegate cb_getMessage_Ljava_util_Locale_;
#pragma warning disable 0169
		static Delegate GetGetMessage_Ljava_util_Locale_Handler ()
		{
			if (cb_getMessage_Ljava_util_Locale_ == null)
				cb_getMessage_Ljava_util_Locale_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr>) n_GetMessage_Ljava_util_Locale_);
			return cb_getMessage_Ljava_util_Locale_;
		}

		static IntPtr n_GetMessage_Ljava_util_Locale_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Org.Apache.Commons.Math3.Exception.Util.ExceptionContext __this = global::Java.Lang.Object.GetObject<global::Org.Apache.Commons.Math3.Exception.Util.ExceptionContext> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Java.Util.Locale p0 = global::Java.Lang.Object.GetObject<global::Java.Util.Locale> (native_p0, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = JNIEnv.NewString (__this.GetMessage (p0));
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_getMessage_Ljava_util_Locale_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.exception.util']/class[@name='ExceptionContext']/method[@name='getMessage' and count(parameter)=1 and parameter[1][@type='java.util.Locale']]"
		[Register ("getMessage", "(Ljava/util/Locale;)Ljava/lang/String;", "GetGetMessage_Ljava_util_Locale_Handler")]
		public virtual unsafe string GetMessage (global::Java.Util.Locale p0)
		{
			if (id_getMessage_Ljava_util_Locale_ == IntPtr.Zero)
				id_getMessage_Ljava_util_Locale_ = JNIEnv.GetMethodID (class_ref, "getMessage", "(Ljava/util/Locale;)Ljava/lang/String;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				string __ret;
				if (((object) this).GetType () == ThresholdType)
					__ret = JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getMessage_Ljava_util_Locale_, __args), JniHandleOwnership.TransferLocalRef);
				else
					__ret = JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getMessage", "(Ljava/util/Locale;)Ljava/lang/String;"), __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static Delegate cb_getMessage_Ljava_util_Locale_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetGetMessage_Ljava_util_Locale_Ljava_lang_String_Handler ()
		{
			if (cb_getMessage_Ljava_util_Locale_Ljava_lang_String_ == null)
				cb_getMessage_Ljava_util_Locale_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>) n_GetMessage_Ljava_util_Locale_Ljava_lang_String_);
			return cb_getMessage_Ljava_util_Locale_Ljava_lang_String_;
		}

		static IntPtr n_GetMessage_Ljava_util_Locale_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			global::Org.Apache.Commons.Math3.Exception.Util.ExceptionContext __this = global::Java.Lang.Object.GetObject<global::Org.Apache.Commons.Math3.Exception.Util.ExceptionContext> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Java.Util.Locale p0 = global::Java.Lang.Object.GetObject<global::Java.Util.Locale> (native_p0, JniHandleOwnership.DoNotTransfer);
			string p1 = JNIEnv.GetString (native_p1, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = JNIEnv.NewString (__this.GetMessage (p0, p1));
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_getMessage_Ljava_util_Locale_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.exception.util']/class[@name='ExceptionContext']/method[@name='getMessage' and count(parameter)=2 and parameter[1][@type='java.util.Locale'] and parameter[2][@type='java.lang.String']]"
		[Register ("getMessage", "(Ljava/util/Locale;Ljava/lang/String;)Ljava/lang/String;", "GetGetMessage_Ljava_util_Locale_Ljava_lang_String_Handler")]
		public virtual unsafe string GetMessage (global::Java.Util.Locale p0, string p1)
		{
			if (id_getMessage_Ljava_util_Locale_Ljava_lang_String_ == IntPtr.Zero)
				id_getMessage_Ljava_util_Locale_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "getMessage", "(Ljava/util/Locale;Ljava/lang/String;)Ljava/lang/String;");
			IntPtr native_p1 = JNIEnv.NewString (p1);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);

				string __ret;
				if (((object) this).GetType () == ThresholdType)
					__ret = JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getMessage_Ljava_util_Locale_Ljava_lang_String_, __args), JniHandleOwnership.TransferLocalRef);
				else
					__ret = JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getMessage", "(Ljava/util/Locale;Ljava/lang/String;)Ljava/lang/String;"), __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p1);
			}
		}

		static Delegate cb_getValue_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetGetValue_Ljava_lang_String_Handler ()
		{
			if (cb_getValue_Ljava_lang_String_ == null)
				cb_getValue_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr>) n_GetValue_Ljava_lang_String_);
			return cb_getValue_Ljava_lang_String_;
		}

		static IntPtr n_GetValue_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Org.Apache.Commons.Math3.Exception.Util.ExceptionContext __this = global::Java.Lang.Object.GetObject<global::Org.Apache.Commons.Math3.Exception.Util.ExceptionContext> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.GetValue (p0));
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_getValue_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.exception.util']/class[@name='ExceptionContext']/method[@name='getValue' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("getValue", "(Ljava/lang/String;)Ljava/lang/Object;", "GetGetValue_Ljava_lang_String_Handler")]
		public virtual unsafe global::Java.Lang.Object GetValue (string p0)
		{
			if (id_getValue_Ljava_lang_String_ == IntPtr.Zero)
				id_getValue_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "getValue", "(Ljava/lang/String;)Ljava/lang/Object;");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				global::Java.Lang.Object __ret;
				if (((object) this).GetType () == ThresholdType)
					__ret = global::Java.Lang.Object.GetObject<global::Java.Lang.Object> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getValue_Ljava_lang_String_, __args), JniHandleOwnership.TransferLocalRef);
				else
					__ret = global::Java.Lang.Object.GetObject<global::Java.Lang.Object> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getValue", "(Ljava/lang/String;)Ljava/lang/Object;"), __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_setValue_Ljava_lang_String_Ljava_lang_Object_;
#pragma warning disable 0169
		static Delegate GetSetValue_Ljava_lang_String_Ljava_lang_Object_Handler ()
		{
			if (cb_setValue_Ljava_lang_String_Ljava_lang_Object_ == null)
				cb_setValue_Ljava_lang_String_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr>) n_SetValue_Ljava_lang_String_Ljava_lang_Object_);
			return cb_setValue_Ljava_lang_String_Ljava_lang_Object_;
		}

		static void n_SetValue_Ljava_lang_String_Ljava_lang_Object_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			global::Org.Apache.Commons.Math3.Exception.Util.ExceptionContext __this = global::Java.Lang.Object.GetObject<global::Org.Apache.Commons.Math3.Exception.Util.ExceptionContext> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Java.Lang.Object p1 = global::Java.Lang.Object.GetObject<global::Java.Lang.Object> (native_p1, JniHandleOwnership.DoNotTransfer);
			__this.SetValue (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_setValue_Ljava_lang_String_Ljava_lang_Object_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.exception.util']/class[@name='ExceptionContext']/method[@name='setValue' and count(parameter)=2 and parameter[1][@type='java.lang.String'] and parameter[2][@type='java.lang.Object']]"
		[Register ("setValue", "(Ljava/lang/String;Ljava/lang/Object;)V", "GetSetValue_Ljava_lang_String_Ljava_lang_Object_Handler")]
		public virtual unsafe void SetValue (string p0, global::Java.Lang.Object p1)
		{
			if (id_setValue_Ljava_lang_String_Ljava_lang_Object_ == IntPtr.Zero)
				id_setValue_Ljava_lang_String_Ljava_lang_Object_ = JNIEnv.GetMethodID (class_ref, "setValue", "(Ljava/lang/String;Ljava/lang/Object;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setValue_Ljava_lang_String_Ljava_lang_Object_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setValue", "(Ljava/lang/String;Ljava/lang/Object;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

	}
}
