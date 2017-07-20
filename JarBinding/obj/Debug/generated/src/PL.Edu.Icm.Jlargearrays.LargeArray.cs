using System;
using System.Collections.Generic;
using Android.Runtime;

namespace PL.Edu.Icm.Jlargearrays {

	// Metadata.xml XPath class reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']"
	[global::Android.Runtime.Register ("pl/edu/icm/jlargearrays/LargeArray", DoNotGenerateAcw=true)]
	public abstract partial class LargeArray : global::Java.Lang.Object, global::Java.IO.ISerializable, global::Java.Lang.ICloneable {


		// Metadata.xml XPath field reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/field[@name='LARGEST_SUBARRAY']"
		[Register ("LARGEST_SUBARRAY")]
		public const int LargestSubarray = (int) 1073741824;

		static IntPtr parent_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/field[@name='parent']"
		[Register ("parent")]
		protected global::Java.Lang.Object Parent {
			get {
				if (parent_jfieldId == IntPtr.Zero)
					parent_jfieldId = JNIEnv.GetFieldID (class_ref, "parent", "Ljava/lang/Object;");
				IntPtr __ret = JNIEnv.GetObjectField (((global::Java.Lang.Object) this).Handle, parent_jfieldId);
				return global::Java.Lang.Object.GetObject<global::Java.Lang.Object> (__ret, JniHandleOwnership.TransferLocalRef);
			}
			set {
				if (parent_jfieldId == IntPtr.Zero)
					parent_jfieldId = JNIEnv.GetFieldID (class_ref, "parent", "Ljava/lang/Object;");
				IntPtr native_value = JNIEnv.ToLocalJniHandle (value);
				try {
					JNIEnv.SetField (((global::Java.Lang.Object) this).Handle, parent_jfieldId, native_value);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static IntPtr ptr_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/field[@name='ptr']"
		[Register ("ptr")]
		protected long Ptr {
			get {
				if (ptr_jfieldId == IntPtr.Zero)
					ptr_jfieldId = JNIEnv.GetFieldID (class_ref, "ptr", "J");
				return JNIEnv.GetLongField (((global::Java.Lang.Object) this).Handle, ptr_jfieldId);
			}
			set {
				if (ptr_jfieldId == IntPtr.Zero)
					ptr_jfieldId = JNIEnv.GetFieldID (class_ref, "ptr", "J");
				try {
					JNIEnv.SetField (((global::Java.Lang.Object) this).Handle, ptr_jfieldId, value);
				} finally {
				}
			}
		}

		static IntPtr sizeof_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/field[@name='sizeof']"
		[Register ("sizeof")]
		protected long Sizeof {
			get {
				if (sizeof_jfieldId == IntPtr.Zero)
					sizeof_jfieldId = JNIEnv.GetFieldID (class_ref, "sizeof", "J");
				return JNIEnv.GetLongField (((global::Java.Lang.Object) this).Handle, sizeof_jfieldId);
			}
			set {
				if (sizeof_jfieldId == IntPtr.Zero)
					sizeof_jfieldId = JNIEnv.GetFieldID (class_ref, "sizeof", "J");
				try {
					JNIEnv.SetField (((global::Java.Lang.Object) this).Handle, sizeof_jfieldId, value);
				} finally {
				}
			}
		}
		// Metadata.xml XPath class reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray.Deallocator']"
		[global::Android.Runtime.Register ("pl/edu/icm/jlargearrays/LargeArray$Deallocator", DoNotGenerateAcw=true)]
		protected internal partial class Deallocator : global::Java.Lang.Object, global::Java.Lang.IRunnable {

			internal static IntPtr java_class_handle;
			internal static IntPtr class_ref {
				get {
					return JNIEnv.FindClass ("pl/edu/icm/jlargearrays/LargeArray$Deallocator", ref java_class_handle);
				}
			}

			protected override IntPtr ThresholdClass {
				get { return class_ref; }
			}

			protected override global::System.Type ThresholdType {
				get { return typeof (Deallocator); }
			}

			protected Deallocator (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

			static IntPtr id_ctor_JJJ;
			// Metadata.xml XPath constructor reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray.Deallocator']/constructor[@name='LargeArray.Deallocator' and count(parameter)=3 and parameter[1][@type='long'] and parameter[2][@type='long'] and parameter[3][@type='long']]"
			[Register (".ctor", "(JJJ)V", "")]
			public unsafe Deallocator (long p0, long p1, long p2)
				: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
					return;

				try {
					JValue* __args = stackalloc JValue [3];
					__args [0] = new JValue (p0);
					__args [1] = new JValue (p1);
					__args [2] = new JValue (p2);
					if (((object) this).GetType () != typeof (Deallocator)) {
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

			static Delegate cb_run;
#pragma warning disable 0169
			static Delegate GetRunHandler ()
			{
				if (cb_run == null)
					cb_run = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr>) n_Run);
				return cb_run;
			}

			static void n_Run (IntPtr jnienv, IntPtr native__this)
			{
				global::PL.Edu.Icm.Jlargearrays.LargeArray.Deallocator __this = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.LargeArray.Deallocator> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				__this.Run ();
			}
#pragma warning restore 0169

			static IntPtr id_run;
			// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray.Deallocator']/method[@name='run' and count(parameter)=0]"
			[Register ("run", "()V", "GetRunHandler")]
			public virtual unsafe void Run ()
			{
				if (id_run == IntPtr.Zero)
					id_run = JNIEnv.GetMethodID (class_ref, "run", "()V");
				try {

					if (((object) this).GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_run);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "run", "()V"));
				} finally {
				}
			}

		}

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("pl/edu/icm/jlargearrays/LargeArray", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (LargeArray); }
		}

		protected LargeArray (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/constructor[@name='LargeArray' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		protected unsafe LargeArray ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (((object) this).GetType () != typeof (LargeArray)) {
					SetHandle (
							global::Android.Runtime.JNIEnv.StartCreateInstance (((object) this).GetType (), "()V"),
							JniHandleOwnership.TransferLocalRef);
					global::Android.Runtime.JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, "()V");
					return;
				}

				if (id_ctor == IntPtr.Zero)
					id_ctor = JNIEnv.GetMethodID (class_ref, "<init>", "()V");
				SetHandle (
						global::Android.Runtime.JNIEnv.StartCreateInstance (class_ref, id_ctor),
						JniHandleOwnership.TransferLocalRef);
				JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, class_ref, id_ctor);
			} finally {
			}
		}

		static IntPtr id_ctor_Ljava_lang_Object_JLpl_edu_icm_jlargearrays_LargeArrayType_J;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/constructor[@name='LargeArray' and count(parameter)=4 and parameter[1][@type='java.lang.Object'] and parameter[2][@type='long'] and parameter[3][@type='pl.edu.icm.jlargearrays.LargeArrayType'] and parameter[4][@type='long']]"
		[Register (".ctor", "(Ljava/lang/Object;JLpl/edu/icm/jlargearrays/LargeArrayType;J)V", "")]
		public unsafe LargeArray (global::Java.Lang.Object p0, long p1, global::PL.Edu.Icm.Jlargearrays.LargeArrayType p2, long p3)
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				if (((object) this).GetType () != typeof (LargeArray)) {
					SetHandle (
							global::Android.Runtime.JNIEnv.StartCreateInstance (((object) this).GetType (), "(Ljava/lang/Object;JLpl/edu/icm/jlargearrays/LargeArrayType;J)V", __args),
							JniHandleOwnership.TransferLocalRef);
					global::Android.Runtime.JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, "(Ljava/lang/Object;JLpl/edu/icm/jlargearrays/LargeArrayType;J)V", __args);
					return;
				}

				if (id_ctor_Ljava_lang_Object_JLpl_edu_icm_jlargearrays_LargeArrayType_J == IntPtr.Zero)
					id_ctor_Ljava_lang_Object_JLpl_edu_icm_jlargearrays_LargeArrayType_J = JNIEnv.GetMethodID (class_ref, "<init>", "(Ljava/lang/Object;JLpl/edu/icm/jlargearrays/LargeArrayType;J)V");
				SetHandle (
						global::Android.Runtime.JNIEnv.StartCreateInstance (class_ref, id_ctor_Ljava_lang_Object_JLpl_edu_icm_jlargearrays_LargeArrayType_J, __args),
						JniHandleOwnership.TransferLocalRef);
				JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, class_ref, id_ctor_Ljava_lang_Object_JLpl_edu_icm_jlargearrays_LargeArrayType_J, __args);
			} finally {
			}
		}

		static Delegate cb_getData;
#pragma warning disable 0169
		static Delegate GetGetDataHandler ()
		{
			if (cb_getData == null)
				cb_getData = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetData);
			return cb_getData;
		}

		static IntPtr n_GetData (IntPtr jnienv, IntPtr native__this)
		{
			global::PL.Edu.Icm.Jlargearrays.LargeArray __this = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.LargeArray> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.Data);
		}
#pragma warning restore 0169

		public abstract global::Java.Lang.Object Data {
			// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='getData' and count(parameter)=0]"
			[Register ("getData", "()Ljava/lang/Object;", "GetGetDataHandler")] get;
		}

		static Delegate cb_isConstant;
#pragma warning disable 0169
		static Delegate GetIsConstantHandler ()
		{
			if (cb_isConstant == null)
				cb_isConstant = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, bool>) n_IsConstant);
			return cb_isConstant;
		}

		static bool n_IsConstant (IntPtr jnienv, IntPtr native__this)
		{
			global::PL.Edu.Icm.Jlargearrays.LargeArray __this = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.LargeArray> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.IsConstant;
		}
#pragma warning restore 0169

		static IntPtr id_isConstant;
		public virtual unsafe bool IsConstant {
			// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='isConstant' and count(parameter)=0]"
			[Register ("isConstant", "()Z", "GetIsConstantHandler")]
			get {
				if (id_isConstant == IntPtr.Zero)
					id_isConstant = JNIEnv.GetMethodID (class_ref, "isConstant", "()Z");
				try {

					if (((object) this).GetType () == ThresholdType)
						return JNIEnv.CallBooleanMethod (((global::Java.Lang.Object) this).Handle, id_isConstant);
					else
						return JNIEnv.CallNonvirtualBooleanMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "isConstant", "()Z"));
				} finally {
				}
			}
		}

		static Delegate cb_isLarge;
#pragma warning disable 0169
		static Delegate GetIsLargeHandler ()
		{
			if (cb_isLarge == null)
				cb_isLarge = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, bool>) n_IsLarge);
			return cb_isLarge;
		}

		static bool n_IsLarge (IntPtr jnienv, IntPtr native__this)
		{
			global::PL.Edu.Icm.Jlargearrays.LargeArray __this = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.LargeArray> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.IsLarge;
		}
#pragma warning restore 0169

		static IntPtr id_isLarge;
		public virtual unsafe bool IsLarge {
			// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='isLarge' and count(parameter)=0]"
			[Register ("isLarge", "()Z", "GetIsLargeHandler")]
			get {
				if (id_isLarge == IntPtr.Zero)
					id_isLarge = JNIEnv.GetMethodID (class_ref, "isLarge", "()Z");
				try {

					if (((object) this).GetType () == ThresholdType)
						return JNIEnv.CallBooleanMethod (((global::Java.Lang.Object) this).Handle, id_isLarge);
					else
						return JNIEnv.CallNonvirtualBooleanMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "isLarge", "()Z"));
				} finally {
				}
			}
		}

		static Delegate cb_isNumeric;
#pragma warning disable 0169
		static Delegate GetIsNumericHandler ()
		{
			if (cb_isNumeric == null)
				cb_isNumeric = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, bool>) n_IsNumeric);
			return cb_isNumeric;
		}

		static bool n_IsNumeric (IntPtr jnienv, IntPtr native__this)
		{
			global::PL.Edu.Icm.Jlargearrays.LargeArray __this = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.LargeArray> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.IsNumeric;
		}
#pragma warning restore 0169

		static IntPtr id_isNumeric;
		public virtual unsafe bool IsNumeric {
			// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='isNumeric' and count(parameter)=0]"
			[Register ("isNumeric", "()Z", "GetIsNumericHandler")]
			get {
				if (id_isNumeric == IntPtr.Zero)
					id_isNumeric = JNIEnv.GetMethodID (class_ref, "isNumeric", "()Z");
				try {

					if (((object) this).GetType () == ThresholdType)
						return JNIEnv.CallBooleanMethod (((global::Java.Lang.Object) this).Handle, id_isNumeric);
					else
						return JNIEnv.CallNonvirtualBooleanMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "isNumeric", "()Z"));
				} finally {
				}
			}
		}

		static IntPtr id_getMaxSizeOf32bitArray;
		static IntPtr id_setMaxSizeOf32bitArray_I;
		public static unsafe int MaxSizeOf32bitArray {
			// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='getMaxSizeOf32bitArray' and count(parameter)=0]"
			[Register ("getMaxSizeOf32bitArray", "()I", "GetGetMaxSizeOf32bitArrayHandler")]
			get {
				if (id_getMaxSizeOf32bitArray == IntPtr.Zero)
					id_getMaxSizeOf32bitArray = JNIEnv.GetStaticMethodID (class_ref, "getMaxSizeOf32bitArray", "()I");
				try {
					return JNIEnv.CallStaticIntMethod  (class_ref, id_getMaxSizeOf32bitArray);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='setMaxSizeOf32bitArray' and count(parameter)=1 and parameter[1][@type='int']]"
			[Register ("setMaxSizeOf32bitArray", "(I)V", "GetSetMaxSizeOf32bitArray_IHandler")]
			set {
				if (id_setMaxSizeOf32bitArray_I == IntPtr.Zero)
					id_setMaxSizeOf32bitArray_I = JNIEnv.GetStaticMethodID (class_ref, "setMaxSizeOf32bitArray", "(I)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);
					JNIEnv.CallStaticVoidMethod  (class_ref, id_setMaxSizeOf32bitArray_I, __args);
				} finally {
				}
			}
		}

		static Delegate cb_getType;
#pragma warning disable 0169
		static Delegate GetGetTypeHandler ()
		{
			if (cb_getType == null)
				cb_getType = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetType);
			return cb_getType;
		}

		static IntPtr n_GetType (IntPtr jnienv, IntPtr native__this)
		{
			global::PL.Edu.Icm.Jlargearrays.LargeArray __this = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.LargeArray> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.Type);
		}
#pragma warning restore 0169

		static IntPtr id_getType;
		public virtual unsafe global::PL.Edu.Icm.Jlargearrays.LargeArrayType Type {
			// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='getType' and count(parameter)=0]"
			[Register ("getType", "()Lpl/edu/icm/jlargearrays/LargeArrayType;", "GetGetTypeHandler")]
			get {
				if (id_getType == IntPtr.Zero)
					id_getType = JNIEnv.GetMethodID (class_ref, "getType", "()Lpl/edu/icm/jlargearrays/LargeArrayType;");
				try {

					if (((object) this).GetType () == ThresholdType)
						return global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.LargeArrayType> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getType), JniHandleOwnership.TransferLocalRef);
					else
						return global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.LargeArrayType> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getType", "()Lpl/edu/icm/jlargearrays/LargeArrayType;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_clone;
#pragma warning disable 0169
		static Delegate GetCloneHandler ()
		{
			if (cb_clone == null)
				cb_clone = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Clone);
			return cb_clone;
		}

		static IntPtr n_Clone (IntPtr jnienv, IntPtr native__this)
		{
			global::PL.Edu.Icm.Jlargearrays.LargeArray __this = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.LargeArray> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.Clone ());
		}
#pragma warning restore 0169

		static IntPtr id_clone;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='clone' and count(parameter)=0]"
		[Register ("clone", "()Ljava/lang/Object;", "GetCloneHandler")]
		public virtual unsafe global::Java.Lang.Object Clone ()
		{
			if (id_clone == IntPtr.Zero)
				id_clone = JNIEnv.GetMethodID (class_ref, "clone", "()Ljava/lang/Object;");
			try {

				if (((object) this).GetType () == ThresholdType)
					return global::Java.Lang.Object.GetObject<global::Java.Lang.Object> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_clone), JniHandleOwnership.TransferLocalRef);
				else
					return global::Java.Lang.Object.GetObject<global::Java.Lang.Object> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "clone", "()Ljava/lang/Object;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get_J;
#pragma warning disable 0169
		static Delegate GetGet_JHandler ()
		{
			if (cb_get_J == null)
				cb_get_J = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, long, IntPtr>) n_Get_J);
			return cb_get_J;
		}

		static IntPtr n_Get_J (IntPtr jnienv, IntPtr native__this, long p0)
		{
			global::PL.Edu.Icm.Jlargearrays.LargeArray __this = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.LargeArray> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.Get (p0));
		}
#pragma warning restore 0169

		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='get' and count(parameter)=1 and parameter[1][@type='long']]"
		[Register ("get", "(J)Ljava/lang/Object;", "GetGet_JHandler")]
		public abstract global::Java.Lang.Object Get (long p0);

		static Delegate cb_getBoolean_J;
#pragma warning disable 0169
		static Delegate GetGetBoolean_JHandler ()
		{
			if (cb_getBoolean_J == null)
				cb_getBoolean_J = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, long, bool>) n_GetBoolean_J);
			return cb_getBoolean_J;
		}

		static bool n_GetBoolean_J (IntPtr jnienv, IntPtr native__this, long p0)
		{
			global::PL.Edu.Icm.Jlargearrays.LargeArray __this = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.LargeArray> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.GetBoolean (p0);
		}
#pragma warning restore 0169

		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='getBoolean' and count(parameter)=1 and parameter[1][@type='long']]"
		[Register ("getBoolean", "(J)Z", "GetGetBoolean_JHandler")]
		public abstract bool GetBoolean (long p0);

		static Delegate cb_getBooleanData;
#pragma warning disable 0169
		static Delegate GetGetBooleanDataHandler ()
		{
			if (cb_getBooleanData == null)
				cb_getBooleanData = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetBooleanData);
			return cb_getBooleanData;
		}

		static IntPtr n_GetBooleanData (IntPtr jnienv, IntPtr native__this)
		{
			global::PL.Edu.Icm.Jlargearrays.LargeArray __this = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.LargeArray> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewArray (__this.GetBooleanData ());
		}
#pragma warning restore 0169

		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='getBooleanData' and count(parameter)=0]"
		[Register ("getBooleanData", "()[Z", "GetGetBooleanDataHandler")]
		public abstract bool[] GetBooleanData ();

		static Delegate cb_getBooleanData_arrayZJJJ;
#pragma warning disable 0169
		static Delegate GetGetBooleanData_arrayZJJJHandler ()
		{
			if (cb_getBooleanData_arrayZJJJ == null)
				cb_getBooleanData_arrayZJJJ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, long, long, long, IntPtr>) n_GetBooleanData_arrayZJJJ);
			return cb_getBooleanData_arrayZJJJ;
		}

		static IntPtr n_GetBooleanData_arrayZJJJ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, long p1, long p2, long p3)
		{
			global::PL.Edu.Icm.Jlargearrays.LargeArray __this = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.LargeArray> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool[] p0 = (bool[]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (bool));
			IntPtr __ret = JNIEnv.NewArray (__this.GetBooleanData (p0, p1, p2, p3));
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
			return __ret;
		}
#pragma warning restore 0169

		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='getBooleanData' and count(parameter)=4 and parameter[1][@type='boolean[]'] and parameter[2][@type='long'] and parameter[3][@type='long'] and parameter[4][@type='long']]"
		[Register ("getBooleanData", "([ZJJJ)[Z", "GetGetBooleanData_arrayZJJJHandler")]
		public abstract bool[] GetBooleanData (bool[] p0, long p1, long p2, long p3);

		static Delegate cb_getBoolean_safe_J;
#pragma warning disable 0169
		static Delegate GetGetBoolean_safe_JHandler ()
		{
			if (cb_getBoolean_safe_J == null)
				cb_getBoolean_safe_J = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, long, bool>) n_GetBoolean_safe_J);
			return cb_getBoolean_safe_J;
		}

		static bool n_GetBoolean_safe_J (IntPtr jnienv, IntPtr native__this, long p0)
		{
			global::PL.Edu.Icm.Jlargearrays.LargeArray __this = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.LargeArray> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.GetBoolean_safe (p0);
		}
#pragma warning restore 0169

		static IntPtr id_getBoolean_safe_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='getBoolean_safe' and count(parameter)=1 and parameter[1][@type='long']]"
		[Register ("getBoolean_safe", "(J)Z", "GetGetBoolean_safe_JHandler")]
		public virtual unsafe bool GetBoolean_safe (long p0)
		{
			if (id_getBoolean_safe_J == IntPtr.Zero)
				id_getBoolean_safe_J = JNIEnv.GetMethodID (class_ref, "getBoolean_safe", "(J)Z");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (((object) this).GetType () == ThresholdType)
					return JNIEnv.CallBooleanMethod (((global::Java.Lang.Object) this).Handle, id_getBoolean_safe_J, __args);
				else
					return JNIEnv.CallNonvirtualBooleanMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getBoolean_safe", "(J)Z"), __args);
			} finally {
			}
		}

		static Delegate cb_getByte_J;
#pragma warning disable 0169
		static Delegate GetGetByte_JHandler ()
		{
			if (cb_getByte_J == null)
				cb_getByte_J = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, long, sbyte>) n_GetByte_J);
			return cb_getByte_J;
		}

		static sbyte n_GetByte_J (IntPtr jnienv, IntPtr native__this, long p0)
		{
			global::PL.Edu.Icm.Jlargearrays.LargeArray __this = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.LargeArray> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.GetByte (p0);
		}
#pragma warning restore 0169

		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='getByte' and count(parameter)=1 and parameter[1][@type='long']]"
		[Register ("getByte", "(J)B", "GetGetByte_JHandler")]
		public abstract sbyte GetByte (long p0);

		static Delegate cb_getByteData;
#pragma warning disable 0169
		static Delegate GetGetByteDataHandler ()
		{
			if (cb_getByteData == null)
				cb_getByteData = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetByteData);
			return cb_getByteData;
		}

		static IntPtr n_GetByteData (IntPtr jnienv, IntPtr native__this)
		{
			global::PL.Edu.Icm.Jlargearrays.LargeArray __this = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.LargeArray> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewArray (__this.GetByteData ());
		}
#pragma warning restore 0169

		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='getByteData' and count(parameter)=0]"
		[Register ("getByteData", "()[B", "GetGetByteDataHandler")]
		public abstract byte[] GetByteData ();

		static Delegate cb_getByteData_arrayBJJJ;
#pragma warning disable 0169
		static Delegate GetGetByteData_arrayBJJJHandler ()
		{
			if (cb_getByteData_arrayBJJJ == null)
				cb_getByteData_arrayBJJJ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, long, long, long, IntPtr>) n_GetByteData_arrayBJJJ);
			return cb_getByteData_arrayBJJJ;
		}

		static IntPtr n_GetByteData_arrayBJJJ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, long p1, long p2, long p3)
		{
			global::PL.Edu.Icm.Jlargearrays.LargeArray __this = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.LargeArray> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			byte[] p0 = (byte[]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (byte));
			IntPtr __ret = JNIEnv.NewArray (__this.GetByteData (p0, p1, p2, p3));
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
			return __ret;
		}
#pragma warning restore 0169

		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='getByteData' and count(parameter)=4 and parameter[1][@type='byte[]'] and parameter[2][@type='long'] and parameter[3][@type='long'] and parameter[4][@type='long']]"
		[Register ("getByteData", "([BJJJ)[B", "GetGetByteData_arrayBJJJHandler")]
		public abstract byte[] GetByteData (byte[] p0, long p1, long p2, long p3);

		static Delegate cb_getByte_safe_J;
#pragma warning disable 0169
		static Delegate GetGetByte_safe_JHandler ()
		{
			if (cb_getByte_safe_J == null)
				cb_getByte_safe_J = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, long, sbyte>) n_GetByte_safe_J);
			return cb_getByte_safe_J;
		}

		static sbyte n_GetByte_safe_J (IntPtr jnienv, IntPtr native__this, long p0)
		{
			global::PL.Edu.Icm.Jlargearrays.LargeArray __this = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.LargeArray> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.GetByte_safe (p0);
		}
#pragma warning restore 0169

		static IntPtr id_getByte_safe_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='getByte_safe' and count(parameter)=1 and parameter[1][@type='long']]"
		[Register ("getByte_safe", "(J)B", "GetGetByte_safe_JHandler")]
		public virtual unsafe sbyte GetByte_safe (long p0)
		{
			if (id_getByte_safe_J == IntPtr.Zero)
				id_getByte_safe_J = JNIEnv.GetMethodID (class_ref, "getByte_safe", "(J)B");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (((object) this).GetType () == ThresholdType)
					return JNIEnv.CallByteMethod (((global::Java.Lang.Object) this).Handle, id_getByte_safe_J, __args);
				else
					return JNIEnv.CallNonvirtualByteMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getByte_safe", "(J)B"), __args);
			} finally {
			}
		}

		static Delegate cb_getDouble_J;
#pragma warning disable 0169
		static Delegate GetGetDouble_JHandler ()
		{
			if (cb_getDouble_J == null)
				cb_getDouble_J = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, long, double>) n_GetDouble_J);
			return cb_getDouble_J;
		}

		static double n_GetDouble_J (IntPtr jnienv, IntPtr native__this, long p0)
		{
			global::PL.Edu.Icm.Jlargearrays.LargeArray __this = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.LargeArray> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.GetDouble (p0);
		}
#pragma warning restore 0169

		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='getDouble' and count(parameter)=1 and parameter[1][@type='long']]"
		[Register ("getDouble", "(J)D", "GetGetDouble_JHandler")]
		public abstract double GetDouble (long p0);

		static Delegate cb_getDoubleData;
#pragma warning disable 0169
		static Delegate GetGetDoubleDataHandler ()
		{
			if (cb_getDoubleData == null)
				cb_getDoubleData = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetDoubleData);
			return cb_getDoubleData;
		}

		static IntPtr n_GetDoubleData (IntPtr jnienv, IntPtr native__this)
		{
			global::PL.Edu.Icm.Jlargearrays.LargeArray __this = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.LargeArray> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewArray (__this.GetDoubleData ());
		}
#pragma warning restore 0169

		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='getDoubleData' and count(parameter)=0]"
		[Register ("getDoubleData", "()[D", "GetGetDoubleDataHandler")]
		public abstract double[] GetDoubleData ();

		static Delegate cb_getDoubleData_arrayDJJJ;
#pragma warning disable 0169
		static Delegate GetGetDoubleData_arrayDJJJHandler ()
		{
			if (cb_getDoubleData_arrayDJJJ == null)
				cb_getDoubleData_arrayDJJJ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, long, long, long, IntPtr>) n_GetDoubleData_arrayDJJJ);
			return cb_getDoubleData_arrayDJJJ;
		}

		static IntPtr n_GetDoubleData_arrayDJJJ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, long p1, long p2, long p3)
		{
			global::PL.Edu.Icm.Jlargearrays.LargeArray __this = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.LargeArray> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			double[] p0 = (double[]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (double));
			IntPtr __ret = JNIEnv.NewArray (__this.GetDoubleData (p0, p1, p2, p3));
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
			return __ret;
		}
#pragma warning restore 0169

		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='getDoubleData' and count(parameter)=4 and parameter[1][@type='double[]'] and parameter[2][@type='long'] and parameter[3][@type='long'] and parameter[4][@type='long']]"
		[Register ("getDoubleData", "([DJJJ)[D", "GetGetDoubleData_arrayDJJJHandler")]
		public abstract double[] GetDoubleData (double[] p0, long p1, long p2, long p3);

		static Delegate cb_getDouble_safe_J;
#pragma warning disable 0169
		static Delegate GetGetDouble_safe_JHandler ()
		{
			if (cb_getDouble_safe_J == null)
				cb_getDouble_safe_J = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, long, double>) n_GetDouble_safe_J);
			return cb_getDouble_safe_J;
		}

		static double n_GetDouble_safe_J (IntPtr jnienv, IntPtr native__this, long p0)
		{
			global::PL.Edu.Icm.Jlargearrays.LargeArray __this = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.LargeArray> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.GetDouble_safe (p0);
		}
#pragma warning restore 0169

		static IntPtr id_getDouble_safe_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='getDouble_safe' and count(parameter)=1 and parameter[1][@type='long']]"
		[Register ("getDouble_safe", "(J)D", "GetGetDouble_safe_JHandler")]
		public virtual unsafe double GetDouble_safe (long p0)
		{
			if (id_getDouble_safe_J == IntPtr.Zero)
				id_getDouble_safe_J = JNIEnv.GetMethodID (class_ref, "getDouble_safe", "(J)D");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (((object) this).GetType () == ThresholdType)
					return JNIEnv.CallDoubleMethod (((global::Java.Lang.Object) this).Handle, id_getDouble_safe_J, __args);
				else
					return JNIEnv.CallNonvirtualDoubleMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getDouble_safe", "(J)D"), __args);
			} finally {
			}
		}

		static Delegate cb_getFloat_J;
#pragma warning disable 0169
		static Delegate GetGetFloat_JHandler ()
		{
			if (cb_getFloat_J == null)
				cb_getFloat_J = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, long, float>) n_GetFloat_J);
			return cb_getFloat_J;
		}

		static float n_GetFloat_J (IntPtr jnienv, IntPtr native__this, long p0)
		{
			global::PL.Edu.Icm.Jlargearrays.LargeArray __this = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.LargeArray> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.GetFloat (p0);
		}
#pragma warning restore 0169

		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='getFloat' and count(parameter)=1 and parameter[1][@type='long']]"
		[Register ("getFloat", "(J)F", "GetGetFloat_JHandler")]
		public abstract float GetFloat (long p0);

		static Delegate cb_getFloatData;
#pragma warning disable 0169
		static Delegate GetGetFloatDataHandler ()
		{
			if (cb_getFloatData == null)
				cb_getFloatData = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetFloatData);
			return cb_getFloatData;
		}

		static IntPtr n_GetFloatData (IntPtr jnienv, IntPtr native__this)
		{
			global::PL.Edu.Icm.Jlargearrays.LargeArray __this = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.LargeArray> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewArray (__this.GetFloatData ());
		}
#pragma warning restore 0169

		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='getFloatData' and count(parameter)=0]"
		[Register ("getFloatData", "()[F", "GetGetFloatDataHandler")]
		public abstract float[] GetFloatData ();

		static Delegate cb_getFloatData_arrayFJJJ;
#pragma warning disable 0169
		static Delegate GetGetFloatData_arrayFJJJHandler ()
		{
			if (cb_getFloatData_arrayFJJJ == null)
				cb_getFloatData_arrayFJJJ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, long, long, long, IntPtr>) n_GetFloatData_arrayFJJJ);
			return cb_getFloatData_arrayFJJJ;
		}

		static IntPtr n_GetFloatData_arrayFJJJ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, long p1, long p2, long p3)
		{
			global::PL.Edu.Icm.Jlargearrays.LargeArray __this = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.LargeArray> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			float[] p0 = (float[]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (float));
			IntPtr __ret = JNIEnv.NewArray (__this.GetFloatData (p0, p1, p2, p3));
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
			return __ret;
		}
#pragma warning restore 0169

		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='getFloatData' and count(parameter)=4 and parameter[1][@type='float[]'] and parameter[2][@type='long'] and parameter[3][@type='long'] and parameter[4][@type='long']]"
		[Register ("getFloatData", "([FJJJ)[F", "GetGetFloatData_arrayFJJJHandler")]
		public abstract float[] GetFloatData (float[] p0, long p1, long p2, long p3);

		static Delegate cb_getFloat_safe_J;
#pragma warning disable 0169
		static Delegate GetGetFloat_safe_JHandler ()
		{
			if (cb_getFloat_safe_J == null)
				cb_getFloat_safe_J = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, long, float>) n_GetFloat_safe_J);
			return cb_getFloat_safe_J;
		}

		static float n_GetFloat_safe_J (IntPtr jnienv, IntPtr native__this, long p0)
		{
			global::PL.Edu.Icm.Jlargearrays.LargeArray __this = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.LargeArray> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.GetFloat_safe (p0);
		}
#pragma warning restore 0169

		static IntPtr id_getFloat_safe_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='getFloat_safe' and count(parameter)=1 and parameter[1][@type='long']]"
		[Register ("getFloat_safe", "(J)F", "GetGetFloat_safe_JHandler")]
		public virtual unsafe float GetFloat_safe (long p0)
		{
			if (id_getFloat_safe_J == IntPtr.Zero)
				id_getFloat_safe_J = JNIEnv.GetMethodID (class_ref, "getFloat_safe", "(J)F");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (((object) this).GetType () == ThresholdType)
					return JNIEnv.CallFloatMethod (((global::Java.Lang.Object) this).Handle, id_getFloat_safe_J, __args);
				else
					return JNIEnv.CallNonvirtualFloatMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getFloat_safe", "(J)F"), __args);
			} finally {
			}
		}

		static Delegate cb_getFromNative_J;
#pragma warning disable 0169
		static Delegate GetGetFromNative_JHandler ()
		{
			if (cb_getFromNative_J == null)
				cb_getFromNative_J = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, long, IntPtr>) n_GetFromNative_J);
			return cb_getFromNative_J;
		}

		static IntPtr n_GetFromNative_J (IntPtr jnienv, IntPtr native__this, long p0)
		{
			global::PL.Edu.Icm.Jlargearrays.LargeArray __this = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.LargeArray> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.GetFromNative (p0));
		}
#pragma warning restore 0169

		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='getFromNative' and count(parameter)=1 and parameter[1][@type='long']]"
		[Register ("getFromNative", "(J)Ljava/lang/Object;", "GetGetFromNative_JHandler")]
		public abstract global::Java.Lang.Object GetFromNative (long p0);

		static Delegate cb_getInt_J;
#pragma warning disable 0169
		static Delegate GetGetInt_JHandler ()
		{
			if (cb_getInt_J == null)
				cb_getInt_J = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, long, int>) n_GetInt_J);
			return cb_getInt_J;
		}

		static int n_GetInt_J (IntPtr jnienv, IntPtr native__this, long p0)
		{
			global::PL.Edu.Icm.Jlargearrays.LargeArray __this = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.LargeArray> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.GetInt (p0);
		}
#pragma warning restore 0169

		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='getInt' and count(parameter)=1 and parameter[1][@type='long']]"
		[Register ("getInt", "(J)I", "GetGetInt_JHandler")]
		public abstract int GetInt (long p0);

		static Delegate cb_getIntData;
#pragma warning disable 0169
		static Delegate GetGetIntDataHandler ()
		{
			if (cb_getIntData == null)
				cb_getIntData = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetIntData);
			return cb_getIntData;
		}

		static IntPtr n_GetIntData (IntPtr jnienv, IntPtr native__this)
		{
			global::PL.Edu.Icm.Jlargearrays.LargeArray __this = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.LargeArray> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewArray (__this.GetIntData ());
		}
#pragma warning restore 0169

		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='getIntData' and count(parameter)=0]"
		[Register ("getIntData", "()[I", "GetGetIntDataHandler")]
		public abstract int[] GetIntData ();

		static Delegate cb_getIntData_arrayIJJJ;
#pragma warning disable 0169
		static Delegate GetGetIntData_arrayIJJJHandler ()
		{
			if (cb_getIntData_arrayIJJJ == null)
				cb_getIntData_arrayIJJJ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, long, long, long, IntPtr>) n_GetIntData_arrayIJJJ);
			return cb_getIntData_arrayIJJJ;
		}

		static IntPtr n_GetIntData_arrayIJJJ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, long p1, long p2, long p3)
		{
			global::PL.Edu.Icm.Jlargearrays.LargeArray __this = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.LargeArray> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			int[] p0 = (int[]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (int));
			IntPtr __ret = JNIEnv.NewArray (__this.GetIntData (p0, p1, p2, p3));
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
			return __ret;
		}
#pragma warning restore 0169

		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='getIntData' and count(parameter)=4 and parameter[1][@type='int[]'] and parameter[2][@type='long'] and parameter[3][@type='long'] and parameter[4][@type='long']]"
		[Register ("getIntData", "([IJJJ)[I", "GetGetIntData_arrayIJJJHandler")]
		public abstract int[] GetIntData (int[] p0, long p1, long p2, long p3);

		static Delegate cb_getInt_safe_J;
#pragma warning disable 0169
		static Delegate GetGetInt_safe_JHandler ()
		{
			if (cb_getInt_safe_J == null)
				cb_getInt_safe_J = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, long, int>) n_GetInt_safe_J);
			return cb_getInt_safe_J;
		}

		static int n_GetInt_safe_J (IntPtr jnienv, IntPtr native__this, long p0)
		{
			global::PL.Edu.Icm.Jlargearrays.LargeArray __this = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.LargeArray> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.GetInt_safe (p0);
		}
#pragma warning restore 0169

		static IntPtr id_getInt_safe_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='getInt_safe' and count(parameter)=1 and parameter[1][@type='long']]"
		[Register ("getInt_safe", "(J)I", "GetGetInt_safe_JHandler")]
		public virtual unsafe int GetInt_safe (long p0)
		{
			if (id_getInt_safe_J == IntPtr.Zero)
				id_getInt_safe_J = JNIEnv.GetMethodID (class_ref, "getInt_safe", "(J)I");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (((object) this).GetType () == ThresholdType)
					return JNIEnv.CallIntMethod (((global::Java.Lang.Object) this).Handle, id_getInt_safe_J, __args);
				else
					return JNIEnv.CallNonvirtualIntMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getInt_safe", "(J)I"), __args);
			} finally {
			}
		}

		static Delegate cb_getLong_J;
#pragma warning disable 0169
		static Delegate GetGetLong_JHandler ()
		{
			if (cb_getLong_J == null)
				cb_getLong_J = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, long, long>) n_GetLong_J);
			return cb_getLong_J;
		}

		static long n_GetLong_J (IntPtr jnienv, IntPtr native__this, long p0)
		{
			global::PL.Edu.Icm.Jlargearrays.LargeArray __this = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.LargeArray> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.GetLong (p0);
		}
#pragma warning restore 0169

		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='getLong' and count(parameter)=1 and parameter[1][@type='long']]"
		[Register ("getLong", "(J)J", "GetGetLong_JHandler")]
		public abstract long GetLong (long p0);

		static Delegate cb_getLongData;
#pragma warning disable 0169
		static Delegate GetGetLongDataHandler ()
		{
			if (cb_getLongData == null)
				cb_getLongData = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetLongData);
			return cb_getLongData;
		}

		static IntPtr n_GetLongData (IntPtr jnienv, IntPtr native__this)
		{
			global::PL.Edu.Icm.Jlargearrays.LargeArray __this = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.LargeArray> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewArray (__this.GetLongData ());
		}
#pragma warning restore 0169

		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='getLongData' and count(parameter)=0]"
		[Register ("getLongData", "()[J", "GetGetLongDataHandler")]
		public abstract long[] GetLongData ();

		static Delegate cb_getLongData_arrayJJJJ;
#pragma warning disable 0169
		static Delegate GetGetLongData_arrayJJJJHandler ()
		{
			if (cb_getLongData_arrayJJJJ == null)
				cb_getLongData_arrayJJJJ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, long, long, long, IntPtr>) n_GetLongData_arrayJJJJ);
			return cb_getLongData_arrayJJJJ;
		}

		static IntPtr n_GetLongData_arrayJJJJ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, long p1, long p2, long p3)
		{
			global::PL.Edu.Icm.Jlargearrays.LargeArray __this = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.LargeArray> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			long[] p0 = (long[]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (long));
			IntPtr __ret = JNIEnv.NewArray (__this.GetLongData (p0, p1, p2, p3));
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
			return __ret;
		}
#pragma warning restore 0169

		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='getLongData' and count(parameter)=4 and parameter[1][@type='long[]'] and parameter[2][@type='long'] and parameter[3][@type='long'] and parameter[4][@type='long']]"
		[Register ("getLongData", "([JJJJ)[J", "GetGetLongData_arrayJJJJHandler")]
		public abstract long[] GetLongData (long[] p0, long p1, long p2, long p3);

		static Delegate cb_getLong_safe_J;
#pragma warning disable 0169
		static Delegate GetGetLong_safe_JHandler ()
		{
			if (cb_getLong_safe_J == null)
				cb_getLong_safe_J = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, long, long>) n_GetLong_safe_J);
			return cb_getLong_safe_J;
		}

		static long n_GetLong_safe_J (IntPtr jnienv, IntPtr native__this, long p0)
		{
			global::PL.Edu.Icm.Jlargearrays.LargeArray __this = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.LargeArray> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.GetLong_safe (p0);
		}
#pragma warning restore 0169

		static IntPtr id_getLong_safe_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='getLong_safe' and count(parameter)=1 and parameter[1][@type='long']]"
		[Register ("getLong_safe", "(J)J", "GetGetLong_safe_JHandler")]
		public virtual unsafe long GetLong_safe (long p0)
		{
			if (id_getLong_safe_J == IntPtr.Zero)
				id_getLong_safe_J = JNIEnv.GetMethodID (class_ref, "getLong_safe", "(J)J");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (((object) this).GetType () == ThresholdType)
					return JNIEnv.CallLongMethod (((global::Java.Lang.Object) this).Handle, id_getLong_safe_J, __args);
				else
					return JNIEnv.CallNonvirtualLongMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getLong_safe", "(J)J"), __args);
			} finally {
			}
		}

		static Delegate cb_getShort_J;
#pragma warning disable 0169
		static Delegate GetGetShort_JHandler ()
		{
			if (cb_getShort_J == null)
				cb_getShort_J = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, long, short>) n_GetShort_J);
			return cb_getShort_J;
		}

		static short n_GetShort_J (IntPtr jnienv, IntPtr native__this, long p0)
		{
			global::PL.Edu.Icm.Jlargearrays.LargeArray __this = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.LargeArray> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.GetShort (p0);
		}
#pragma warning restore 0169

		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='getShort' and count(parameter)=1 and parameter[1][@type='long']]"
		[Register ("getShort", "(J)S", "GetGetShort_JHandler")]
		public abstract short GetShort (long p0);

		static Delegate cb_getShortData;
#pragma warning disable 0169
		static Delegate GetGetShortDataHandler ()
		{
			if (cb_getShortData == null)
				cb_getShortData = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetShortData);
			return cb_getShortData;
		}

		static IntPtr n_GetShortData (IntPtr jnienv, IntPtr native__this)
		{
			global::PL.Edu.Icm.Jlargearrays.LargeArray __this = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.LargeArray> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewArray (__this.GetShortData ());
		}
#pragma warning restore 0169

		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='getShortData' and count(parameter)=0]"
		[Register ("getShortData", "()[S", "GetGetShortDataHandler")]
		public abstract short[] GetShortData ();

		static Delegate cb_getShortData_arraySJJJ;
#pragma warning disable 0169
		static Delegate GetGetShortData_arraySJJJHandler ()
		{
			if (cb_getShortData_arraySJJJ == null)
				cb_getShortData_arraySJJJ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, long, long, long, IntPtr>) n_GetShortData_arraySJJJ);
			return cb_getShortData_arraySJJJ;
		}

		static IntPtr n_GetShortData_arraySJJJ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, long p1, long p2, long p3)
		{
			global::PL.Edu.Icm.Jlargearrays.LargeArray __this = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.LargeArray> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			short[] p0 = (short[]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (short));
			IntPtr __ret = JNIEnv.NewArray (__this.GetShortData (p0, p1, p2, p3));
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
			return __ret;
		}
#pragma warning restore 0169

		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='getShortData' and count(parameter)=4 and parameter[1][@type='short[]'] and parameter[2][@type='long'] and parameter[3][@type='long'] and parameter[4][@type='long']]"
		[Register ("getShortData", "([SJJJ)[S", "GetGetShortData_arraySJJJHandler")]
		public abstract short[] GetShortData (short[] p0, long p1, long p2, long p3);

		static Delegate cb_getShort_safe_J;
#pragma warning disable 0169
		static Delegate GetGetShort_safe_JHandler ()
		{
			if (cb_getShort_safe_J == null)
				cb_getShort_safe_J = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, long, short>) n_GetShort_safe_J);
			return cb_getShort_safe_J;
		}

		static short n_GetShort_safe_J (IntPtr jnienv, IntPtr native__this, long p0)
		{
			global::PL.Edu.Icm.Jlargearrays.LargeArray __this = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.LargeArray> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.GetShort_safe (p0);
		}
#pragma warning restore 0169

		static IntPtr id_getShort_safe_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='getShort_safe' and count(parameter)=1 and parameter[1][@type='long']]"
		[Register ("getShort_safe", "(J)S", "GetGetShort_safe_JHandler")]
		public virtual unsafe short GetShort_safe (long p0)
		{
			if (id_getShort_safe_J == IntPtr.Zero)
				id_getShort_safe_J = JNIEnv.GetMethodID (class_ref, "getShort_safe", "(J)S");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (((object) this).GetType () == ThresholdType)
					return JNIEnv.CallShortMethod (((global::Java.Lang.Object) this).Handle, id_getShort_safe_J, __args);
				else
					return JNIEnv.CallNonvirtualShortMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getShort_safe", "(J)S"), __args);
			} finally {
			}
		}

		static Delegate cb_getUnsignedByte_J;
#pragma warning disable 0169
		static Delegate GetGetUnsignedByte_JHandler ()
		{
			if (cb_getUnsignedByte_J == null)
				cb_getUnsignedByte_J = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, long, short>) n_GetUnsignedByte_J);
			return cb_getUnsignedByte_J;
		}

		static short n_GetUnsignedByte_J (IntPtr jnienv, IntPtr native__this, long p0)
		{
			global::PL.Edu.Icm.Jlargearrays.LargeArray __this = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.LargeArray> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.GetUnsignedByte (p0);
		}
#pragma warning restore 0169

		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='getUnsignedByte' and count(parameter)=1 and parameter[1][@type='long']]"
		[Register ("getUnsignedByte", "(J)S", "GetGetUnsignedByte_JHandler")]
		public abstract short GetUnsignedByte (long p0);

		static Delegate cb_getUnsignedByte_safe_J;
#pragma warning disable 0169
		static Delegate GetGetUnsignedByte_safe_JHandler ()
		{
			if (cb_getUnsignedByte_safe_J == null)
				cb_getUnsignedByte_safe_J = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, long, short>) n_GetUnsignedByte_safe_J);
			return cb_getUnsignedByte_safe_J;
		}

		static short n_GetUnsignedByte_safe_J (IntPtr jnienv, IntPtr native__this, long p0)
		{
			global::PL.Edu.Icm.Jlargearrays.LargeArray __this = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.LargeArray> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.GetUnsignedByte_safe (p0);
		}
#pragma warning restore 0169

		static IntPtr id_getUnsignedByte_safe_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='getUnsignedByte_safe' and count(parameter)=1 and parameter[1][@type='long']]"
		[Register ("getUnsignedByte_safe", "(J)S", "GetGetUnsignedByte_safe_JHandler")]
		public virtual unsafe short GetUnsignedByte_safe (long p0)
		{
			if (id_getUnsignedByte_safe_J == IntPtr.Zero)
				id_getUnsignedByte_safe_J = JNIEnv.GetMethodID (class_ref, "getUnsignedByte_safe", "(J)S");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (((object) this).GetType () == ThresholdType)
					return JNIEnv.CallShortMethod (((global::Java.Lang.Object) this).Handle, id_getUnsignedByte_safe_J, __args);
				else
					return JNIEnv.CallNonvirtualShortMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getUnsignedByte_safe", "(J)S"), __args);
			} finally {
			}
		}

		static Delegate cb_get_safe_J;
#pragma warning disable 0169
		static Delegate GetGet_safe_JHandler ()
		{
			if (cb_get_safe_J == null)
				cb_get_safe_J = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, long, IntPtr>) n_Get_safe_J);
			return cb_get_safe_J;
		}

		static IntPtr n_Get_safe_J (IntPtr jnienv, IntPtr native__this, long p0)
		{
			global::PL.Edu.Icm.Jlargearrays.LargeArray __this = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.LargeArray> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.Get_safe (p0));
		}
#pragma warning restore 0169

		static IntPtr id_get_safe_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='get_safe' and count(parameter)=1 and parameter[1][@type='long']]"
		[Register ("get_safe", "(J)Ljava/lang/Object;", "GetGet_safe_JHandler")]
		public virtual unsafe global::Java.Lang.Object Get_safe (long p0)
		{
			if (id_get_safe_J == IntPtr.Zero)
				id_get_safe_J = JNIEnv.GetMethodID (class_ref, "get_safe", "(J)Ljava/lang/Object;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (((object) this).GetType () == ThresholdType)
					return global::Java.Lang.Object.GetObject<global::Java.Lang.Object> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get_safe_J, __args), JniHandleOwnership.TransferLocalRef);
				else
					return global::Java.Lang.Object.GetObject<global::Java.Lang.Object> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get_safe", "(J)Ljava/lang/Object;"), __args), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_length;
#pragma warning disable 0169
		static Delegate GetLengthHandler ()
		{
			if (cb_length == null)
				cb_length = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, long>) n_Length);
			return cb_length;
		}

		static long n_Length (IntPtr jnienv, IntPtr native__this)
		{
			global::PL.Edu.Icm.Jlargearrays.LargeArray __this = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.LargeArray> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.Length ();
		}
#pragma warning restore 0169

		static IntPtr id_length;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='length' and count(parameter)=0]"
		[Register ("length", "()J", "GetLengthHandler")]
		public virtual unsafe long Length ()
		{
			if (id_length == IntPtr.Zero)
				id_length = JNIEnv.GetMethodID (class_ref, "length", "()J");
			try {

				if (((object) this).GetType () == ThresholdType)
					return JNIEnv.CallLongMethod (((global::Java.Lang.Object) this).Handle, id_length);
				else
					return JNIEnv.CallNonvirtualLongMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "length", "()J"));
			} finally {
			}
		}

		static Delegate cb_nativePointer;
#pragma warning disable 0169
		static Delegate GetNativePointerHandler ()
		{
			if (cb_nativePointer == null)
				cb_nativePointer = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, long>) n_NativePointer);
			return cb_nativePointer;
		}

		static long n_NativePointer (IntPtr jnienv, IntPtr native__this)
		{
			global::PL.Edu.Icm.Jlargearrays.LargeArray __this = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.LargeArray> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.NativePointer ();
		}
#pragma warning restore 0169

		static IntPtr id_nativePointer;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='nativePointer' and count(parameter)=0]"
		[Register ("nativePointer", "()J", "GetNativePointerHandler")]
		public virtual unsafe long NativePointer ()
		{
			if (id_nativePointer == IntPtr.Zero)
				id_nativePointer = JNIEnv.GetMethodID (class_ref, "nativePointer", "()J");
			try {

				if (((object) this).GetType () == ThresholdType)
					return JNIEnv.CallLongMethod (((global::Java.Lang.Object) this).Handle, id_nativePointer);
				else
					return JNIEnv.CallNonvirtualLongMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "nativePointer", "()J"));
			} finally {
			}
		}

		static Delegate cb_set_JLjava_lang_Object_;
#pragma warning disable 0169
		static Delegate GetSet_JLjava_lang_Object_Handler ()
		{
			if (cb_set_JLjava_lang_Object_ == null)
				cb_set_JLjava_lang_Object_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, long, IntPtr>) n_Set_JLjava_lang_Object_);
			return cb_set_JLjava_lang_Object_;
		}

		static void n_Set_JLjava_lang_Object_ (IntPtr jnienv, IntPtr native__this, long p0, IntPtr native_p1)
		{
			global::PL.Edu.Icm.Jlargearrays.LargeArray __this = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.LargeArray> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Java.Lang.Object p1 = global::Java.Lang.Object.GetObject<global::Java.Lang.Object> (native_p1, JniHandleOwnership.DoNotTransfer);
			__this.Set (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_set_JLjava_lang_Object_;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='set' and count(parameter)=2 and parameter[1][@type='long'] and parameter[2][@type='java.lang.Object']]"
		[Register ("set", "(JLjava/lang/Object;)V", "GetSet_JLjava_lang_Object_Handler")]
		public virtual unsafe void Set (long p0, global::Java.Lang.Object p1)
		{
			if (id_set_JLjava_lang_Object_ == IntPtr.Zero)
				id_set_JLjava_lang_Object_ = JNIEnv.GetMethodID (class_ref, "set", "(JLjava/lang/Object;)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set_JLjava_lang_Object_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set", "(JLjava/lang/Object;)V"), __args);
			} finally {
			}
		}

		static Delegate cb_setBoolean_JZ;
#pragma warning disable 0169
		static Delegate GetSetBoolean_JZHandler ()
		{
			if (cb_setBoolean_JZ == null)
				cb_setBoolean_JZ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, long, bool>) n_SetBoolean_JZ);
			return cb_setBoolean_JZ;
		}

		static void n_SetBoolean_JZ (IntPtr jnienv, IntPtr native__this, long p0, bool p1)
		{
			global::PL.Edu.Icm.Jlargearrays.LargeArray __this = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.LargeArray> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.SetBoolean (p0, p1);
		}
#pragma warning restore 0169

		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='setBoolean' and count(parameter)=2 and parameter[1][@type='long'] and parameter[2][@type='boolean']]"
		[Register ("setBoolean", "(JZ)V", "GetSetBoolean_JZHandler")]
		public abstract void SetBoolean (long p0, bool p1);

		static Delegate cb_setBoolean_safe_JZ;
#pragma warning disable 0169
		static Delegate GetSetBoolean_safe_JZHandler ()
		{
			if (cb_setBoolean_safe_JZ == null)
				cb_setBoolean_safe_JZ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, long, bool>) n_SetBoolean_safe_JZ);
			return cb_setBoolean_safe_JZ;
		}

		static void n_SetBoolean_safe_JZ (IntPtr jnienv, IntPtr native__this, long p0, bool p1)
		{
			global::PL.Edu.Icm.Jlargearrays.LargeArray __this = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.LargeArray> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.SetBoolean_safe (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_setBoolean_safe_JZ;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='setBoolean_safe' and count(parameter)=2 and parameter[1][@type='long'] and parameter[2][@type='boolean']]"
		[Register ("setBoolean_safe", "(JZ)V", "GetSetBoolean_safe_JZHandler")]
		public virtual unsafe void SetBoolean_safe (long p0, bool p1)
		{
			if (id_setBoolean_safe_JZ == IntPtr.Zero)
				id_setBoolean_safe_JZ = JNIEnv.GetMethodID (class_ref, "setBoolean_safe", "(JZ)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setBoolean_safe_JZ, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setBoolean_safe", "(JZ)V"), __args);
			} finally {
			}
		}

		static Delegate cb_setByte_JB;
#pragma warning disable 0169
		static Delegate GetSetByte_JBHandler ()
		{
			if (cb_setByte_JB == null)
				cb_setByte_JB = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, long, sbyte>) n_SetByte_JB);
			return cb_setByte_JB;
		}

		static void n_SetByte_JB (IntPtr jnienv, IntPtr native__this, long p0, sbyte p1)
		{
			global::PL.Edu.Icm.Jlargearrays.LargeArray __this = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.LargeArray> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.SetByte (p0, p1);
		}
#pragma warning restore 0169

		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='setByte' and count(parameter)=2 and parameter[1][@type='long'] and parameter[2][@type='byte']]"
		[Register ("setByte", "(JB)V", "GetSetByte_JBHandler")]
		public abstract void SetByte (long p0, sbyte p1);

		static Delegate cb_setByte_safe_JB;
#pragma warning disable 0169
		static Delegate GetSetByte_safe_JBHandler ()
		{
			if (cb_setByte_safe_JB == null)
				cb_setByte_safe_JB = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, long, sbyte>) n_SetByte_safe_JB);
			return cb_setByte_safe_JB;
		}

		static void n_SetByte_safe_JB (IntPtr jnienv, IntPtr native__this, long p0, sbyte p1)
		{
			global::PL.Edu.Icm.Jlargearrays.LargeArray __this = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.LargeArray> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.SetByte_safe (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_setByte_safe_JB;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='setByte_safe' and count(parameter)=2 and parameter[1][@type='long'] and parameter[2][@type='byte']]"
		[Register ("setByte_safe", "(JB)V", "GetSetByte_safe_JBHandler")]
		public virtual unsafe void SetByte_safe (long p0, sbyte p1)
		{
			if (id_setByte_safe_JB == IntPtr.Zero)
				id_setByte_safe_JB = JNIEnv.GetMethodID (class_ref, "setByte_safe", "(JB)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setByte_safe_JB, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setByte_safe", "(JB)V"), __args);
			} finally {
			}
		}

		static Delegate cb_setDouble_JD;
#pragma warning disable 0169
		static Delegate GetSetDouble_JDHandler ()
		{
			if (cb_setDouble_JD == null)
				cb_setDouble_JD = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, long, double>) n_SetDouble_JD);
			return cb_setDouble_JD;
		}

		static void n_SetDouble_JD (IntPtr jnienv, IntPtr native__this, long p0, double p1)
		{
			global::PL.Edu.Icm.Jlargearrays.LargeArray __this = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.LargeArray> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.SetDouble (p0, p1);
		}
#pragma warning restore 0169

		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='setDouble' and count(parameter)=2 and parameter[1][@type='long'] and parameter[2][@type='double']]"
		[Register ("setDouble", "(JD)V", "GetSetDouble_JDHandler")]
		public abstract void SetDouble (long p0, double p1);

		static Delegate cb_setDouble_safe_JD;
#pragma warning disable 0169
		static Delegate GetSetDouble_safe_JDHandler ()
		{
			if (cb_setDouble_safe_JD == null)
				cb_setDouble_safe_JD = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, long, double>) n_SetDouble_safe_JD);
			return cb_setDouble_safe_JD;
		}

		static void n_SetDouble_safe_JD (IntPtr jnienv, IntPtr native__this, long p0, double p1)
		{
			global::PL.Edu.Icm.Jlargearrays.LargeArray __this = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.LargeArray> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.SetDouble_safe (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_setDouble_safe_JD;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='setDouble_safe' and count(parameter)=2 and parameter[1][@type='long'] and parameter[2][@type='double']]"
		[Register ("setDouble_safe", "(JD)V", "GetSetDouble_safe_JDHandler")]
		public virtual unsafe void SetDouble_safe (long p0, double p1)
		{
			if (id_setDouble_safe_JD == IntPtr.Zero)
				id_setDouble_safe_JD = JNIEnv.GetMethodID (class_ref, "setDouble_safe", "(JD)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setDouble_safe_JD, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setDouble_safe", "(JD)V"), __args);
			} finally {
			}
		}

		static Delegate cb_setFloat_JF;
#pragma warning disable 0169
		static Delegate GetSetFloat_JFHandler ()
		{
			if (cb_setFloat_JF == null)
				cb_setFloat_JF = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, long, float>) n_SetFloat_JF);
			return cb_setFloat_JF;
		}

		static void n_SetFloat_JF (IntPtr jnienv, IntPtr native__this, long p0, float p1)
		{
			global::PL.Edu.Icm.Jlargearrays.LargeArray __this = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.LargeArray> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.SetFloat (p0, p1);
		}
#pragma warning restore 0169

		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='setFloat' and count(parameter)=2 and parameter[1][@type='long'] and parameter[2][@type='float']]"
		[Register ("setFloat", "(JF)V", "GetSetFloat_JFHandler")]
		public abstract void SetFloat (long p0, float p1);

		static Delegate cb_setFloat_safe_JF;
#pragma warning disable 0169
		static Delegate GetSetFloat_safe_JFHandler ()
		{
			if (cb_setFloat_safe_JF == null)
				cb_setFloat_safe_JF = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, long, float>) n_SetFloat_safe_JF);
			return cb_setFloat_safe_JF;
		}

		static void n_SetFloat_safe_JF (IntPtr jnienv, IntPtr native__this, long p0, float p1)
		{
			global::PL.Edu.Icm.Jlargearrays.LargeArray __this = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.LargeArray> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.SetFloat_safe (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_setFloat_safe_JF;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='setFloat_safe' and count(parameter)=2 and parameter[1][@type='long'] and parameter[2][@type='float']]"
		[Register ("setFloat_safe", "(JF)V", "GetSetFloat_safe_JFHandler")]
		public virtual unsafe void SetFloat_safe (long p0, float p1)
		{
			if (id_setFloat_safe_JF == IntPtr.Zero)
				id_setFloat_safe_JF = JNIEnv.GetMethodID (class_ref, "setFloat_safe", "(JF)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setFloat_safe_JF, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setFloat_safe", "(JF)V"), __args);
			} finally {
			}
		}

		static Delegate cb_setInt_JI;
#pragma warning disable 0169
		static Delegate GetSetInt_JIHandler ()
		{
			if (cb_setInt_JI == null)
				cb_setInt_JI = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, long, int>) n_SetInt_JI);
			return cb_setInt_JI;
		}

		static void n_SetInt_JI (IntPtr jnienv, IntPtr native__this, long p0, int p1)
		{
			global::PL.Edu.Icm.Jlargearrays.LargeArray __this = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.LargeArray> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.SetInt (p0, p1);
		}
#pragma warning restore 0169

		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='setInt' and count(parameter)=2 and parameter[1][@type='long'] and parameter[2][@type='int']]"
		[Register ("setInt", "(JI)V", "GetSetInt_JIHandler")]
		public abstract void SetInt (long p0, int p1);

		static Delegate cb_setInt_safe_JI;
#pragma warning disable 0169
		static Delegate GetSetInt_safe_JIHandler ()
		{
			if (cb_setInt_safe_JI == null)
				cb_setInt_safe_JI = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, long, int>) n_SetInt_safe_JI);
			return cb_setInt_safe_JI;
		}

		static void n_SetInt_safe_JI (IntPtr jnienv, IntPtr native__this, long p0, int p1)
		{
			global::PL.Edu.Icm.Jlargearrays.LargeArray __this = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.LargeArray> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.SetInt_safe (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_setInt_safe_JI;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='setInt_safe' and count(parameter)=2 and parameter[1][@type='long'] and parameter[2][@type='int']]"
		[Register ("setInt_safe", "(JI)V", "GetSetInt_safe_JIHandler")]
		public virtual unsafe void SetInt_safe (long p0, int p1)
		{
			if (id_setInt_safe_JI == IntPtr.Zero)
				id_setInt_safe_JI = JNIEnv.GetMethodID (class_ref, "setInt_safe", "(JI)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setInt_safe_JI, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setInt_safe", "(JI)V"), __args);
			} finally {
			}
		}

		static Delegate cb_setLong_JJ;
#pragma warning disable 0169
		static Delegate GetSetLong_JJHandler ()
		{
			if (cb_setLong_JJ == null)
				cb_setLong_JJ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, long, long>) n_SetLong_JJ);
			return cb_setLong_JJ;
		}

		static void n_SetLong_JJ (IntPtr jnienv, IntPtr native__this, long p0, long p1)
		{
			global::PL.Edu.Icm.Jlargearrays.LargeArray __this = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.LargeArray> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.SetLong (p0, p1);
		}
#pragma warning restore 0169

		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='setLong' and count(parameter)=2 and parameter[1][@type='long'] and parameter[2][@type='long']]"
		[Register ("setLong", "(JJ)V", "GetSetLong_JJHandler")]
		public abstract void SetLong (long p0, long p1);

		static Delegate cb_setLong_safe_JJ;
#pragma warning disable 0169
		static Delegate GetSetLong_safe_JJHandler ()
		{
			if (cb_setLong_safe_JJ == null)
				cb_setLong_safe_JJ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, long, long>) n_SetLong_safe_JJ);
			return cb_setLong_safe_JJ;
		}

		static void n_SetLong_safe_JJ (IntPtr jnienv, IntPtr native__this, long p0, long p1)
		{
			global::PL.Edu.Icm.Jlargearrays.LargeArray __this = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.LargeArray> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.SetLong_safe (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_setLong_safe_JJ;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='setLong_safe' and count(parameter)=2 and parameter[1][@type='long'] and parameter[2][@type='long']]"
		[Register ("setLong_safe", "(JJ)V", "GetSetLong_safe_JJHandler")]
		public virtual unsafe void SetLong_safe (long p0, long p1)
		{
			if (id_setLong_safe_JJ == IntPtr.Zero)
				id_setLong_safe_JJ = JNIEnv.GetMethodID (class_ref, "setLong_safe", "(JJ)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setLong_safe_JJ, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setLong_safe", "(JJ)V"), __args);
			} finally {
			}
		}

		static Delegate cb_setShort_JS;
#pragma warning disable 0169
		static Delegate GetSetShort_JSHandler ()
		{
			if (cb_setShort_JS == null)
				cb_setShort_JS = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, long, short>) n_SetShort_JS);
			return cb_setShort_JS;
		}

		static void n_SetShort_JS (IntPtr jnienv, IntPtr native__this, long p0, short p1)
		{
			global::PL.Edu.Icm.Jlargearrays.LargeArray __this = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.LargeArray> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.SetShort (p0, p1);
		}
#pragma warning restore 0169

		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='setShort' and count(parameter)=2 and parameter[1][@type='long'] and parameter[2][@type='short']]"
		[Register ("setShort", "(JS)V", "GetSetShort_JSHandler")]
		public abstract void SetShort (long p0, short p1);

		static Delegate cb_setShort_safe_JS;
#pragma warning disable 0169
		static Delegate GetSetShort_safe_JSHandler ()
		{
			if (cb_setShort_safe_JS == null)
				cb_setShort_safe_JS = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, long, short>) n_SetShort_safe_JS);
			return cb_setShort_safe_JS;
		}

		static void n_SetShort_safe_JS (IntPtr jnienv, IntPtr native__this, long p0, short p1)
		{
			global::PL.Edu.Icm.Jlargearrays.LargeArray __this = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.LargeArray> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.SetShort_safe (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_setShort_safe_JS;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='setShort_safe' and count(parameter)=2 and parameter[1][@type='long'] and parameter[2][@type='short']]"
		[Register ("setShort_safe", "(JS)V", "GetSetShort_safe_JSHandler")]
		public virtual unsafe void SetShort_safe (long p0, short p1)
		{
			if (id_setShort_safe_JS == IntPtr.Zero)
				id_setShort_safe_JS = JNIEnv.GetMethodID (class_ref, "setShort_safe", "(JS)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setShort_safe_JS, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setShort_safe", "(JS)V"), __args);
			} finally {
			}
		}

		static Delegate cb_setToNative_JLjava_lang_Object_;
#pragma warning disable 0169
		static Delegate GetSetToNative_JLjava_lang_Object_Handler ()
		{
			if (cb_setToNative_JLjava_lang_Object_ == null)
				cb_setToNative_JLjava_lang_Object_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, long, IntPtr>) n_SetToNative_JLjava_lang_Object_);
			return cb_setToNative_JLjava_lang_Object_;
		}

		static void n_SetToNative_JLjava_lang_Object_ (IntPtr jnienv, IntPtr native__this, long p0, IntPtr native_p1)
		{
			global::PL.Edu.Icm.Jlargearrays.LargeArray __this = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.LargeArray> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Java.Lang.Object p1 = global::Java.Lang.Object.GetObject<global::Java.Lang.Object> (native_p1, JniHandleOwnership.DoNotTransfer);
			__this.SetToNative (p0, p1);
		}
#pragma warning restore 0169

		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='setToNative' and count(parameter)=2 and parameter[1][@type='long'] and parameter[2][@type='java.lang.Object']]"
		[Register ("setToNative", "(JLjava/lang/Object;)V", "GetSetToNative_JLjava_lang_Object_Handler")]
		public abstract void SetToNative (long p0, global::Java.Lang.Object p1);

		static Delegate cb_setUnsignedByte_JS;
#pragma warning disable 0169
		static Delegate GetSetUnsignedByte_JSHandler ()
		{
			if (cb_setUnsignedByte_JS == null)
				cb_setUnsignedByte_JS = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, long, short>) n_SetUnsignedByte_JS);
			return cb_setUnsignedByte_JS;
		}

		static void n_SetUnsignedByte_JS (IntPtr jnienv, IntPtr native__this, long p0, short p1)
		{
			global::PL.Edu.Icm.Jlargearrays.LargeArray __this = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.LargeArray> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.SetUnsignedByte (p0, p1);
		}
#pragma warning restore 0169

		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='setUnsignedByte' and count(parameter)=2 and parameter[1][@type='long'] and parameter[2][@type='short']]"
		[Register ("setUnsignedByte", "(JS)V", "GetSetUnsignedByte_JSHandler")]
		public abstract void SetUnsignedByte (long p0, short p1);

		static Delegate cb_setUnsignedByte_safe_JB;
#pragma warning disable 0169
		static Delegate GetSetUnsignedByte_safe_JBHandler ()
		{
			if (cb_setUnsignedByte_safe_JB == null)
				cb_setUnsignedByte_safe_JB = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, long, sbyte>) n_SetUnsignedByte_safe_JB);
			return cb_setUnsignedByte_safe_JB;
		}

		static void n_SetUnsignedByte_safe_JB (IntPtr jnienv, IntPtr native__this, long p0, sbyte p1)
		{
			global::PL.Edu.Icm.Jlargearrays.LargeArray __this = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.LargeArray> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.SetUnsignedByte_safe (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_setUnsignedByte_safe_JB;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='setUnsignedByte_safe' and count(parameter)=2 and parameter[1][@type='long'] and parameter[2][@type='byte']]"
		[Register ("setUnsignedByte_safe", "(JB)V", "GetSetUnsignedByte_safe_JBHandler")]
		public virtual unsafe void SetUnsignedByte_safe (long p0, sbyte p1)
		{
			if (id_setUnsignedByte_safe_JB == IntPtr.Zero)
				id_setUnsignedByte_safe_JB = JNIEnv.GetMethodID (class_ref, "setUnsignedByte_safe", "(JB)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setUnsignedByte_safe_JB, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setUnsignedByte_safe", "(JB)V"), __args);
			} finally {
			}
		}

		static Delegate cb_set_safe_JLjava_lang_Object_;
#pragma warning disable 0169
		static Delegate GetSet_safe_JLjava_lang_Object_Handler ()
		{
			if (cb_set_safe_JLjava_lang_Object_ == null)
				cb_set_safe_JLjava_lang_Object_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, long, IntPtr>) n_Set_safe_JLjava_lang_Object_);
			return cb_set_safe_JLjava_lang_Object_;
		}

		static void n_Set_safe_JLjava_lang_Object_ (IntPtr jnienv, IntPtr native__this, long p0, IntPtr native_p1)
		{
			global::PL.Edu.Icm.Jlargearrays.LargeArray __this = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.LargeArray> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Java.Lang.Object p1 = global::Java.Lang.Object.GetObject<global::Java.Lang.Object> (native_p1, JniHandleOwnership.DoNotTransfer);
			__this.Set_safe (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_set_safe_JLjava_lang_Object_;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='set_safe' and count(parameter)=2 and parameter[1][@type='long'] and parameter[2][@type='java.lang.Object']]"
		[Register ("set_safe", "(JLjava/lang/Object;)V", "GetSet_safe_JLjava_lang_Object_Handler")]
		public virtual unsafe void Set_safe (long p0, global::Java.Lang.Object p1)
		{
			if (id_set_safe_JLjava_lang_Object_ == IntPtr.Zero)
				id_set_safe_JLjava_lang_Object_ = JNIEnv.GetMethodID (class_ref, "set_safe", "(JLjava/lang/Object;)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set_safe_JLjava_lang_Object_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set_safe", "(JLjava/lang/Object;)V"), __args);
			} finally {
			}
		}

		static Delegate cb_zeroNativeMemory_J;
#pragma warning disable 0169
		static Delegate GetZeroNativeMemory_JHandler ()
		{
			if (cb_zeroNativeMemory_J == null)
				cb_zeroNativeMemory_J = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, long>) n_ZeroNativeMemory_J);
			return cb_zeroNativeMemory_J;
		}

		static void n_ZeroNativeMemory_J (IntPtr jnienv, IntPtr native__this, long p0)
		{
			global::PL.Edu.Icm.Jlargearrays.LargeArray __this = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.LargeArray> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.ZeroNativeMemory (p0);
		}
#pragma warning restore 0169

		static IntPtr id_zeroNativeMemory_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='zeroNativeMemory' and count(parameter)=1 and parameter[1][@type='long']]"
		[Register ("zeroNativeMemory", "(J)V", "GetZeroNativeMemory_JHandler")]
		protected virtual unsafe void ZeroNativeMemory (long p0)
		{
			if (id_zeroNativeMemory_J == IntPtr.Zero)
				id_zeroNativeMemory_J = JNIEnv.GetMethodID (class_ref, "zeroNativeMemory", "(J)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_zeroNativeMemory_J, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "zeroNativeMemory", "(J)V"), __args);
			} finally {
			}
		}

	}

	[global::Android.Runtime.Register ("pl/edu/icm/jlargearrays/LargeArray", DoNotGenerateAcw=true)]
	internal partial class LargeArrayInvoker : LargeArray {

		public LargeArrayInvoker (IntPtr handle, JniHandleOwnership transfer) : base (handle, transfer) {}

		protected override global::System.Type ThresholdType {
			get { return typeof (LargeArrayInvoker); }
		}

		static IntPtr id_getData;
		public override unsafe global::Java.Lang.Object Data {
			// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='getData' and count(parameter)=0]"
			[Register ("getData", "()Ljava/lang/Object;", "GetGetDataHandler")]
			get {
				if (id_getData == IntPtr.Zero)
					id_getData = JNIEnv.GetMethodID (class_ref, "getData", "()Ljava/lang/Object;");
				try {
					return global::Java.Lang.Object.GetObject<global::Java.Lang.Object> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getData), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static IntPtr id_get_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='get' and count(parameter)=1 and parameter[1][@type='long']]"
		[Register ("get", "(J)Ljava/lang/Object;", "GetGet_JHandler")]
		public override unsafe global::Java.Lang.Object Get (long p0)
		{
			if (id_get_J == IntPtr.Zero)
				id_get_J = JNIEnv.GetMethodID (class_ref, "get", "(J)Ljava/lang/Object;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				return global::Java.Lang.Object.GetObject<global::Java.Lang.Object> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get_J, __args), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static IntPtr id_getBoolean_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='getBoolean' and count(parameter)=1 and parameter[1][@type='long']]"
		[Register ("getBoolean", "(J)Z", "GetGetBoolean_JHandler")]
		public override unsafe bool GetBoolean (long p0)
		{
			if (id_getBoolean_J == IntPtr.Zero)
				id_getBoolean_J = JNIEnv.GetMethodID (class_ref, "getBoolean", "(J)Z");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				return JNIEnv.CallBooleanMethod (((global::Java.Lang.Object) this).Handle, id_getBoolean_J, __args);
			} finally {
			}
		}

		static IntPtr id_getBooleanData;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='getBooleanData' and count(parameter)=0]"
		[Register ("getBooleanData", "()[Z", "GetGetBooleanDataHandler")]
		public override unsafe bool[] GetBooleanData ()
		{
			if (id_getBooleanData == IntPtr.Zero)
				id_getBooleanData = JNIEnv.GetMethodID (class_ref, "getBooleanData", "()[Z");
			try {
				return (bool[]) JNIEnv.GetArray (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getBooleanData), JniHandleOwnership.TransferLocalRef, typeof (bool));
			} finally {
			}
		}

		static IntPtr id_getBooleanData_arrayZJJJ;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='getBooleanData' and count(parameter)=4 and parameter[1][@type='boolean[]'] and parameter[2][@type='long'] and parameter[3][@type='long'] and parameter[4][@type='long']]"
		[Register ("getBooleanData", "([ZJJJ)[Z", "GetGetBooleanData_arrayZJJJHandler")]
		public override unsafe bool[] GetBooleanData (bool[] p0, long p1, long p2, long p3)
		{
			if (id_getBooleanData_arrayZJJJ == IntPtr.Zero)
				id_getBooleanData_arrayZJJJ = JNIEnv.GetMethodID (class_ref, "getBooleanData", "([ZJJJ)[Z");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				bool[] __ret = (bool[]) JNIEnv.GetArray (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getBooleanData_arrayZJJJ, __args), JniHandleOwnership.TransferLocalRef, typeof (bool));
				return __ret;
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static IntPtr id_getByte_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='getByte' and count(parameter)=1 and parameter[1][@type='long']]"
		[Register ("getByte", "(J)B", "GetGetByte_JHandler")]
		public override unsafe sbyte GetByte (long p0)
		{
			if (id_getByte_J == IntPtr.Zero)
				id_getByte_J = JNIEnv.GetMethodID (class_ref, "getByte", "(J)B");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				return JNIEnv.CallByteMethod (((global::Java.Lang.Object) this).Handle, id_getByte_J, __args);
			} finally {
			}
		}

		static IntPtr id_getByteData;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='getByteData' and count(parameter)=0]"
		[Register ("getByteData", "()[B", "GetGetByteDataHandler")]
		public override unsafe byte[] GetByteData ()
		{
			if (id_getByteData == IntPtr.Zero)
				id_getByteData = JNIEnv.GetMethodID (class_ref, "getByteData", "()[B");
			try {
				return (byte[]) JNIEnv.GetArray (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getByteData), JniHandleOwnership.TransferLocalRef, typeof (byte));
			} finally {
			}
		}

		static IntPtr id_getByteData_arrayBJJJ;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='getByteData' and count(parameter)=4 and parameter[1][@type='byte[]'] and parameter[2][@type='long'] and parameter[3][@type='long'] and parameter[4][@type='long']]"
		[Register ("getByteData", "([BJJJ)[B", "GetGetByteData_arrayBJJJHandler")]
		public override unsafe byte[] GetByteData (byte[] p0, long p1, long p2, long p3)
		{
			if (id_getByteData_arrayBJJJ == IntPtr.Zero)
				id_getByteData_arrayBJJJ = JNIEnv.GetMethodID (class_ref, "getByteData", "([BJJJ)[B");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				byte[] __ret = (byte[]) JNIEnv.GetArray (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getByteData_arrayBJJJ, __args), JniHandleOwnership.TransferLocalRef, typeof (byte));
				return __ret;
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static IntPtr id_getDouble_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='getDouble' and count(parameter)=1 and parameter[1][@type='long']]"
		[Register ("getDouble", "(J)D", "GetGetDouble_JHandler")]
		public override unsafe double GetDouble (long p0)
		{
			if (id_getDouble_J == IntPtr.Zero)
				id_getDouble_J = JNIEnv.GetMethodID (class_ref, "getDouble", "(J)D");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				return JNIEnv.CallDoubleMethod (((global::Java.Lang.Object) this).Handle, id_getDouble_J, __args);
			} finally {
			}
		}

		static IntPtr id_getDoubleData;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='getDoubleData' and count(parameter)=0]"
		[Register ("getDoubleData", "()[D", "GetGetDoubleDataHandler")]
		public override unsafe double[] GetDoubleData ()
		{
			if (id_getDoubleData == IntPtr.Zero)
				id_getDoubleData = JNIEnv.GetMethodID (class_ref, "getDoubleData", "()[D");
			try {
				return (double[]) JNIEnv.GetArray (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getDoubleData), JniHandleOwnership.TransferLocalRef, typeof (double));
			} finally {
			}
		}

		static IntPtr id_getDoubleData_arrayDJJJ;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='getDoubleData' and count(parameter)=4 and parameter[1][@type='double[]'] and parameter[2][@type='long'] and parameter[3][@type='long'] and parameter[4][@type='long']]"
		[Register ("getDoubleData", "([DJJJ)[D", "GetGetDoubleData_arrayDJJJHandler")]
		public override unsafe double[] GetDoubleData (double[] p0, long p1, long p2, long p3)
		{
			if (id_getDoubleData_arrayDJJJ == IntPtr.Zero)
				id_getDoubleData_arrayDJJJ = JNIEnv.GetMethodID (class_ref, "getDoubleData", "([DJJJ)[D");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				double[] __ret = (double[]) JNIEnv.GetArray (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getDoubleData_arrayDJJJ, __args), JniHandleOwnership.TransferLocalRef, typeof (double));
				return __ret;
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static IntPtr id_getFloat_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='getFloat' and count(parameter)=1 and parameter[1][@type='long']]"
		[Register ("getFloat", "(J)F", "GetGetFloat_JHandler")]
		public override unsafe float GetFloat (long p0)
		{
			if (id_getFloat_J == IntPtr.Zero)
				id_getFloat_J = JNIEnv.GetMethodID (class_ref, "getFloat", "(J)F");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				return JNIEnv.CallFloatMethod (((global::Java.Lang.Object) this).Handle, id_getFloat_J, __args);
			} finally {
			}
		}

		static IntPtr id_getFloatData;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='getFloatData' and count(parameter)=0]"
		[Register ("getFloatData", "()[F", "GetGetFloatDataHandler")]
		public override unsafe float[] GetFloatData ()
		{
			if (id_getFloatData == IntPtr.Zero)
				id_getFloatData = JNIEnv.GetMethodID (class_ref, "getFloatData", "()[F");
			try {
				return (float[]) JNIEnv.GetArray (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getFloatData), JniHandleOwnership.TransferLocalRef, typeof (float));
			} finally {
			}
		}

		static IntPtr id_getFloatData_arrayFJJJ;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='getFloatData' and count(parameter)=4 and parameter[1][@type='float[]'] and parameter[2][@type='long'] and parameter[3][@type='long'] and parameter[4][@type='long']]"
		[Register ("getFloatData", "([FJJJ)[F", "GetGetFloatData_arrayFJJJHandler")]
		public override unsafe float[] GetFloatData (float[] p0, long p1, long p2, long p3)
		{
			if (id_getFloatData_arrayFJJJ == IntPtr.Zero)
				id_getFloatData_arrayFJJJ = JNIEnv.GetMethodID (class_ref, "getFloatData", "([FJJJ)[F");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				float[] __ret = (float[]) JNIEnv.GetArray (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getFloatData_arrayFJJJ, __args), JniHandleOwnership.TransferLocalRef, typeof (float));
				return __ret;
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static IntPtr id_getFromNative_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='getFromNative' and count(parameter)=1 and parameter[1][@type='long']]"
		[Register ("getFromNative", "(J)Ljava/lang/Object;", "GetGetFromNative_JHandler")]
		public override unsafe global::Java.Lang.Object GetFromNative (long p0)
		{
			if (id_getFromNative_J == IntPtr.Zero)
				id_getFromNative_J = JNIEnv.GetMethodID (class_ref, "getFromNative", "(J)Ljava/lang/Object;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				return global::Java.Lang.Object.GetObject<global::Java.Lang.Object> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getFromNative_J, __args), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static IntPtr id_getInt_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='getInt' and count(parameter)=1 and parameter[1][@type='long']]"
		[Register ("getInt", "(J)I", "GetGetInt_JHandler")]
		public override unsafe int GetInt (long p0)
		{
			if (id_getInt_J == IntPtr.Zero)
				id_getInt_J = JNIEnv.GetMethodID (class_ref, "getInt", "(J)I");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				return JNIEnv.CallIntMethod (((global::Java.Lang.Object) this).Handle, id_getInt_J, __args);
			} finally {
			}
		}

		static IntPtr id_getIntData;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='getIntData' and count(parameter)=0]"
		[Register ("getIntData", "()[I", "GetGetIntDataHandler")]
		public override unsafe int[] GetIntData ()
		{
			if (id_getIntData == IntPtr.Zero)
				id_getIntData = JNIEnv.GetMethodID (class_ref, "getIntData", "()[I");
			try {
				return (int[]) JNIEnv.GetArray (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getIntData), JniHandleOwnership.TransferLocalRef, typeof (int));
			} finally {
			}
		}

		static IntPtr id_getIntData_arrayIJJJ;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='getIntData' and count(parameter)=4 and parameter[1][@type='int[]'] and parameter[2][@type='long'] and parameter[3][@type='long'] and parameter[4][@type='long']]"
		[Register ("getIntData", "([IJJJ)[I", "GetGetIntData_arrayIJJJHandler")]
		public override unsafe int[] GetIntData (int[] p0, long p1, long p2, long p3)
		{
			if (id_getIntData_arrayIJJJ == IntPtr.Zero)
				id_getIntData_arrayIJJJ = JNIEnv.GetMethodID (class_ref, "getIntData", "([IJJJ)[I");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				int[] __ret = (int[]) JNIEnv.GetArray (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getIntData_arrayIJJJ, __args), JniHandleOwnership.TransferLocalRef, typeof (int));
				return __ret;
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static IntPtr id_getLong_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='getLong' and count(parameter)=1 and parameter[1][@type='long']]"
		[Register ("getLong", "(J)J", "GetGetLong_JHandler")]
		public override unsafe long GetLong (long p0)
		{
			if (id_getLong_J == IntPtr.Zero)
				id_getLong_J = JNIEnv.GetMethodID (class_ref, "getLong", "(J)J");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				return JNIEnv.CallLongMethod (((global::Java.Lang.Object) this).Handle, id_getLong_J, __args);
			} finally {
			}
		}

		static IntPtr id_getLongData;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='getLongData' and count(parameter)=0]"
		[Register ("getLongData", "()[J", "GetGetLongDataHandler")]
		public override unsafe long[] GetLongData ()
		{
			if (id_getLongData == IntPtr.Zero)
				id_getLongData = JNIEnv.GetMethodID (class_ref, "getLongData", "()[J");
			try {
				return (long[]) JNIEnv.GetArray (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getLongData), JniHandleOwnership.TransferLocalRef, typeof (long));
			} finally {
			}
		}

		static IntPtr id_getLongData_arrayJJJJ;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='getLongData' and count(parameter)=4 and parameter[1][@type='long[]'] and parameter[2][@type='long'] and parameter[3][@type='long'] and parameter[4][@type='long']]"
		[Register ("getLongData", "([JJJJ)[J", "GetGetLongData_arrayJJJJHandler")]
		public override unsafe long[] GetLongData (long[] p0, long p1, long p2, long p3)
		{
			if (id_getLongData_arrayJJJJ == IntPtr.Zero)
				id_getLongData_arrayJJJJ = JNIEnv.GetMethodID (class_ref, "getLongData", "([JJJJ)[J");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				long[] __ret = (long[]) JNIEnv.GetArray (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getLongData_arrayJJJJ, __args), JniHandleOwnership.TransferLocalRef, typeof (long));
				return __ret;
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static IntPtr id_getShort_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='getShort' and count(parameter)=1 and parameter[1][@type='long']]"
		[Register ("getShort", "(J)S", "GetGetShort_JHandler")]
		public override unsafe short GetShort (long p0)
		{
			if (id_getShort_J == IntPtr.Zero)
				id_getShort_J = JNIEnv.GetMethodID (class_ref, "getShort", "(J)S");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				return JNIEnv.CallShortMethod (((global::Java.Lang.Object) this).Handle, id_getShort_J, __args);
			} finally {
			}
		}

		static IntPtr id_getShortData;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='getShortData' and count(parameter)=0]"
		[Register ("getShortData", "()[S", "GetGetShortDataHandler")]
		public override unsafe short[] GetShortData ()
		{
			if (id_getShortData == IntPtr.Zero)
				id_getShortData = JNIEnv.GetMethodID (class_ref, "getShortData", "()[S");
			try {
				return (short[]) JNIEnv.GetArray (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getShortData), JniHandleOwnership.TransferLocalRef, typeof (short));
			} finally {
			}
		}

		static IntPtr id_getShortData_arraySJJJ;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='getShortData' and count(parameter)=4 and parameter[1][@type='short[]'] and parameter[2][@type='long'] and parameter[3][@type='long'] and parameter[4][@type='long']]"
		[Register ("getShortData", "([SJJJ)[S", "GetGetShortData_arraySJJJHandler")]
		public override unsafe short[] GetShortData (short[] p0, long p1, long p2, long p3)
		{
			if (id_getShortData_arraySJJJ == IntPtr.Zero)
				id_getShortData_arraySJJJ = JNIEnv.GetMethodID (class_ref, "getShortData", "([SJJJ)[S");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				short[] __ret = (short[]) JNIEnv.GetArray (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getShortData_arraySJJJ, __args), JniHandleOwnership.TransferLocalRef, typeof (short));
				return __ret;
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static IntPtr id_getUnsignedByte_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='getUnsignedByte' and count(parameter)=1 and parameter[1][@type='long']]"
		[Register ("getUnsignedByte", "(J)S", "GetGetUnsignedByte_JHandler")]
		public override unsafe short GetUnsignedByte (long p0)
		{
			if (id_getUnsignedByte_J == IntPtr.Zero)
				id_getUnsignedByte_J = JNIEnv.GetMethodID (class_ref, "getUnsignedByte", "(J)S");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				return JNIEnv.CallShortMethod (((global::Java.Lang.Object) this).Handle, id_getUnsignedByte_J, __args);
			} finally {
			}
		}

		static IntPtr id_setBoolean_JZ;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='setBoolean' and count(parameter)=2 and parameter[1][@type='long'] and parameter[2][@type='boolean']]"
		[Register ("setBoolean", "(JZ)V", "GetSetBoolean_JZHandler")]
		public override unsafe void SetBoolean (long p0, bool p1)
		{
			if (id_setBoolean_JZ == IntPtr.Zero)
				id_setBoolean_JZ = JNIEnv.GetMethodID (class_ref, "setBoolean", "(JZ)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setBoolean_JZ, __args);
			} finally {
			}
		}

		static IntPtr id_setByte_JB;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='setByte' and count(parameter)=2 and parameter[1][@type='long'] and parameter[2][@type='byte']]"
		[Register ("setByte", "(JB)V", "GetSetByte_JBHandler")]
		public override unsafe void SetByte (long p0, sbyte p1)
		{
			if (id_setByte_JB == IntPtr.Zero)
				id_setByte_JB = JNIEnv.GetMethodID (class_ref, "setByte", "(JB)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setByte_JB, __args);
			} finally {
			}
		}

		static IntPtr id_setDouble_JD;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='setDouble' and count(parameter)=2 and parameter[1][@type='long'] and parameter[2][@type='double']]"
		[Register ("setDouble", "(JD)V", "GetSetDouble_JDHandler")]
		public override unsafe void SetDouble (long p0, double p1)
		{
			if (id_setDouble_JD == IntPtr.Zero)
				id_setDouble_JD = JNIEnv.GetMethodID (class_ref, "setDouble", "(JD)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setDouble_JD, __args);
			} finally {
			}
		}

		static IntPtr id_setFloat_JF;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='setFloat' and count(parameter)=2 and parameter[1][@type='long'] and parameter[2][@type='float']]"
		[Register ("setFloat", "(JF)V", "GetSetFloat_JFHandler")]
		public override unsafe void SetFloat (long p0, float p1)
		{
			if (id_setFloat_JF == IntPtr.Zero)
				id_setFloat_JF = JNIEnv.GetMethodID (class_ref, "setFloat", "(JF)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setFloat_JF, __args);
			} finally {
			}
		}

		static IntPtr id_setInt_JI;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='setInt' and count(parameter)=2 and parameter[1][@type='long'] and parameter[2][@type='int']]"
		[Register ("setInt", "(JI)V", "GetSetInt_JIHandler")]
		public override unsafe void SetInt (long p0, int p1)
		{
			if (id_setInt_JI == IntPtr.Zero)
				id_setInt_JI = JNIEnv.GetMethodID (class_ref, "setInt", "(JI)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setInt_JI, __args);
			} finally {
			}
		}

		static IntPtr id_setLong_JJ;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='setLong' and count(parameter)=2 and parameter[1][@type='long'] and parameter[2][@type='long']]"
		[Register ("setLong", "(JJ)V", "GetSetLong_JJHandler")]
		public override unsafe void SetLong (long p0, long p1)
		{
			if (id_setLong_JJ == IntPtr.Zero)
				id_setLong_JJ = JNIEnv.GetMethodID (class_ref, "setLong", "(JJ)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setLong_JJ, __args);
			} finally {
			}
		}

		static IntPtr id_setShort_JS;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='setShort' and count(parameter)=2 and parameter[1][@type='long'] and parameter[2][@type='short']]"
		[Register ("setShort", "(JS)V", "GetSetShort_JSHandler")]
		public override unsafe void SetShort (long p0, short p1)
		{
			if (id_setShort_JS == IntPtr.Zero)
				id_setShort_JS = JNIEnv.GetMethodID (class_ref, "setShort", "(JS)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setShort_JS, __args);
			} finally {
			}
		}

		static IntPtr id_setToNative_JLjava_lang_Object_;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='setToNative' and count(parameter)=2 and parameter[1][@type='long'] and parameter[2][@type='java.lang.Object']]"
		[Register ("setToNative", "(JLjava/lang/Object;)V", "GetSetToNative_JLjava_lang_Object_Handler")]
		public override unsafe void SetToNative (long p0, global::Java.Lang.Object p1)
		{
			if (id_setToNative_JLjava_lang_Object_ == IntPtr.Zero)
				id_setToNative_JLjava_lang_Object_ = JNIEnv.GetMethodID (class_ref, "setToNative", "(JLjava/lang/Object;)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setToNative_JLjava_lang_Object_, __args);
			} finally {
			}
		}

		static IntPtr id_setUnsignedByte_JS;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArray']/method[@name='setUnsignedByte' and count(parameter)=2 and parameter[1][@type='long'] and parameter[2][@type='short']]"
		[Register ("setUnsignedByte", "(JS)V", "GetSetUnsignedByte_JSHandler")]
		public override unsafe void SetUnsignedByte (long p0, short p1)
		{
			if (id_setUnsignedByte_JS == IntPtr.Zero)
				id_setUnsignedByte_JS = JNIEnv.GetMethodID (class_ref, "setUnsignedByte", "(JS)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setUnsignedByte_JS, __args);
			} finally {
			}
		}

	}

}
