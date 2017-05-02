using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Org.Apache.Commons.Math3.Exception.Util {

	// Metadata.xml XPath interface reference: path="/api/package[@name='org.apache.commons.math3.exception.util']/interface[@name='ExceptionContextProvider']"
	[Register ("org/apache/commons/math3/exception/util/ExceptionContextProvider", "", "Org.Apache.Commons.Math3.Exception.Util.IExceptionContextProviderInvoker")]
	public partial interface IExceptionContextProvider : IJavaObject {

		global::Org.Apache.Commons.Math3.Exception.Util.ExceptionContext Context {
			// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.exception.util']/interface[@name='ExceptionContextProvider']/method[@name='getContext' and count(parameter)=0]"
			[Register ("getContext", "()Lorg/apache/commons/math3/exception/util/ExceptionContext;", "GetGetContextHandler:Org.Apache.Commons.Math3.Exception.Util.IExceptionContextProviderInvoker, JarBinding")] get;
		}

	}

	[global::Android.Runtime.Register ("org/apache/commons/math3/exception/util/ExceptionContextProvider", DoNotGenerateAcw=true)]
	internal class IExceptionContextProviderInvoker : global::Java.Lang.Object, IExceptionContextProvider {

		static IntPtr java_class_ref = JNIEnv.FindClass ("org/apache/commons/math3/exception/util/ExceptionContextProvider");

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (IExceptionContextProviderInvoker); }
		}

		IntPtr class_ref;

		public static IExceptionContextProvider GetObject (IntPtr handle, JniHandleOwnership transfer)
		{
			return global::Java.Lang.Object.GetObject<IExceptionContextProvider> (handle, transfer);
		}

		static IntPtr Validate (IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf (handle, java_class_ref))
				throw new InvalidCastException (string.Format ("Unable to convert instance of type '{0}' to type '{1}'.",
							JNIEnv.GetClassNameFromInstance (handle), "org.apache.commons.math3.exception.util.ExceptionContextProvider"));
			return handle;
		}

		protected override void Dispose (bool disposing)
		{
			if (this.class_ref != IntPtr.Zero)
				JNIEnv.DeleteGlobalRef (this.class_ref);
			this.class_ref = IntPtr.Zero;
			base.Dispose (disposing);
		}

		public IExceptionContextProviderInvoker (IntPtr handle, JniHandleOwnership transfer) : base (Validate (handle), transfer)
		{
			IntPtr local_ref = JNIEnv.GetObjectClass (((global::Java.Lang.Object) this).Handle);
			this.class_ref = JNIEnv.NewGlobalRef (local_ref);
			JNIEnv.DeleteLocalRef (local_ref);
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
			global::Org.Apache.Commons.Math3.Exception.Util.IExceptionContextProvider __this = global::Java.Lang.Object.GetObject<global::Org.Apache.Commons.Math3.Exception.Util.IExceptionContextProvider> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.Context);
		}
#pragma warning restore 0169

		IntPtr id_getContext;
		public unsafe global::Org.Apache.Commons.Math3.Exception.Util.ExceptionContext Context {
			get {
				if (id_getContext == IntPtr.Zero)
					id_getContext = JNIEnv.GetMethodID (class_ref, "getContext", "()Lorg/apache/commons/math3/exception/util/ExceptionContext;");
				return global::Java.Lang.Object.GetObject<global::Org.Apache.Commons.Math3.Exception.Util.ExceptionContext> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getContext), JniHandleOwnership.TransferLocalRef);
			}
		}

	}

}
