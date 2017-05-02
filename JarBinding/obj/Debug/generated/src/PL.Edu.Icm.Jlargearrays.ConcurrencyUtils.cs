using System;
using System.Collections.Generic;
using Android.Runtime;

namespace PL.Edu.Icm.Jlargearrays {

	// Metadata.xml XPath class reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='ConcurrencyUtils']"
	[global::Android.Runtime.Register ("pl/edu/icm/jlargearrays/ConcurrencyUtils", DoNotGenerateAcw=true)]
	public partial class ConcurrencyUtils : global::Java.Lang.Object {

		// Metadata.xml XPath class reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='ConcurrencyUtils.CustomExceptionHandler']"
		[global::Android.Runtime.Register ("pl/edu/icm/jlargearrays/ConcurrencyUtils$CustomExceptionHandler", DoNotGenerateAcw=true)]
		public partial class CustomExceptionHandler : global::Java.Lang.Object, global::Java.Lang.Thread.IUncaughtExceptionHandler {

			internal static IntPtr java_class_handle;
			internal static IntPtr class_ref {
				get {
					return JNIEnv.FindClass ("pl/edu/icm/jlargearrays/ConcurrencyUtils$CustomExceptionHandler", ref java_class_handle);
				}
			}

			protected override IntPtr ThresholdClass {
				get { return class_ref; }
			}

			protected override global::System.Type ThresholdType {
				get { return typeof (CustomExceptionHandler); }
			}

			protected CustomExceptionHandler (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

			static Delegate cb_uncaughtException_Ljava_lang_Thread_Ljava_lang_Throwable_;
#pragma warning disable 0169
			static Delegate GetUncaughtException_Ljava_lang_Thread_Ljava_lang_Throwable_Handler ()
			{
				if (cb_uncaughtException_Ljava_lang_Thread_Ljava_lang_Throwable_ == null)
					cb_uncaughtException_Ljava_lang_Thread_Ljava_lang_Throwable_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr>) n_UncaughtException_Ljava_lang_Thread_Ljava_lang_Throwable_);
				return cb_uncaughtException_Ljava_lang_Thread_Ljava_lang_Throwable_;
			}

			static void n_UncaughtException_Ljava_lang_Thread_Ljava_lang_Throwable_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
			{
				global::PL.Edu.Icm.Jlargearrays.ConcurrencyUtils.CustomExceptionHandler __this = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.ConcurrencyUtils.CustomExceptionHandler> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				global::Java.Lang.Thread p0 = global::Java.Lang.Object.GetObject<global::Java.Lang.Thread> (native_p0, JniHandleOwnership.DoNotTransfer);
				global::Java.Lang.Throwable p1 = global::Java.Lang.Object.GetObject<global::Java.Lang.Throwable> (native_p1, JniHandleOwnership.DoNotTransfer);
				__this.UncaughtException (p0, p1);
			}
#pragma warning restore 0169

			static IntPtr id_uncaughtException_Ljava_lang_Thread_Ljava_lang_Throwable_;
			// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='ConcurrencyUtils.CustomExceptionHandler']/method[@name='uncaughtException' and count(parameter)=2 and parameter[1][@type='java.lang.Thread'] and parameter[2][@type='java.lang.Throwable']]"
			[Register ("uncaughtException", "(Ljava/lang/Thread;Ljava/lang/Throwable;)V", "GetUncaughtException_Ljava_lang_Thread_Ljava_lang_Throwable_Handler")]
			public virtual unsafe void UncaughtException (global::Java.Lang.Thread p0, global::Java.Lang.Throwable p1)
			{
				if (id_uncaughtException_Ljava_lang_Thread_Ljava_lang_Throwable_ == IntPtr.Zero)
					id_uncaughtException_Ljava_lang_Thread_Ljava_lang_Throwable_ = JNIEnv.GetMethodID (class_ref, "uncaughtException", "(Ljava/lang/Thread;Ljava/lang/Throwable;)V");
				try {
					JValue* __args = stackalloc JValue [2];
					__args [0] = new JValue (p0);
					__args [1] = new JValue (p1);

					if (((object) this).GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_uncaughtException_Ljava_lang_Thread_Ljava_lang_Throwable_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "uncaughtException", "(Ljava/lang/Thread;Ljava/lang/Throwable;)V"), __args);
				} finally {
				}
			}

		}

		// Metadata.xml XPath class reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='ConcurrencyUtils.CustomThreadFactory']"
		[global::Android.Runtime.Register ("pl/edu/icm/jlargearrays/ConcurrencyUtils$CustomThreadFactory", DoNotGenerateAcw=true)]
		public partial class CustomThreadFactory : global::Java.Lang.Object, global::Java.Util.Concurrent.IThreadFactory {

			internal static IntPtr java_class_handle;
			internal static IntPtr class_ref {
				get {
					return JNIEnv.FindClass ("pl/edu/icm/jlargearrays/ConcurrencyUtils$CustomThreadFactory", ref java_class_handle);
				}
			}

			protected override IntPtr ThresholdClass {
				get { return class_ref; }
			}

			protected override global::System.Type ThresholdType {
				get { return typeof (CustomThreadFactory); }
			}

			protected CustomThreadFactory (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

			static Delegate cb_newThread_Ljava_lang_Runnable_;
#pragma warning disable 0169
			static Delegate GetNewThread_Ljava_lang_Runnable_Handler ()
			{
				if (cb_newThread_Ljava_lang_Runnable_ == null)
					cb_newThread_Ljava_lang_Runnable_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr>) n_NewThread_Ljava_lang_Runnable_);
				return cb_newThread_Ljava_lang_Runnable_;
			}

			static IntPtr n_NewThread_Ljava_lang_Runnable_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				global::PL.Edu.Icm.Jlargearrays.ConcurrencyUtils.CustomThreadFactory __this = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.ConcurrencyUtils.CustomThreadFactory> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				global::Java.Lang.IRunnable p0 = (global::Java.Lang.IRunnable)global::Java.Lang.Object.GetObject<global::Java.Lang.IRunnable> (native_p0, JniHandleOwnership.DoNotTransfer);
				IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.NewThread (p0));
				return __ret;
			}
#pragma warning restore 0169

			static IntPtr id_newThread_Ljava_lang_Runnable_;
			// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='ConcurrencyUtils.CustomThreadFactory']/method[@name='newThread' and count(parameter)=1 and parameter[1][@type='java.lang.Runnable']]"
			[Register ("newThread", "(Ljava/lang/Runnable;)Ljava/lang/Thread;", "GetNewThread_Ljava_lang_Runnable_Handler")]
			public virtual unsafe global::Java.Lang.Thread NewThread (global::Java.Lang.IRunnable p0)
			{
				if (id_newThread_Ljava_lang_Runnable_ == IntPtr.Zero)
					id_newThread_Ljava_lang_Runnable_ = JNIEnv.GetMethodID (class_ref, "newThread", "(Ljava/lang/Runnable;)Ljava/lang/Thread;");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (p0);

					global::Java.Lang.Thread __ret;
					if (((object) this).GetType () == ThresholdType)
						__ret = global::Java.Lang.Object.GetObject<global::Java.Lang.Thread> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_newThread_Ljava_lang_Runnable_, __args), JniHandleOwnership.TransferLocalRef);
					else
						__ret = global::Java.Lang.Object.GetObject<global::Java.Lang.Thread> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "newThread", "(Ljava/lang/Runnable;)Ljava/lang/Thread;"), __args), JniHandleOwnership.TransferLocalRef);
					return __ret;
				} finally {
				}
			}

		}

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("pl/edu/icm/jlargearrays/ConcurrencyUtils", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (ConcurrencyUtils); }
		}

		protected ConcurrencyUtils (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_getConcurrentThreshold;
		static IntPtr id_setConcurrentThreshold_J;
		public static unsafe long ConcurrentThreshold {
			// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='ConcurrencyUtils']/method[@name='getConcurrentThreshold' and count(parameter)=0]"
			[Register ("getConcurrentThreshold", "()J", "GetGetConcurrentThresholdHandler")]
			get {
				if (id_getConcurrentThreshold == IntPtr.Zero)
					id_getConcurrentThreshold = JNIEnv.GetStaticMethodID (class_ref, "getConcurrentThreshold", "()J");
				try {
					return JNIEnv.CallStaticLongMethod  (class_ref, id_getConcurrentThreshold);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='ConcurrencyUtils']/method[@name='setConcurrentThreshold' and count(parameter)=1 and parameter[1][@type='long']]"
			[Register ("setConcurrentThreshold", "(J)V", "GetSetConcurrentThreshold_JHandler")]
			set {
				if (id_setConcurrentThreshold_J == IntPtr.Zero)
					id_setConcurrentThreshold_J = JNIEnv.GetStaticMethodID (class_ref, "setConcurrentThreshold", "(J)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);
					JNIEnv.CallStaticVoidMethod  (class_ref, id_setConcurrentThreshold_J, __args);
				} finally {
				}
			}
		}

		static IntPtr id_getNumberOfProcessors;
		public static unsafe int NumberOfProcessors {
			// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='ConcurrencyUtils']/method[@name='getNumberOfProcessors' and count(parameter)=0]"
			[Register ("getNumberOfProcessors", "()I", "GetGetNumberOfProcessorsHandler")]
			get {
				if (id_getNumberOfProcessors == IntPtr.Zero)
					id_getNumberOfProcessors = JNIEnv.GetStaticMethodID (class_ref, "getNumberOfProcessors", "()I");
				try {
					return JNIEnv.CallStaticIntMethod  (class_ref, id_getNumberOfProcessors);
				} finally {
				}
			}
		}

		static IntPtr id_getNumberOfThreads;
		static IntPtr id_setNumberOfThreads_I;
		public static unsafe int NumberOfThreads {
			// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='ConcurrencyUtils']/method[@name='getNumberOfThreads' and count(parameter)=0]"
			[Register ("getNumberOfThreads", "()I", "GetGetNumberOfThreadsHandler")]
			get {
				if (id_getNumberOfThreads == IntPtr.Zero)
					id_getNumberOfThreads = JNIEnv.GetStaticMethodID (class_ref, "getNumberOfThreads", "()I");
				try {
					return JNIEnv.CallStaticIntMethod  (class_ref, id_getNumberOfThreads);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='ConcurrencyUtils']/method[@name='setNumberOfThreads' and count(parameter)=1 and parameter[1][@type='int']]"
			[Register ("setNumberOfThreads", "(I)V", "GetSetNumberOfThreads_IHandler")]
			set {
				if (id_setNumberOfThreads_I == IntPtr.Zero)
					id_setNumberOfThreads_I = JNIEnv.GetStaticMethodID (class_ref, "setNumberOfThreads", "(I)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);
					JNIEnv.CallStaticVoidMethod  (class_ref, id_setNumberOfThreads_I, __args);
				} finally {
				}
			}
		}

		static IntPtr id_getThreadPool;
		static IntPtr id_setThreadPool_Ljava_util_concurrent_ExecutorService_;
		public static unsafe global::Java.Util.Concurrent.IExecutorService ThreadPool {
			// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='ConcurrencyUtils']/method[@name='getThreadPool' and count(parameter)=0]"
			[Register ("getThreadPool", "()Ljava/util/concurrent/ExecutorService;", "GetGetThreadPoolHandler")]
			get {
				if (id_getThreadPool == IntPtr.Zero)
					id_getThreadPool = JNIEnv.GetStaticMethodID (class_ref, "getThreadPool", "()Ljava/util/concurrent/ExecutorService;");
				try {
					return global::Java.Lang.Object.GetObject<global::Java.Util.Concurrent.IExecutorService> (JNIEnv.CallStaticObjectMethod  (class_ref, id_getThreadPool), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='ConcurrencyUtils']/method[@name='setThreadPool' and count(parameter)=1 and parameter[1][@type='java.util.concurrent.ExecutorService']]"
			[Register ("setThreadPool", "(Ljava/util/concurrent/ExecutorService;)V", "GetSetThreadPool_Ljava_util_concurrent_ExecutorService_Handler")]
			set {
				if (id_setThreadPool_Ljava_util_concurrent_ExecutorService_ == IntPtr.Zero)
					id_setThreadPool_Ljava_util_concurrent_ExecutorService_ = JNIEnv.GetStaticMethodID (class_ref, "setThreadPool", "(Ljava/util/concurrent/ExecutorService;)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);
					JNIEnv.CallStaticVoidMethod  (class_ref, id_setThreadPool_Ljava_util_concurrent_ExecutorService_, __args);
				} finally {
				}
			}
		}

		static IntPtr id_shutdownThreadPoolAndAwaitTermination;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='ConcurrencyUtils']/method[@name='shutdownThreadPoolAndAwaitTermination' and count(parameter)=0]"
		[Register ("shutdownThreadPoolAndAwaitTermination", "()V", "")]
		public static unsafe void ShutdownThreadPoolAndAwaitTermination ()
		{
			if (id_shutdownThreadPoolAndAwaitTermination == IntPtr.Zero)
				id_shutdownThreadPoolAndAwaitTermination = JNIEnv.GetStaticMethodID (class_ref, "shutdownThreadPoolAndAwaitTermination", "()V");
			try {
				JNIEnv.CallStaticVoidMethod  (class_ref, id_shutdownThreadPoolAndAwaitTermination);
			} finally {
			}
		}

		static IntPtr id_submit_Ljava_lang_Runnable_;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='ConcurrencyUtils']/method[@name='submit' and count(parameter)=1 and parameter[1][@type='java.lang.Runnable']]"
		[Register ("submit", "(Ljava/lang/Runnable;)Ljava/util/concurrent/Future;", "")]
		public static unsafe global::Java.Util.Concurrent.IFuture Submit (global::Java.Lang.IRunnable p0)
		{
			if (id_submit_Ljava_lang_Runnable_ == IntPtr.Zero)
				id_submit_Ljava_lang_Runnable_ = JNIEnv.GetStaticMethodID (class_ref, "submit", "(Ljava/lang/Runnable;)Ljava/util/concurrent/Future;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				global::Java.Util.Concurrent.IFuture __ret = global::Java.Lang.Object.GetObject<global::Java.Util.Concurrent.IFuture> (JNIEnv.CallStaticObjectMethod  (class_ref, id_submit_Ljava_lang_Runnable_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static IntPtr id_submit_Ljava_util_concurrent_Callable_;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='ConcurrencyUtils']/method[@name='submit' and count(parameter)=1 and parameter[1][@type='java.util.concurrent.Callable&lt;T&gt;']]"
		[Register ("submit", "(Ljava/util/concurrent/Callable;)Ljava/util/concurrent/Future;", "")]
		[global::Java.Interop.JavaTypeParameters (new string [] {"T"})]
		public static unsafe global::Java.Util.Concurrent.IFuture Submit (global::Java.Util.Concurrent.ICallable p0)
		{
			if (id_submit_Ljava_util_concurrent_Callable_ == IntPtr.Zero)
				id_submit_Ljava_util_concurrent_Callable_ = JNIEnv.GetStaticMethodID (class_ref, "submit", "(Ljava/util/concurrent/Callable;)Ljava/util/concurrent/Future;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				global::Java.Util.Concurrent.IFuture __ret = global::Java.Lang.Object.GetObject<global::Java.Util.Concurrent.IFuture> (JNIEnv.CallStaticObjectMethod  (class_ref, id_submit_Ljava_util_concurrent_Callable_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static IntPtr id_waitForCompletion_arrayLjava_util_concurrent_Future_;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='ConcurrencyUtils']/method[@name='waitForCompletion' and count(parameter)=1 and parameter[1][@type='java.util.concurrent.Future&lt;?&gt;[]']]"
		[Register ("waitForCompletion", "([Ljava/util/concurrent/Future;)V", "")]
		public static unsafe void WaitForCompletion (global::Java.Util.Concurrent.IFuture[] p0)
		{
			if (id_waitForCompletion_arrayLjava_util_concurrent_Future_ == IntPtr.Zero)
				id_waitForCompletion_arrayLjava_util_concurrent_Future_ = JNIEnv.GetStaticMethodID (class_ref, "waitForCompletion", "([Ljava/util/concurrent/Future;)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_waitForCompletion_arrayLjava_util_concurrent_Future_, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

	}
}
