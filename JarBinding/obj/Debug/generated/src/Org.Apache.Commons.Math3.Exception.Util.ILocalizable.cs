using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Org.Apache.Commons.Math3.Exception.Util {

	// Metadata.xml XPath interface reference: path="/api/package[@name='org.apache.commons.math3.exception.util']/interface[@name='Localizable']"
	[Register ("org/apache/commons/math3/exception/util/Localizable", "", "Org.Apache.Commons.Math3.Exception.Util.ILocalizableInvoker")]
	public partial interface ILocalizable : global::Java.IO.ISerializable {

		string SourceString {
			// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.exception.util']/interface[@name='Localizable']/method[@name='getSourceString' and count(parameter)=0]"
			[Register ("getSourceString", "()Ljava/lang/String;", "GetGetSourceStringHandler:Org.Apache.Commons.Math3.Exception.Util.ILocalizableInvoker, JarBinding")] get;
		}

		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.exception.util']/interface[@name='Localizable']/method[@name='getLocalizedString' and count(parameter)=1 and parameter[1][@type='java.util.Locale']]"
		[Register ("getLocalizedString", "(Ljava/util/Locale;)Ljava/lang/String;", "GetGetLocalizedString_Ljava_util_Locale_Handler:Org.Apache.Commons.Math3.Exception.Util.ILocalizableInvoker, JarBinding")]
		string GetLocalizedString (global::Java.Util.Locale p0);

	}

	[global::Android.Runtime.Register ("org/apache/commons/math3/exception/util/Localizable", DoNotGenerateAcw=true)]
	internal class ILocalizableInvoker : global::Java.Lang.Object, ILocalizable {

		static IntPtr java_class_ref = JNIEnv.FindClass ("org/apache/commons/math3/exception/util/Localizable");

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (ILocalizableInvoker); }
		}

		IntPtr class_ref;

		public static ILocalizable GetObject (IntPtr handle, JniHandleOwnership transfer)
		{
			return global::Java.Lang.Object.GetObject<ILocalizable> (handle, transfer);
		}

		static IntPtr Validate (IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf (handle, java_class_ref))
				throw new InvalidCastException (string.Format ("Unable to convert instance of type '{0}' to type '{1}'.",
							JNIEnv.GetClassNameFromInstance (handle), "org.apache.commons.math3.exception.util.Localizable"));
			return handle;
		}

		protected override void Dispose (bool disposing)
		{
			if (this.class_ref != IntPtr.Zero)
				JNIEnv.DeleteGlobalRef (this.class_ref);
			this.class_ref = IntPtr.Zero;
			base.Dispose (disposing);
		}

		public ILocalizableInvoker (IntPtr handle, JniHandleOwnership transfer) : base (Validate (handle), transfer)
		{
			IntPtr local_ref = JNIEnv.GetObjectClass (((global::Java.Lang.Object) this).Handle);
			this.class_ref = JNIEnv.NewGlobalRef (local_ref);
			JNIEnv.DeleteLocalRef (local_ref);
		}

		static Delegate cb_getSourceString;
#pragma warning disable 0169
		static Delegate GetGetSourceStringHandler ()
		{
			if (cb_getSourceString == null)
				cb_getSourceString = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetSourceString);
			return cb_getSourceString;
		}

		static IntPtr n_GetSourceString (IntPtr jnienv, IntPtr native__this)
		{
			global::Org.Apache.Commons.Math3.Exception.Util.ILocalizable __this = global::Java.Lang.Object.GetObject<global::Org.Apache.Commons.Math3.Exception.Util.ILocalizable> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.SourceString);
		}
#pragma warning restore 0169

		IntPtr id_getSourceString;
		public unsafe string SourceString {
			get {
				if (id_getSourceString == IntPtr.Zero)
					id_getSourceString = JNIEnv.GetMethodID (class_ref, "getSourceString", "()Ljava/lang/String;");
				return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getSourceString), JniHandleOwnership.TransferLocalRef);
			}
		}

		static Delegate cb_getLocalizedString_Ljava_util_Locale_;
#pragma warning disable 0169
		static Delegate GetGetLocalizedString_Ljava_util_Locale_Handler ()
		{
			if (cb_getLocalizedString_Ljava_util_Locale_ == null)
				cb_getLocalizedString_Ljava_util_Locale_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr>) n_GetLocalizedString_Ljava_util_Locale_);
			return cb_getLocalizedString_Ljava_util_Locale_;
		}

		static IntPtr n_GetLocalizedString_Ljava_util_Locale_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Org.Apache.Commons.Math3.Exception.Util.ILocalizable __this = global::Java.Lang.Object.GetObject<global::Org.Apache.Commons.Math3.Exception.Util.ILocalizable> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Java.Util.Locale p0 = global::Java.Lang.Object.GetObject<global::Java.Util.Locale> (native_p0, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = JNIEnv.NewString (__this.GetLocalizedString (p0));
			return __ret;
		}
#pragma warning restore 0169

		IntPtr id_getLocalizedString_Ljava_util_Locale_;
		public unsafe string GetLocalizedString (global::Java.Util.Locale p0)
		{
			if (id_getLocalizedString_Ljava_util_Locale_ == IntPtr.Zero)
				id_getLocalizedString_Ljava_util_Locale_ = JNIEnv.GetMethodID (class_ref, "getLocalizedString", "(Ljava/util/Locale;)Ljava/lang/String;");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue (p0);
			string __ret = JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getLocalizedString_Ljava_util_Locale_, __args), JniHandleOwnership.TransferLocalRef);
			return __ret;
		}

	}

}
